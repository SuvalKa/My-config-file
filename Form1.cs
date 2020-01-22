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

namespace _7Гринев
{
    public partial class Form1 : Form
    {
        static double[] BubbleSort(double[] mas)
        {
            double temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }

        static void CreateFile(string filename)
        {
            FileInfo file = new FileInfo(filename);
            if (file.Exists == false)
            {
                file.Create();
                MessageBox.Show(filename + " Создан");
            } else
            {
                MessageBox.Show(filename + " Уже существует!");
            }
        }
        static void DeleteFile(string filename)
        {
            FileInfo file = new FileInfo(filename);
            if (file.Exists == true)
            {
                file.Delete();
                MessageBox.Show(filename+ " Удален");
            } else
            {
                MessageBox.Show(filename+ " Уже не существует!");
            }

        }
        public Form1()
        {
            InitializeComponent();
            FileInfo file = new FileInfo("input.txt");
        }
        private void button1_Click(object sender, EventArgs e)
        {
 
            //CreateFile("file1.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteFile("file1.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())

            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (OpenFileDialog openFileDialog2 = new OpenFileDialog())
                    {
                        if (openFileDialog2.ShowDialog() == DialogResult.OK)
                        {
                            string file1= openFileDialog1.FileName;
                            string file2 = openFileDialog2.FileName;
                            string str;
                            string new_str;
                            string[] splitted_str;
                            new_str = "";
                            str = "";
                           
                            StreamReader streamReader = new StreamReader(file1);
                            StreamWriter writeText = new StreamWriter(file2);
                            while (!streamReader.EndOfStream)
                            {
                                str += streamReader.ReadLine() + "\n";
                            }
                            streamReader.Close();
                            splitted_str = str.Split('\n');
                            double[] arr = new double[splitted_str.Length];
                            for (int i = 0; i < arr.Length; ++i)
                            {
                                textBox2.Text += splitted_str[i]+"\r\n";
                                arr[i] = Convert.ToDouble(splitted_str[i]);
                            }
                            arr = BubbleSort(arr);
                            foreach (double num in arr)
                            {
                                new_str = new_str + num.ToString() + "\r\n";
                            }
                            writeText.Write(new_str);
                            writeText.Close();
                        }
                    }




                }

            }
            
            //FileInfo file = new FileInfo("file1.txt");
            //writeText = file.AppendText();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())

        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                StreamWriter writeText = new StreamWriter(filename);
                writeText.Write(textBox1.Text);
                writeText.Close();

            }

        }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateFile("file2.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteFile("file2.txt");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        { 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    StreamReader streamReader = new StreamReader(filename);
                    string str = "";
                    while (!streamReader.EndOfStream)
                    {
                        str += streamReader.ReadLine()+"\r\n";
                    }
                    textBox1.Text = str;
                    streamReader.Close();



                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    StreamReader streamReader = new StreamReader(filename);
                    string str = "";
                    while (!streamReader.EndOfStream)
                    {
                        str += streamReader.ReadLine() + "\r\n";
                    }
                    textBox2.Text = str;
                    streamReader.Close();
                }
            }
        }
    }
}
