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
                sgmlReader.InputStream = reader;
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
            var element = webBrowser1.Document.GetElementById("clickget_list").InnerHtml;
            var element2 = webBrowser1.Document.GetElementById("clickget_list");
            var element3 = webBrowser1.DocumentStream;

            aaa

            using (var sr = new StreamReader(element3, Encoding.UTF8))
            {
                var xml = ParseHtml(sr);

                var fuga = xml.Descendants("div").ToList().Where(x => x.FirstAttribute.ToString().Contains("clickget"));

            }

        }

        private void getHTML()
        {
            using (var stream = new WebClient().OpenRead("http://www.bing.com/search?cc=jp&q=linq"))
            using (var sr = new StreamReader(stream, Encoding.UTF8))
            {
                var xml = ParseHtml(sr); // これだけでHtml to Xml完了。あとはLinq to Xmlで操作。

                XNamespace ns = "http://www.w3.org/1999/xhtml";
                foreach (var item in xml.Descendants(ns + "h3"))
                {
                    Console.WriteLine(item.Value); // bingでlinqを検索した結果のタイトルを列挙
                }
            }
        }
    
    }
}
