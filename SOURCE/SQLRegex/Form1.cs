using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ANDREICSLIB;
using SQLRegex.ServiceReference1;
using System.Data.Entity.Core.Metadata.Edm;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using ANDREICSLIB.ClassExtras;

namespace SQLRegex
{
    public partial class Form1 : Form
    {
        #region licensing

        private const string AppTitle = "SQL Regex";
        private const double AppVersion = 0.1;
        private const String HelpString = "";

        private readonly String OtherText =
            @"©" + DateTime.Now.Year +
            @" Andrei Gec (http://www.andreigec.net)
Licensed under GNU LGPL (http://www.gnu.org/)
OCR © Tessnet2/Tesseract (http://www.pixel-technology.com/freeware/tessnet2/)(https://code.google.com/p/tesseract-ocr/)
Zip Assets © SharpZipLib (http://www.sharpdevelop.net/OpenSource/SharpZipLib/)
";
        public Licensing.DownloadedSolutionDetails GetDetails()
        {
            try
            {
                var sr = new ServicesClient();
                var ti = sr.GetTitleInfo(AppTitle);
                if (ti == null)
                    return null;
                return ToDownloadedSolutionDetails(ti);

            }
            catch (Exception)
            {
            }
            return null;
        }

        public static Licensing.DownloadedSolutionDetails ToDownloadedSolutionDetails(TitleInfoServiceModel tism)
        {
            return new Licensing.DownloadedSolutionDetails()
            {
                ZipFileLocation = tism.LatestTitleDownloadPath,
                ChangeLog = tism.LatestTitleChangelog,
                Version = tism.LatestTitleVersion
            };
        }

        public void InitLicensing()
        {
            Licensing.CreateLicense(this, menuStrip1, new Licensing.SolutionDetails(GetDetails, HelpString, AppTitle, AppVersion, OtherText));
        }

        #endregion

        private Controller c;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitLicensing();
            if (string.IsNullOrEmpty(connectionStringTB.Text) == false)
            {
                UpdateConnectionString(connectionStringTB.Text);
                UpdateTables();
                tableLB.SelectedItem = "tblArticle";
                columnsLB.SelectedItem = "txtContent";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateConnectionString(string cs)
        {
            if (string.IsNullOrEmpty(cs))
            {
                MessageBox.Show("error with empty connection string");
                return;
            }

            if (c == null || c.ConnectionString != cs)
            {
                c = new Controller(cs);
                UpdateTables();
            }
        }

        private void UpdateTables()
        {
            try
            {
                tableLB.Items.Clear();
                columnsLB.Items.Clear();
                rowLV.Items.Clear();

                var t = c.GetTables();
                AddItems(t, ref tableLB);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateColumns(string table)
        {
            columnsLB.Items.Clear();
            if (string.IsNullOrEmpty(table))
                return;

            if (string.IsNullOrEmpty(table) == false)
            {
                var cols = c.GetColumns(table);
                AddItems(cols, ref columnsLB);
            }
        }

        private static string RegexReplace(string orig, string[] regexes, string[] outRegexes)
        {
            var ret = orig;
            int a = 0;
            while (a < regexes.Count())
            {
                var inarr = regexes[a];
                var outarr = outRegexes.Length > a ? outRegexes[a] : "";
                ret = new Regex(inarr).Replace(ret, outarr);
                a++;
            }

            return ret;
        }

        private void UpdateRows(string table, string column, string where, string[] regexes, string[] outRegexes)
        {
            rowLV.Items.Clear();
            if (string.IsNullOrEmpty(table))
                return;
            if (string.IsNullOrEmpty(column))
                return;

            var rows = c.GetValues(table, column, where);
            if (rows != null && rows.Any())
                AddItems(rows.Select(s => new LviItem(table, column, s, RegexReplace(s, regexes, outRegexes), where)).ToList(), ref rowLV);
        }

        private void AddItems(List<LviItem> items, ref ListView lv)
        {
            foreach (var i in items)
            {
                var lvi = new ListViewItem(i.table);
                lvi.SubItems.Add(i.column);
                lvi.SubItems.Add(i.rowValue);
                lvi.SubItems.Add(i.postRegex);
                lvi.Tag = i;
                lv.Items.Add(lvi);
            }
        }

        private void AddItems(List<string> items, ref ListBox lb)
        {
            foreach (var i in items)
            {
                lb.Items.Add(i);
            }
        }

        private void tableLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateColumns((string)tableLB.SelectedItem);
        }

        private string[] GetRegexes(string regexes)
        {
            var r = regexes.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return r;
        }

        private void UpdateRows()
        {
            try
            {
                var rin = GetRegexes(inRegexesTB.Text);
                var rout = GetRegexes(outTBRegexes.Text);
                while (rout.Count() < rin.Count())
                {
                    ArrayExtras.AddItemToArray(ref rout, "");
                }

                UpdateRows((string)tableLB.SelectedItem, (string)columnsLB.SelectedItem, (string)whereTB.Text, rin, rout);
            }
            catch (Exception ex)
            {
                MessageBox.Show("sql error:\r\n" + ex);
            }

        }

        private void QueryB_Click(object sender, EventArgs e)
        {
            UpdateConnectionString(connectionStringTB.Text);
            UpdateRows();
        }

        private void SaveChangesB_Click(object sender, EventArgs e)
        {
            UpdateRows();

            var ret = new List<LviItem>();
            foreach (ListViewItem lvi in rowLV.Items)
            {
                var t = lvi.Tag as LviItem;
                if (t != null && t.postRegex != t.rowValue)
                {
                    ret.Add(t);
                }
            }

            if (ret.Any())
                c.SaveChanges(ret, true);
            else
            {
                MessageBox.Show("No items would be affected");
            }
        }

        private void columnsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRows();
        }
    }
}
