using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Mp3Downmload
{
    internal class Download
    {
        public static string downloadLink;
        public static string songName;
        public static Form form;
        public static async void Request(string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://youtube-mp3-download1.p.rapidapi.com/dl?id=" + id),
                Headers =
    {
        { "X-RapidAPI-Key", "0078b45442msh21cb18bfe5935f0p10df8ajsn9d6990f885a2" },
        { "X-RapidAPI-Host", "youtube-mp3-download1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                dynamic json = JsonConvert.DeserializeObject(body);

                songName  = json["title"];
                downloadLink = json["link"];
                using (form = new Form())
                {
                    form.Text = "Video";
                    form.MinimumSize = new System.Drawing.Size(form.Width, form.Height);
                    
                    form.TopMost = true;
                    form.AutoSize = true;
                    form.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                    Label text = new Label();

                    text.Text = songName;
                    text.AutoSize = true;

                    Button btn = new Button();
                    btn.Text = "Download";
                    btn.Click += Btn_Click;
                    btn.Top = 100;
                    btn.Left = (form.ClientSize.Width - btn.Width) / 2;


                    form.Controls.Add(text);
                    form.Controls.Add(btn);
                    form.Width = 1000;

                    form.ShowDialog();
                }

            }
        }

        private static void Btn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(downloadLink);
            form.Close();
        }
    }
}
