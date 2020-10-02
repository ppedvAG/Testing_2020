using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ppedv.MittagsHunger.UI.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.DataBindings.Add(nameof(TextBox.Text), textBox1, "Text");
            textBox2.DataBindings.Add(nameof(TextBox.BackColor), textBox1, "Text",true);
        }
    }
}
