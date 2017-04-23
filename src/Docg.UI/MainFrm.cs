using System;
using System.Windows.Forms;

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
    }
}