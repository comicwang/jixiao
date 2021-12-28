using Infoearth.Framework.SqlWinform.Controls;
using Infoearth.Framework.SqlWinform.Forms;
using Infoearth.Framework.SqlWinform.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoearth.Framework.SqlWinform
{
    public partial class FormMain : Form
    {
        private PersonManager _personManager = new PersonManager();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlFristPage controlPerson = new ControlFristPage();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlPerson controlPerson = new ControlPerson();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 项目管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlProject controlPerson = new ControlProject();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 项目绩效一览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlProjectSummary controlPerson = new ControlProjectSummary();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 资料查档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlProjec2Person controlPerson = new ControlProjec2Person();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 人员绩效一览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlPersonSummary controlPerson = new ControlPersonSummary();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlFristPage controlPerson = new ControlFristPage();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }

        private void 绩效兑现ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();

            ControlPerson2Money controlPerson = new ControlPerson2Money();
            controlPerson.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(controlPerson);
        }
    }
}
