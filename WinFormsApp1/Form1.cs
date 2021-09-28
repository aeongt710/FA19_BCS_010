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
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        String content="";
        public Form1()
        {
            InitializeComponent();
            this.Text = "Notepad";
            
        }
        //protected override void OnTextChanged(out Position line, out Position column)
        //{
        //    line = 0; column = 0;
        //    int caret = this.CaretIndex;
        //    int iLine = this.GetLineIndexFromCharacterIndex(caret);
        //    if (iLine < 0) iLine = 0;
        //    line = iLine;
        //    int firstChar = this.GetCharacterIndexFromLineIndex(iLine);
        //    if (firstChar < 0) firstChar = 0;
        //    column = caret - firstChar;
        //    base.OnTextChanged(e);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Text.Length == 0)
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    toolStripStatusLabel1.Text = saveFileDialog1.FileName;
                    toolStripStatusLabel2.Text = "";
                }
            }
            else
            {
                File.WriteAllText(toolStripStatusLabel1.Text, textBox1.Text);
                toolStripStatusLabel2.Text = "";
            }
        }




    private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            if ( openFileDialog1.FileName != "")
            {
                content = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
            

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            //label1.Text = line + "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "*";
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;

        }

        private void textBox1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            toolStripStatusLabel4.Text = "Ln, " + line + " Col, " + column;
        }
    }
}
