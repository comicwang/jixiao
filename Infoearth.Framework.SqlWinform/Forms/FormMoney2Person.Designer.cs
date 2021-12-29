
namespace Infoearth.Framework.SqlWinform.Forms
{
    partial class FormMoney2Person
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMoney2Person));
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboRoom = new System.Windows.Forms.ComboBox();
            this.comboPosition = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dtpCashTime = new System.Windows.Forms.DateTimePicker();
            this.comboCashGroup = new System.Windows.Forms.ComboBox();
            this.txtCashMoney = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAll = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlloted = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.moneySummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneySummaryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(596, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "职务：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "科室：";
            // 
            // comboRoom
            // 
            this.comboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRoom.FormattingEnabled = true;
            this.comboRoom.Location = new System.Drawing.Point(376, 18);
            this.comboRoom.Margin = new System.Windows.Forms.Padding(4);
            this.comboRoom.Name = "comboRoom";
            this.comboRoom.Size = new System.Drawing.Size(179, 23);
            this.comboRoom.TabIndex = 7;
            // 
            // comboPosition
            // 
            this.comboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPosition.FormattingEnabled = true;
            this.comboPosition.Location = new System.Drawing.Point(657, 18);
            this.comboPosition.Margin = new System.Windows.Forms.Padding(4);
            this.comboPosition.Name = "comboPosition";
            this.comboPosition.Size = new System.Drawing.Size(179, 23);
            this.comboPosition.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(737, 474);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 16;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(617, 474);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 29);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "兑现金额：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "兑现时间：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "兑现分组：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "备注";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(46, 230);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(791, 202);
            this.txtRemark.TabIndex = 19;
            // 
            // dtpCashTime
            // 
            this.dtpCashTime.Location = new System.Drawing.Point(376, 112);
            this.dtpCashTime.Name = "dtpCashTime";
            this.dtpCashTime.Size = new System.Drawing.Size(179, 25);
            this.dtpCashTime.TabIndex = 20;
            // 
            // comboCashGroup
            // 
            this.comboCashGroup.FormattingEnabled = true;
            this.comboCashGroup.Location = new System.Drawing.Point(105, 160);
            this.comboCashGroup.Margin = new System.Windows.Forms.Padding(4);
            this.comboCashGroup.Name = "comboCashGroup";
            this.comboCashGroup.Size = new System.Drawing.Size(731, 23);
            this.comboCashGroup.TabIndex = 22;
            // 
            // txtCashMoney
            // 
            this.txtCashMoney.Location = new System.Drawing.Point(105, 112);
            this.txtCashMoney.Margin = new System.Windows.Forms.Padding(4);
            this.txtCashMoney.Name = "txtCashMoney";
            this.txtCashMoney.Size = new System.Drawing.Size(179, 25);
            this.txtCashMoney.TabIndex = 23;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(105, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 23);
            this.comboBox2.TabIndex = 26;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "分配绩效：";
            // 
            // txtAll
            // 
            this.txtAll.Location = new System.Drawing.Point(105, 66);
            this.txtAll.Margin = new System.Windows.Forms.Padding(4);
            this.txtAll.Name = "txtAll";
            this.txtAll.ReadOnly = true;
            this.txtAll.Size = new System.Drawing.Size(179, 25);
            this.txtAll.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "已兑绩效：";
            // 
            // txtAlloted
            // 
            this.txtAlloted.Location = new System.Drawing.Point(376, 66);
            this.txtAlloted.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlloted.Name = "txtAlloted";
            this.txtAlloted.ReadOnly = true;
            this.txtAlloted.Size = new System.Drawing.Size(179, 25);
            this.txtAlloted.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(568, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "剩余未兑：";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(657, 66);
            this.txtLeft.Margin = new System.Windows.Forms.Padding(4);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(179, 25);
            this.txtLeft.TabIndex = 25;
            // 
            // moneySummaryBindingSource
            // 
            this.moneySummaryBindingSource.DataSource = typeof(Infoearth.Framework.SqlWinform.Dto.MoneySummary);
            // 
            // FormMoney2Person
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 518);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAlloted);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAll);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCashMoney);
            this.Controls.Add(this.comboCashGroup);
            this.Controls.Add(this.dtpCashTime);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboPosition);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboRoom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMoney2Person";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "绩效兑现";
            this.Load += new System.EventHandler(this.FormPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneySummaryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboRoom;
        private System.Windows.Forms.ComboBox comboPosition;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.DateTimePicker dtpCashTime;
        private System.Windows.Forms.ComboBox comboCashGroup;
        private System.Windows.Forms.TextBox txtCashMoney;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAlloted;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.BindingSource moneySummaryBindingSource;
    }
}