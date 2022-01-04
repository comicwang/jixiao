using Infoearth.Framework.SqlWinform.Entity;
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
using Infoearth.Framework.SqlWinform.extention;
using Infoearth.Framework.SqlWinform.Dto;
using Infoearth.Framework.SqlWinform.Forms;
using Infoearth.Framework.SqlWinform.Mock;

namespace Infoearth.Framework.SqlWinform.Controls
{
    public partial class ControlProjec2Person : UserControl
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();

        public ControlProjec2Person()
        {
            InitializeComponent();
        }

        private void ControlProjec2Person_Load(object sender, EventArgs e)
        {
            this.groupBox1.BindControlDB(this.bindingSource1, typeof(Project));
            IniProjects();
            this.dataGridView1.BindDb<Project2Person>(true,IniSummary, SaveProject);
            this.dataGridView2.BindDb<Project2Person>(true,IniSummary, SaveProject);
        }

        private void IniProjects()
        {
            var projects = _projectManager.CurrentDb.AsQueryable().WhereIF(checkBox1.Checked, t => t.memony != t.allotMoney).ToList();
            comboBox1.DataSource = projects;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void IniSummary()
        {
            var allotedDatas = _p2pManager.CurrentDb.AsQueryable().Where(t => t.prid ==int.Parse(lblid.Text)).ToList();

            var data = new MoneySummary(allotedDatas);
            data.TotalMoneyVal = (bindingSource1.DataSource as Project).memony;
            lblResult.Visible = data.LeftMoneyVal == 0;
            label18.Visible = data.LeftMoneyVal != 0;
            bindingSource2.DataSource =data;
        }

        private void IniGrids()
        {
            int peid = int.Parse(lblid.Text);
            var datas = _p2pManager.CurrentDb.AsQueryable().Where(t => t.prid == peid).Mapper(t => t.person, p => p.peid).ToList();

            var data1 = new List<Project2Person>();
            var tmp1 = datas.Where(t => t.allot == allotEnum.主要).ToList();
            if (tmp1 != null && tmp1.Count > 0)
            {
                data1.AddRange(tmp1);
                int columnIndex = 1;
                data1.ForEach(t => { t.Grid_Num = columnIndex; columnIndex++; });
            }
            var data2 = new List<Project2Person>();
            var tmp2 = datas.Where(t => t.allot == allotEnum.普惠).ToList();
            if (tmp2 != null && tmp2.Count > 0)
            {
                data2.AddRange(tmp2);
                int columnIndex = 1;
                data2.ForEach(t => { t.Grid_Num = columnIndex; columnIndex++; });
            }
            dataGridView1.DataSource = tmp1;
            dataGridView2.DataSource = tmp2;
        }

        private void SaveProject()
        {
            var allotedDatas = _p2pManager.CurrentDb.AsQueryable().Where(t => t.prid == int.Parse(lblid.Text)).ToList();

            _projectManager.Update(lblid.Text, t => t.allotMoney = allotedDatas.Sum(s => s.money));

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IniProjects();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projects = comboBox1.DataSource as List<Project>;
            this.bindingSource1.DataSource = projects[comboBox1.SelectedIndex];
          
            IniGrids();
            IniSummary();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var souce = dataGridView1.DataSource;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pnlSel.Visible = !radioButton1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var project = bindingSource1.DataSource as Project;

            List<Person> selected = new List<Person>();
            //手动选择
            if (radioButton1.Checked)
            {
                //选取主要人员
                if (radioButton3.Checked)
                {
                    if (project == null)
                    {
                        MessageBox.Show("项目信息不存在");
                        return;
                    }
                    if (string.IsNullOrEmpty(project.persons))
                    {
                        MessageBox.Show("主要人员为空,请手选分配");
                        return;
                    }
                    string[] persons = project.persons.Split(',');
                    foreach (var item in persons)
                    {
                        var person = _personManager.CurrentDb.AsQueryable().Where(t => t.name == item).First();
                        if (person == null)
                        {
                            if (DialogResult.Yes == MessageBox.Show($"未找到【{item}】的人员分配记录,是否新增并加入分配?", "未找到人员", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                int id = _personManager.InsertReturnIdentity(new Person() { name = item });
                                selected.Add(new Person()
                                {
                                    id = id,
                                    name = item
                                });
                            }
                        }
                        else
                        {
                            selected.Add(person);
                        }
                    }
                }
                //手动挑选人员
                else
                {
                    FormPersonSel formPersonSel = new FormPersonSel();
                    if (formPersonSel.ShowDialog() == DialogResult.OK)
                    {
                        selected = formPersonSel.SelectedPerons;
                    }
                    else
                        return;
                }
            }
            else
            {

                var pCount = _p2pManager.CurrentDb.AsQueryable().Where(t => t.allot == allotEnum.普惠).GroupBy(t => t.peid).Select(t => new PersonSelector() { id = t.peid, times = SqlSugar.SqlFunc.AggregateCount(t), money = SqlSugar.SqlFunc.AggregateSum(t.money) }).ToList().ToDictionary(t => t.id);

                var excludeIds = _p2pManager.CurrentDb.AsQueryable().Where(t => t.prid == project.id && t.allot == allotEnum.主要).Select(t => t.peid).ToList();
                var person = _personManager.CurrentDb.AsQueryable().Where(t => t.room != "不分配" && t.persondelta > 0).Where(t => !excludeIds.Contains(t.id)).Select(t => new PersonSelector() { id = t.id, room = t.room, delta = t.persondelta }).ToList();

                foreach (var item in person)
                {
                    if (pCount.ContainsKey(item.id))
                    {
                        item.times = pCount[item.id].times;
                        item.money = pCount[item.id].money;
                    }
                }

                //分组分配次数
                var pTimes = person.GroupBy(t => t.times).OrderBy(t => t.Key).ToDictionary(t => t.Key);

                int selTimes = 1;

                while (true)
                {
                    int personNum = new Random(Guid.NewGuid().GetHashCode()).Next((int)numericUpDown1.Value, (int)numericUpDown2.Value + 1);
                    /*机选分配规则
                    1.不选择本次主要奖金的获取人员
                    2.优先选择分配次数少的人员
                    3.均衡分配高中低普惠系数的人员
                    4.普惠人员的最高金额不能高于主要人员的最低金额
                    5.抽取人员的科室尽量是本项目主要负责部门的人员
                   */
                    selected.Clear();

                    //判断最少次数的人员是否满足本次人数---满足从里面根据下级条件继续筛选；不满足选中里面所有人员，剩余人员从下一级条件中继续筛选
                    int lessTime = pTimes.Min(t => t.Key);
                    int lessCount = pTimes[lessTime].Count();

                    List<PersonSelector> nextSelector = pTimes[lessTime].ToList();

                    int index = 1;
                    while (nextSelector.Count < personNum)
                    {
                        if (index > pTimes.Count - 1)
                        {
                            MessageBox.Show("人数不满足选取的数量");
                            continue;
                        }
                        foreach (var item in nextSelector)
                        {
                            selected.Add(new Person()
                            {
                                id = item.id,
                                persondelta = item.delta
                            });
                        }
                        personNum -= nextSelector.Count;
                        nextSelector = pTimes[pTimes.Keys.Skip(index).FirstOrDefault()].ToList();
                        index++;
                    }
                    //科室人员筛选
                    var roomSelect = nextSelector.Where(t => !string.IsNullOrEmpty(t.room) && project.room.Contains(t.room)).ToList();
                    if (roomSelect.Count < personNum)
                    {
                        foreach (var item in roomSelect)
                        {
                            selected.Add(new Person()
                            {
                                id = item.id,
                                persondelta = item.delta
                            });
                        }
                        personNum -= roomSelect.Count;

                        //剩下的随机挑选其他人员
                        nextSelector.Where(t => !project.room.Contains(t.room)).ToList().Selector(personNum).ForEach(t =>
                        {
                            selected.Add(new Person() { id = t.id, persondelta = t.delta });
                        }); ;
                    }
                    else
                    {
                        //科室随机挑选
                        roomSelect.Selector(personNum).ForEach(t =>
                        {
                            selected.Add(new Person() { id = t.id, persondelta = t.delta });
                        });
                    }

                    //检查金额是否有超过
                    //计算吃肉最小值，内定最少为65%的0.1
                    double minMoney = _p2pManager.CurrentDb.AsQueryable().Where(t => t.prid == project.id && t.allot == allotEnum.主要).Min(t => t.money);
                    if (minMoney < project.memony * (int)allotEnum.主要 / 1000)
                        minMoney = project.memony * (int)allotEnum.主要 / 1000;
                
                    //检查系数最大值是否超过
                    if (tabControl1.SelectedIndex == 1)
                    {
                        double maxMoney = project.memony * selected.Max(t => t.persondelta) * (int)(allotEnum.普惠) / 100 / selected.Sum(t => t.persondelta);
                        if (maxMoney > minMoney)
                        {
                            selTimes++;
                            continue;
                        }
                        //检查人员系数是否
                        bool avanged = selected.Any(t => t.persondelta >= 1 && t.persondelta < 2) && selected.Any(t => t.persondelta >= 2 && t.persondelta < 3) && selected.Any(t => t.persondelta >= 3);
                        if (avanged == false)
                        {

                            if (selTimes > 100)
                            {
                                MessageBox.Show("无法满足个人系数均分");
                                break;
                            }
                            selTimes++;
                            continue;
                        }
                    }

                    break;
                }
            }


            List<Project2Person> p2pResult = new List<Project2Person>();
            if (tabControl1.SelectedIndex == 0)
            {
                foreach (var item in selected)
                {
                    p2pResult.Add(new Project2Person()
                    {
                        allot = allotEnum.主要,
                        allotime = DateTime.Now,
                        peid = item.id,
                        prid = project.id
                    });
                }
            }
            else
            {
                foreach (var item in selected)
                {
                    p2pResult.Add(new Project2Person()
                    {
                        allot = allotEnum.普惠,
                        allotime = DateTime.Now,
                        peid = item.id,
                        prid = project.id,
                        money =Math.Round(project.memony * item.persondelta * (int)(allotEnum.普惠) / 100 / selected.Sum(t => t.persondelta),2),
                        delta = item.persondelta

                    }); ;
                }
            }
            _p2pManager.CurrentDb.AsDeleteable().Where(t => t.prid == project.id && t.allot == (tabControl1.SelectedIndex == 0 ? allotEnum.主要 : allotEnum.普惠)).ExecuteCommand();
            _p2pManager.CurrentDb.InsertRange(p2pResult);

            IniGrids();
            IniSummary();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //删除
            if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
            {
                int id = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                bool success = _p2pManager.CurrentDb.DeleteById(id);
                if (success)
                    IniGrids();
            }
            //查看绩效
            else if (e.ColumnIndex == dataGridView1.Columns.Count - 2)
            {
                FormPersonSummary formPersonSummary = new FormPersonSummary(int.Parse(dataGridView1["peidDataGridViewTextBoxColumn", e.RowIndex].Value.ToString()));
                formPersonSummary.Show();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //删除
            if (e.ColumnIndex == dataGridView2.Columns.Count - 1)
            {
                int id = int.Parse(dataGridView2[0, e.RowIndex].Value.ToString());
                bool success = _p2pManager.CurrentDb.DeleteById(id);
                if (success)
                    IniGrids();
            }
            //查看绩效
            else if (e.ColumnIndex == dataGridView2.Columns.Count - 2)
            {
                FormPersonSummary formPersonSummary = new FormPersonSummary(int.Parse(dataGridView2["peidDataGridViewTextBoxColumn", e.RowIndex].Value.ToString()));
                formPersonSummary.Show();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["deltaDataGridViewTextBoxColumn"].Index)
            {
                float del = 0;
                string delta = dataGridView1[e.ColumnIndex, e.RowIndex].Value?.ToString();
                if(float.TryParse(delta,out del)==false)
                {
                    MessageBox.Show("系数值必须为数值");
                    return;
                }
                var project = bindingSource1.DataSource as Project;
                dataGridView1["moneyDataGridViewTextBoxColumn", e.RowIndex].Value = Math.Round(del * project.memony * 0.65, 2);
            }
        }
    }
}
