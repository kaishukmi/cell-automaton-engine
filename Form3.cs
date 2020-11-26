using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace CellAutomatonEngine
{
    public partial class Form3 : Form
    {
        protected override CreateParams CreateParams        //閉じるボタン無効化
        {
            [SecurityPermission(SecurityAction.Demand,
                Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;

                return cp;
            }
        }
        private int realfps;            //nミリ秒あたりに一回描画  interval

        private bool _okparam;
        public bool okparam
        {
            get
            {
                return _okparam;
            }
            set
            {
                _okparam = value;
            }
        }
        
        private int _fpsdispparam;      //表示fps 例)30        最初にform1から受け取る　後の変更はこのフォームのみ(現在は)
        public int fpsdispparam
        {
            get
            {
                return _fpsdispparam;
            }
            set
            {
                _fpsdispparam = value;
            }
        }
        private int _skipfparam;        //nフレームスキップする   最初にform1から受け取る後の変更はこのフォームのみ(現在は)
        public int skipfparam           //
        {
            get
            {
                return _skipfparam;
            }
            set
            {
                _skipfparam = value;
            }
        }
        private int _skipfnumparam;
        public int skipfnumparam
        {
            get
            {
                return _skipfnumparam;
            }
            set
            {
                _skipfnumparam = value;
            }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox3.Text = _fpsdispparam.ToString();
            realfps = 1000 / _fpsdispparam;
            textBox4.Text = realfps.ToString();
            textBox2.Text = _skipfparam.ToString();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
            button4.Enabled = false;
            button3.Enabled = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            CheckBox item = (CheckBox)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
            this.TopMost = item.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _okparam = false;
            if((textBox4.Text!="")&&(int.Parse(textBox4.Text) != 0))
            {
                _okparam = true;
                realfps = int.Parse(textBox4.Text);
                _fpsdispparam = 1000 / realfps;
                textBox3.Text = _fpsdispparam.ToString();
                button4.Enabled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _okparam = false;
            if ((textBox3.Text!="")&&(int.Parse(textBox3.Text) != 0))
            {
                _okparam = true;
                _fpsdispparam = int.Parse(textBox3.Text);
                realfps = 1000 / _fpsdispparam;
                textBox4.Text = realfps.ToString();
                button4.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _okparam = false;
            if (textBox2.Text != "")
            {
                _okparam = true;
                _skipfparam = int.Parse(textBox2.Text);
                button4.Enabled = true;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _okparam = false;
            if(textBox1.Text !="")
            {
                _okparam = true;
                _skipfnumparam = int.Parse(textBox1.Text);
                button3.Enabled = true;
                if (int.Parse(textBox1.Text) == 0)
                {
                    button3.Enabled = false;
                }
            }
        }
    }
}
