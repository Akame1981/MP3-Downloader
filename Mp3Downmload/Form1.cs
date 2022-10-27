using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Mp3Downmload
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
            var uri = new Uri(url);

            // you can check host here => uri.Host <= "www.youtube.com"

            var query = HttpUtility.ParseQueryString(uri.Query);
            var videoId = query["v"];

            // videoId = 6QlW4m9xVZY
            Download.Request(videoId);
        }


        void download()
        {
        }
        int counter = 0;
        string oldtext = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText(TextDataFormat.Text);


            if (oldtext != clipboardText)
            {
                counter = 0;
            }
            oldtext = clipboardText;
            if (clipboardText.Contains("youtube.com"))
            {
                if(counter == 0)
                {
                    var url = clipboardText;
                    var uri = new Uri(url);

                    // you can check host here => uri.Host <= "www.youtube.com"

                    var query = HttpUtility.ParseQueryString(uri.Query);
                    var videoId = query["v"];

                    // videoId = 6QlW4m9xVZY
                    Download.Request(videoId);
                    counter++;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.MaximumSize = new Size(this.Width - 15, 0);
        }
    }
}
