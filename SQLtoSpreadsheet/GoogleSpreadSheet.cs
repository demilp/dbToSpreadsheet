using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;

namespace SQLtoExcel
{
    public class GoogleSpreadSheet
    {
        string[] Scopes = { SheetsService.Scope.Spreadsheets };
        string ApplicationName = "";
        string SpreadsheetId = "";
        SheetsService service;

        public GoogleSpreadSheet(String applicaionName, String spreadsheetId)
        {
            ApplicationName = applicaionName;
            SpreadsheetId = spreadsheetId;

            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);


                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public void WriteValues(string pageName, DataSet ds)
        {
            String range2 = pageName+"!A1:"+R1C1ToA1Notation(ds.Tables[0].Columns.Count, ds.Tables[0].Rows.Count+1);
            ValueRange valueRange = new ValueRange();
            valueRange.MajorDimension = "ROWS";//"ROWS";//COLUMNS
            //Colum names
            valueRange.Values = new List<IList<object>>();
            List<object> oblist = new List<object>();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                oblist.Add(ds.Tables[0].Columns[i].ColumnName);
            }
             valueRange.Values.Add(oblist);

            //Values
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                oblist = new List<object>();
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    oblist.Add(ds.Tables[0].Rows[i][ds.Tables[0].Columns[j].ColumnName]);
                }
                valueRange.Values.Add(oblist);
            }

            SpreadsheetsResource.ValuesResource.UpdateRequest update = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range2);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse result2 = update.Execute();
        }
        private string R1C1ToA1Notation(int columnNumber, int row)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName + row;
        }

    }
}
