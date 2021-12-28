using Infoearth.Framework.SqlWinform.Entity;
using Infoearth.Framework.SqlWinform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Mock
{
    public class BussnessMocker
    {
        private ProjectManager _projectManager = new ProjectManager();
        private Project2PersonManager _p2pManager = new Project2PersonManager();
        private PersonManager _personManager = new PersonManager();
        private DictionaryManager _dicManager = new DictionaryManager();

        /// <summary>
        /// 模拟人员
        /// </summary>
        /// <param name="mockCount"></param>
        public void MockPersons(int mockCount)
        {
            var currentNames = _personManager.CurrentDb.AsQueryable().Select(t => t.name).ToList();
            List<Person> persons = new List<Person>();
            var dicNames = Mocker.MockNamesAndSex(mockCount, currentNames);
            Dictionary<string, List<string>> _dicMockDictonary = new Dictionary<string, List<string>>();//提高效率
            foreach (var item in dicNames)
            {
                Person person = new Person()
                {
                    name = item.Key,
                    sex = item.Value,
                };
                person = MockDictonary(person, _dicMockDictonary);
                persons.Add(person);
            }
            _personManager.Insert(persons);
        }

        public void MockProject(int projectCount)
        {
            var persons = _personManager.CurrentDb.AsQueryable().Select(t => t.name).ToList();
            List<Project> projects = new List<Project>();
            Dictionary<string, List<string>> _dicMockDictonary = new Dictionary<string, List<string>>();//提高效率
            for (int i = 0; i < projectCount; i++)
            {
                //随机挑选2-5个人作为主要项目人员
                List<string> mockNames = persons.Selector(new Random(Guid.NewGuid().GetHashCode()).Next(2, 6)).ToList();
                Project project = new Project()
                {
                    name = "绩效测试项目" + i,
                    memony = new Random(Guid.NewGuid().GetHashCode()).Next(15, 300) * 1000,
                    year = 2021,
                    persons = string.Join(",", mockNames)
                };
                project= MockDictonary(project, _dicMockDictonary);
                project.name = project.room + project.name;
                projects.Add(project);
            }
            _projectManager.Insert(projects);
        }


        public T MockDictonary<T>(T entity, Dictionary<string, List<string>> dic) where T : class, new()
        {
            var props = typeof(T).GetProperties();
            foreach (var item in props)
            {
                if (item.GetValue(entity) == null)
                {
                    if (dic.ContainsKey(item.Name) == false)
                    {
                        var lst = _dicManager.CurrentDb.AsQueryable().Where(t => t.model.ToLower() == item.Name.ToLower()).Select(t => t.value).ToList();
                        dic.Add(item.Name, lst);
                    }
                    var vals = dic[item.Name];
                    if (vals != null && vals.Count > 0)
                    {
                        string val = vals[new Random(Guid.NewGuid().GetHashCode()).Next(0, vals.Count)];
                        item.SetValue(entity, val);
                    }
                }
            }
            return entity;
        }
    }
}
