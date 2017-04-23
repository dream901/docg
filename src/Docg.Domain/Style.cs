namespace Docg.Domain
{
    /// <summary>
    /// 模型：样式
    /// </summary>
    public class Style
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 是否加粗
        /// </summary>
        public bool IsBold { get; set; }
    }
}