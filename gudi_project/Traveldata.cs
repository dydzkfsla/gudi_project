using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gudi_project
{
    public partial class Traveldata : Form
    {
        public Travel travel { get; set; }
        List<Tuple<string, double, double>> tuples = new List<Tuple<string, double, double>>();
        public Traveldata(Travel travel)
        {
            InitializeComponent();
            this.travel = travel;
        }

        private void Traveldata_Load(object sender, EventArgs e)
        {
            Version ver = webBrowser1.Version;
            string name = webBrowser1.ProductName;
            string str = webBrowser1.ProductVersion;
            string html = "kakaoMap.html";
            string dir = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(dir, html);
            webBrowser1.Navigate(path);
        }
        private void ShowMap() // 위도, 경도에 해당하는 지역을 지도에 표시
        {
            object[] arr = new object[] { travel.trv_lat, travel.trv_lng }; // 위도, 경도
            object res = webBrowser1.Document.InvokeScript("panTo", arr); // html 의 panTo 자바스크립트 함수 호출. 
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ShowMap();
        }
    }
}
