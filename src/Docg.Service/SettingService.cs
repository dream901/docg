using Docg.Domain;
using System;
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
        /// 文件路径
        /// </summary>
        public string XmlFilePath;

        public SettingService()
        {
            //var path = Path.Combine(@"C:\works\docg\src\Docg.UI", @"\resource\setting.xml");
            XmlFilePath = @"C:\works\docg\src\Docg.UI\Resources\setting.xml";
        }

        /// <summary>
        /// 获取设置详情
        /// </summary>
        /// <returns></returns>
        public Setting GetSetting()
        {
            try
            {
                var doc = XDocument.Load(XmlFilePath);
                if (doc == null)
                    return null;

                var setting = new Setting();

                var nodes = doc.Element("setting").Elements("style");
                var styles = from d in nodes
                             select new Style
                             {
                                 Name = d.Element("name").Value,
                                 FontSize = Convert.ToInt32(d.Element("size").Value),
                                 IsBold = string.Equals(d.Element("bold").Value, "true")
                             };
                if (!styles.Any())
                    return null;

                foreach (var ele in styles)
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SetSetting(Setting model)
        {
            try
            {
                var doc = XDocument.Load(XmlFilePath);
                if (doc == null)
                    return false;
                var nodes = doc.Element("setting").Elements("style");
                if (!nodes.Any())
                    return false;

                foreach (var ele in nodes)
                {
                    switch (ele.Element("name").Value)
                    {
                        case "主题":
                            ele.Element("name").SetValue(model.Theme.Name);
                            ele.Element("size").SetValue(model.Theme.FontSize);
                            ele.Element("bold").SetValue(model.Theme.IsBold.ToString().ToLower());
                            break;

                        case "一级标题":
                            ele.Element("name").SetValue(model.Title1.Name);
                            ele.Element("size").SetValue(model.Title1.FontSize);
                            ele.Element("bold").SetValue(model.Title1.IsBold.ToString().ToLower());
                            break;

                        case "二级标题":
                            ele.Element("name").SetValue(model.Title2.Name);
                            ele.Element("size").SetValue(model.Title2.FontSize);
                            ele.Element("bold").SetValue(model.Title2.IsBold.ToString().ToLower());
                            break;

                        case "三级标题":
                            ele.Element("name").SetValue(model.Title3.Name);
                            ele.Element("size").SetValue(model.Title3.FontSize);
                            ele.Element("bold").SetValue(model.Title3.IsBold.ToString().ToLower());
                            break;

                        case "正文":
                            ele.Element("name").SetValue(model.Content.Name);
                            ele.Element("size").SetValue(model.Content.FontSize);
                            ele.Element("bold").SetValue(model.Content.IsBold.ToString().ToLower());
                            break;

                        default:
                            break;
                    }
                }
                doc.Save(XmlFilePath);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}