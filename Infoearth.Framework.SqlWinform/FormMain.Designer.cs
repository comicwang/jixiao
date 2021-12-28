
namespace Infoearth.Framework.SqlWinform
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.首页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资料查档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绩效管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人员绩效一览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目绩效一览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.绩效兑现ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首页ToolStripMenuItem,
            this.数据录入ToolStripMenuItem,
            this.资料查档ToolStripMenuItem,
            this.绩效兑现ToolStripMenuItem,
            this.绩效管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1221, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 首页ToolStripMenuItem
            // 
            this.首页ToolStripMenuItem.Name = "首页ToolStripMenuItem";
            this.首页ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.首页ToolStripMenuItem.Text = "首页";
            this.首页ToolStripMenuItem.Click += new System.EventHandler(this.首页ToolStripMenuItem_Click);
            // 
            // 数据录入ToolStripMenuItem
            // 
            this.数据录入ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人员管理ToolStripMenuItem,
            this.项目管理ToolStripMenuItem});
            this.数据录入ToolStripMenuItem.Name = "数据录入ToolStripMenuItem";
            this.数据录入ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.数据录入ToolStripMenuItem.Text = "数据录入";
            // 
            // 人员管理ToolStripMenuItem
            // 
            this.人员管理ToolStripMenuItem.Name = "人员管理ToolStripMenuItem";
            this.人员管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.人员管理ToolStripMenuItem.Text = "人员管理";
            this.人员管理ToolStripMenuItem.Click += new System.EventHandler(this.人员管理ToolStripMenuItem_Click);
            // 
            // 项目管理ToolStripMenuItem
            // 
            this.项目管理ToolStripMenuItem.Name = "项目管理ToolStripMenuItem";
            this.项目管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.项目管理ToolStripMenuItem.Text = "项目管理";
            this.项目管理ToolStripMenuItem.Click += new System.EventHandler(this.项目管理ToolStripMenuItem_Click);
            // 
            // 资料查档ToolStripMenuItem
            // 
            this.资料查档ToolStripMenuItem.Name = "资料查档ToolStripMenuItem";
            this.资料查档ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.资料查档ToolStripMenuItem.Text = "绩效分配";
            this.资料查档ToolStripMenuItem.Click += new System.EventHandler(this.资料查档ToolStripMenuItem_Click);
            // 
            // 绩效管理ToolStripMenuItem
            // 
            this.绩效管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人员绩效一览ToolStripMenuItem,
            this.项目绩效一览ToolStripMenuItem});
            this.绩效管理ToolStripMenuItem.Name = "绩效管理ToolStripMenuItem";
            this.绩效管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.绩效管理ToolStripMenuItem.Text = "绩效查档";
            // 
            // 人员绩效一览ToolStripMenuItem
            // 
            this.人员绩效一览ToolStripMenuItem.Name = "人员绩效一览ToolStripMenuItem";
            this.人员绩效一览ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.人员绩效一览ToolStripMenuItem.Text = "人员绩效一览";
            this.人员绩效一览ToolStripMenuItem.Click += new System.EventHandler(this.人员绩效一览ToolStripMenuItem_Click);
            // 
            // 项目绩效一览ToolStripMenuItem
            // 
            this.项目绩效一览ToolStripMenuItem.Name = "项目绩效一览ToolStripMenuItem";
            this.项目绩效一览ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.项目绩效一览ToolStripMenuItem.Text = "项目绩效一览";
            this.项目绩效一览ToolStripMenuItem.Click += new System.EventHandler(this.项目绩效一览ToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 28);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1221, 727);
            this.pnlMain.TabIndex = 1;
            // 
            // 绩效兑现ToolStripMenuItem
            // 
            this.绩效兑现ToolStripMenuItem.Name = "绩效兑现ToolStripMenuItem";
            this.绩效兑现ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.绩效兑现ToolStripMenuItem.Text = "绩效兑现";
            this.绩效兑现ToolStripMenuItem.Click += new System.EventHandler(this.绩效兑现ToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 755);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绩效转换系统";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 首页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资料查档ToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem 项目管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绩效管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人员绩效一览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目绩效一览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绩效兑现ToolStripMenuItem;
    }
}

