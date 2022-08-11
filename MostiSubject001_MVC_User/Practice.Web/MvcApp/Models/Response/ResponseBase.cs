using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Response
{
    public class ResponseBase
    {
        /// <summary>
        /// Response 결과 
        /// </summary>
        public bool IsResult { get; set; }

        /// <summary>
        /// Response 결과 데이터
        /// </summary>
        public object ResultData { get; set; }

        #region 페이징 관련 데이터
        /// <summary>
        /// 페이지 번호
        /// </summary>
        public int PAGE_NUMBER { get; set; }

        /// <summary>
        /// 페이지 정렬
        /// </summary>
        public string PAGE_SORT { get; set; }

        /// <summary>
        /// 페이지 당 게시물 수
        /// </summary>
        public int ROW_COUNT { get; set; }

        /// <summary>
        /// 전체 게시물 수
        /// </summary>
        public int TOTAL_COUNT { get; set; }
        #endregion
    }
}