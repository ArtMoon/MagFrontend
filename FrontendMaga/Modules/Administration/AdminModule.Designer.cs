namespace FrontendMaga.Administration
{
    partial class AdminModule
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgSensorRules = new System.Windows.Forms.DataGridView();
            this.colPrID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSensId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgReason = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgSolution = new System.Windows.Forms.DataGridView();
            this.colSolID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolSensID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSolNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.colReasID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSensor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReasRule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReasValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReasNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorRules)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReason)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSolution)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1045, 629);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1037, 600);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.72832F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.27168F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeObjects, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.46154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.53846F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 594F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1031, 594);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.00481F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.99519F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(196, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.53061F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.46939F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(832, 588);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgSensorRules);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 200);
            this.panel1.TabIndex = 1;
            // 
            // dgSensorRules
            // 
            this.dgSensorRules.AllowUserToAddRows = false;
            this.dgSensorRules.AllowUserToOrderColumns = true;
            this.dgSensorRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSensorRules.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgSensorRules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSensorRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSensorRules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrID,
            this.colSensId,
            this.colRule,
            this.colValue,
            this.colBound,
            this.colText,
            this.colNumber});
            this.dgSensorRules.ContextMenuStrip = this.contextMenuStrip1;
            this.dgSensorRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSensorRules.Location = new System.Drawing.Point(0, 0);
            this.dgSensorRules.Name = "dgSensorRules";
            this.dgSensorRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSensorRules.Size = new System.Drawing.Size(826, 200);
            this.dgSensorRules.TabIndex = 0;
            this.dgSensorRules.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSensorRules_CellClick);
            this.dgSensorRules.Enter += new System.EventHandler(this.dgSensorRules_Enter);
            // 
            // colPrID
            // 
            this.colPrID.HeaderText = "ID";
            this.colPrID.Name = "colPrID";
            this.colPrID.ReadOnly = true;
            // 
            // colSensId
            // 
            this.colSensId.HeaderText = "ID датчика";
            this.colSensId.Name = "colSensId";
            // 
            // colRule
            // 
            this.colRule.HeaderText = "Условие";
            this.colRule.Name = "colRule";
            this.colRule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Значение";
            this.colValue.Name = "colValue";
            // 
            // colBound
            // 
            this.colBound.HeaderText = "Граница";
            this.colBound.Name = "colBound";
            this.colBound.ReadOnly = true;
            // 
            // colText
            // 
            this.colText.HeaderText = "Ситуация";
            this.colText.Name = "colText";
            // 
            // colNumber
            // 
            this.colNumber.HeaderText = "Номер ";
            this.colNumber.Name = "colNumber";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.DeleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.button1_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgReason);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 209);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 188);
            this.panel3.TabIndex = 2;
            // 
            // dgReason
            // 
            this.dgReason.AllowUserToAddRows = false;
            this.dgReason.AllowUserToOrderColumns = true;
            this.dgReason.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReason.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgReason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReason.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReasID,
            this.colSensor,
            this.colReasRule,
            this.colReasValue,
            this.colReason,
            this.colProb,
            this.colReasNumber});
            this.dgReason.ContextMenuStrip = this.contextMenuStrip1;
            this.dgReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgReason.Location = new System.Drawing.Point(0, 0);
            this.dgReason.Name = "dgReason";
            this.dgReason.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgReason.Size = new System.Drawing.Size(826, 188);
            this.dgReason.TabIndex = 3;
            this.dgReason.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReason_CellClick);
            this.dgReason.Enter += new System.EventHandler(this.dgSensorRules_Enter);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgSolution);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 403);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(826, 182);
            this.panel4.TabIndex = 3;
            // 
            // dgSolution
            // 
            this.dgSolution.AllowUserToAddRows = false;
            this.dgSolution.AllowUserToOrderColumns = true;
            this.dgSolution.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSolution.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.dgSolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSolution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSolution.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSolID,
            this.colSolution,
            this.colParam,
            this.colSolSensID,
            this.colSolNumber});
            this.dgSolution.ContextMenuStrip = this.contextMenuStrip1;
            this.dgSolution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSolution.Location = new System.Drawing.Point(0, 0);
            this.dgSolution.Name = "dgSolution";
            this.dgSolution.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSolution.Size = new System.Drawing.Size(826, 182);
            this.dgSolution.TabIndex = 4;
            this.dgSolution.Enter += new System.EventHandler(this.dgSensorRules_Enter);
            // 
            // colSolID
            // 
            this.colSolID.HeaderText = "ID";
            this.colSolID.Name = "colSolID";
            this.colSolID.ReadOnly = true;
            // 
            // colSolution
            // 
            this.colSolution.HeaderText = "Решение";
            this.colSolution.Name = "colSolution";
            // 
            // colParam
            // 
            this.colParam.HeaderText = "Параметр воздействия";
            this.colParam.Name = "colParam";
            // 
            // colSolSensID
            // 
            this.colSolSensID.HeaderText = "ID датчика";
            this.colSolSensID.Name = "colSolSensID";
            // 
            // colSolNumber
            // 
            this.colSolNumber.HeaderText = "Номер ";
            this.colSolNumber.Name = "colSolNumber";
            // 
            // treeObjects
            // 
            this.treeObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeObjects.Location = new System.Drawing.Point(3, 3);
            this.treeObjects.Name = "treeObjects";
            this.treeObjects.Size = new System.Drawing.Size(187, 588);
            this.treeObjects.TabIndex = 0;
            this.treeObjects.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeObjects_NodeMouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1037, 600);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Objects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // colReasID
            // 
            this.colReasID.HeaderText = "ID";
            this.colReasID.Name = "colReasID";
            this.colReasID.ReadOnly = true;
            // 
            // colSensor
            // 
            this.colSensor.HeaderText = "ID датчика";
            this.colSensor.Name = "colSensor";
            // 
            // colReasRule
            // 
            this.colReasRule.HeaderText = "Правило";
            this.colReasRule.Name = "colReasRule";
            this.colReasRule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colReasValue
            // 
            this.colReasValue.HeaderText = "Значение";
            this.colReasValue.Name = "colReasValue";
            // 
            // colReason
            // 
            this.colReason.HeaderText = "Причина";
            this.colReason.Name = "colReason";
            // 
            // colProb
            // 
            this.colProb.HeaderText = "Вероятность";
            this.colProb.Name = "colProb";
            // 
            // colReasNumber
            // 
            this.colReasNumber.HeaderText = "Номер ";
            this.colReasNumber.Name = "colReasNumber";
            // 
            // AdminModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(1045, 629);
            this.Controls.Add(this.tabControl1);
            this.Name = "AdminModule";
            this.Text = "AdminModule";
            this.Load += new System.EventHandler(this.AdminModule_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSensorRules)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReason)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSolution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgSensorRules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgReason;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgSolution;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolSensID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSolNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSensId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBound;
        private System.Windows.Forms.DataGridViewTextBoxColumn colText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReasID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSensor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReasRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReasValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProb;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReasNumber;
    }
}