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
    public partial class Form6 : Form
    {
        ColorDialog colordia = new ColorDialog();

        private int _ant_colornum;
        public int ant_colornum
        {
            get
            {
                return _ant_colornum;
            }
            set
            {
                _ant_colornum = value;
                ant_colornum_change();
            }
        }


        public Form6()
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

        private void ant_colornum_change()
        {
            textBox1.Text = _ant_colornum.ToString();
        }

        public void automata_change(int automatamode)
        {
            groupBox1.Location = new Point(700, 700);
            groupBox2.Location = new Point(700, 700);
            groupBox3.Location = new Point(700, 700);
            switch (automatamode)
            {
                case 1:
                    groupBox1.Location = new Point(0, 0);
                    this.MaximumSize = new Size(1000,1000);
                    this.MinimumSize = new Size(1,1);
                    this.Size = new Size(groupBox1.Width, groupBox1.Height+10);
                    this.MaximumSize = this.Size;
                    this.MinimumSize = this.Size;
                    break;
                case 2:
                    groupBox2.Location = new Point(0, 0);
                    this.MaximumSize = new Size(1000, 1000);
                    this.MinimumSize = new Size(1, 1);
                    this.Size = new Size(groupBox2.Width+20, groupBox2.Height+30);
                    this.MaximumSize = this.Size;
                    this.MinimumSize = this.Size;
                    break;
                case 3:
                    groupBox1.Location = new Point(0, 0);
                    this.MaximumSize = new Size(1000, 1000);
                    this.MinimumSize = new Size(1, 1);
                    this.Size = new Size(groupBox3.Width, groupBox3.Height+10);
                    this.MaximumSize = this.Size;
                    this.MinimumSize = this.Size;
                    break;
            }
        }

        public void lifegame_change_d(bool d1,bool d2,bool d3,bool d4,bool d5,bool d6,bool d7,bool d8,bool d9)
        {
            checkBox1.Checked = d1;
            checkBox2.Checked = d2;
            checkBox3.Checked = d3;
            checkBox4.Checked = d4;
            checkBox5.Checked = d5;
            checkBox6.Checked = d6;
            checkBox7.Checked = d7;
            checkBox8.Checked = d8;
            checkBox9.Checked = d9;
        }

        public void lifegame_change_l(bool l1, bool l2, bool l3, bool l4, bool l5, bool l6, bool l7, bool l8, bool l9)
        {
            checkBox10.Checked = l1;
            checkBox11.Checked = l2;
            checkBox12.Checked = l3;
            checkBox13.Checked = l4;
            checkBox14.Checked = l5;
            checkBox15.Checked = l6;
            checkBox16.Checked = l7;
            checkBox17.Checked = l8;
            checkBox18.Checked = l9;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
        }

        #region button_event

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void c1_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c1.BackColor = colordia.Color;
            }
        }

        private void c2_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c2.BackColor = colordia.Color;
            }
        }

        private void c3_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c3.BackColor = colordia.Color;
            }
        }

        private void c4_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c4.BackColor = colordia.Color;
            }
        }

        private void c5_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c5.BackColor = colordia.Color;
            }
        }

        private void c6_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c6.BackColor = colordia.Color;
            }
        }

        private void c7_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c7.BackColor = colordia.Color;
            }
        }

        private void c8_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c8.BackColor = colordia.Color;
            }
        }

        private void c9_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c9.BackColor = colordia.Color;
            }
        }

        private void c10_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c10.BackColor = colordia.Color;
            }
        }

        private void c11_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c11.BackColor = colordia.Color;
            }
        }

        private void c12_Click(object sender, EventArgs e)
        {
            if (colordia.ShowDialog() == DialogResult.OK)
            {
                c12.BackColor = colordia.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "")&&(int.Parse(textBox1.Text) >1)&&(int.Parse(textBox1.Text)<13))
            {
                _ant_colornum = int.Parse(textBox1.Text);
            }
        }

        #endregion


        #region GetRandColor5
        int r;
        int g;
        int b;
        Random rnd = new Random();
        private Color getrandcolor5(int mode)//明輝彩分離型ランダムカラーコード発生関数      色の定義に完全に遵守  汎用性も完璧で新しい色の種類の追加も容易
        {
            //本来の色の定義より可変域を広めに設定すること
            /*mode =    0:All           1:Vivid         2:PerfectVivit      3:Pale          4:VeryPale          5:Deep              6:Light 
             *          7:Dark          8:Soft          9:Strong            10:Dull         11:Grayish          12:LightGrayish     13:DarkGrayish
             *          
             *          100:B&W         101:Sepia       102:ColorBlind      103:Fall        104:Spring          105:Sumer           106:Winter
             *          107:Red         108:Orange      109:Yellow          110:Green       111:Cyan            112:Blue            113:Purple
             *          114:Pink        115:Bloody      116:Gore        
             */
            //指定した種類の色の輝度が最小の場合の色のしきい値を｛最小の値~最大の値+増やした可変域   or   最小の値-増やした可変域~最大の値   or   最小の値-増やした可変域~最大の値+新たに増やした可変域｝と表現する
            //ここで色を増やしたらすること→→→→→→→→1.コンボボックスに項目を追加  2.コンボボックスのイベントに追加
            int imax = 0;               //彩度の最大値
            int imin = 0;               //彩度の最小値
            double ibright = 0;         //輝度の最小値(最大値はibright+0.05)
            double ibrightwaight = 0;   //輝度のしきい値を増加させるただし明るい方向のみの増加
            if ((mode < 100) && (mode != 0))
            {
                switch (mode)           //生成に必要な数値を代入
                {
                    case 1://8~169  *35
                        imax = 169; imin = 8; ibright = 35;
                        break;
                    case 2://0~255  *0
                        imax = 255; imin = 0; ibright = 0;
                        break;
                    case 3://165~216  *75
                        imax = 216; imin = 165; ibright = 75;
                        break;
                    case 4://198~209  *80
                        imax = 209; imin = 198; ibright = 80;
                        break;
                    case 5://65~11  *15
                        imax = 65; imin = 11; ibright = 15;
                        break;
                    case 6://103~228  *65
                        imax = 228; imin = 103; ibright = 65;
                        break;
                    case 7://22~53  *15
                        imax = 53; imin = 22; ibright = 15;
                        break;
                    case 8://94~186  *55
                        imax = 186; imin = 94; ibright = 55;
                        break;
                    case 9://35~142  *35
                        imax = 142; imin = 35; ibright = 35;
                        break;
                    case 10://53~124  *35
                        imax = 124; imin = 53; ibright = 35;
                        break;
                    case 11://91~112  *40
                        imax = 112; imin = 91; ibright = 40;
                        break;
                    case 12://142~163  *60
                        imax = 163; imin = 142; ibright = 60;
                        break;
                    case 13://30~45  *15
                        imax = 45; imin = 30; ibright = 15;
                        break;
                }
                switch (rnd.Next(6))    //色の生成
                {
                    case 0:
                        r = imax; g = imin; b = rnd.Next(imax - imin) + imin;
                        break;
                    case 1:
                        r = imax; b = imin; g = rnd.Next(imax - imin) + imin;
                        break;
                    case 2:
                        g = imax; r = imin; b = rnd.Next(imax - imin) + imin;
                        break;
                    case 3:
                        g = imax; b = imin; r = rnd.Next(imax - imin) + imin;
                        break;
                    case 4:
                        b = imax; r = imin; g = rnd.Next(imax - imin) + imin;
                        break;
                    case 5:
                        b = imax; g = imin; r = rnd.Next(imax - imin) + imin;
                        break;
                }
                if (ibright != 0)       //輝度補正
                {
                    double weight = rnd.Next(6 + (int)ibrightwaight);
                    if (weight != 0)
                    {
                        r = (int)((double)r / ibright * (ibright + ((weight) / 100)));
                        g = (int)((double)g / ibright * (ibright + ((weight) / 100)));
                        b = (int)((double)b / ibright * (ibright + ((weight) / 100)));
                    }
                }
            }
            else
            {
                r = rnd.Next(255); g = rnd.Next(255); b = rnd.Next(255);
                switch (mode)
                {
                    case 100:
                        g = r;
                        b = r;
                        break;
                    case 101:
                        r = rnd.Next(192) + 64;
                        r = (int)(r * 0.9);
                        g = (int)(r * 0.7);
                        b = (int)(r * 0.4);
                        break;
                    case 102:
                        g = r;
                        break;
                    case 103:
                        r = (int)(r * 0.9); g = (int)(g * 0.7); b = (int)(b * 0.4);
                        break;
                    case 107:
                        r = rnd.Next(34) + 222;
                        g = rnd.Next(r - 94);
                        b = g;
                        break;
                    case 110:
                        g = rnd.Next(162) + 94;
                        r = rnd.Next(g - 94);
                        b = r;
                        break;
                    case 115:
                        g = 0;
                        b = 0;
                        break;
                    case 116:
                        r = rnd.Next(64) + 168;
                        if (rnd.Next(5) != 1) r = 0;
                        g = 0;
                        b = 0;
                        break;
                }
            }
            return Color.FromArgb(255, r, g, b);
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            int colmode = 2;
            //c1.BackColor = getrandcolor5(colmode);
            c2.BackColor = getrandcolor5(colmode);
            c3.BackColor = getrandcolor5(colmode);
            c4.BackColor = getrandcolor5(colmode);
            c5.BackColor = getrandcolor5(colmode);
            c6.BackColor = getrandcolor5(colmode);
            c7.BackColor = getrandcolor5(colmode);
            c8.BackColor = getrandcolor5(colmode);
            c9.BackColor = getrandcolor5(colmode);
            c10.BackColor = getrandcolor5(colmode);
            c11.BackColor = getrandcolor5(colmode);
            c12.BackColor = getrandcolor5(colmode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l1.Text = rnd.Next(2) == 0 ? "R" : "L";
            l2.Text = rnd.Next(2) == 0 ? "R" : "L";
            l3.Text = rnd.Next(2) == 0 ? "R" : "L";
            l4.Text = rnd.Next(2) == 0 ? "R" : "L";
            l5.Text = rnd.Next(2) == 0 ? "R" : "L";
            l6.Text = rnd.Next(2) == 0 ? "R" : "L";
            l7.Text = rnd.Next(2) == 0 ? "R" : "L";
            l8.Text = rnd.Next(2) == 0 ? "R" : "L";
            l9.Text = rnd.Next(2) == 0 ? "R" : "L";
            l10.Text = rnd.Next(2) == 0 ? "R" : "L";
            l11.Text = rnd.Next(2) == 0 ? "R" : "L";
            l12.Text = rnd.Next(2) == 0 ? "R" : "L";
        }

    }
}
