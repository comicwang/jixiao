using Infoearth.Framework.SqlWinform.Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoearth.Framework.SqlWinform
{
    public class DbContext<T> where T : class, new()
    {
        public static string GetCurrentProjectPath
        {

            get
            {
                return $"{Application.StartupPath.Replace(@"\bin\Debug", "")}\\db\\money.sqlite";
            }
        }

        private static readonly string ConnectionString = $"DataSource={GetCurrentProjectPath}";

        public DbContext()
        {
            var config = new ConnectionConfig()
            {
                ConnectionString = ConnectionString,
                DbType = DbType.Sqlite,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            };

            //判断数据库是否存在，不存在则创建
            if (!File.Exists(GetCurrentProjectPath))
            {
                SqlSugarClient db = new SqlSugarClient(config);

                db.DbMaintenance.CreateDatabase();

                //创建实体表
                db.CodeFirst.InitTables(typeof(Person),typeof(Dictionry),typeof(Project),typeof(Project2Person),typeof(Money2Person));

            }
            
            Db = new SqlSugarClient(config);

            Db.CodeFirst.InitTables(typeof(Project), typeof(Project2Person), typeof(Money2Person));
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                  Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            };
        }


        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来操作当前表的数据

        public SimpleClient<Person> person_Db { get { return new SimpleClient<Person>(Db); } }

        public SimpleClient<Dictionry> dictionary_Db { get { return new SimpleClient<Dictionry>(Db); } }

        public SimpleClient<Project> project_Db { get { return new SimpleClient<Project>(Db); } }


        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(T obj)
        {
            RepareNull(obj);
            return CurrentDb.Insert(obj);
        }

        public virtual int InsertReturnIdentity(T obj)
        {
            RepareNull(obj);
            return CurrentDb.InsertReturnIdentity(obj);
        }


        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Insert(List<T> objs)
        {
            objs.ForEach(t => RepareNull(t));
            return CurrentDb.InsertRange(objs);
        }

        /// <summary>
        /// 根据实体更新，实体需要有主键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            RepareNull(obj);
            return CurrentDb.Update(obj);
        }

        /// <summary>
        ///批量更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Update(List<T> objs)
        {
            objs.ForEach(t => RepareNull(t));
            return CurrentDb.UpdateRange(objs);
        }

        public bool Update(string id, Action<T> action)
        {
            var result = CurrentDb.GetById(id);
            if (result == null)
            {
                return false;
            }
            if (action != null)
            {
                action(result);
            }
            return Update(result);
        }

        private void RepareNull(T t)
        {
            var props = typeof(T).GetProperties();
            foreach (PropertyInfo item in props)
            {
                SugarColumn sugarColumn= item.GetCustomAttribute<SugarColumn>();
                if (sugarColumn != null && sugarColumn.IsIgnore == false)
                {
                    if (item.PropertyType == typeof(string))
                    {
                        if (item.GetValue(t) == null)
                            item.SetValue(t, string.Empty);
                    }
                }
            }
        }
    }
}
