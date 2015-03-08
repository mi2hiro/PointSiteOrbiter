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
            GetScraping("http://hapitas.jp/");
            //GetScraping("http://www.xbox.com/ja-JP/games/calendar/xboxone?xr=shellnav");
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

            var ns = xml.Root.Name.Namespace;

            var fuga = xml.Element("div");
            fuga = xml.Element("html");
            fuga = xml.Element("html").Element("body");
            fuga = xml.Element("html").Element("body").Element("div");

            var query = xml.Descendants(ns + "table")
                .Last()
                .Descendants(ns + "tr")
                .Skip(1) // テーブル一行目は項目説明なので飛ばす
                .Select(e => e.Elements(ns + "td").ToList())
                .Select(es => new
                {
                    Title = es.First().Value,
                    ReleaseDate = es.Last().Value
                });

            var hoge="";
        }
    
    }
}
