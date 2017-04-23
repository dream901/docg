using Docg.Service;
using System.Windows.Forms;

namespace Docg.UI
{
    /// <summary>
    /// 设置界面
    /// </summary>
    public partial class SettingFrm : Form
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SettingFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetFrm_Load(object sender, System.EventArgs e)
        {
            var settingService = new SettingService();
            var setting = settingService.GetSetting();

            // 设置主题
            this.lbTheme.Text = setting.Theme.Name;
            this.txtTheme.Text = setting.Theme.FontSize.ToString();
            this.rbThemeY.Checked = setting.Theme.IsBold;
            this.rbThemeN.Checked = !this.rbThemeY.Checked;

            // 设置一级标题
            this.lbTitle1.Text = setting.Title1.Name;
            this.txtTitle1.Text = setting.Title1.FontSize.ToString();
            this.rbTitle1Y.Checked = setting.Title1.IsBold;
            this.rbTitle1N.Checked = !this.rbTitle1Y.Checked;

            // 设置二级标题
            this.lbTitle2.Text = setting.Title2.Name;
            this.txtTitle2.Text = setting.Title2.FontSize.ToString();
            this.rbTitle2Y.Checked = setting.Title2.IsBold;
            this.rbTitle2N.Checked = !this.rbTitle2Y.Checked;

            // 设置三级标题
            this.lbTitle3.Text = setting.Title3.Name;
            this.txtTitle3.Text = setting.Title3.FontSize.ToString();
            this.rbTitle3Y.Checked = setting.Title3.IsBold;
            this.rbTitle3N.Checked = !this.rbTitle3Y.Checked;

            // 设置正文
            this.lbContent.Text = setting.Content.Name;
            this.txtContent.Text = setting.Content.FontSize.ToString();
            this.rbContentY.Checked = setting.Content.IsBold;
            this.rbContentN.Checked = !this.rbContentY.Checked;
        }
    }
}