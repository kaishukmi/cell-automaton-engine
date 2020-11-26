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

//http://note.chiebukuro.yahoo.co.jp/detail/n315249
//http://note.chiebukuro.yahoo.co.jp/detail/n191521
//http://d.hatena.ne.jp/mena621/20120726/1343284569
//
//
//
//


namespace CellAutomatonEngine
{
    public partial class Form2 : Form
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
        public Form2()
        {
            InitializeComponent();
        }

        private int _widthparam;
        public int widthparam
        {
            get
            {
                return _widthparam;
            }
            set
            {
                _widthparam = value;
            }
        }
        private int _heightparam;
        public int heightparam
        {
            get
            {
                return _heightparam;
            }
            set
            {
                _heightparam = value;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || '9' < e.KeyChar)
            {
                //押されたキーが 0～9でない場合は、イベントをキャンセルする
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //trackBar1.Value = int.Parse(textBox1.Text);
            /*if(int.Parse(textBox1.Text) <= 2)
            {
                textBox1.Text = "3";
            }
            _widthparam = int.Parse(textBox1.Text);*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //trackBar2.Value = int.Parse(textBox2.Text);
            /*if (int.Parse(textBox2.Text) <= 2)
            {
                textBox2.Text = "3";
            }
            _heightparam = int.Parse(textBox2.Text);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) <= 9)
            {
                textBox1.Text = "10";
            }
            trackBar1.Value = int.Parse(textBox1.Text);
            _widthparam = int.Parse(textBox1.Text);
            if (int.Parse(textBox2.Text) <= 9)
            {
                textBox2.Text = "10";
            }
            trackBar2.Value = int.Parse(textBox2.Text);
            _heightparam = int.Parse(textBox2.Text);
            /*widthparam = int.Parse(textBox1.Text);
            heightparam = int.Parse(textBox2.Text);*/
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) <= 9)
            {
                textBox1.Text = "10";
            }
            trackBar1.Value = int.Parse(textBox1.Text);
            _widthparam = int.Parse(textBox1.Text);
            if (int.Parse(textBox2.Text) <= 9)
            {
                textBox2.Text = "10";
            }
            trackBar2.Value = int.Parse(textBox2.Text);
            _heightparam = int.Parse(textBox2.Text);
            /*widthparam = int.Parse(textBox1.Text);
            heightparam = int.Parse(textBox2.Text);*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = _widthparam.ToString();
            textBox2.Text = _heightparam.ToString();
            trackBar1.Value = int.Parse(textBox1.Text);
            trackBar2.Value = int.Parse(textBox2.Text);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            CheckBox item = (CheckBox)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
            this.TopMost = item.Checked;
            //checkBox1.Checked = !checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
