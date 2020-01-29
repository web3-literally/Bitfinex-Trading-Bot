namespace CDSBot
{
    partial class MainUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridOrder = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvgPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridPosition = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSwap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApiPublicKey = new System.Windows.Forms.TextBox();
            this.txtApiSecretKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gridWallet = new System.Windows.Forms.DataGridView();
            this.colCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboTicker = new System.Windows.Forms.ComboBox();
            this.spinOrderCount = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.spinAmount = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.spinMinSize = new System.Windows.Forms.NumericUpDown();
            this.spinCoefficient = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboDistribution = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.spinUpperPrice = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.spinLowerPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.spinDistance = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.spinProfitPercent = new System.Windows.Forms.NumericUpDown();
            this.radioProfitPercent = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.spinProfitTarget = new System.Windows.Forms.NumericUpDown();
            this.radioProfitTarget = new System.Windows.Forms.RadioButton();
            this.spinFee = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreviewOrders = new System.Windows.Forms.Button();
            this.btnPlaceOrders = new System.Windows.Forms.Button();
            this.btnDeleteOrders = new System.Windows.Forms.Button();
            this.btnBreakAllLoops = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.textPreview = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWallet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinOrderCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCoefficient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUpperPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLowerPrice)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProfitPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProfitTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFee)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridOrder
            // 
            this.gridOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSymbol,
            this.colType,
            this.Status,
            this.colPrice,
            this.colAvgPrice,
            this.colRemainAmount,
            this.colOriginAmount,
            this.colTime,
            this.Column1});
            this.gridOrder.Location = new System.Drawing.Point(235, 405);
            this.gridOrder.Name = "gridOrder";
            this.gridOrder.RowHeadersVisible = false;
            this.gridOrder.Size = new System.Drawing.Size(892, 168);
            this.gridOrder.TabIndex = 1;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colSymbol
            // 
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            this.colSymbol.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colAvgPrice
            // 
            this.colAvgPrice.HeaderText = "Avg Price";
            this.colAvgPrice.Name = "colAvgPrice";
            this.colAvgPrice.ReadOnly = true;
            // 
            // colRemainAmount
            // 
            this.colRemainAmount.HeaderText = "Amount";
            this.colRemainAmount.Name = "colRemainAmount";
            this.colRemainAmount.ReadOnly = true;
            this.colRemainAmount.Width = 150;
            // 
            // colOriginAmount
            // 
            this.colOriginAmount.HeaderText = "Orig Amount";
            this.colOriginAmount.Name = "colOriginAmount";
            this.colOriginAmount.ReadOnly = true;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "CreatedAt";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "UpdatedAt";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // gridPosition
            // 
            this.gridPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.colStatus,
            this.colBase,
            this.colAmount,
            this.colSwap});
            this.gridPosition.Location = new System.Drawing.Point(235, 581);
            this.gridPosition.Name = "gridPosition";
            this.gridPosition.RowHeadersVisible = false;
            this.gridPosition.Size = new System.Drawing.Size(892, 150);
            this.gridPosition.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Symbol";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 139;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colBase
            // 
            this.colBase.HeaderText = "Base";
            this.colBase.Name = "colBase";
            this.colBase.ReadOnly = true;
            this.colBase.Width = 120;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            // 
            // colSwap
            // 
            this.colSwap.HeaderText = "Meta";
            this.colSwap.Name = "colSwap";
            this.colSwap.ReadOnly = true;
            this.colSwap.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "API";
            // 
            // txtApiPublicKey
            // 
            this.txtApiPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApiPublicKey.Location = new System.Drawing.Point(5, 42);
            this.txtApiPublicKey.Name = "txtApiPublicKey";
            this.txtApiPublicKey.Size = new System.Drawing.Size(224, 22);
            this.txtApiPublicKey.TabIndex = 4;
            // 
            // txtApiSecretKey
            // 
            this.txtApiSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApiSecretKey.Location = new System.Drawing.Point(5, 109);
            this.txtApiSecretKey.Name = "txtApiSecretKey";
            this.txtApiSecretKey.PasswordChar = '*';
            this.txtApiSecretKey.Size = new System.Drawing.Size(224, 26);
            this.txtApiSecretKey.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Secret";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(5, 158);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(224, 36);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // gridWallet
            // 
            this.gridWallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridWallet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCurrency,
            this.colBalance});
            this.gridWallet.Location = new System.Drawing.Point(5, 210);
            this.gridWallet.Name = "gridWallet";
            this.gridWallet.RowHeadersVisible = false;
            this.gridWallet.Size = new System.Drawing.Size(224, 521);
            this.gridWallet.TabIndex = 8;
            // 
            // colCurrency
            // 
            this.colCurrency.HeaderText = "Currency";
            this.colCurrency.Name = "colCurrency";
            this.colCurrency.ReadOnly = true;
            this.colCurrency.Width = 120;
            // 
            // colBalance
            // 
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.comboTicker);
            this.groupBox1.Controls.Add(this.spinOrderCount);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.spinAmount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.spinMinSize);
            this.groupBox1.Controls.Add(this.spinCoefficient);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboDistribution);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.spinUpperPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.spinLowerPrice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(240, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 179);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SHORT Orders Parameters";
            // 
            // comboTicker
            // 
            this.comboTicker.FormattingEnabled = true;
            this.comboTicker.Location = new System.Drawing.Point(111, 33);
            this.comboTicker.Name = "comboTicker";
            this.comboTicker.Size = new System.Drawing.Size(122, 28);
            this.comboTicker.TabIndex = 16;
            // 
            // spinOrderCount
            // 
            this.spinOrderCount.Location = new System.Drawing.Point(368, 144);
            this.spinOrderCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinOrderCount.Name = "spinOrderCount";
            this.spinOrderCount.Size = new System.Drawing.Size(125, 26);
            this.spinOrderCount.TabIndex = 15;
            this.spinOrderCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(282, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Order Count";
            // 
            // spinAmount
            // 
            this.spinAmount.DecimalPlaces = 5;
            this.spinAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinAmount.Location = new System.Drawing.Point(111, 144);
            this.spinAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinAmount.Name = "spinAmount";
            this.spinAmount.Size = new System.Drawing.Size(122, 26);
            this.spinAmount.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(49, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Amount";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinMinSize
            // 
            this.spinMinSize.DecimalPlaces = 5;
            this.spinMinSize.Location = new System.Drawing.Point(368, 107);
            this.spinMinSize.Name = "spinMinSize";
            this.spinMinSize.Size = new System.Drawing.Size(125, 26);
            this.spinMinSize.TabIndex = 11;
            this.spinMinSize.Tag = "";
            this.spinMinSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // spinCoefficient
            // 
            this.spinCoefficient.DecimalPlaces = 2;
            this.spinCoefficient.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinCoefficient.Location = new System.Drawing.Point(368, 71);
            this.spinCoefficient.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinCoefficient.Name = "spinCoefficient";
            this.spinCoefficient.Size = new System.Drawing.Size(125, 26);
            this.spinCoefficient.TabIndex = 9;
            this.spinCoefficient.Value = new decimal(new int[] {
            134,
            0,
            0,
            131072});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(303, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Min Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(288, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Coefficient";
            // 
            // comboDistribution
            // 
            this.comboDistribution.FormattingEnabled = true;
            this.comboDistribution.Items.AddRange(new object[] {
            "Flat",
            "Linear Up",
            "Linear Dn",
            "Exponential Up",
            "Exponential Dn"});
            this.comboDistribution.Location = new System.Drawing.Point(368, 34);
            this.comboDistribution.Name = "comboDistribution";
            this.comboDistribution.Size = new System.Drawing.Size(125, 28);
            this.comboDistribution.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(250, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Distribution Type";
            // 
            // spinUpperPrice
            // 
            this.spinUpperPrice.DecimalPlaces = 5;
            this.spinUpperPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinUpperPrice.Location = new System.Drawing.Point(111, 107);
            this.spinUpperPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinUpperPrice.Name = "spinUpperPrice";
            this.spinUpperPrice.Size = new System.Drawing.Size(122, 26);
            this.spinUpperPrice.TabIndex = 5;
            this.spinUpperPrice.Value = new decimal(new int[] {
            8600,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Upper Price";
            // 
            // spinLowerPrice
            // 
            this.spinLowerPrice.DecimalPlaces = 5;
            this.spinLowerPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinLowerPrice.Location = new System.Drawing.Point(112, 71);
            this.spinLowerPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinLowerPrice.Name = "spinLowerPrice";
            this.spinLowerPrice.Size = new System.Drawing.Size(121, 26);
            this.spinLowerPrice.TabIndex = 3;
            this.spinLowerPrice.Value = new decimal(new int[] {
            8300,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lower Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ticker Choice";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.spinDistance);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.spinProfitPercent);
            this.groupBox2.Controls.Add(this.radioProfitPercent);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.spinProfitTarget);
            this.groupBox2.Controls.Add(this.radioProfitTarget);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(240, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 144);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conditional Order Parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(172, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "USD ( Distance )";
            // 
            // spinDistance
            // 
            this.spinDistance.DecimalPlaces = 2;
            this.spinDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinDistance.Location = new System.Drawing.Point(46, 107);
            this.spinDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinDistance.Name = "spinDistance";
            this.spinDistance.Size = new System.Drawing.Size(120, 26);
            this.spinDistance.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(173, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = " % ( Profit percentage )";
            // 
            // spinProfitPercent
            // 
            this.spinProfitPercent.DecimalPlaces = 2;
            this.spinProfitPercent.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinProfitPercent.Location = new System.Drawing.Point(47, 70);
            this.spinProfitPercent.Name = "spinProfitPercent";
            this.spinProfitPercent.Size = new System.Drawing.Size(120, 26);
            this.spinProfitPercent.TabIndex = 4;
            // 
            // radioProfitPercent
            // 
            this.radioProfitPercent.AutoSize = true;
            this.radioProfitPercent.Location = new System.Drawing.Point(20, 77);
            this.radioProfitPercent.Name = "radioProfitPercent";
            this.radioProfitPercent.Size = new System.Drawing.Size(14, 13);
            this.radioProfitPercent.TabIndex = 3;
            this.radioProfitPercent.TabStop = true;
            this.radioProfitPercent.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(173, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "USD ( Profit target )";
            // 
            // spinProfitTarget
            // 
            this.spinProfitTarget.DecimalPlaces = 2;
            this.spinProfitTarget.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinProfitTarget.Location = new System.Drawing.Point(47, 34);
            this.spinProfitTarget.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinProfitTarget.Name = "spinProfitTarget";
            this.spinProfitTarget.Size = new System.Drawing.Size(120, 26);
            this.spinProfitTarget.TabIndex = 1;
            // 
            // radioProfitTarget
            // 
            this.radioProfitTarget.AutoSize = true;
            this.radioProfitTarget.Location = new System.Drawing.Point(20, 41);
            this.radioProfitTarget.Name = "radioProfitTarget";
            this.radioProfitTarget.Size = new System.Drawing.Size(14, 13);
            this.radioProfitTarget.TabIndex = 0;
            this.radioProfitTarget.TabStop = true;
            this.radioProfitTarget.UseVisualStyleBackColor = true;
            // 
            // spinFee
            // 
            this.spinFee.DecimalPlaces = 2;
            this.spinFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinFee.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinFee.Location = new System.Drawing.Point(24, 31);
            this.spinFee.Name = "spinFee";
            this.spinFee.Size = new System.Drawing.Size(111, 26);
            this.spinFee.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(139, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 16);
            this.label15.TabIndex = 13;
            this.label15.Text = "%";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.spinFee);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(572, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 70);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fee";
            // 
            // btnPreviewOrders
            // 
            this.btnPreviewOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPreviewOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviewOrders.Location = new System.Drawing.Point(240, 366);
            this.btnPreviewOrders.Name = "btnPreviewOrders";
            this.btnPreviewOrders.Size = new System.Drawing.Size(153, 33);
            this.btnPreviewOrders.TabIndex = 15;
            this.btnPreviewOrders.Text = "Preview Orders";
            this.btnPreviewOrders.UseVisualStyleBackColor = false;
            this.btnPreviewOrders.Click += new System.EventHandler(this.btnPreviewOrders_Click);
            // 
            // btnPlaceOrders
            // 
            this.btnPlaceOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPlaceOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrders.Location = new System.Drawing.Point(411, 366);
            this.btnPlaceOrders.Name = "btnPlaceOrders";
            this.btnPlaceOrders.Size = new System.Drawing.Size(165, 33);
            this.btnPlaceOrders.TabIndex = 16;
            this.btnPlaceOrders.Text = "Place Orders";
            this.btnPlaceOrders.UseVisualStyleBackColor = false;
            this.btnPlaceOrders.Click += new System.EventHandler(this.btnPlaceOrders_Click);
            // 
            // btnDeleteOrders
            // 
            this.btnDeleteOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDeleteOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteOrders.Location = new System.Drawing.Point(594, 366);
            this.btnDeleteOrders.Name = "btnDeleteOrders";
            this.btnDeleteOrders.Size = new System.Drawing.Size(169, 33);
            this.btnDeleteOrders.TabIndex = 17;
            this.btnDeleteOrders.Text = "Delete Orders";
            this.btnDeleteOrders.UseVisualStyleBackColor = false;
            this.btnDeleteOrders.Click += new System.EventHandler(this.btnDeleteOrders_Click);
            // 
            // btnBreakAllLoops
            // 
            this.btnBreakAllLoops.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnBreakAllLoops.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBreakAllLoops.Location = new System.Drawing.Point(781, 366);
            this.btnBreakAllLoops.Name = "btnBreakAllLoops";
            this.btnBreakAllLoops.Size = new System.Drawing.Size(164, 33);
            this.btnBreakAllLoops.TabIndex = 18;
            this.btnBreakAllLoops.Text = "Break All Loops";
            this.btnBreakAllLoops.UseVisualStyleBackColor = false;
            this.btnBreakAllLoops.Click += new System.EventHandler(this.btnBreakAllLoops_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(963, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(164, 33);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textPreview
            // 
            this.textPreview.Location = new System.Drawing.Point(762, 15);
            this.textPreview.Name = "textPreview";
            this.textPreview.Size = new System.Drawing.Size(362, 342);
            this.textPreview.TabIndex = 21;
            this.textPreview.Text = "";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 738);
            this.Controls.Add(this.textPreview);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBreakAllLoops);
            this.Controls.Add(this.btnDeleteOrders);
            this.Controls.Add(this.btnPlaceOrders);
            this.Controls.Add(this.btnPreviewOrders);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridWallet);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtApiSecretKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApiPublicKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridPosition);
            this.Controls.Add(this.gridOrder);
            this.Name = "MainUI";
            this.Text = "Trading bot";
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridWallet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinOrderCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCoefficient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinUpperPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLowerPrice)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProfitPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinProfitTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFee)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridOrder;
        private System.Windows.Forms.DataGridView gridPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApiPublicKey;
        private System.Windows.Forms.TextBox txtApiSecretKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView gridWallet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown spinOrderCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown spinAmount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown spinMinSize;
        private System.Windows.Forms.NumericUpDown spinCoefficient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboDistribution;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown spinUpperPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown spinLowerPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown spinDistance;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown spinProfitPercent;
        private System.Windows.Forms.RadioButton radioProfitPercent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown spinProfitTarget;
        private System.Windows.Forms.RadioButton radioProfitTarget;
        private System.Windows.Forms.NumericUpDown spinFee;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPreviewOrders;
        private System.Windows.Forms.Button btnPlaceOrders;
        private System.Windows.Forms.Button btnDeleteOrders;
        private System.Windows.Forms.Button btnBreakAllLoops;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox comboTicker;
        private System.Windows.Forms.RichTextBox textPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvgPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriginAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSwap;
    }
}

