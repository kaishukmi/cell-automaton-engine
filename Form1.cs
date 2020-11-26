using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellAutomatonEngine
{
    public partial class Form1 : Form       //操作、描画関係クラス
    {
        #region Variable declaration

        Random cRandom = new System.Random();       //乱数生成用 int iResult1 = cRandom.Next();　()内にnで0以上n未満の乱数を生成

        const int bitboard_max_width = 1001;        //1から使う
        const int bitboard_max_height = 1001;       //1から使う

        string about;                               //作成日時、ヴァージョン等のメモ、イニシャライズで設定

        //他クラスのメンバも含めてここでなるべく一元管理する目的もあるが、高速演算時の表示回数を減らあす目的でここに擬似的なメンバを生成する。
        int generation;                             //現在の世代数
        int automatonmode;                          //1=ライフゲーム 2=蟻 
        string automatonname;                       //オートマトンの名前
        string automatonstate;                      //オートマトンの現在の状態の名前  実行中　など
        string inputboxtext;
        int cells_width;                            //横方向セルの個数              要)変更時にform2に連絡  現在はform2でのみ変更可
        int cells_height;                           //縦方向セルの個数              要)変更時にform2に連絡  現在はform2でのみ変更可
        float cells_sizew;                          //セルの横幅
        float cells_sizeh;                          //セルの高さ
        int pickX;                                  //現在マウスカーソルが置かれているX座標   0を始点とする 計算領域に保存時に1加算して配列の剰余計算領域を確保する
        int pickY;                                  //現在マウスカーソルが置かれているY座標   0を始点とする 計算領域に保存時に1加算して配列の剰余計算領域を確保する
        int spickX;                                 //照合用X座標
        int spickY;                                 //照合用Y座標
        Size cells_size;                            //セルのサイズ
        Size canvas_size;                           //描画空間のサイズ
        Bitmap canvas_back = new Bitmap(1900, 1900);
        Bitmap canvas= new Bitmap(1900, 1900);
        //main_option_para_st option_para = new main_option_para_st();              //静的メンバのため宣言不要
        Form2 form2 = new Form2();                  //セルの広さ指定フォーム
        Form3 form3 = new Form3();                  //スピードコントローラー
        Form4 form4 = new Form4();                  //セルコントローラー
        Form5 form5 = new Form5();                  //モニター
        Form6 form6 = new Form6();                  //ルールセレクター
        int fps_disp;                               //表示用のFPS＝フォーム間の適切な受け渡しに使用      要)変更時にform3に連絡  現在はform3でのみ変更可
        int fps_real;                               //実fps
        int skipf;                                  //描画をスキップするフレーム                         要)変更時にf3に連絡     現在はf3でのみ変更可

        public struct main_option_para_st
        {
            public static bool form2Visible;            //form2が現在見えていたらtrue
            public static bool form3Visible;
            public static bool form4Visible;
            public static bool form5Visible;
            public static bool form6Visible;
            public static bool unEuclidian;             //非ユークリッド幾何学空間ならtrue
            public static bool visual_borderable;       //罫線を表示するならtrue
            public static bool mouthcursor_visible;     //マウスカーソルの表示非表示
        }
        public struct main_option_colors
        {
            public static Color canvas_border;              //それぞれのオートマトン選択時に直接変更すること
            public static Color canvas_back;
            public static Color subuse;                     //サブカラー アントで中心点に使用 その他も用途に応じて自由に
            public static Color[] colors;
        }
        public struct lifegame_para
        {
            public static bool[,] bitboardproto;                //ライフゲームビットボード              1を始点とする 0は巡回する配列の剰余の計算に使う
            public static bool[,] bitboardprotobuffer;          //ライフゲームビットボード処理用空間
            public static bool[] neighborrule_l;                //セルが生存時の隣人数に応じたルールneighborrule_l[neighbor]の形でboolで生存か死亡か入れておく
            public static bool[] neighborrule_d;                //セルが死亡時の隣人数に応じたルール
            public static int neighbor;                         //隣人数
        }
        public struct Ant_Rule                      //そのまま使わないこと
        {
            public int num;                  //ポインタ
            public int color;                //色番号
            public int RL;                   //0で右、1で左
        }
        public struct ant_para
        {
            public static int[,] ant_board;
            public static Ant_Rule[] ant_rule;
            public static int antrulenum;           //ルールの使用される数
            public static int ant_direction;        //1で上　3で下　5で右　7で左
            public static int ant_x;
            public static int ant_y;
            public static int ant_max;              //現在の色の最大値
            public static int ant_max_C;            //現在の色の最大値の色
        }

        #endregion

        #region form1control

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialization();
            SizeChange_Redraw();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("フォームのサイズが変更されました");
            SizeChange_Redraw();
            Automata_draw_front();
        }

        #endregion

        #region Bitboard Definition //実装不可能
        /*public UInt64 bitBoard;

        public BitBoard(UInt64 board)
        {
            bitBoard = board;
        }

        public static implicit operator BitBoard(UInt64 board)
        {
            return new BitBoard(board);
        }
        public static implicit operator UInt64(BitBoard board)
        {
            return board.bitBoard;
        }

        public static BitBoard operator <<(BitBoard board, int shift)
        {
            return board.bitBoard << shift;
        }
        public static BitBoard operator >>(BitBoard board, int shift)
        {
            return board.bitBoard >> shift;
        }
        public static BitBoard operator &(BitBoard a, BitBoard b)
        {
            return a.bitBoard & b.bitBoard;
        }
        public static BitBoard operator |(BitBoard a, BitBoard b)
        {
            return a.bitBoard | b.bitBoard;
        }
        public static BitBoard operator ^(BitBoard a, BitBoard b)
        {
            return a.bitBoard ^ b.bitBoard;
        }
        public static BitBoard operator ~(BitBoard a)
        {
            return ~a.bitBoard;
        }
        */
    #endregion

        #region Initialization
        private void Initialization()
        {
            about = @"Cellular Automaton Engine Ver 1.0 
2016 Kaisyu Kamei

Implementation
-Conway's Game of Life
-Langton's Ant";

            fps_disp = 30;
            fps_real = 1000 / fps_disp;
            timer1.Interval = fps_real;
            skipf = 0;
            //MessageBox.Show(fps_real.ToString());
            automatonmode = 1;
            automatonname = "Conway's Game of Life";
            cells_height = 50;
            cells_width = 50;
            spickX = 0;
            spickY = 0;
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            #region main_option initialize
            main_option_para_st.form2Visible = true;
            main_option_para_st.form3Visible = true;
            main_option_para_st.form4Visible = true;
            main_option_para_st.form5Visible = true;
            main_option_para_st.form6Visible = true;
            main_option_para_st.unEuclidian = true;
            main_option_para_st.visual_borderable = true;
            main_option_para_st.mouthcursor_visible = true;
            #endregion

            //インスタンス化など最初期の初期化
            #region most_initialize

            main_option_colors.canvas_border = Color.FromArgb(50, 50, 50);
            main_option_colors.canvas_back = Color.FromArgb(0, 0, 0);
            main_option_colors.colors = new Color[13];              //0から12まで。0は使用しないが一応

            lifegame_para.bitboardproto = new bool[bitboard_max_width + 1, bitboard_max_height + 1];          //ビットボード初期化   計算領域の確保で両端に一つ余裕を作る
            lifegame_para.bitboardprotobuffer = new bool[bitboard_max_width + 1, bitboard_max_height + 1];    //ビットボードバッファ初期化
            lifegame_para.neighborrule_l = new bool[9];     //生存時      0~8までの9つ
            lifegame_para.neighborrule_d = new bool[9];     //死亡時      0~8までの9つ

            ant_para.ant_rule = new Ant_Rule[13];           //1から12
            for (int i = 0; i <= 12; i++)
            {
                ant_para.ant_rule[i] = new Ant_Rule();      //いる？
            }
            ant_para.ant_board = new int[bitboard_max_width, bitboard_max_height];      //1からつかう

            #endregion

            this.TopMost = true;

            form2.widthparam = cells_width;
            form2.heightparam = cells_height;
            form2.button2.Click += new EventHandler(this.button2_Click);
            form2.button3.Click += new EventHandler(this.button2_Click);
            form2.Show();
            form2.Location = new Point(this.Location.X + 619, this.Location.Y + 210);

            form3.fpsdispparam = fps_disp;
            form3.skipfparam = skipf;
            form3.button2.Click += new EventHandler(this.form3runbutton_click);
            form3.button1.Click += new EventHandler(this.form3stopbutton_click);
            form3.button3.Click += new EventHandler(this.form3skipbutton_click);
            form3.button4.Click += new EventHandler(this.form3gobutton_click);
            form3.Show();
            form3.Location = new Point(this.Location.X + 619, this.Location.Y);

            form4.button2.Click += new EventHandler(this.form4clearbutton_click);
            form4.button1.Click += new EventHandler(this.form4randombutton_click);
            form4.Show();
            form4.Location = new Point(this.Location.X + 781, this.Location.Y);

            form5.Show();
            form5.Location = new Point(this.Location.X+619, this.Location.Y+348);

            generation = 0;
            form5.label1 = cells_width * cells_height;
            form5.label2 = 0;

            form6.checkBox1.CheckedChanged += new EventHandler(this.lifegame_change_d1);
            form6.checkBox2.CheckedChanged += new EventHandler(this.lifegame_change_d2);
            form6.checkBox3.CheckedChanged += new EventHandler(this.lifegame_change_d3);
            form6.checkBox4.CheckedChanged += new EventHandler(this.lifegame_change_d4);
            form6.checkBox5.CheckedChanged += new EventHandler(this.lifegame_change_d5);
            form6.checkBox6.CheckedChanged += new EventHandler(this.lifegame_change_d6);
            form6.checkBox7.CheckedChanged += new EventHandler(this.lifegame_change_d7);
            form6.checkBox8.CheckedChanged += new EventHandler(this.lifegame_change_d8);
            form6.checkBox9.CheckedChanged += new EventHandler(this.lifegame_change_d9);
            form6.checkBox10.CheckedChanged += new EventHandler(this.lifegame_change_l1);
            form6.checkBox11.CheckedChanged += new EventHandler(this.lifegame_change_l2);
            form6.checkBox12.CheckedChanged += new EventHandler(this.lifegame_change_l3);
            form6.checkBox13.CheckedChanged += new EventHandler(this.lifegame_change_l4);
            form6.checkBox14.CheckedChanged += new EventHandler(this.lifegame_change_l5);
            form6.checkBox15.CheckedChanged += new EventHandler(this.lifegame_change_l6);
            form6.checkBox16.CheckedChanged += new EventHandler(this.lifegame_change_l7);
            form6.checkBox17.CheckedChanged += new EventHandler(this.lifegame_change_l8);
            form6.checkBox18.CheckedChanged += new EventHandler(this.lifegame_change_l9);
            form6.c1.Click += new EventHandler(this.ant_change_c1);
            form6.c2.Click += new EventHandler(this.ant_change_c2);
            form6.c3.Click += new EventHandler(this.ant_change_c3);
            form6.c4.Click += new EventHandler(this.ant_change_c4);
            form6.c5.Click += new EventHandler(this.ant_change_c5);
            form6.c6.Click += new EventHandler(this.ant_change_c6);
            form6.c7.Click += new EventHandler(this.ant_change_c7);
            form6.c8.Click += new EventHandler(this.ant_change_c8);
            form6.c9.Click += new EventHandler(this.ant_change_c9);
            form6.c10.Click += new EventHandler(this.ant_change_c10);
            form6.c11.Click += new EventHandler(this.ant_change_c11);
            form6.c12.Click += new EventHandler(this.ant_change_c12);
            form6.l1.Click += new EventHandler(this.ant_change_l1);
            form6.l2.Click += new EventHandler(this.ant_change_l2);
            form6.l3.Click += new EventHandler(this.ant_change_l3);
            form6.l4.Click += new EventHandler(this.ant_change_l4);
            form6.l5.Click += new EventHandler(this.ant_change_l5);
            form6.l6.Click += new EventHandler(this.ant_change_l6);
            form6.l7.Click += new EventHandler(this.ant_change_l7);
            form6.l8.Click += new EventHandler(this.ant_change_l8);
            form6.l9.Click += new EventHandler(this.ant_change_l9);
            form6.l10.Click += new EventHandler(this.ant_change_l10);
            form6.l11.Click += new EventHandler(this.ant_change_l11);
            form6.l12.Click += new EventHandler(this.ant_change_l12);

            form6.button1.Click += new EventHandler(this.ant_colornum_get);
            form6.button2.Click += new EventHandler(this.ant_color_random);
            form6.button3.Click += new EventHandler(this.ant_direction_random);

            form6.Show();
            form6.Location = new Point(this.Location.X + 782, this.Location.Y + 348);
            form6.automata_change(automatonmode);

            automata_change();      //重要
        }

        #endregion

        #region SizeChangeRedraw_Function

        private void Cell_Redraw()
        {
            Graphics g = Graphics.FromImage(canvas_back);
            SolidBrush lifecellb = new SolidBrush(main_option_colors.colors[2]);
            //g.FillRectangle(lifecellb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int j = 1; j <= cells_width; j++)
            {
                for (int k = 1; k <= cells_height; k++)
                {
                    if (lifegame_para.bitboardproto[j, k])
                    {
                        g.FillRectangle(lifecellb, (j - 1) * cells_sizew, (k - 1) * cells_sizeh, cells_sizew, cells_sizeh);
                    }
                }
            }
            lifecellb.Dispose();
            g.Dispose();
            pictureBox1.Image = canvas_back;
        }

        private void Ant_Redraw()
        {
            ant_count();                //各マスの数を計算
            Graphics g = Graphics.FromImage(canvas_back);
            SolidBrush lifecellb = new SolidBrush(main_option_colors.colors[ant_para.ant_max_C]);
            Pen borderp = new Pen(main_option_colors.canvas_border, 1);
            //g.FillRectangle(lifecellb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.FillRectangle(lifecellb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int j = 1; j <= cells_width; j++)
            {
                for (int k = 1; k <= cells_height; k++)
                {
                    if (ant_para.ant_rule[ant_para.ant_board[j, k]].color != ant_para.ant_max_C)
                    {
                        lifecellb = new SolidBrush(main_option_colors.colors[ant_para.ant_rule[ant_para.ant_board[j, k]].color]);
                        g.FillRectangle(lifecellb, (j - 1) * cells_sizew, (k - 1) * cells_sizeh, cells_sizew, cells_sizeh);
                    }
                }
            }
            if (main_option_para_st.visual_borderable)
            {
                int i = 0;
                while (i <= cells_width)
                {
                    g.DrawLine(borderp, i * cells_sizew, 0, i * cells_sizew, pictureBox1.Height);
                    i++;
                }
                i = 0;
                while (i <= cells_height)
                {
                    g.DrawLine(borderp, 0, i * cells_sizeh, pictureBox1.Width, i * cells_sizeh);
                    i++;
                }
            }
            lifecellb = new SolidBrush(main_option_colors.subuse);
            g.FillRectangle(lifecellb, (ant_para.ant_x - 1) * cells_sizew, (ant_para.ant_y - 1) * cells_sizeh, cells_sizew, cells_sizeh);
            lifecellb.Dispose();
            borderp.Dispose();
            g.Dispose();
            pictureBox1.Image = canvas_back;
        }

        private void Fixsize_Redraw_back()              //背景のみの再描画
        {
            Graphics g = Graphics.FromImage(canvas_back);
            SolidBrush backb = new SolidBrush(main_option_colors.colors[1]);
            Pen borderp = new Pen(main_option_colors.canvas_border, 1);
            g.FillRectangle(backb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            if (main_option_para_st.visual_borderable)
            {
                int i = 0;
                while (i <= cells_width)
                {
                    g.DrawLine(borderp, i * cells_sizew, 0, i * cells_sizew, pictureBox1.Height);
                    i++;
                }
                i = 0;
                while (i <= cells_height)
                {
                    g.DrawLine(borderp, 0, i * cells_sizeh, pictureBox1.Width, i * cells_sizeh);
                    i++;
                }
            }
            backb.Dispose();
            borderp.Dispose();
            g.Dispose();
            pictureBox1.Image = canvas_back;
        }

        private void Ant_Redraw_back()              //罫線を描画しない
        {
            Graphics g = Graphics.FromImage(canvas_back);
            SolidBrush backb = new SolidBrush(main_option_colors.colors[1]);
            //Pen borderp = new Pen(main_option_colors.canvas_border, 1);
            g.FillRectangle(backb, 0, 0, pictureBox1.Width, pictureBox1.Height);
            /*if (main_option_para_st.visual_borderable)
            {
                int i = 0;
                while (i <= cells_width)
                {
                    g.DrawLine(borderp, i * cells_sizew, 0, i * cells_sizew, pictureBox1.Height);
                    i++;
                }
                i = 0;
                while (i <= cells_height)
                {
                    g.DrawLine(borderp, 0, i * cells_sizeh, pictureBox1.Width, i * cells_sizeh);
                    i++;
                }
            }*/
            backb.Dispose();
            //borderp.Dispose();
            g.Dispose();
            pictureBox1.Image = canvas_back;
        }

        private void SizeChange_Redraw()
        {
            pictureBox1.Size = new Size(this.Width - 16, this.Height - 63);
            canvas_size = pictureBox1.Size;   //new Size(this.Width-16,this.Height-63)
            cells_sizew = pictureBox1.Width / (float)cells_width;
            cells_sizeh = pictureBox1.Height / (float)cells_height;
            Automata_draw_back();
        }

        private void CellSizeChange_Redraw(float  cellsizeWidth,float cellsizeHeight)
        {
            /*pictureBox1.Size = new Size(this.Width - 16, this.Height - 63);
            canvas_size = pictureBox1.Size;   //new Size(this.Width-16,this.Height-63)
            cells_sizew = pictureBox1.Width / (float)cells_width;
            cells_sizeh = pictureBox1.Height / (float)cells_height;*/
            float Pwidth = cellsizeWidth * cells_width;
            float Pheight = cellsizeHeight * cells_height;
            pictureBox1.Size = new Size((int)Pwidth,(int)Pheight);
            this.Size = new Size(pictureBox1.Width + 16, pictureBox1.Height + 63);
            canvas_size = pictureBox1.Size;   //new Size(this.Width-16,this.Height-63)
            Automata_draw_back();
        }

        #endregion

        #region ButtonEvent
        //====================================================================================================================================================
        //================================================================-----BUTTON EVENT-----==============================================================
        //====================================================================================================================================================
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(about);
        }
        
        private void 非ユークリッド幾何学空間ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            main_option_para_st.unEuclidian = !(main_option_para_st.unEuclidian);
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
        }

        private void conwaysGameOfLifeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Conway's Game of Life";
            automatonmode = 1;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void langtonsAntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Langton's Ant";
            automatonmode = 2;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void vonNeumannUniversalConstructerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Von Neumann Universal Constructor";
            automatonmode = 3;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void coddsCellularAutomatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Codd's Cellular Automaton";
            automatonmode = 4;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void langtonsLoopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Langton's Loop";
            automatonmode = 5;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void wirewarldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Wire World";
            automatonmode = 6;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void elementaryCellularAutomatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            automatonname = "Elementary Cellular Automata";
            automatonmode = 7;
            automata_change();
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.conwaysGameOfLifeToolStripMenuItem,
                this.langtonsAntToolStripMenuItem,
                this.vonNeumannUniversalConstructerToolStripMenuItem,
                this.coddsCellularAutomatonToolStripMenuItem,
                this.langtonsLoopToolStripMenuItem,
                this.wirewarldToolStripMenuItem,
                this.elementaryCellularAutomatonToolStripMenuItem,
            };
            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void セルの量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //inputboxtext = Interaction.InputBox("質問内容", "タイトルバー文字列", "デフォルトの答え", 200, 100);
            if (main_option_para_st.form2Visible)
            {
                form2.Hide();
            }
            else
            {
                form2.Show();
            }
            main_option_para_st.form2Visible = !(main_option_para_st.form2Visible);
        }

        private void 常に最前面表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
            this.TopMost = item.Checked;
        }


        private void button2_Click(object sender, EventArgs e)          //form2のボタンクリックイベント
        {
            //MessageBox.Show(cells_width.ToString());
            cells_width = form2.widthparam;
            cells_height = form2.heightparam;
            SizeChange_Redraw();
            Automata_draw_front();
        }

        private void form3runbutton_click(object sender,EventArgs e)    //form3のボタンクリックイベント
        {
            timer1.Start();
            実行ToolStripMenuItem.Text = "停止(F5)";
        }
        private void form3stopbutton_click(object sender, EventArgs e)   //form3のボタンクリックイベント
        {
            timer1.Stop();
            実行ToolStripMenuItem.Text = "実行(F5)";
        }

        private void form3skipbutton_click(object sender, EventArgs e)  //form3のスキップボタンクリックイベント
        {
            int lnum = form3.skipfnumparam;
            for (int s = 1; s <= lnum; s++)
            {
                Automata_running();
            }
            Automata_draw_back();
            Automata_draw_front();
        }

        private void form3gobutton_click(object sender, EventArgs e)    //form3の適用ボタンクリックイベント
        {
            fps_disp = form3.fpsdispparam;
            fps_real = 1000 / fps_disp;
            timer1.Interval = fps_real;
            skipf = form3.skipfparam;
            //MessageBox.Show(skipf.ToString());
        }

        private void form4clearbutton_click(object sender, EventArgs e) //form4の初期化ボタンイベント
        {
            switch (automatonmode)
            {
                case 1:
                    for (int i = 0; i < bitboard_max_width + 1; i++)
                    {
                        for (int j = 0; j < bitboard_max_height + 1; j++)
                        {
                            lifegame_para.bitboardproto[i, j] = false;
                            lifegame_para.bitboardprotobuffer[i, j] = false;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < bitboard_max_width; i++)
                    {
                        for (int j = 0; j < bitboard_max_height; j++)
                        {
                            ant_para.ant_board[i, j] = 0;
                        }
                    }
                    break;
            }
            Automata_draw_back();
            Automata_draw_front();
            generation = 0;
            form5.geneparam = 0;
        }

        private void 初期化ToolStripMenuItem_Click(object sender, EventArgs e)     //同上
        {
            switch (automatonmode)
            {
                case 1:
                    for (int i = 0; i < bitboard_max_width + 1; i++)
                    {
                        for (int j = 0; j < bitboard_max_height + 1; j++)
                        {
                            lifegame_para.bitboardproto[i, j] = false;
                            lifegame_para.bitboardprotobuffer[i, j] = false;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < bitboard_max_width; i++)
                    {
                        for (int j = 0; j < bitboard_max_height; j++)
                        {
                            ant_para.ant_board[i, j] = 0;
                        }
                    }
                    break;
            }
            Automata_draw_back();
            Automata_draw_front();
            generation = 0;
            form5.geneparam = 0;
        }

        private void form4randombutton_click(object sender, EventArgs e)    //form4のランダムボタンイベント
        {
            switch (automatonmode)
            {
                case 1:
                    for (int x = 1; x <= cells_width; x++)
                    {
                        for (int y = 1; y <= cells_height; y++)
                        {
                            lifegame_para.bitboardproto[x, y] = cRandom.Next(3) == 0 ? true : false;
                        }
                    }
                    break;
                case 2:
                    for (int x = 1; x <= cells_width; x++)
                    {
                        for (int y = 1; y <= cells_height; y++)
                        {
                            ant_para.ant_board[x, y] = cRandom.Next(form5.colornum);
                        }
                    }
                    break;
            }
            Automata_draw_back();
            Automata_draw_front();
        }
        private void pictureBox1_Click(object sender, EventArgs e)      //mousedownに移動する
        {
            switch (automatonmode)
            {
                case 1:
                    if ((pickX != spickX) || (pickY != spickY))
                    {
                        lifegame_para.bitboardproto[pickX, pickY] = !lifegame_para.bitboardproto[pickX, pickY];   //選択されているセルの反転
                        spickX = pickX;
                        spickY = pickY;
                    }
                    break;
                case 2:
                    ant_para.ant_x = pickX;
                    ant_para.ant_y = pickY;
                    Automata_draw_front();
                    break;
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            if (!main_option_para_st.mouthcursor_visible)
            {
                Cursor.Hide();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!main_option_para_st.mouthcursor_visible)
            {
                Cursor.Show();
            }
            Automata_draw_back();
            Automata_draw_front();
        }

        private void 実行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("フォームのサイズが変更されました");
            if (実行ToolStripMenuItem.Text == "実行(F5)")
            {
                実行ToolStripMenuItem.Text = "停止(F5)";
                timer1.Start();
            }
            else
            {
                実行ToolStripMenuItem.Text = "実行(F5)";
                timer1.Stop();
            }
        }

        private void ウィンドウサイズToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 罫線の表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_option_para_st.visual_borderable = !(main_option_para_st.visual_borderable);
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //チェック状態を反転させる
            item.Checked = !item.Checked;
            SizeChange_Redraw();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //SizeChange_Redraw();
            switch(automatonmode)
            {
                case 1:
                    if (!timer1.Enabled)
                    {
                        Automata_draw_back();
                        Automata_draw_front();
                    }

                    Point sp = Cursor.Position;
                    Point cp = this.PointToClient(sp);
                    cp.Y = cp.Y - 27;
                    double picX;
                    double picY;
                    picX = cp.X / cells_sizew;
                    picY = cp.Y / cells_sizeh;
                    picX = Math.Floor(picX);
                    picY = Math.Floor(picY);
                    pickX = (int)picX+1;
                    pickY = (int)picY+1;
                    this.Text = string.Format("CellAutomatonEngine - {0} - {1},{2}",automatonname,pickX.ToString(),pickY.ToString());
                    canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics g = Graphics.FromImage(canvas_back);
                    SolidBrush lifegamepre = new SolidBrush(main_option_colors.colors[3]);
                    g.FillRectangle(lifegamepre, (float)(picX * cells_sizew), (float)(picY * cells_sizeh),(float)cells_sizew, (float)cells_sizeh);
                    g.Dispose();
                    lifegamepre.Dispose();
                    break;
                case 2:
                    if (!timer1.Enabled)
                    {
                        Automata_draw_front();
                    }

                    sp = Cursor.Position;
                    cp = this.PointToClient(sp);
                    cp.Y = cp.Y - 27;
                    picX = cp.X / cells_sizew;
                    picY = cp.Y / cells_sizeh;
                    picX = Math.Floor(picX);
                    picY = Math.Floor(picY);
                    pickX = (int)picX + 1;
                    pickY = (int)picY + 1;
                    this.Text = string.Format("CellAutomatonEngine - {0} - {1},{2}", automatonname, pickX.ToString(), pickY.ToString());
                    canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    g = Graphics.FromImage(canvas_back);
                    lifegamepre = new SolidBrush(main_option_colors.subuse);
                    g.FillRectangle(lifegamepre, (float)(picX * cells_sizew), (float)(picY * cells_sizeh), (float)cells_sizew, (float)cells_sizeh);
                    g.Dispose();
                    lifegamepre.Dispose();
                    break;
            }
        }

        private void 縦のセルに合わせてサイズ変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_sizew = cells_sizeh;
            CellSizeChange_Redraw(cells_sizew,cells_sizeh);
        }

        private void 横に合わせてサイズ変更ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cells_sizeh = cells_sizew;
            CellSizeChange_Redraw(cells_sizew, cells_sizeh);
            //MessageBox.Show(this.Height.ToString());
        }

        private void ムーア近傍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
            {
                this.ムーア近傍ToolStripMenuItem,
                this.ノイマン近傍ToolStripMenuItem,
            };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void ノイマン近傍ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem[] groupMenuItems = new ToolStripMenuItem[]
             {
                this.ムーア近傍ToolStripMenuItem,
                this.ノイマン近傍ToolStripMenuItem,
             };

            //グループのToolStripMenuItemを列挙する
            foreach (ToolStripMenuItem item in groupMenuItems)
            {
                if (object.ReferenceEquals(item, sender))
                {
                    //ClickされたToolStripMenuItemならば、Indeterminateにする
                    item.CheckState = CheckState.Indeterminate;
                }
                else
                {
                    //ClickされたToolStripMenuItemでなければ、Uncheckedにする
                    item.CheckState = CheckState.Unchecked;
                }
            }

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 実行設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (main_option_para_st.form3Visible)
            {
                form3.Hide();
            }
            else
            {
                form3.Show();
            }
            main_option_para_st.form3Visible = !(main_option_para_st.form3Visible);
        }
        private void ライフゲームコントローラToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (main_option_para_st.form4Visible)
            {
                form4.Hide();
            }
            else
            {
                form4.Show();
            }
            main_option_para_st.form4Visible = !(main_option_para_st.form4Visible);
        }

        private void モニターウィンドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (main_option_para_st.form5Visible)
            {
                form5.Hide();
            }
            else
            {
                form5.Show();
            }
            main_option_para_st.form5Visible = !(main_option_para_st.form5Visible);
        }

        private void ルールウィンドウToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (main_option_para_st.form6Visible)
            {
                form6.Hide();
            }
            else
            {
                form6.Show();
            }
            main_option_para_st.form6Visible = !(main_option_para_st.form6Visible);
        }

        private void lifegame_change_d1(object sender,EventArgs e)
        {
            lifegame_para.neighborrule_d[0] = !lifegame_para.neighborrule_d[0];
        }
        private void lifegame_change_d2(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[1] = !lifegame_para.neighborrule_d[1];
        }
        private void lifegame_change_d3(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[2] = !lifegame_para.neighborrule_d[2];
        }
        private void lifegame_change_d4(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[3] = !lifegame_para.neighborrule_d[3];
        }
        private void lifegame_change_d5(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[4] = !lifegame_para.neighborrule_d[4];
        }
        private void lifegame_change_d6(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[5] = !lifegame_para.neighborrule_d[5];
        }
        private void lifegame_change_d7(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[6] = !lifegame_para.neighborrule_d[6];
        }
        private void lifegame_change_d8(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[7] = !lifegame_para.neighborrule_d[7];
        }
        private void lifegame_change_d9(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_d[8] = !lifegame_para.neighborrule_d[8];
        }

        private void lifegame_change_l1(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[0] = !lifegame_para.neighborrule_l[0];
        }
        private void lifegame_change_l2(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[1] = !lifegame_para.neighborrule_l[1];
        }
        private void lifegame_change_l3(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[2] = !lifegame_para.neighborrule_l[2];
        }
        private void lifegame_change_l4(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[3] = !lifegame_para.neighborrule_l[3];
        }
        private void lifegame_change_l5(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[4] = !lifegame_para.neighborrule_l[4];
        }
        private void lifegame_change_l6(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[5] = !lifegame_para.neighborrule_l[5];
        }
        private void lifegame_change_l7(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[6] = !lifegame_para.neighborrule_l[6];
        }
        private void lifegame_change_l8(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[7] = !lifegame_para.neighborrule_l[7];
        }
        private void lifegame_change_l9(object sender, EventArgs e)
        {
            lifegame_para.neighborrule_l[8] = !lifegame_para.neighborrule_l[8];
        }

        private void ant_change_c1(object sender, EventArgs e)
        {
            main_option_colors.colors[1] = form6.c1.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c2(object sender, EventArgs e)
        {
            main_option_colors.colors[2] = form6.c2.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c3(object sender, EventArgs e)
        {
            main_option_colors.colors[3] = form6.c3.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c4(object sender, EventArgs e)
        {
            main_option_colors.colors[4] = form6.c4.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c5(object sender, EventArgs e)
        {
            main_option_colors.colors[5] = form6.c5.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c6(object sender, EventArgs e)
        {
            main_option_colors.colors[6] = form6.c6.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c7(object sender, EventArgs e)
        {
            main_option_colors.colors[7] = form6.c7.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c8(object sender, EventArgs e)
        {
            main_option_colors.colors[8] = form6.c8.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c9(object sender, EventArgs e)
        {
            main_option_colors.colors[9] = form6.c9.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c10(object sender, EventArgs e)
        {
            main_option_colors.colors[10] = form6.c10.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c11(object sender, EventArgs e)
        {
            main_option_colors.colors[11] = form6.c11.BackColor;
            Automata_draw_front();
        }
        private void ant_change_c12(object sender, EventArgs e)
        {
            main_option_colors.colors[12] = form6.c12.BackColor;
            Automata_draw_front();
        }

        private void ant_change_l1(object sender, EventArgs e)
        {
            form6.l1.Text = form6.l1.Text == "R" ? "L" : "R";
            ant_para.ant_rule[0].RL = form6.l1.Text == "R" ? 0 : 1;
        }
        private void ant_change_l2(object sender, EventArgs e)
        {
            form6.l2.Text = form6.l2.Text == "R" ? "L" : "R";
            ant_para.ant_rule[1].RL = form6.l2.Text == "R" ? 0 : 1;
        }
        private void ant_change_l3(object sender, EventArgs e)
        {
            form6.l3.Text = form6.l3.Text == "R" ? "L" : "R";
            ant_para.ant_rule[2].RL = form6.l3.Text == "R" ? 0 : 1;
        }
        private void ant_change_l4(object sender, EventArgs e)
        {
            form6.l4.Text = form6.l4.Text == "R" ? "L" : "R";
            ant_para.ant_rule[3].RL = form6.l4.Text == "R" ? 0 : 1;
        }
        private void ant_change_l5(object sender, EventArgs e)
        {
            form6.l5.Text = form6.l5.Text == "R" ? "L" : "R";
            ant_para.ant_rule[4].RL = form6.l5.Text == "R" ? 0 : 1;
        }
        private void ant_change_l6(object sender, EventArgs e)
        {
            form6.l6.Text = form6.l6.Text == "R" ? "L" : "R";
            ant_para.ant_rule[5].RL = form6.l6.Text == "R" ? 0 : 1;
        }
        private void ant_change_l7(object sender, EventArgs e)
        {
            form6.l7.Text = form6.l7.Text == "R" ? "L" : "R";
            ant_para.ant_rule[6].RL = form6.l7.Text == "R" ? 0 : 1;
        }
        private void ant_change_l8(object sender, EventArgs e)
        {
            form6.l8.Text = form6.l8.Text == "R" ? "L" : "R";
            ant_para.ant_rule[7].RL = form6.l8.Text == "R" ? 0 : 1;
        }
        private void ant_change_l9(object sender, EventArgs e)
        {
            form6.l9.Text = form6.l9.Text == "R" ? "L" : "R";
            ant_para.ant_rule[8].RL = form6.l9.Text == "R" ? 0 : 1;
        }
        private void ant_change_l10(object sender, EventArgs e)
        {
            form6.l10.Text = form6.l10.Text == "R" ? "L" : "R";
            ant_para.ant_rule[9].RL = form6.l10.Text == "R" ? 0 : 1;
        }
        private void ant_change_l11(object sender, EventArgs e)
        {
            form6.l11.Text = form6.l11.Text == "R" ? "L" : "R";
            ant_para.ant_rule[10].RL = form6.l11.Text == "R" ? 0 : 1;
        }
        private void ant_change_l12(object sender, EventArgs e)
        {
            form6.l12.Text = form6.l12.Text == "R" ? "L" : "R";
            ant_para.ant_rule[11].RL = form6.l12.Text == "R" ? 0 : 1;
        }

        private void ant_colornum_get(object sender, EventArgs e)
        {
            ant_para.antrulenum = form6.ant_colornum-1;
            form5.colornum = ant_para.antrulenum+1;
        }

        private void ant_color_random(object sender, EventArgs e)
        {
            main_option_colors.colors[1] = form6.c1.BackColor;
            main_option_colors.colors[2] = form6.c2.BackColor;
            main_option_colors.colors[3] = form6.c3.BackColor;
            main_option_colors.colors[4] = form6.c4.BackColor;
            main_option_colors.colors[5] = form6.c5.BackColor;
            main_option_colors.colors[6] = form6.c6.BackColor;
            main_option_colors.colors[7] = form6.c7.BackColor;
            main_option_colors.colors[8] = form6.c8.BackColor;
            main_option_colors.colors[9] = form6.c9.BackColor;
            main_option_colors.colors[10] = form6.c10.BackColor;
            main_option_colors.colors[11] = form6.c11.BackColor;
            main_option_colors.colors[12] = form6.c12.BackColor;
            form5.color1 = main_option_colors.colors[1];
            form5.color2 = main_option_colors.colors[2];
            form5.color3 = main_option_colors.colors[3];
            form5.color4 = main_option_colors.colors[4];
            form5.color5 = main_option_colors.colors[5];
            form5.color6 = main_option_colors.colors[6];
            form5.color7 = main_option_colors.colors[7];
            form5.color8 = main_option_colors.colors[8];
            form5.color9 = main_option_colors.colors[9];
            form5.color10 = main_option_colors.colors[10];
            form5.color11 = main_option_colors.colors[11];
            form5.color12 = main_option_colors.colors[12];
        }

        private void ant_direction_random(object sender,EventArgs e)
        {
            ant_para.ant_rule[0].RL = form6.l1.Text == "R" ? 0 : 1;
            ant_para.ant_rule[1].RL = form6.l2.Text == "R" ? 0 : 1;
            ant_para.ant_rule[2].RL = form6.l3.Text == "R" ? 0 : 1;
            ant_para.ant_rule[3].RL = form6.l4.Text == "R" ? 0 : 1;
            ant_para.ant_rule[4].RL = form6.l5.Text == "R" ? 0 : 1;
            ant_para.ant_rule[5].RL = form6.l6.Text == "R" ? 0 : 1;
            ant_para.ant_rule[6].RL = form6.l7.Text == "R" ? 0 : 1;
            ant_para.ant_rule[7].RL = form6.l8.Text == "R" ? 0 : 1;
            ant_para.ant_rule[8].RL = form6.l9.Text == "R" ? 0 : 1;
            ant_para.ant_rule[9].RL = form6.l10.Text == "R" ? 0 : 1;
            ant_para.ant_rule[10].RL = form6.l11.Text == "R" ? 0 : 1;
            ant_para.ant_rule[11].RL = form6.l12.Text == "R" ? 0 : 1;
        }

        //===================================================================================================================================================
        //===================================================================================================================================================
        //===================================================================================================================================================

        #endregion

        #region Automata_moving
        private void automata_change()
        {
            switch (automatonmode)
            {
                case 1:
                    #region lifegame_initialize

                    main_option_colors.colors[0] = Color.FromArgb(255, 0, 0);       //エラーカラー
                    main_option_colors.colors[1] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[2] = Color.FromArgb(0, 255, 0);
                    main_option_colors.colors[3] = Color.FromArgb(0, 190, 0);
                    main_option_colors.colors[4] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[5] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[6] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[7] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[8] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[9] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[10] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[11] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[12] = Color.FromArgb(0, 0, 0);
                    form5.color1 = main_option_colors.colors[1];
                    form5.color2 = main_option_colors.colors[2];
                    form5.color3 = main_option_colors.colors[3];
                    form5.color4 = main_option_colors.colors[4];
                    form5.color5 = main_option_colors.colors[5];
                    form5.color6 = main_option_colors.colors[6];
                    form5.color7 = main_option_colors.colors[7];
                    form5.color8 = main_option_colors.colors[8];
                    form5.color9 = main_option_colors.colors[9];
                    form5.color10 = main_option_colors.colors[10];
                    form5.color11 = main_option_colors.colors[11];
                    form5.color12 = main_option_colors.colors[12];
                    form5.colornum = 2;

                    for (int i = 0; i < bitboard_max_width + 1; i++)
                    {
                        for (int j = 0; j < bitboard_max_height + 1; j++)
                        {
                            lifegame_para.bitboardproto[i, j] = false;
                        }
                    }
                    for (int i = 0; i < bitboard_max_width + 1; i++)
                    {
                        for (int j = 0; j < bitboard_max_height + 1; j++)
                        {
                            lifegame_para.bitboardprotobuffer[i, j] = false;
                        }
                    }

                    form6.lifegame_change_d(false,false,false,true,false,false,false,false,false);
                    form6.lifegame_change_l(false, false, true, true, false, false, false, false, false);

                    lifegame_para.neighborrule_d[0] = form6.checkBox1.Checked;
                    lifegame_para.neighborrule_d[1] = form6.checkBox2.Checked;
                    lifegame_para.neighborrule_d[2] = form6.checkBox3.Checked;
                    lifegame_para.neighborrule_d[3] = form6.checkBox4.Checked;
                    lifegame_para.neighborrule_d[4] = form6.checkBox5.Checked;
                    lifegame_para.neighborrule_d[5] = form6.checkBox6.Checked;
                    lifegame_para.neighborrule_d[6] = form6.checkBox7.Checked;
                    lifegame_para.neighborrule_d[7] = form6.checkBox8.Checked;
                    lifegame_para.neighborrule_d[8] = form6.checkBox9.Checked;

                    lifegame_para.neighborrule_l[0] = form6.checkBox10.Checked;
                    lifegame_para.neighborrule_l[1] = form6.checkBox11.Checked;
                    lifegame_para.neighborrule_l[2] = form6.checkBox12.Checked;
                    lifegame_para.neighborrule_l[3] = form6.checkBox13.Checked;
                    lifegame_para.neighborrule_l[4] = form6.checkBox14.Checked;
                    lifegame_para.neighborrule_l[5] = form6.checkBox15.Checked;
                    lifegame_para.neighborrule_l[6] = form6.checkBox16.Checked;
                    lifegame_para.neighborrule_l[7] = form6.checkBox17.Checked;
                    lifegame_para.neighborrule_l[8] = form6.checkBox18.Checked;

                    #endregion
                    break;
                case 2:
                    #region ant_initialize
                    main_option_colors.colors[0] = Color.FromArgb(255, 0, 0);       //エラーカラー
                    main_option_colors.colors[1] = Color.FromArgb(255, 255, 255);
                    main_option_colors.colors[2] = Color.FromArgb(255, 0, 0);
                    main_option_colors.colors[3] = Color.FromArgb(0, 255, 0);
                    main_option_colors.colors[4] = Color.FromArgb(0, 0, 255);
                    main_option_colors.colors[5] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[6] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[7] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[8] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[9] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[10] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[11] = Color.FromArgb(0, 0, 0);
                    main_option_colors.colors[12] = Color.FromArgb(0, 0, 0);
                    form5.color1 = main_option_colors.colors[1];
                    form5.color2 = main_option_colors.colors[2];
                    form5.color3 = main_option_colors.colors[3];
                    form5.color4 = main_option_colors.colors[4];
                    form5.color5 = main_option_colors.colors[5];
                    form5.color6 = main_option_colors.colors[6];
                    form5.color7 = main_option_colors.colors[7];
                    form5.color8 = main_option_colors.colors[8];
                    form5.color9 = main_option_colors.colors[9];
                    form5.color10 = main_option_colors.colors[10];
                    form5.color11 = main_option_colors.colors[11];
                    form5.color12 = main_option_colors.colors[12];
                    form5.colornum = 4;                                     //とりあえず
                    form6.c1.BackColor = main_option_colors.colors[1];
                    form6.c2.BackColor = main_option_colors.colors[2];
                    form6.c3.BackColor = main_option_colors.colors[3];
                    form6.c4.BackColor = main_option_colors.colors[4];
                    form6.c5.BackColor = main_option_colors.colors[5];
                    form6.c6.BackColor = main_option_colors.colors[6];
                    form6.c7.BackColor = main_option_colors.colors[7];
                    form6.c8.BackColor = main_option_colors.colors[8];
                    form6.c9.BackColor = main_option_colors.colors[9];
                    form6.c10.BackColor = main_option_colors.colors[10];
                    form6.c11.BackColor = main_option_colors.colors[11];
                    form6.c12.BackColor = main_option_colors.colors[12];
                    form6.ant_colornum = 4;

                    main_option_colors.subuse = Color.FromArgb(0, 0, 0);    //中心点

                    for (int i = 0; i < bitboard_max_width; i++)
                    {
                        for (int j = 0; j < bitboard_max_height; j++)
                        {
                            ant_para.ant_board[i, j] = 0;           //背景は0
                        }
                    }

                    ant_para.antrulenum = 3;                        //背景以外の数

                    for (int x = 0; x <= 11; x++)
                    {
                        ant_para.ant_rule[x].num = x;
                        ant_para.ant_rule[x].color = x + 1;
                    }

                    ant_para.ant_rule[0].RL = 0;
                    ant_para.ant_rule[1].RL = 1;
                    ant_para.ant_rule[2].RL = 0;
                    ant_para.ant_rule[3].RL = 1;
                    ant_para.ant_rule[4].RL = 0;
                    ant_para.ant_rule[5].RL = 0;
                    ant_para.ant_rule[6].RL = 0;
                    ant_para.ant_rule[7].RL = 0;
                    ant_para.ant_rule[8].RL = 0;
                    ant_para.ant_rule[9].RL = 0;
                    ant_para.ant_rule[10].RL = 0;
                    ant_para.ant_rule[11].RL = 0;
                    ant_para.ant_rule[12].RL = 0;

                    ant_para.ant_direction = 1;
                    ant_para.ant_x = cells_width / 2;
                    ant_para.ant_y = cells_height / 2;

                    form5.label1 = cells_width * cells_height;
                    form5.label2 = 0;
                    form5.label3 = 0;
                    form5.label4 = 0;
                    form5.label5 = 0;
                    form5.label6 = 0;
                    form5.label7 = 0;
                    form5.label8 = 0;
                    form5.label9 = 0;
                    form5.label10 = 0;
                    form5.label11 = 0;
                    form5.label12 = 0;

                    form6.l1.Text = "R";
                    form6.l2.Text = "L";
                    form6.l3.Text = "R";
                    form6.l4.Text = "L";
                    form6.l5.Text = "R";
                    form6.l6.Text = "R";
                    form6.l7.Text = "R";
                    form6.l8.Text = "R";
                    form6.l9.Text = "R";
                    form6.l10.Text = "R";
                    form6.l11.Text = "R";
                    form6.l12.Text = "R";

                    #endregion
                    break;
            }
            form6.automata_change(automatonmode);
            Automata_draw_back();
            Automata_draw_front();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int s = 0; s <= skipf; s++)
            {
                Automata_running();
            }
            Automata_draw_back();
            Automata_draw_front();
        }

        private void Automata_running()
        {
            switch (automatonmode)
            {
                case 1:
                    lifegame_running_proto1();
                    break;
                case 2:
                    ant_running();
                    break;
            }
            generation++;
        }

        private void Automata_draw_back()
        {
            switch (automatonmode)
            {
                case 1:
                    Fixsize_Redraw_back();
                    break;
                case 2:
                    //Ant_Redraw_back();
                    break;
            }
        }

        private void Automata_draw_front()
        {
            switch (automatonmode)
            {
                case 1:
                    Cell_Redraw();
                    break;
                case 2:
                    Ant_Redraw();
                    break;
            }
            form5.geneparam = generation;
        }

    #endregion

        #region lifegame_running
        private void lifegame_running_proto1()                  //ライフゲームメインループ
        {
            form5._label2 = 0;
            if (main_option_para_st.unEuclidian)        //非ユークリッド幾何学空間  画面端ループ
            {
                lifegame_para.bitboardproto[0, 0] = lifegame_para.bitboardproto[cells_width, cells_height];
                lifegame_para.bitboardproto[cells_width + 1, cells_height + 1] = lifegame_para.bitboardproto[1, 1];
                lifegame_para.bitboardproto[0, cells_height + 1] = lifegame_para.bitboardproto[cells_width, 1];
                lifegame_para.bitboardproto[cells_width + 1, 0] = lifegame_para.bitboardproto[1, cells_height];
                for (int x = 1; x <= cells_width; x++)
                {
                    lifegame_para.bitboardproto[x, 0] = lifegame_para.bitboardproto[x, cells_height];
                    lifegame_para.bitboardproto[x, cells_height + 1] = lifegame_para.bitboardproto[x, 1];
                }
                for (int y = 1; y <= cells_width; y++)
                {
                    lifegame_para.bitboardproto[0, y] = lifegame_para.bitboardproto[cells_width, y];
                    lifegame_para.bitboardproto[cells_width + 1, y] = lifegame_para.bitboardproto[1, y];
                }
            }
            for (int x = 1; x <= cells_width; x++)
            {
                for (int y = 1; y <= cells_height; y++)
                {
                    lifegame_para.neighbor = 0;
                    for (int i = 1; i <= 3; i++)
                    {
                        for (int j = 1; j <= 3; j++)
                        {
                            //lifegame_para.neighbor += 1 * lifegame_para.bitboardproto[x + i, y + j];
                            if ((i != 2) | (j != 2))
                            {
                                lifegame_para.neighbor = lifegame_para.bitboardproto[x + i-2, y + j-2] ? lifegame_para.neighbor + 1 : lifegame_para.neighbor;    //三項演算子使いたかっただけ
                            }
                        }
                    }
                    lifegame_para.bitboardprotobuffer[x, y] = lifegame_para.bitboardproto[x, y] ? lifegame_para.neighborrule_l[lifegame_para.neighbor] : lifegame_para.neighborrule_d[lifegame_para.neighbor];
                    form5.label2 = lifegame_para.bitboardprotobuffer[x, y] ? form5.label2 +1 : form5.label2;
                }
            }
            for (int x = 1; x <= cells_width; x++)
            {
                for (int y = 1; y <= cells_height; y++)
                {
                    lifegame_para.bitboardproto[x, y] = lifegame_para.bitboardprotobuffer[x, y];
                    lifegame_para.bitboardprotobuffer[x, y] = false;
                }
            }
            form5.label1 = (cells_width * cells_height) - form5.label2;
        }

        #endregion

        #region Langton's Ant_running

        private void ant_count()
        {
            form5.label1 = 0;
            form5.label2 = 0;
            form5.label3 = 0;
            form5.label4 = 0;
            form5.label5 = 0;
            form5.label6 = 0;
            form5.label7 = 0;
            form5.label8 = 0;
            form5.label9 = 0;
            form5.label10 = 0;
            form5.label11 = 0;
            form5.label12 = 0;
            for (int x = 1; x <= cells_width; x++)
            {
                for (int y = 1; y <= cells_height; y++)
                {
                    switch (ant_para.ant_board[x, y])
                    {
                        case 0:
                            form5.label1 += 1;
                            break;
                        case 1:
                            form5.label2 += 1;
                            break;
                        case 2:
                            form5.label3 += 1;
                            break;
                        case 3:
                            form5.label4 += 1;
                            break;
                        case 4:
                            form5.label5 += 1;
                            break;
                        case 5:
                            form5.label6 += 1;
                            break;
                        case 6:
                            form5.label7 += 1;
                            break;
                        case 7:
                            form5.label8 += 1;
                            break;
                        case 8:
                            form5.label9 += 1;
                            break;
                        case 9:
                            form5.label10 += 1;
                            break;
                        case 10:
                            form5.label11 += 1;
                            break;
                        case 11:
                            form5.label12 += 1;
                            break;
                        /*case 12:
                            form5.label1 += 1;
                            break;*/
                    }
                }
            }
            ant_para.ant_max = 0;
            for (int i = 0; i <= 11; i++)
            {
                switch (i)
                {
                    case 0:
                        ant_para.ant_max = form5.label1;
                        ant_para.ant_max_C = 1;
                        break;
                    case 1:
                        ant_para.ant_max = ant_para.ant_max >= form5.label2 ? ant_para.ant_max : form5.label2;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label2 ? ant_para.ant_max_C : 2;
                        break;
                    case 2:
                        ant_para.ant_max = ant_para.ant_max >= form5.label3 ? ant_para.ant_max : form5.label3;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label3 ? ant_para.ant_max_C : 3;
                        break;
                    case 3:
                        ant_para.ant_max = ant_para.ant_max >= form5.label4 ? ant_para.ant_max : form5.label4;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label4 ? ant_para.ant_max_C : 4;
                        break;
                    case 4:
                        ant_para.ant_max = ant_para.ant_max >= form5.label5 ? ant_para.ant_max : form5.label5;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label5 ? ant_para.ant_max_C : 5;
                        break;
                    case 5:
                        ant_para.ant_max = ant_para.ant_max >= form5.label6 ? ant_para.ant_max : form5.label6;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label6 ? ant_para.ant_max_C : 6;
                        break;
                    case 6:
                        ant_para.ant_max = ant_para.ant_max >= form5.label7 ? ant_para.ant_max : form5.label7;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label7 ? ant_para.ant_max_C : 7;
                        break;
                    case 7:
                        ant_para.ant_max = ant_para.ant_max >= form5.label8 ? ant_para.ant_max : form5.label8;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label8 ? ant_para.ant_max_C : 8;
                        break;
                    case 8:
                        ant_para.ant_max = ant_para.ant_max >= form5.label9 ? ant_para.ant_max : form5.label9;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label9 ? ant_para.ant_max_C : 9;
                        break;
                    case 9:
                        ant_para.ant_max = ant_para.ant_max >= form5.label10 ? ant_para.ant_max : form5.label10;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label10 ? ant_para.ant_max_C : 10;
                        break;
                    case 10:
                        ant_para.ant_max = ant_para.ant_max >= form5.label11 ? ant_para.ant_max : form5.label11;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label11 ? ant_para.ant_max_C : 11;
                        break;
                    case 11:
                        ant_para.ant_max = ant_para.ant_max >= form5.label12 ? ant_para.ant_max : form5.label12;
                        ant_para.ant_max_C = ant_para.ant_max >= form5.label12 ? ant_para.ant_max_C : 12;
                        break;
                }
            }
        }

        private void ant_running()
        {
            switch(ant_para.ant_rule[ant_para.ant_board[ant_para.ant_x,ant_para.ant_y]].RL + ant_para.ant_direction)
            {
                case 1:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 5;
                    ant_para.ant_x += 1;
                    break;
                case 2:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 7;
                    ant_para.ant_x -= 1;
                    break;
                case 3:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 7;
                    ant_para.ant_x -= 1;
                    break;
                case 4:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 5;
                    ant_para.ant_x += 1;
                    break;
                case 5:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 3;
                    ant_para.ant_y += 1;
                    break;
                case 6:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 1;
                    ant_para.ant_y -= 1;
                    break;
                case 7:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 1;
                    ant_para.ant_y -= 1;
                    break;
                case 8:
                    ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] = (ant_para.ant_board[ant_para.ant_x, ant_para.ant_y] + 1) % (ant_para.antrulenum + 1);
                    ant_para.ant_direction = 3;
                    ant_para.ant_y += 1;
                    break;
            }
        }

        #endregion



        #region CSV read

        /// <summary>
        /// CSVをArrayListに変換
        /// </summary>
        /// <param name="csvText">CSVの内容が入ったString</param>
        /// <returns>変換結果のArrayList</returns>
        public static System.Collections.ArrayList CsvToArrayList2(string csvText)
        {
            //前後の改行を削除しておく
            csvText = csvText.Trim(new char[] { '\r', '\n' });

            System.Collections.ArrayList csvRecords =
                new System.Collections.ArrayList();
            System.Collections.ArrayList csvFields =
                new System.Collections.ArrayList();

            int csvTextLength = csvText.Length;
            int startPos = 0, endPos = 0;
            string field = "";

            while (true)
            {
                //空白を飛ばす
                while (startPos < csvTextLength &&
                    (csvText[startPos] == ' ' || csvText[startPos] == '\t'))
                {
                    startPos++;
                }

                //データの最後の位置を取得
                if (startPos < csvTextLength && csvText[startPos] == '"')
                {
                    //"で囲まれているとき
                    //最後の"を探す
                    endPos = startPos;
                    while (true)
                    {
                        endPos = csvText.IndexOf('"', endPos + 1);
                        if (endPos < 0)
                        {
                            throw new ApplicationException("\"が不正");
                        }
                        //"が2つ続かない時は終了
                        if (endPos + 1 == csvTextLength || csvText[endPos + 1] != '"')
                        {
                            break;
                        }
                        //"が2つ続く
                        endPos++;
                    }

                    //一つのフィールドを取り出す
                    field = csvText.Substring(startPos, endPos - startPos + 1);
                    //""を"にする
                    field = field.Substring(1, field.Length - 2).Replace("\"\"", "\"");

                    endPos++;
                    //空白を飛ばす
                    while (endPos < csvTextLength &&
                        csvText[endPos] != ',' && csvText[endPos] != '\n')
                    {
                        endPos++;
                    }
                }
                else
                {
                    //"で囲まれていない
                    //カンマか改行の位置
                    endPos = startPos;
                    while (endPos < csvTextLength &&
                        csvText[endPos] != ',' && csvText[endPos] != '\n')
                    {
                        endPos++;
                    }

                    //一つのフィールドを取り出す
                    field = csvText.Substring(startPos, endPos - startPos);
                    //後の空白を削除
                    field = field.TrimEnd();
                }

                //フィールドの追加
                csvFields.Add(field);

                //行の終了か調べる
                if (endPos >= csvTextLength || csvText[endPos] == '\n')
                {
                    //行の終了
                    //レコードの追加
                    csvFields.TrimToSize();
                    csvRecords.Add(csvFields);
                    csvFields = new System.Collections.ArrayList(
                        csvFields.Count);

                    if (endPos >= csvTextLength)
                    {
                        //終了
                        break;
                    }
                }

                //次のデータの開始位置
                startPos = endPos + 1;
            }

            csvRecords.TrimToSize();
            return csvRecords;
        }

        #endregion

        #region CSV write

        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">CSVに変換するDataTable</param>
        /// <param name="csvPath">保存先のCSVファイルのパス</param>
        /// <param name="writeHeader">ヘッダを書き込む時はtrue。</param>
        public void ConvertDataTableToCsv(
            DataTable dt, string csvPath, bool writeHeader)
        {
            //CSVファイルに書き込むときに使うEncoding
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("Shift_JIS");

            //書き込むファイルを開く
            System.IO.StreamWriter sr =
                new System.IO.StreamWriter(csvPath, false, enc);

            int colCount = dt.Columns.Count;
            int lastColIndex = colCount - 1;

            //ヘッダを書き込む
            if (writeHeader)
            {
                for (int i = 0; i < colCount; i++)
                {
                    //ヘッダの取得
                    string field = dt.Columns[i].Caption;
                    //"で囲む
                    field = EncloseDoubleQuotesIfNeed(field);
                    //フィールドを書き込む
                    sr.Write(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sr.Write(',');
                    }
                }
                //改行する
                sr.Write("\r\n");
            }

            //レコードを書き込む
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < colCount; i++)
                {
                    //フィールドの取得
                    string field = row[i].ToString();
                    //"で囲む
                    field = EncloseDoubleQuotesIfNeed(field);
                    //フィールドを書き込む
                    sr.Write(field);
                    //カンマを書き込む
                    if (lastColIndex > i)
                    {
                        sr.Write(',');
                    }
                }
                //改行する
                sr.Write("\r\n");
            }

            //閉じる
            sr.Close();
        }

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        private bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }
    
        #endregion

    }
}
