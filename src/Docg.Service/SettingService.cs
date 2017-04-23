using Docg.Domain;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Docg.Service
{
    /// <summary>
    /// 服务：设置
    /// </summary>
    public class SettingService
    {
        /// <summary>
        /// 获取设置详情
        /// </summary>
        /// <returns></returns>
        public Setting GetSetting()
        {
            //var path = Path.Combine(@"C:\works\docg\src\Docg.UI", @"\resource\setting.xml");
            var doc = XDocument.Load(@"C:\works\docg\src\Docg.UI\resource\setting.xml");
            if (doc == null)
                return null;

            var setting = new Setting();

            var eles = from d in doc.Descendants("setting").Elements("style")
                       select new Style
                       {
                           Name = d.Attribute("name").Value,
                           FontSize = Convert.ToInt32(d.Attribute("size").Value),
                           IsBold = string.Equals(d.Attribute("bold").Value, "true")
                       };
            if (!eles.Any())
                return null;

            foreach (var ele in eles)
            {
                switch (ele.Name)
                {
                    case "主题":
                        setting.Theme = ele;
                        break;

                    case "一级标题":
                        setting.Title1 = ele;
                        break;

                    case "二级标题":
                        setting.Title2 = ele;
                        break;

                    case "三级标题":
                        setting.Title3 = ele;
                        break;

                    case "正文":
                        setting.Content = ele;
                        break;
                    default:
                        break;
                }
            }
            return setting;
        }
    }
}