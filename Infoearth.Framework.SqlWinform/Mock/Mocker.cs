﻿using Infoearth.Framework.SqlWinform.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Framework.SqlWinform.Mock
{
    public static class Mocker
    {
        /// <summary>
        /// 模拟人名
        /// </summary>
        /// <param name="mockCount"></param>
        /// <param name="exclusives"></param>
        /// <param name="uniq"></param>
        /// <param name="Sex"></param>
        /// <returns></returns>
        public static List<string> MockNames(int mockCount, List<string> exclusives = null, bool uniq = true, Sex Sex = Sex.不明)
        {
            List<string> result = new List<string>();

            List<string> mockIndex = new List<string>();

            List<Char> chars = new List<char>();
            if (Sex == Sex.不明)
            {
                chars.AddRange(_lastNameMan.ToCharArray());
                chars.AddRange(_lastNameWoMan.ToCharArray());
            }
            else if (Sex == Sex.男)
            {
                chars.AddRange(_lastNameMan.ToCharArray());
            }
            else
            {
                chars.AddRange(_lastNameWoMan.ToCharArray());
            }
            Random random = new Random();
            int index = 0;
            while (index < mockCount)
            {
                int firstIndex = random.Next(0, Xing.Count);
                int lastIndex = random.Next(0, chars.Count);
                string nameIndex = $"{firstIndex}{lastIndex}";
                if (uniq)
                {
                    if (mockIndex.Contains(nameIndex))
                    {
                        continue;
                    }
                }
                mockIndex.Add(nameIndex);
                string name = Xing[firstIndex] + chars[lastIndex];
                if (exclusives != null && exclusives.Count > 0)
                {
                    if (exclusives.Contains(name))
                        continue;
                }
                result.Add(name);
                index++;
            }
            return result;
        }

        /// <summary>
        /// 模拟人名
        /// </summary>
        /// <param name="mockCount"></param>
        /// <param name="exclusives"></param>
        /// <param name="uniq"></param>
        /// <param name="Sex"></param>
        /// <returns></returns>
        public static Dictionary<string, Sex> MockNamesAndSex(int mockCount, List<string> exclusives = null, bool uniq = true, Sex Sex = Sex.不明)
        {
            Dictionary<string, Sex> result = new Dictionary<string, Sex>();

            List<string> mockIndex = new List<string>();

            List<Char> chars = new List<char>();
            if (Sex == Sex.不明)
            {
                chars.AddRange(_lastNameMan.ToCharArray());
                chars.AddRange(_lastNameWoMan.ToCharArray());
            }
            else if (Sex == Sex.男)
            {
                chars.AddRange(_lastNameMan.ToCharArray());
            }
            else
            {
                chars.AddRange(_lastNameWoMan.ToCharArray());
            }
            int index = 0;
            while (index < mockCount)
            {
                int firstIndex = new Random(Guid.NewGuid().GetHashCode()).Next(0, Xing.Count);
                int lastIndex = new Random(Guid.NewGuid().GetHashCode()).Next(0, chars.Count);
                string nameIndex = $"{firstIndex}{lastIndex}";
                if (uniq)
                {
                    if (mockIndex.Contains(nameIndex))
                    {
                        continue;
                    }
                }
                mockIndex.Add(nameIndex);
                string name = Xing[firstIndex] + chars[lastIndex];
                if (exclusives != null && exclusives.Count > 0)
                {
                    if (exclusives.Contains(name))
                        continue;
                }
                Sex sex = Sex.男;
                if (Sex == Sex.不明)
                {
                    if (lastIndex >= _lastNameMan.Length)
                    {
                        sex = Sex.女;
                    }
                }
                else
                    sex = Sex;

                result.Add(name, sex);
                index++;
            }
            return result;
        }

        /// <summary>
        /// 集合随机选取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ts"></param>
        /// <param name="selectCount"></param>
        /// <returns></returns>
        public static List<T> Selector<T>(this List<T> ts, int selectCount)
        {
            List<T> result = new List<T>();
            int index = 0;
            List<int> mockIndex = new List<int>();
            while (index < selectCount)
            {
                int selIndex = new Random(Guid.NewGuid().GetHashCode()).Next(0, ts.Count);
                if (mockIndex.Contains(selIndex))
                    continue;
                mockIndex.Add(selIndex);
                result.Add(ts[selIndex]);
                index++;
            }

            return result;
        }

        private static List<string> Xing = new List<string>() {"赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯", "陈", "楮", "卫", "蒋", "沈", "韩", "杨",
        "朱", "秦", "尤", "许", "何", "吕", "施", "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜",
        "戚", "谢", "邹", "喻", "柏", "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎",
        "鲁", "韦", "昌", "马", "苗", "凤", "花", "方", "俞", "任", "袁", "柳", "酆", "鲍", "史", "唐",
        "费", "廉", "岑", "薛", "雷", "贺", "倪", "汤", "滕", "殷", "罗", "毕", "郝", "邬", "安", "常",
        "乐", "于", "时", "傅", "皮", "卞", "齐", "康", "伍", "余", "元", "卜", "顾", "孟", "平", "黄",
        "和", "穆", "萧", "尹", "姚", "邵", "湛", "汪", "祁", "毛", "禹", "狄", "米", "贝", "明", "臧",
        "计", "伏", "成", "戴", "谈", "宋", "茅", "庞", "熊", "纪", "舒", "屈", "项", "祝", "董", "梁",
        "杜", "阮", "蓝", "闽", "席", "季", "麻", "强", "贾", "路", "娄", "危", "江", "童", "颜", "郭",
        "梅", "盛", "林", "刁", "锺", "徐", "丘", "骆", "高", "夏", "蔡", "田", "樊", "胡", "凌", "霍",
        "虞", "万", "支", "柯", "昝", "管", "卢", "莫", "经", "房", "裘", "缪", "干", "解", "应", "宗",
        "丁", "宣", "贲", "邓", "郁", "单", "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚",
        "程", "嵇", "邢", "滑", "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麹", "家", "封",
        "芮", "羿", "储", "靳", "汲", "邴", "糜", "松", "井", "段", "富", "巫", "乌", "焦", "巴", "弓",
        "牧", "隗", "山", "谷", "车", "侯", "宓", "蓬", "全", "郗", "班", "仰", "秋", "仲", "伊", "宫",
        "宁", "仇", "栾", "暴", "甘", "斜", "厉", "戎", "祖", "武", "符", "刘", "景", "詹", "束", "龙",
        "叶", "幸", "司", "韶", "郜", "黎", "蓟", "薄", "印", "宿", "白", "怀", "蒲", "邰", "从", "鄂",
        "索", "咸", "籍", "赖", "卓", "蔺", "屠", "蒙", "池", "乔", "阴", "郁", "胥", "能", "苍", "双",
        "闻", "莘", "党", "翟", "谭", "贡", "劳", "逄", "姬", "申", "扶", "堵", "冉", "宰", "郦", "雍",
        "郤", "璩", "桑", "桂", "濮", "牛", "寿", "通", "边", "扈", "燕", "冀", "郏", "浦", "尚", "农",
        "温", "别", "庄", "晏", "柴", "瞿", "阎", "充", "慕", "连", "茹", "习", "宦", "艾", "鱼", "容",
        "向", "古", "易", "慎", "戈", "廖", "庾", "终", "暨", "居", "衡", "步", "都", "耿", "满", "弘",
        "匡", "国", "文", "寇", "广", "禄", "阙", "东", "欧", "殳", "沃", "利", "蔚", "越", "夔", "隆",
        "师", "巩", "厍", "聂", "晁", "勾", "敖", "融", "冷", "訾", "辛", "阚", "那", "简", "饶", "空",
        "曾", "毋", "沙", "乜", "养", "鞠", "须", "丰", "巢", "关", "蒯", "相", "查", "后", "荆", "红",
        "游", "竺", "权", "逑", "盖", "益", "桓", "公", "仉", "督", "晋", "楚", "阎", "法", "汝", "鄢",
        "涂", "钦", "岳", "帅", "缑", "亢", "况", "后", "有", "琴", "归", "海", "墨", "哈", "谯", "笪",
        "年", "爱", "阳", "佟", "商", "牟", "佘", "佴", "伯", "赏",
        "万俟", "司马", "上官", "欧阳", "夏侯", "诸葛", "闻人", "东方", "赫连", "皇甫", "尉迟", "公羊",
        "澹台", "公冶", "宗政", "濮阳", "淳于", "单于", "太叔", "申屠", "公孙", "仲孙", "轩辕", "令狐",
        "锺离", "宇文", "长孙", "慕容", "鲜于", "闾丘", "司徒", "司空", "丌官", "司寇", "子车", "微生",
        "颛孙", "端木", "巫马", "公西", "漆雕", "乐正", "壤驷", "公良", "拓拔", "夹谷", "宰父", "谷梁",
        "段干", "百里", "东郭", "南门", "呼延", "羊舌", "梁丘", "左丘", "东门", "西门", "南宫"};

        private static string _lastNameMan = "刚伟勇毅俊峰强军平保东文辉力明永健世广志义兴良海山仁波宁贵福生龙元全国胜学祥才发武新利清飞彬富顺信子杰涛昌成康星光天达安岩中茂进林有坚和彪博诚先敬震振壮会思群豪心邦承乐绍功松善厚庆磊民友裕河哲江超浩亮政谦亨奇固之轮翰朗伯宏言若鸣朋斌梁栋维启克伦翔旭鹏泽晨辰士以建家致树炎德行时泰盛雄琛钧冠策腾楠榕风航弘";


        private static string _lastNameWoMan = "秀娟英华慧巧美娜静淑惠珠翠雅芝玉萍红娥玲芬芳燕彩春菊兰凤洁梅琳素云莲真环雪荣爱妹霞香月莺媛艳瑞凡佳嘉琼勤珍贞莉桂娣叶璧璐娅琦晶妍茜秋珊莎锦黛青倩婷姣婉娴瑾颖露瑶怡婵雁蓓纨仪荷丹蓉眉君琴蕊薇菁梦岚苑婕馨瑗琰韵融园艺咏卿聪澜纯毓悦昭冰爽琬茗羽希宁欣飘育滢馥筠柔竹霭凝鱼晓欢霄枫芸菲寒伊亚宜可姬舒影荔枝思丽墨";


    }
}
