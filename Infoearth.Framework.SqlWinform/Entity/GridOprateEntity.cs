using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Entity
{
    public class GridOprateEntity
    {
        [SqlSugar.SugarColumn(IsIgnore =true)]
        public string grid_edit => "编辑";

        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string grid_del => "删除";

        //[SqlSugar.SugarColumn(IsIgnore = true)]
        //public string grid_view => "查看";
    }

    public class GridViewEntity
    {
        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string grid_edit => "查看";

        [SqlSugar.SugarColumn(IsIgnore = true)]
        public string grid_del => "删除";
    }
}
