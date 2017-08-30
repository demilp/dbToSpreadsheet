using System;
using System.Data;
using System.Data.Common;

namespace  SQLtoExcel
{



public class DB
{
    //-----------------------------------------------------------------------------------------------------------------------------------------------------
    //PUBLIC_MEMBERS
    //-----------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------
    //PUBLIC_CLASS
    //------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------
    //PUBLIC_VARS
    //------------------------------------------------------------------------------------------

    public static DB Instance
    {
        get
        {
            if (_instance == null) _instance = new DB();
            return _instance;
        }
    }

    //------------------------------------------------------------------------------------------
    //PUBLIC_METHODS
    //------------------------------------------------------------------------------------------

    public void Initialize( string pPath)
    {
        bool isOleDb = false;
        if (_initialized) return;
        string[] parameters = pPath.Split(';');
        for (int i = 0; i < parameters.Length; i++)
        {
            if(parameters[i] == "")
                continue;
            string key = parameters[i].Split('=')[0];
            string value = parameters[i].Split('=')[1];
            if (key.ToLower().Trim() == "provider")
                isOleDb = true;
        }
        if (isOleDb)
        {
            _conn = new _OledbConnection(pPath);
            //_conn = new _OledbDataReaderConnection(pPath);
        }
        else
        {
            _conn = new _SqlConnection(pPath);
        }
        _initialized = true;
    }
    public void Close()
    {
        if (!_initialized) return;

        _conn.ForceClose();
    }

    public DbDataReader EQ(string query)
    {
        return _conn.EQ(query);
    }

    public DataSet EQ2(string query)
    {
        return _conn.EQ2(query);
    }

        public DataTable ExecuteSelect2(string query)
    {
        if (!_initialized) return null;
        return _conn.ExecuteSelect(query);
    }

    //-----------------------------------------------------------------------------------------------------------------------------------------------------
    //PRIVATE_MEMBERS
    //-----------------------------------------------------------------------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------------
    //PRIVATE_VARS
    //------------------------------------------------------------------------------------------

    private static DB _instance;
    private AccessConnection _conn;
    private bool _initialized;

    //------------------------------------------------------------------------------------------
    //CONSTRUCTORS_DESTRUCTORS
    //------------------------------------------------------------------------------------------

    private DB()
    {
        _initialized = false;
    }

    private string GetNowStr()
    {
        DateTime now = DateTime.Now;
        return ("#" + now.ToString("yyyy/MM/dd HH:mm:ss") + "#");
    }

    private string GetNowDateStr()
    {
        DateTime now = DateTime.Now;
        return ("(" + now.ToString("yyyy-MM-dd") + ")");
    }
}
}