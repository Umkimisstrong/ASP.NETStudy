using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Request
{
    public class RequestBase
    {
        #region 페이징 관련 데이터
        /// <summary>
        /// 페이지 당 게시물 수
        /// </summary>
        public int ROW_COUNT { get; set; } = 20;

        /// <summary>
        /// 페이지 번호
        /// </summary>
        public int PAGE_NUMBER { get; set; } = 1;

        /// <summary>
        /// 페이지 정렬
        /// </summary>
        public string PAGE_SORT { get; set; }
        #endregion
    }
}