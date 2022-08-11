namespace MvcApp.Models.Common
{
    /// <summary>
    /// TODO : [과제] Drop Down List에 항목을 추가할 때 사용합니다.
    /// </summary>
    public class TextValueItem
    {
        /// <summary>
        /// Display Text 필드 입니다.
        /// </summary>
        public string TextField { get; set; }

        /// <summary>
        /// Select Value 필드 입니다.
        /// </summary>
        public string ValueField { get; set; }
    }
}