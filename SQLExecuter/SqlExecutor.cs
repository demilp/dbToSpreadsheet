using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BypassSqlExecuter
{
    public partial class SqlExecutor : Form
    {
        Bypass.BypassClient client;
        public delegate void OnResponse();
        public OnResponse onResponse;
        public SqlExecutor()
        {
            InitializeComponent();
            onResponse = new OnResponse(SetDataSource);
            client = new Bypass.BypassClient(ConfigurationManager.AppSettings["ip"], int.Parse(ConfigurationManager.AppSettings["port"]), ConfigurationManager.AppSettings["delimitador"], "sqlExecutor", "tool");
            client.CommandReceivedEvent += OnData;
        }
        //string[] ids = new string[] { "sql" };
        private void executeBtn_Click(object sender, EventArgs e)
        {
            if (queryTb.Text != "")
            {
                string t = queryTb.Text.Trim();
                //if (t.IndexOf(" ") != -1)
                {
                    if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                    {
                        client.SendData("1|" + t, "tool", "sql");
                    }
                    else
                    {
                        client.SendData("0|" + t, "tool", "sql");
                    }
                }
            }

        }
        private void executeBtn2_Click(object sender, EventArgs e)
        {
            if (queryTb2.Text != "")
            {
                string t = queryTb2.Text.Trim();
                //if (t.IndexOf(" ") != -1)
                {
                    if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                    {
                        client.SendData("1|" + t, "tool", "sql");
                    }
                    else
                    {
                        client.SendData("0|" + t, "tool", "sql");
                    }
                }
            }
        }
        private void executeBtn3_Click(object sender, EventArgs e)
        {
            if (queryTb3.Text != "")
            {
                string t = queryTb3.Text.Trim();
                //if (t.IndexOf(" ") != -1)
                {
                    if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                    {
                        client.SendData("1|" + t, "tool", "sql");
                    }
                    else
                    {
                        client.SendData("0|" + t, "tool", "sql");
                    }
                }
            }
        }



        private void OnData(object sender, Bypass.CommandEventArgs args)
        {
            if (args.command.Trim() == "")
            {
                return;
            }
            response = args.command;
            Invoke(onResponse);
        }
        string response;
        public void SetDataSource()
        {
            Response r = JsonConvert.DeserializeObject<Response>(response);
            //r.result = Encoding.UTF8.GetString(Convert.FromBase64String(r.result));
            resultLabel.Text = r.result;
            try
            {
                grid.DataSource = JsonConvert.DeserializeObject(r.data.ToString());
            }
            catch (Exception e)
            {
                grid.DataSource = JsonConvert.DeserializeObject("[{\"result\":\"deserialization error\"}]");
            }
        }

        private void SqlExecuter_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1:
                    if (queryTb.Text != "")
                    {
                        string t = queryTb.Text.Trim();
                        //if (t.IndexOf(" ") != -1)
                        {
                            if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                            {
                                client.SendData("1|" + t, "tool", "sql");
                            }
                            else
                            {
                                client.SendData("0|" + t, "tool", "sql");
                            }
                        }
                    }
                    break;
                case Keys.F2:
                    if (queryTb2.Text != "")
                    {
                        string t = queryTb2.Text.Trim();
                        //if (t.IndexOf(" ") != -1)
                        {
                            if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                            {
                                client.SendData("1|" + t, "tool", "sql");
                            }
                            else
                            {
                                client.SendData("0|" + t, "tool", "sql");
                            }
                        }
                    }
                    break;
                case Keys.F3:
                    if (queryTb3.Text != "")
                    {
                        string t = queryTb3.Text.Trim();
                        //if (t.IndexOf(" ") != -1)
                        {
                            if (t.Substring(0, t.IndexOf(" ")).ToLower() == "select")
                            {
                                client.SendData("1|" + t, "tool", "sql");
                            }
                            else
                            {
                                client.SendData("0|" + t, "tool", "sql");
                            }
                        }
                    }
                    break;
            }
            // etc..
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void queryTb_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
    public struct Response
    {
        public string result;
        public string queryId;
        public JValue data;
    }
}
