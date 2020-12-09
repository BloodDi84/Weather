using Newtonsoft.Json;
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

namespace Weather
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }
        string c = "Pekin";

        public void Weather()
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={c}&appid=9748a46a0ba3134b4670fead1f1c43df&units=metric";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string response = reader.ReadToEnd();
            WeatherResponse wr = JsonConvert.DeserializeObject<WeatherResponse>(response);
            LCity.Text = wr.Name;
            LTemperature.Text = wr.Main.Temp.ToString();
        }
 

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            Weather();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            switch(comboBox1.SelectedIndex) {

                case 0:
                    c = "Donetsk";
                break;
                case 1:
                    c = "Makiyivka";
                    break;
                case 2:
                    c = "Kyiv";
                    break;
                case 3:
                    c = "Kharkiv";
                    break;
                case 4:
                    c = "Krasnyy Luch";
                    break;

                    

            }
            Weather();
        }
    }
}
