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
        public Form1()
        {
            InitializeComponent();
            this.Text = "Notepad";
            textBox1.ScrollBars = ScrollBars.Vertical;
            this.WindowState = FormWindowState.Maximized;
            this.Icon = new Icon("icons8_txt.ico");
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButton();
        }

        public void saveButton()
        {
            if (toolStripStatusLabelFilepath.Text == ""|| toolStripStatusLabelFilepath.Text== "No file selected")
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                    toolStripStatusLabelFilepath.Text = saveFileDialog1.FileName;
                    toolStripStatusLabelTextChanged.Text = "";
                }
                else
                {
                    toolStripStatusLabelFilepath.Text = "No file selected";
                }
            }
            else
            {
                File.WriteAllText(toolStripStatusLabelFilepath.Text, textBox1.Text);
                toolStripStatusLabelTextChanged.Text = "";
            }
        }


    private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.ShowDialog();
            if ( openFileDialog1.FileName != "")
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                toolStripStatusLabelFilepath.Text = openFileDialog1.FileName;
                toolStripStatusLabelTextChanged.Text = "";
            }
            else
            {
                if(toolStripStatusLabelFilepath.Text=="")
                    toolStripStatusLabelFilepath.Text = "No file selected";
            }
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            toolStripStatusLabelFilepath.Text = "";
            toolStripStatusLabelTextChanged.Text = "";
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabelTextChanged.Text = "*";
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            toolStripStatusLabelPointer.Text = "Ln, " + line + " Col, " + column;
        }


        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
            {
                textBox1.Cut();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (textBox1.SelectionLength > 0)
                {
                     textBox1.SelectionStart = textBox1.SelectionStart + textBox1.SelectionLength;
                }
                else
                {
                    textBox1.Paste();
                }
 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(toolStripStatusLabelTextChanged.Text == "*")
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveButton();
                }
                else if (result == DialogResult.No)
                {

                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }




        private void textBox1_Validated(object sender, EventArgs e)
        {
            int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
            int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
            toolStripStatusLabelPointer.Text = "Ln, " + line + " Col, " + column;
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox1.Font = fontDialog1.Font;
            
        }

        private void wrapTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wrapTextToolStripMenuItem.Checked == false)
            {
                textBox1.WordWrap = true;
                wrapTextToolStripMenuItem.Checked = true;
            }
            else
            {
                textBox1.WordWrap = false;
                wrapTextToolStripMenuItem.Checked = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabelTextChanged.Text == "*")
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveButton();
                }
                else if (result == DialogResult.No)
                {
                    this.Dispose();
                }
            }
            else
            {
                this.Dispose();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
                toolStripStatusLabelFilepath.Text = saveFileDialog1.FileName;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name: Muhammad Ahmad\nReg No: FA19-BCS-010\nCourse: Visual Programming\nSection: BCS-5A","About Notepad");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
        //int line = textBox1.GetLineFromCharIndex(textBox1.SelectionStart);
        //int column = textBox1.SelectionStart - textBox1.GetFirstCharIndexFromLine(line);
        //toolStripStatusLabel4.Text = "Ln, " + line + " Col, " + column;
}

