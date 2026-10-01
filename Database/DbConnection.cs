using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace UCSPyayStudentRegistration.Database {
 public static class DbConnection {
  public static string DataDirectory { get { return Path.Combine(Application.StartupPath, "Data"); } }
  public static string DatabasePath { get { return Path.Combine(DataDirectory, "UCSPyayRegistration.mdb"); } }
  public static string ConnectionString { get { return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DatabasePath + ";Jet OLEDB:Database Password=ucspyaydemo;"; } }
  public static OleDbConnection Open() { var c = new OleDbConnection(ConnectionString); c.Open(); return c; }
  public static OleDbCommand Command(string sql, OleDbConnection c, params object[] values) { var cmd=new OleDbCommand(sql,c); foreach(var raw in values){object v=raw??System.DBNull.Value;var p=new OleDbParameter();p.ParameterName="?";p.Value=v;if(v==System.DBNull.Value)p.OleDbType=OleDbType.VarWChar;else if(v is string)p.OleDbType=OleDbType.VarWChar;else if(v is bool)p.OleDbType=OleDbType.Boolean;else if(v is DateTime)p.OleDbType=OleDbType.Date;else if(v is decimal||v is double||v is float)p.OleDbType=OleDbType.Currency;else if(v is int||v is short||v is long)p.OleDbType=OleDbType.Integer;cmd.Parameters.Add(p);}return cmd; }
 }
}
