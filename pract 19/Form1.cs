using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract_19
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        string[,] quest = new string[20, 8];
        int num = 0;  int i = 0;
        int vop=1;
        int[] vopr = new int[20];
        double answer = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                //MessageBox.Show("Выберите вариант ответа");
            }
            else
            {
                if (quest[vopr[num], 5] == "+")
                {
                    if (radioButton1.Checked)
                    {
                        if (radioButton1.Text == quest[num, 4])
                        {
                            answer++;
                        }
                    }
                    else
                    if (radioButton2.Checked)
                    {
                        if (radioButton2.Text == quest[num, 4])
                        {
                            answer++;
                        }
                    }
                    else
                    if (radioButton3.Checked)
                    {
                        if (radioButton3.Text == quest[num, 4])
                        {
                            answer++;
                        }
                    }
                }
                else
                {
                    double count = 0;
                    if (checkBox1.Checked)
                    {
                        string[] s = quest[vopr[num], 5].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (checkBox1.Text == s[i].ToString())
                            {
                                count+=0.5;
                            }
                            else count-=0.5;
                        }
                    }

                    if (checkBox2.Checked)
                    {
                        string[] s = quest[vopr[num], 5].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (checkBox2.Text == s[i].ToString())
                            {
                                count+=0.5;
                            }
                            else
                                count-=0.5;
                        }
                    }

                    if (checkBox3.Checked)
                    {
                        string[] s = quest[vopr[num], 5].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (checkBox3.Text == s[i].ToString())
                            {
                                count+=0.5;
                            }
                            else count-=0.5;
                        }
                    }
                    if (checkBox4.Checked)
                    {
                        string[] s = quest[vopr[num], 5].Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (checkBox4.Text == s[i].ToString())
                            {
                                count+=0.5;
                            }
                            else count-=0.5;
                        }
                    }
                    if (count > 0) { answer = answer + count; }
                }
                if (num < i - 1)
                {
                    label2.Text = $"{answer}";
                    vop++;
                    this.Text = $"Вопрос {vop} из {i}";
                    num++;

                    if (quest[vopr[num], 5] == "+")
                    {
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton3.Visible = true;
                        checkBox1.Visible = false;
                        checkBox2.Visible = false;
                        checkBox3.Visible = false;
                        checkBox4.Visible = false;
                        label1.Text = quest[vopr[num], 0];
                        radioButton1.Text = quest[vopr[num], 1];
                        radioButton2.Text = quest[vopr[num], 2];
                        radioButton3.Text = quest[vopr[num], 3];
                        pictureBox1.Image = Image.FromFile($"{1}.jpg");
                    }
                    else //if(quest[vopr[num], 5] == "+")
                    {
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton3.Visible = false;
                        checkBox1.Visible = true;
                        checkBox2.Visible = true;
                        checkBox3.Visible = true;
                        checkBox4.Visible = true;
                        label1.Text = quest[vopr[num], 0];
                        checkBox1.Text = quest[vopr[num], 1];
                        checkBox2.Text = quest[vopr[num], 2];
                        checkBox3.Text = quest[vopr[num], 3];
                        checkBox4.Text = quest[vopr[num], 4];
                        pictureBox1.Image = Image.FromFile($"{1}.jpg");
                    }

                    /*label1.Text = quest[vopr[num], 0];
                    *//*radioButton1.Text = quest[num, 1];
                    radioButton2.Text = quest[num, 2];
                    radioButton3.Text = quest[num, 3];*//*
                    checkBox1.Text = quest[vopr[num], 1];
                    checkBox2.Text = quest[vopr[num], 2];
                    checkBox3.Text = quest[vopr[num], 3];
                    pictureBox1.Image = Image.FromFile($"{9}.jpg");*/
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = true;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Кол-во правильных ответов: {answer}");
        }

        public Form1()
        {
            InitializeComponent();
            StreamReader sr = File.OpenText("questions.txt");
            StreamReader sr1 = File.OpenText("questions.txt");
            int j;
            int count = 0;
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (s == "")
                {
                    for (j = 0; j < count; j++)
                    {
                        quest[i, j] = sr1.ReadLine();
                    }
                    sr1.ReadLine();
                    i++;
                    count = 0;
                }
                else
                {
                    count++;

                }
            }
            /*while (!sr.EndOfStream)
            {
                for (j = 0; j < 5; j++)
                {
                    quest[i, j] = sr.ReadLine();
                }
                i++;
            }*/
            sr.Close();
            sr1.Close();
            int[] vopr1 = new int[i];
            for (int k = 0; k < i - 1; k++)
            {
                bool flag = false;
                while (flag == false)
                {
                    int v = rnd.Next(0, i);
                    for (j = 0; j < i; j++)
                    {
                        if (v != vopr1[j]) flag = true;
                        else { flag = false; break; }
                    }
                    if (flag == true) vopr1[k] = v;
                }

            }
            vopr = vopr1;


            /*for (int u = 0; u < vopr.Length; u++)
            {
                label2.Text += vopr[u] + " ";
            }*/
            if (quest[vopr[num], 5] == "+")
            {
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                this.Text = $"Вопрос {vop} из {i}";
                label1.Text = quest[vopr[num], 0];
                radioButton1.Text = quest[vopr[num], 1];
                radioButton2.Text = quest[vopr[num], 2];
                radioButton3.Text = quest[vopr[num], 3];
                pictureBox1.Image = Image.FromFile($"{1}.jpg");
            }
            else //if(quest[vopr[num], 5] == "+")
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                this.Text = $"Вопрос {vop} из {i}";
                label1.Text = quest[vopr[num], 0];
                checkBox1.Text = quest[vopr[num], 1];
                checkBox2.Text = quest[vopr[num], 2];
                checkBox3.Text = quest[vopr[num], 3];
                checkBox4.Text = quest[vopr[num], 4];
                pictureBox1.Image = Image.FromFile($"{1}.jpg");
            }
        }
    }
}
