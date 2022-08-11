using MvcApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Response
{
    public class UserResponse : ResponseBase
    {
        #region 검색 관련 Properties

        /// <summary>
        /// 검색분류
        /// </summary>
        public string SEARCH_TYPE { get; set; }

        /// <summary>
        /// 검색어
        /// </summary>
        public string SEARCH_WORD { get; set; }

        /// <summary>
        /// 카테고리
        /// </summary>
        public string PET { get; set; }

        /// <summary>
        /// 계절
        /// </summary>
        public string FAVORITE_SEASON { get; set; }

        /// <summary>
        /// CREATE_TIME_YMDHM 검색 시작일
        /// ex) 201912091005
        /// </summary>
        public string CREATE_TIME_YMDHM_FROM { get; set; }

        /// <summary>
        /// CREATE_TIME_YMDHM 검색 종료일
        /// ex) 201912091955
        /// </summary>
        public string CREATE_TIME_YMDHM_TO { get; set; }

        /// <summary>
        /// 날짜조건 통합 검색 시작일
        /// </summary>
        public string SEARCH_DATE_FROM
        {
            // get {return null}
            //get { return this.SEARCH_DATE_FROM; }
            get { return null; }

            set { if (!string.IsNullOrWhiteSpace(value)) { CREATE_TIME_YMDHM_FROM = value; } }
        }

        /// <summary>
        /// 날짜조건 통합 검색 종료일
        /// </summary>
        public string SEARCH_DATE_TO
        {
            // get {return null;}
            //get { return this.SEARCH_DATE_TO; }
            get { return null; }
            set { if (!string.IsNullOrWhiteSpace(value)) { CREATE_TIME_YMDHM_TO = value; } }
        }

        // User들을 반환하기 위한 List
        public List<UserModel> UserList { get; set; }

        // 한명의 User을 반환하기 위한 UserModel
        public UserModel userModel { get; set; }

        #endregion

        // TODO : [완료] 필요한 모델을 설정 하세요.
    }
}