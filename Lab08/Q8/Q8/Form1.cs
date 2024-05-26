using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Q8
{
    public partial class Form1 : Form
    {
        private string[] imageFiles;
        private int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            ShowImage();
        }

        private void ShowImage()
        {
            if(imageFiles.Length > 0 && currentIndex >= 0 && currentIndex < imageFiles.Length)
            {
                pictureBox1.Image = Image.FromFile(imageFiles[currentIndex]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.Image = null;
            }

            label2.Text = imageFiles.Length.ToString();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIndex = listBox1.SelectedIndex;

            ShowImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentIndex++;

            if(currentIndex >= imageFiles.Length)
                currentIndex = 0;

            ShowImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentIndex--;

            if(currentIndex < 0)
                currentIndex = imageFiles.Length - 1;

            ShowImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*string folderPath = textBox1.Text.Trim();

            if(Directory.Exists(folderPath))
            {
                imageFiles = Directory.GetFiles(folderPath, "*.jpg");

                listBox1.Items.Clear();
                listBox1.Items.AddRange(imageFiles);

                currentIndex = 0;
                ShowImage();
            }
            else
            {
                MessageBox.Show("Invalid folder path. Enter a valid folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            using(FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.SelectedPath = textBox1.Text.Trim();

                if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFiles = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*jpg");

                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(imageFiles);

                    currentIndex = 0;
                    ShowImage();

                    textBox1.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
