namespace Docg.Domain
{
    /// <summary>
    /// 模型：设置
    /// </summary>
    public class Setting
    {
        /// <summary>
        /// 主题
        /// </summary>
        public Style Theme { get; set; }

        /// <summary>
        /// 一级标题
        /// </summary>
        public Style Title1 { get; set; }

        /// <summary>
        /// 二级标题
        /// </summary>
        public Style Title2 { get; set; }

        /// <summary>
        /// 三级标题
        /// </summary>

        public Style Title3 { get; set; }

        /// <summary>
        /// 正文
        /// </summary>
        public Style Content { get; set; }
    }
}