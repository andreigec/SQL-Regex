using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANDREICSLIB;

namespace SQLRegex
{
    public class Controller
    {
        public string ConnectionString;
        private DbContext c;
        //public string Table;
        //public List<string> Columns;
        //public string InRegex;
        //public string OutRegex;
        //public bool TestMode = true;


        public Controller(string connectionString)
        {
            ConnectionString = connectionString;
            c = new DbContext(ConnectionString);
        }

        public List<string> GetTables()
        {
            string q = @"SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' ";

            var qr = c.Database.SqlQuery<string>(q);
            var res = qr.OrderBy(s => s.ToString()).ToList();
            return res;
        }

        public List<string> GetColumns(string table)
        {
            string q = @"SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'" + table + "' ";

            var qr = c.Database.SqlQuery<string>(q);
            var res = qr.OrderBy(s => s.ToString()).Distinct().ToList();
            return res;
        }

        public List<string> GetValues(string table, string column, string where)
        {
            string q = string.Format("select top 100 {0} from {1} {2}", column, table, where);
            var resd = c.Database.DynamicSqlQuery(q);
            var ret = new List<string>();
            foreach (var r in resd)
            {
                var v = r.GetType().GetProperty(column).GetValue(r, null);
                var rv = v == null ? "(null)" : v.ToString();
                ret.Add(rv);
            }

            return ret;
        }

        private static string WhereGenerator(LviItem item)
        {
            string where = string.IsNullOrEmpty(item.where)
          ? string.Format("where {0} like '{1}'", item.column, item.rowValue.Replace("'", "''"))
          : string.Format("{0} and {1} like '{2}'", item.where, item.column, item.rowValue.Replace("'", "''"));

            return where;
        }

        public bool OnlyOnce(LviItem item)
        {
            var where2 = WhereGenerator(item);

            string q = string.Format("select top 100 {0} from {1} {2}", item.column, item.table, where2);

            var resd = c.Database.DynamicSqlQuery(q);
            var ret = new List<string>();
            foreach (var r in resd)
            {
                ret.Add("ok");
                if (ret.Count > 1)
                    return false;
            }

            return true;
        }

        private string UpdateRowQuery(LviItem item)
        {
            var where = WhereGenerator(item);

            string q = string.Format("update {0} \r\nset {1} = '{2}' \r\n{3}", item.table, item.column, item.postRegex.Replace("'", "''").Trim(), where);
            return q;
        }

        public void SaveChanges(List<LviItem> item, bool testMode)
        {
            var fn = "queries.txt";
            FileExtras.SaveToFile(fn, "");

            foreach (var i in item)
            {
                //make sure only one matches
                if (OnlyOnce(i) == false)
                {
                    var msg = string.Format("col={0}, table={1}, where={2}, value={3}", i.column, i.table, i.where,
                        i.rowValue);

                    throw new Exception("error, there exists multiple values for:" + msg);
                }

                var query = UpdateRowQuery(i);
                if (testMode)
                {
                    FileExtras.SaveToFile(fn, query, true);
                }
            }

            if (testMode)
            {
                Process.Start("notepad.exe", fn);
            }
        }
    }
}