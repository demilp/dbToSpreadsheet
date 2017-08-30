using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Threading;
using ExportToExcel;

namespace SQLtoExcel
{
    public class Sql2Excel
    {
        public Sql2Excel()
        {
            List<Setting> settings = new List<Setting>();
            int c = 0;
            bool f = true;
            while (f)
            {
                c++;
                if (ConfigurationManager.AppSettings[c + "_query"] != null)
                {
                    Setting s = new Setting();
                    s.query = ConfigurationManager.AppSettings[c + "_query"];
                    s.fieldsNames = ConfigurationManager.AppSettings[c + "_fieldsNames"];
                    s.delimiter = ConfigurationManager.AppSettings[c + "_delimiter"];
                    s.outputPath = ConfigurationManager.AppSettings[c + "_outputPath"];
                    s.spreadsheetId = ConfigurationManager.AppSettings[c + "_googleSpreadsheetId"];
                    s.spreadsheetPageName = ConfigurationManager.AppSettings[c + "_googleSpreadsheetPageName"];
                    settings.Add(s);
                }
                else
                {
                    f = false;
                }

            }

            DB.Instance.Initialize(ConfigurationManager.AppSettings["connectionString"]);
            foreach (Setting setting in settings)
            {
                #region Excel
                DataSet ds = DB.Instance.EQ2(setting.query);
                CreateExcelFile.CreateExcelDocument(ds, Path.ChangeExtension(setting.outputPath, "xlsx"));
                #endregion
                #region Google Spreadsheet

                if (setting.spreadsheetId != "" && setting.spreadsheetPageName != "")
                {
                    try
                    {
                        GoogleSpreadSheet gss = new GoogleSpreadSheet("Sql to Google Spreadsheet",
                            setting.spreadsheetId);
                        gss.WriteValues(setting.spreadsheetPageName, ds);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Thread.Sleep(3000);
                    }
                }
                
                #endregion
                #region Csv
                DbDataReader dr = DB.Instance.EQ(setting.query);
                StringBuilder sb = new StringBuilder();
                bool first = true;
                while (dr.Read())
                {
                    if (first)
                    {
                        string s = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            s+=dr.GetName(i);
                            if (i < dr.FieldCount - 1)
                            {
                                s += setting.delimiter;
                            }
                        }
                        sb.AppendLine(s);
                    }
                    first = false;
                    IDataRecord record = (IDataRecord) dr;
                    for (int i = 0; i < record.FieldCount; i++)
                    {
                        sb.Append(record[i]+setting.delimiter);
                    }
                    sb.AppendLine();
                }
                File.WriteAllText(setting.outputPath, sb.ToString(0, sb.Length));
#endregion
                if (dr != null)
                    dr.Close();
            }
            
        }
        

    }

    public struct Setting
    {
        public string query;
        public string fieldsNames;
        public string delimiter;
        public string outputPath;
        public string spreadsheetId;
        public string spreadsheetPageName;
    }
}