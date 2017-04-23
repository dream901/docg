using Docg.Domain;
using Docg.Service;
using System;
using System.Windows.Forms;

namespace Docg.UI
{
    /// <summary>
    /// 设置界面
    /// </summary>
    public partial class SettingFrm : Form
    {
        private SettingService _settingService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SettingFrm()
        {
            InitializeComponent();
            _settingService = new SettingService();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetFrm_Load(object sender, System.EventArgs e)
        {
            SetValue();
        }

        /// <summary>
        /// 保存按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, System.EventArgs e)
        {
            this.tsbSave.Enabled = false;
            var model = GetValue();
            var modified = _settingService.SetSetting(model);
            if (modified)
            {
                SetValue();
                MessageBox.Show("保存成功！");
            }
            this.tsbSave.Enabled = true;
        }

        /// <summary>
        /// 更新按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbUpdate_Click(object sender, System.EventArgs e)
        {
            this.tsbUpdate.Enabled = false;
            SetValue();
            this.tsbUpdate.Enabled = true;
        }

        /// <summary>
        /// 退出按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbExit_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 获取界面显示的值
        /// </summary>
        /// <returns></returns>
        private Setting GetValue()
        {
            var model = new Setting();

            model.Theme = new Style
            {
                Name = this.lbTheme.Text,
                FontSize = Convert.ToInt32(this.txtTheme.Text),
                IsBold = this.rbThemeY.Checked
            };

            model.Title1 = new Style
            {
                Name = this.lbTitle1.Text,
                FontSize = Convert.ToInt32(this.txtTitle1.Text),
                IsBold = this.rbTitle1Y.Checked
            };

            model.Title2 = new Style
            {
                Name = this.lbTitle2.Text,
                FontSize = Convert.ToInt32(this.txtTitle2.Text),
                IsBold = this.rbTitle2Y.Checked
            };

            model.Title3 = new Style
            {
                Name = this.lbTitle3.Text,
                FontSize = Convert.ToInt32(this.txtTitle3.Text),
                IsBold = this.rbTitle3Y.Checked
            };

            model.Content = new Style
            {
                Name = this.lbContent.Text,
                FontSize = Convert.ToInt32(this.txtContent.Text),
                IsBold = this.rbContentY.Checked
            };
            return model;
        }

        /// <summary>
        /// 设置界面显示的值
        /// </summary>
        /// <param name="model"></param>
        private void SetValue(Setting model = null)
        {
            if (model == null)
                model = _settingService.GetSetting();

            // 设置主题
            this.lbTheme.Text = model.Theme.Name;
            this.txtTheme.Text = model.Theme.FontSize.ToString();
            this.rbThemeY.Checked = model.Theme.IsBold;
            this.rbThemeN.Checked = !this.rbThemeY.Checked;

            // 设置一级标题
            this.lbTitle1.Text = model.Title1.Name;
            this.txtTitle1.Text = model.Title1.FontSize.ToString();
            this.rbTitle1Y.Checked = model.Title1.IsBold;
            this.rbTitle1N.Checked = !this.rbTitle1Y.Checked;

            // 设置二级标题
            this.lbTitle2.Text = model.Title2.Name;
            this.txtTitle2.Text = model.Title2.FontSize.ToString();
            this.rbTitle2Y.Checked = model.Title2.IsBold;
            this.rbTitle2N.Checked = !this.rbTitle2Y.Checked;

            // 设置三级标题
            this.lbTitle3.Text = model.Title3.Name;
            this.txtTitle3.Text = model.Title3.FontSize.ToString();
            this.rbTitle3Y.Checked = model.Title3.IsBold;
            this.rbTitle3N.Checked = !this.rbTitle3Y.Checked;

            // 设置正文
            this.lbContent.Text = model.Content.Name;
            this.txtContent.Text = model.Content.FontSize.ToString();
            this.rbContentY.Checked = model.Content.IsBold;
            this.rbContentN.Checked = !this.rbContentY.Checked;
        }
    }
}