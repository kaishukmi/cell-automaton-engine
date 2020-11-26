namespace CellAutomatonEngine
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.初期化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.読み込みToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.書き出しToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名前を付けて保存AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.実行設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ライフゲームコントローラToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.セルの量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モニターウィンドウToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ルールウィンドウToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.オートマトンの選択ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conwaysGameOfLifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langtonsAntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vonNeumannUniversalConstructerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coddsCellularAutomatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langtonsLoopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wirewarldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementaryCellularAutomatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表示オプションToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.罫線の表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常に最前面表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ウィンドウサイズToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.横に合わせてサイズ変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.色の変更ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.オプションToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.オートマトンオプションToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.非ユークリッド幾何学空間ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ムーア近傍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ノイマン近傍ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.実行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.編集EToolStripMenuItem,
            this.表示VToolStripMenuItem,
            this.オプションToolStripMenuItem,
            this.実行ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初期化ToolStripMenuItem,
            this.toolStripSeparator1,
            this.読み込みToolStripMenuItem,
            this.書き出しToolStripMenuItem,
            this.名前を付けて保存AToolStripMenuItem,
            this.toolStripMenuItem1,
            this.終了ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ファイルToolStripMenuItem.ShowShortcutKeys = false;
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.ファイルToolStripMenuItem.Text = "ファイル(F)";
            // 
            // 初期化ToolStripMenuItem
            // 
            this.初期化ToolStripMenuItem.Name = "初期化ToolStripMenuItem";
            this.初期化ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.初期化ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.初期化ToolStripMenuItem.Text = "初期化(N)";
            this.初期化ToolStripMenuItem.Click += new System.EventHandler(this.初期化ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // 読み込みToolStripMenuItem
            // 
            this.読み込みToolStripMenuItem.Name = "読み込みToolStripMenuItem";
            this.読み込みToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.読み込みToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.読み込みToolStripMenuItem.Text = "読み込み(O)...";
            // 
            // 書き出しToolStripMenuItem
            // 
            this.書き出しToolStripMenuItem.Name = "書き出しToolStripMenuItem";
            this.書き出しToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.書き出しToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.書き出しToolStripMenuItem.Text = "上書き保存(S)...";
            // 
            // 名前を付けて保存AToolStripMenuItem
            // 
            this.名前を付けて保存AToolStripMenuItem.Name = "名前を付けて保存AToolStripMenuItem";
            this.名前を付けて保存AToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.名前を付けて保存AToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.名前を付けて保存AToolStripMenuItem.Text = "名前を付けて保存(A)...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.終了ToolStripMenuItem.Text = "終了(X)";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 編集EToolStripMenuItem
            // 
            this.編集EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.実行設定ToolStripMenuItem,
            this.ライフゲームコントローラToolStripMenuItem,
            this.セルの量ToolStripMenuItem,
            this.モニターウィンドウToolStripMenuItem,
            this.ルールウィンドウToolStripMenuItem,
            this.toolStripSeparator2,
            this.オートマトンの選択ToolStripMenuItem});
            this.編集EToolStripMenuItem.Name = "編集EToolStripMenuItem";
            this.編集EToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.編集EToolStripMenuItem.ShowShortcutKeys = false;
            this.編集EToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.編集EToolStripMenuItem.Text = "編集(E)";
            // 
            // 実行設定ToolStripMenuItem
            // 
            this.実行設定ToolStripMenuItem.Name = "実行設定ToolStripMenuItem";
            this.実行設定ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.実行設定ToolStripMenuItem.Text = "実行コントローラ...";
            this.実行設定ToolStripMenuItem.Click += new System.EventHandler(this.実行設定ToolStripMenuItem_Click);
            // 
            // ライフゲームコントローラToolStripMenuItem
            // 
            this.ライフゲームコントローラToolStripMenuItem.Name = "ライフゲームコントローラToolStripMenuItem";
            this.ライフゲームコントローラToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ライフゲームコントローラToolStripMenuItem.Text = "セルコントローラ...";
            this.ライフゲームコントローラToolStripMenuItem.Click += new System.EventHandler(this.ライフゲームコントローラToolStripMenuItem_Click);
            // 
            // セルの量ToolStripMenuItem
            // 
            this.セルの量ToolStripMenuItem.Name = "セルの量ToolStripMenuItem";
            this.セルの量ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.セルの量ToolStripMenuItem.Text = "セルの広さウィンドウ...";
            this.セルの量ToolStripMenuItem.Click += new System.EventHandler(this.セルの量ToolStripMenuItem_Click);
            // 
            // モニターウィンドウToolStripMenuItem
            // 
            this.モニターウィンドウToolStripMenuItem.Name = "モニターウィンドウToolStripMenuItem";
            this.モニターウィンドウToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.モニターウィンドウToolStripMenuItem.Text = "モニターウィンドウ...";
            this.モニターウィンドウToolStripMenuItem.Click += new System.EventHandler(this.モニターウィンドウToolStripMenuItem_Click);
            // 
            // ルールウィンドウToolStripMenuItem
            // 
            this.ルールウィンドウToolStripMenuItem.Name = "ルールウィンドウToolStripMenuItem";
            this.ルールウィンドウToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.ルールウィンドウToolStripMenuItem.Text = "ルールウィンドウ...";
            this.ルールウィンドウToolStripMenuItem.Click += new System.EventHandler(this.ルールウィンドウToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // オートマトンの選択ToolStripMenuItem
            // 
            this.オートマトンの選択ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conwaysGameOfLifeToolStripMenuItem,
            this.langtonsAntToolStripMenuItem,
            this.vonNeumannUniversalConstructerToolStripMenuItem,
            this.coddsCellularAutomatonToolStripMenuItem,
            this.langtonsLoopToolStripMenuItem,
            this.wirewarldToolStripMenuItem,
            this.elementaryCellularAutomatonToolStripMenuItem});
            this.オートマトンの選択ToolStripMenuItem.Name = "オートマトンの選択ToolStripMenuItem";
            this.オートマトンの選択ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.オートマトンの選択ToolStripMenuItem.Text = "オートマトンの選択";
            // 
            // conwaysGameOfLifeToolStripMenuItem
            // 
            this.conwaysGameOfLifeToolStripMenuItem.Checked = true;
            this.conwaysGameOfLifeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.conwaysGameOfLifeToolStripMenuItem.Name = "conwaysGameOfLifeToolStripMenuItem";
            this.conwaysGameOfLifeToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.conwaysGameOfLifeToolStripMenuItem.Text = "Conway\'s Game of Life";
            this.conwaysGameOfLifeToolStripMenuItem.Click += new System.EventHandler(this.conwaysGameOfLifeToolStripMenuItem_Click);
            // 
            // langtonsAntToolStripMenuItem
            // 
            this.langtonsAntToolStripMenuItem.Name = "langtonsAntToolStripMenuItem";
            this.langtonsAntToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.langtonsAntToolStripMenuItem.Text = "Langton\'s ant";
            this.langtonsAntToolStripMenuItem.Click += new System.EventHandler(this.langtonsAntToolStripMenuItem_Click);
            // 
            // vonNeumannUniversalConstructerToolStripMenuItem
            // 
            this.vonNeumannUniversalConstructerToolStripMenuItem.Name = "vonNeumannUniversalConstructerToolStripMenuItem";
            this.vonNeumannUniversalConstructerToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.vonNeumannUniversalConstructerToolStripMenuItem.Text = "Von Neumann Universal Constructer";
            this.vonNeumannUniversalConstructerToolStripMenuItem.Click += new System.EventHandler(this.vonNeumannUniversalConstructerToolStripMenuItem_Click);
            // 
            // coddsCellularAutomatonToolStripMenuItem
            // 
            this.coddsCellularAutomatonToolStripMenuItem.Name = "coddsCellularAutomatonToolStripMenuItem";
            this.coddsCellularAutomatonToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.coddsCellularAutomatonToolStripMenuItem.Text = "Codd\'s cellular automaton";
            this.coddsCellularAutomatonToolStripMenuItem.Click += new System.EventHandler(this.coddsCellularAutomatonToolStripMenuItem_Click);
            // 
            // langtonsLoopToolStripMenuItem
            // 
            this.langtonsLoopToolStripMenuItem.Name = "langtonsLoopToolStripMenuItem";
            this.langtonsLoopToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.langtonsLoopToolStripMenuItem.Text = "Langton\'s Loop";
            this.langtonsLoopToolStripMenuItem.Click += new System.EventHandler(this.langtonsLoopToolStripMenuItem_Click);
            // 
            // wirewarldToolStripMenuItem
            // 
            this.wirewarldToolStripMenuItem.Name = "wirewarldToolStripMenuItem";
            this.wirewarldToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.wirewarldToolStripMenuItem.Text = "Wirewarld";
            this.wirewarldToolStripMenuItem.Click += new System.EventHandler(this.wirewarldToolStripMenuItem_Click);
            // 
            // elementaryCellularAutomatonToolStripMenuItem
            // 
            this.elementaryCellularAutomatonToolStripMenuItem.Name = "elementaryCellularAutomatonToolStripMenuItem";
            this.elementaryCellularAutomatonToolStripMenuItem.Size = new System.Drawing.Size(287, 22);
            this.elementaryCellularAutomatonToolStripMenuItem.Text = "Elementary cellular automaton";
            this.elementaryCellularAutomatonToolStripMenuItem.Click += new System.EventHandler(this.elementaryCellularAutomatonToolStripMenuItem_Click);
            // 
            // 表示VToolStripMenuItem
            // 
            this.表示VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.表示オプションToolStripMenuItem,
            this.ウィンドウサイズToolStripMenuItem,
            this.色の変更ToolStripMenuItem});
            this.表示VToolStripMenuItem.Name = "表示VToolStripMenuItem";
            this.表示VToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.表示VToolStripMenuItem.ShowShortcutKeys = false;
            this.表示VToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.表示VToolStripMenuItem.Text = "表示(V)";
            // 
            // 表示オプションToolStripMenuItem
            // 
            this.表示オプションToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.罫線の表示ToolStripMenuItem,
            this.常に最前面表示ToolStripMenuItem});
            this.表示オプションToolStripMenuItem.Name = "表示オプションToolStripMenuItem";
            this.表示オプションToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.表示オプションToolStripMenuItem.Text = "表示オプション";
            // 
            // 罫線の表示ToolStripMenuItem
            // 
            this.罫線の表示ToolStripMenuItem.Checked = true;
            this.罫線の表示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.罫線の表示ToolStripMenuItem.Name = "罫線の表示ToolStripMenuItem";
            this.罫線の表示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.罫線の表示ToolStripMenuItem.Text = "罫線の表示";
            this.罫線の表示ToolStripMenuItem.Click += new System.EventHandler(this.罫線の表示ToolStripMenuItem_Click);
            // 
            // 常に最前面表示ToolStripMenuItem
            // 
            this.常に最前面表示ToolStripMenuItem.Checked = true;
            this.常に最前面表示ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.常に最前面表示ToolStripMenuItem.Name = "常に最前面表示ToolStripMenuItem";
            this.常に最前面表示ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.常に最前面表示ToolStripMenuItem.Text = "常に最前面表示";
            this.常に最前面表示ToolStripMenuItem.Click += new System.EventHandler(this.常に最前面表示ToolStripMenuItem_Click);
            // 
            // ウィンドウサイズToolStripMenuItem
            // 
            this.ウィンドウサイズToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem,
            this.横に合わせてサイズ変更ToolStripMenuItem});
            this.ウィンドウサイズToolStripMenuItem.Name = "ウィンドウサイズToolStripMenuItem";
            this.ウィンドウサイズToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ウィンドウサイズToolStripMenuItem.Text = "ウィンドウサイズ";
            this.ウィンドウサイズToolStripMenuItem.Click += new System.EventHandler(this.ウィンドウサイズToolStripMenuItem_Click);
            // 
            // 縦のセルに合わせてサイズ変更ToolStripMenuItem
            // 
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem.Name = "縦のセルに合わせてサイズ変更ToolStripMenuItem";
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem.Text = "縦合わせてサイズ変更";
            this.縦のセルに合わせてサイズ変更ToolStripMenuItem.Click += new System.EventHandler(this.縦のセルに合わせてサイズ変更ToolStripMenuItem_Click);
            // 
            // 横に合わせてサイズ変更ToolStripMenuItem
            // 
            this.横に合わせてサイズ変更ToolStripMenuItem.Name = "横に合わせてサイズ変更ToolStripMenuItem";
            this.横に合わせてサイズ変更ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.横に合わせてサイズ変更ToolStripMenuItem.Text = "横に合わせてサイズ変更";
            this.横に合わせてサイズ変更ToolStripMenuItem.Click += new System.EventHandler(this.横に合わせてサイズ変更ToolStripMenuItem_Click);
            // 
            // 色の変更ToolStripMenuItem
            // 
            this.色の変更ToolStripMenuItem.Name = "色の変更ToolStripMenuItem";
            this.色の変更ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.色の変更ToolStripMenuItem.Text = "色の変更...";
            // 
            // オプションToolStripMenuItem
            // 
            this.オプションToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.オートマトンオプションToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.オプションToolStripMenuItem.Name = "オプションToolStripMenuItem";
            this.オプションToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.オプションToolStripMenuItem.ShowShortcutKeys = false;
            this.オプションToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.オプションToolStripMenuItem.Text = "オプション(O)";
            // 
            // オートマトンオプションToolStripMenuItem
            // 
            this.オートマトンオプションToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.非ユークリッド幾何学空間ToolStripMenuItem,
            this.ムーア近傍ToolStripMenuItem,
            this.ノイマン近傍ToolStripMenuItem});
            this.オートマトンオプションToolStripMenuItem.Name = "オートマトンオプションToolStripMenuItem";
            this.オートマトンオプションToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.オートマトンオプションToolStripMenuItem.Text = "オートマトンオプション";
            // 
            // 非ユークリッド幾何学空間ToolStripMenuItem
            // 
            this.非ユークリッド幾何学空間ToolStripMenuItem.Checked = true;
            this.非ユークリッド幾何学空間ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.非ユークリッド幾何学空間ToolStripMenuItem.Name = "非ユークリッド幾何学空間ToolStripMenuItem";
            this.非ユークリッド幾何学空間ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.非ユークリッド幾何学空間ToolStripMenuItem.Text = "トーラス状セル・オートマトン";
            this.非ユークリッド幾何学空間ToolStripMenuItem.Click += new System.EventHandler(this.非ユークリッド幾何学空間ToolStripMenuItem_Click_1);
            // 
            // ムーア近傍ToolStripMenuItem
            // 
            this.ムーア近傍ToolStripMenuItem.Checked = true;
            this.ムーア近傍ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ムーア近傍ToolStripMenuItem.Name = "ムーア近傍ToolStripMenuItem";
            this.ムーア近傍ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.ムーア近傍ToolStripMenuItem.Text = "ムーア近傍";
            this.ムーア近傍ToolStripMenuItem.Click += new System.EventHandler(this.ムーア近傍ToolStripMenuItem_Click);
            // 
            // ノイマン近傍ToolStripMenuItem
            // 
            this.ノイマン近傍ToolStripMenuItem.Name = "ノイマン近傍ToolStripMenuItem";
            this.ノイマン近傍ToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.ノイマン近傍ToolStripMenuItem.Text = "ノイマン近傍";
            this.ノイマン近傍ToolStripMenuItem.Click += new System.EventHandler(this.ノイマン近傍ToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.aboutToolStripMenuItem.Text = "about...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // 実行ToolStripMenuItem
            // 
            this.実行ToolStripMenuItem.Name = "実行ToolStripMenuItem";
            this.実行ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.実行ToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.実行ToolStripMenuItem.Text = "実行(F5)";
            this.実行ToolStripMenuItem.Click += new System.EventHandler(this.実行ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(603, 357);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 627);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CellAutomatonEngine - Conway\'s Game of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 読み込みToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 書き出しToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem オートマトンの選択ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示VToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名前を付けて保存AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem オプションToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem オートマトンオプションToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 非ユークリッド幾何学空間ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ムーア近傍ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ノイマン近傍ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem conwaysGameOfLifeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langtonsAntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 実行設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem セルの量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ウィンドウサイズToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 実行ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 初期化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem vonNeumannUniversalConstructerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coddsCellularAutomatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem langtonsLoopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wirewarldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表示オプションToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 罫線の表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 色の変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 縦のセルに合わせてサイズ変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 横に合わせてサイズ変更ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem モニターウィンドウToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 常に最前面表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ライフゲームコントローラToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ルールウィンドウToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementaryCellularAutomatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

