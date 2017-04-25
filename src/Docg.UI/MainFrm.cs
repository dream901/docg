using System;
using System.Windows.Forms;
using Docg.Service;
using Docg.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Docg.UI
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class MainFrm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            //this.Text = "文档生成器v1.0";
            //this.Size = new Size(800, 600);
            //this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.Visible = true;
        }

        /// <summary>
        /// 设置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSet_Click(object sender, EventArgs e)
        {
            SettingFrm frm = new SettingFrm();
            frm.Text = "设置 - " + this.Text;
            frm.Show();
        }

        /// <summary>
        /// 说明按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExplain_Click(object sender, EventArgs e)
        {
            ExplainFrm frm = new ExplainFrm();
            frm.Text = "说明 - " + this.Text;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var txts = new List<InputText>();
            var name = string.Empty;
            var title = string.Empty;
            foreach(var ctrl in this.panel2.Controls)
            {
                Boolean flg = false;
                if (ctrl is RichTextBox)
                {
                    flg = true;
                }
                if (ctrl is TextBox)
                {
                    flg = true;
                }
                if(flg)
                {
                    InputText inputtext = new InputText();
                    name = ctrl.GetType().GetProperty("Name").GetValue(ctrl, null).ToString();
                    title = ctrl.GetType().GetProperty("Text").GetValue(ctrl, null).ToString();
                    inputtext.style = name;
                    inputtext.text = title;
                    txts.Add(inputtext);
                }
            }


            /*************************读取配置样式****************************/

            var setting = new Setting();
            var settingService = new SettingService();
            setting = settingService.GetSetting();
            /*****************************************************************/

            /**************************循环写入文本***************************/

            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document doc = null;

            // 文档生成路径
            Object strFileName = @"D:\test.doc";
            if (System.IO.File.Exists((string)strFileName))
                System.IO.File.Delete((string)strFileName);

            Object Nothing = System.Reflection.Missing.Value;
            Object format = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault;
            
            doc = app.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            app.Selection.ParagraphFormat.FirstLineIndent = 30;//首行缩进的长度

            String content = string.Empty;


            txts.Reverse();
            foreach (var input in txts)
            {
                if (input is InputText)
                {
                    String textContent = input.text;
                    String textType = input.style.Substring(0,6);
                    int size = 0;
                    int isBold = 0;

                    // 设置文本内容
                    
                    doc.Paragraphs.Last.Range.Text = textContent;
                    
                    if (textType == "title0")
                    {
                        // 设置主题样式
                        if (setting.Theme.IsBold)
                        {
                            isBold = 2;
                        }
                        else
                        {
                            isBold = 0;
                        }
                        size = setting.Theme.FontSize;

                        // 字体居中
                        //.Application.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        doc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                    else if (textType == "title1")
                    {
                        // 一级标题
                        if (setting.Title1.IsBold)
                        {
                            isBold = 2;
                        }
                        else
                        {
                            isBold = 0;
                        }
                        size = setting.Title1.FontSize;

                    }
                    else if (textType == "title2")
                    {
                        //  二级标题
                        if (setting.Title2.IsBold)
                        {
                            isBold = 2;
                        }
                        else
                        {
                            isBold = 0;
                        }
                        size = setting.Title2.FontSize;
                    }
                    else if (textType == "title3")
                    {
                        // 三级标题
                        if (setting.Title3.IsBold)
                        {
                            isBold = 2;
                        }
                        else
                        {
                            isBold = 0;
                        }
                        size = setting.Title3.FontSize;
                    }
                    else
                    {
                        // 正文
                        if (setting.Content.IsBold)
                        {
                            isBold = 2;
                        }
                        else
                        {
                            isBold = 0;
                        }
                        size = setting.Content.FontSize;
                    }
                    // 设置字体样式
                    doc.Paragraphs.Last.Range.Bold = isBold;         // 加粗
                    doc.Paragraphs.Last.Range.Font.Size = size;   // 字体大小
                    doc.Paragraphs.Add(ref Nothing);

                }
            }
            // 设置标题居中
            doc.Paragraphs.First.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

            //将doc文档对象的内容保存为DOC文档 

            doc.SaveAs(ref strFileName, ref format, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            //关闭doc文档对象 
            doc.Close(ref Nothing, ref Nothing, ref Nothing);
            //关闭app组件对象 
            app.Quit(ref Nothing, ref Nothing, ref Nothing);

            String strResult = @"文档生成并写入成功" + "\n" + "信息：" + strFileName;

            MessageBox.Show(strResult);
            return;

        }
    }
}