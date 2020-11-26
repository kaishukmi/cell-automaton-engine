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
    public partial class Form5 : Form
    {
        //Label[] colorsamples;
        public Form5()
        {
            InitializeComponent();
        }
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
        #region VariableD 

        private int _geneparam;
        public int geneparam        //ここですべての変化を適用する    つまりgeneparamの変更は最後に回すこと
        {
            get
            {
                return _geneparam;
            }
            set
            {
                _geneparam = value;
                geneparam_change();
            }
        }

        private int _colornum;
        public int colornum
        {
            get
            {
                return _colornum;
            }
            set
            {
                _colornum = value;
                colornum_change();
            }
        }
        private Color _color1;
        public Color color1
        {
            get
            {
                return _color1;
            }
            set
            {
                _color1 = value;
                c1.BackColor = _color1;
            }
        }
        public int _label1;
        public int label1
        {
            get
            {
                return _label1;
            }
            set
            {
                _label1 = value;
            }
        }
        private Color _color2;
        public Color color2
        {
            get
            {
                return _color2;
            }
            set
            {
                _color2 = value;
                c2.BackColor = _color2;

            }
        }
        public int _label2;
        public int label2
        {
            get
            {
                return _label2;
            }
            set
            {
                _label2 = value;
            }
        }
        private Color _color3;
        public Color color3
        {
            get
            {
                return _color3;
            }
            set
            {
                _color3 = value;
                c3.BackColor = _color3;

            }
        }
        public int _label3;
        public int label3
        {
            get
            {
                return _label3;
            }
            set
            {
                _label3 = value;
            }
        }
        private Color _color4;
        public Color color4
        {
            get
            {
                return _color4;
            }
            set
            {
                _color4 = value;
                c4.BackColor = _color4;

            }
        }
        public int _label4;
        public int label4
        {
            get
            {
                return _label4;
            }
            set
            {
                _label4 = value;
            }
        }private Color _color5;
        public Color color5
        {
            get
            {
                return _color5;
            }
            set
            {
                _color5 = value;
                c5.BackColor = _color5;

            }
        }
        public int _label5;
        public int label5
        {
            get
            {
                return _label5;
            }
            set
            {
                _label5 = value;
            }
        }private Color _color6;
        public Color color6
        {
            get
            {
                return _color6;
            }
            set
            {
                _color6 = value;
                c6.BackColor = _color6;

            }
        }
        public int _label6;
        public int label6
        {
            get
            {
                return _label6;
            }
            set
            {
                _label6 = value;
            }
        }private Color _color7;
        public Color color7
        {
            get
            {
                return _color7;
            }
            set
            {
                _color7 = value;
                c7.BackColor = _color7;

            }
        }
        public int _label7;
        public int label7
        {
            get
            {
                return _label7;
            }
            set
            {
                _label7 = value;
            }
        }private Color _color8;
        public Color color8
        {
            get
            {
                return _color8;
            }
            set
            {
                _color8 = value;
                c8.BackColor = _color8;

            }
        }
        public int _label8;
        public int label8
        {
            get
            {
                return _label8;
            }
            set
            {
                _label8 = value;
            }
        }private Color _color9;
        public Color color9
        {
            get
            {
                return _color9;
            }
            set
            {
                _color9 = value;
                c9.BackColor = _color9;

            }
        }
        public int _label9;
        public int label9
        {
            get
            {
                return _label9;
            }
            set
            {
                _label9 = value;
            }
        }private Color _color10;
        public Color color10
        {
            get
            {
                return _color10;
            }
            set
            {
                _color10 = value;
                c10.BackColor = _color10;

            }
        }
        public int _label10;
        public int label10
        {
            get
            {
                return _label10;
            }
            set
            {
                _label10 = value;
            }
        }private Color _color11;
        public Color color11
        {
            get
            {
                return _color11;
            }
            set
            {
                _color11 = value;
                c11.BackColor = _color11;
            }
        }
        public int _label11;
        public int label11
        {
            get
            {
                return _label11;
            }
            set
            {
                _label11 = value;
            }
        }private Color _color12;
        public Color color12
        {
            get
            {
                return _color12;
            }
            set
            {
                _color12 = value;
                c12.BackColor = _color12;

            }
        }
        public int _label12;
        public int label12
        {
            get
            {
                return _label12;
            }
            set
            {
                _label12 = value;
            }
        }

        #endregion

        private void geneparam_change()             //このフォームのメインはこのプロシージャにする
        {
            Label3.Text = _geneparam.ToString();
            l1.Text = label1.ToString();
            l2.Text = label2.ToString();
            l3.Text = label3.ToString();
            l4.Text = label4.ToString();
            l5.Text = label5.ToString();
            l6.Text = label6.ToString();
            l7.Text = label7.ToString();
            l8.Text = label8.ToString();
            l9.Text = label9.ToString();
            l10.Text = label10.ToString();
            l11.Text = label11.ToString();
            l12.Text = label12.ToString();
        }

        private void colornum_change()
        {
            int colornumtmp;
            colornumtmp = (_colornum + _colornum % 2)/2;
            //MessageBox.Show((_colornum).ToString());
            //MessageBox.Show(colornumtmp.ToString());
            this.MaximumSize = new Size(1000,1000);
            this.MinimumSize = new Size(1,1);
            this.Height = 57+(colornumtmp * 36);            //よくわからん　要調整
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
        }
    }
}
