using Sgml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WebScraping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = textBox1.Text;

            url = "http://hapitas.jp/";

            webBrowser1.Navigate(url);


            //GetScraping("http://hapitas.jp/");
            //GetScraping("http://www.xbox.com/ja-JP/games/calendar/xbox360");
        }

        static XDocument ParseHtml(TextReader reader)
        {
            using (var sgmlReader = new SgmlReader { DocType = "HTML", CaseFolding = CaseFolding.ToLower })
            {
                sgmlReader.InputStream = reader; // ↑の初期化子にくっつけても構いません
                return XDocument.Load(sgmlReader);
            }
        }

        static void GetScraping(string url)
        {
            XDocument xml;
            using (var sgml = new SgmlReader() { Href = url })
            {
                xml = XDocument.Load(sgml); // たった3行でHtml to Xml
            }


            var fuga = xml.Descendants("div").ToList().Where(x => x.FirstAttribute.ToString().Contains("clickget"));
            var piko = xml.Descendants("div").ToList().Where(x => x.FirstAttribute.ToString().Contains("clickget"));

            var aaa = "";

            //var query = xml.Descendants(ns + "table")
            //    .Last()
            //    .Descendants(ns + "tr")
            //    .Skip(1) // テーブル一行目は項目説明なので飛ばす
            //    .Select(e => e.Elements(ns + "td").ToList())
            //    .Select(es => new
            //    {
            //        Title = es.First().Value,
            //        ReleaseDate = es.Last().Value
            //    });

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bbb = webBrowser1.Document.Body.InnerHtml;
            var ccc = webBrowser1.DocumentText;
            var ddd = webBrowser1.DocumentStream;

            using (var sr = new StreamReader(bbb, Encoding.UTF8))
            {
                var xml = ParseHtml(sr);

                var fuga = xml.Descendants("div").ToList().Where(x => x.FirstAttribute.ToString().Contains("clickget"));

            }

        }
    
    }
}
