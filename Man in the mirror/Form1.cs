using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Man_in_the_mirror
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            if(label1.Text=="Ready!" && label2.Text == "Ready!")
            {
                btnDoIt.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CriaPasta();

            if (label1.Text == "Ready!" && label2.Text == "Ready!")
            {
                btnDoIt.Enabled = true;
            }
            ofdImage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofdRar.FileName= "Zip Files|*.zip;*.rar";


        }

        private void CriaPasta()
        {
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }
            else
            {
                System.Console.Write("yep");
            }


        }

        string folderName = @"C:\Users\Deus\Desktop\Copia";
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                fileImg = ofdImage.FileName;

                imgTogo.Image=new Bitmap(ofdImage.FileName);
                label1.Text = "Ready!";
                label3.Text = ofdImage.FileName;

            }

            if (label1.Text == "Ready!" && label2.Text == "Ready!")
            {
                btnDoIt.Enabled = true;
            }


        }

        private void btnRar_Click(object sender, EventArgs e)
        {
            if (ofdRar.ShowDialog() == DialogResult.OK)
            {

                fileRar = ofdRar.FileName;
                label4.Text = ofdRar.FileName;

                label2.Text = "Ready!";
                

            }

            if (label1.Text == "Ready!" && label2.Text == "Ready!")
            {
                btnDoIt.Enabled = true;
            }


        }
        string fileImg, fileRar;

        private void btnDoIt_Click(object sender, EventArgs e)
        {

            cmdCopy(fileImg, fileRar);

            //ofdImage.fil

        }

        private void label6_Click(object sender, EventArgs e)
        {
            var message = "I want to learn \"c#\"";
            //label6.Text=message;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                cmdCopy(fileImg, fileRar);
                
                

            }
        }

        private void cmdCopy(string img, string rar)
        {
            string folderPath;

            string command="";

                if (chooseFolder.ShowDialog() == DialogResult.OK)
                {
                    folderPath = chooseFolder.SelectedPath;
                //label6.Text = folderPath;

                if (textBox1.Text != "")
                {
                    command = "copy / b \"" + img + "\" + \"" + rar + "\" \"" + folderPath + "\\"+textBox1.Text+".jpg\"";
                }
                else
                {
                    command = "copy / b \"" + img + "\" + \"" + rar + "\" \"" + folderPath + "\"";
                }
                    //label6.Text = command;

                    string strCmdText;
                    
                    strCmdText = "/C "+command;
                

                    System.Diagnostics.Process.Start("CMD.exe", strCmdText);


                label5.Text = label5.Text + folderPath;
            }
        }


    }



    

}
