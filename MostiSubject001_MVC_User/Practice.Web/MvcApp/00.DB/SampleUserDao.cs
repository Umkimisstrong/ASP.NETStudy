using MvcApp.Models.Entity;
using MvcApp.Models.Request;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace MvcApp.DB
{
    /// <summary>
    /// MVC 실습용 유저 정보
    /// </summary>
    public class SampleUserDao
    {
        /// <summary>
        ///  [SAMPLE] USER 목록 조회
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DataSet ListUser(UserRequest request)
        {
            // 01. 파라미터 생성
            Dictionary<string, object> arrParamNames = new Dictionary<string, object>();
            arrParamNames.Add("@SEARCH_TYPE", request.SEARCH_TYPE);
            arrParamNames.Add("@SEARCH_WORD", request.SEARCH_WORD);
            arrParamNames.Add("@PET", request.PET);
            arrParamNames.Add("@SEASON", request.FAVORITE_SEASON);
            arrParamNames.Add("@CREATE_TIME_FROM", request.CREATE_TIME_YMDHM_FROM);
            arrParamNames.Add("@CREATE_TIME_TO", request.CREATE_TIME_YMDHM_TO);
            arrParamNames.Add("@PAGE_NUMBER", request.PAGE_NUMBER);
            arrParamNames.Add("@ROW_COUNT", request.ROW_COUNT);

            // 02. 쿼리 실행
            string strSPName = "UP_SAMPLE_USER_L";   // DB Connection 정보 
            DataSet dsResult = SqlHelper.ExecuteFillDataSet(ConfigurationManager.AppSettings["Data_Base"], strSPName, arrParamNames);

            return dsResult;
        }

        /// <summary>
        /// USER 상세 조회
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DataSet ReadUser(UserModel request)
        {
            // 01. 파라미터 생성
            Dictionary<string, object> arrParamNames = new Dictionary<string, object>();
            // TODO : [완료] 필요한 PARAM을 설정하세요.
            // 필요한 PARAM - @USER_SEQ   INT

            arrParamNames.Add("@USER_ID", request.USER_ID);

            
            // 02. 쿼리 실행
            string strSPName = "UP_SAMPLE_USER_R";   // DB Connection 정보 
            DataSet dsResult = SqlHelper.ExecuteFillDataSet(ConfigurationManager.AppSettings["Data_Base"], strSPName, arrParamNames);


            // 03. 데이터셋 반환
            return dsResult;
        }

        /// <summary>
        /// USER 정보 입력/수정
        /// </summary>
        /// <param name="request"></param>
        /// <param name="saveMode"></param>
        /// <returns></returns>
        public bool SaveUser(UserModel request, string saveMode)
        {
            // 01. 반환 개체 생성
            bool response = false;
            int iResult = 0;

            // 02. 구분값에 따른 입력/수정
            if (saveMode.Equals("CREATE"))
                iResult = CreateUser(request);
            else if (saveMode.Equals("UPDATE"))
                iResult = UpdateUser(request);

            if (iResult > 0)
                response = true;

            return response;
        }

        /// <summary>
        /// USER 정보 입력
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int CreateUser(UserModel request)
        {
            // 01. 반환  개체 생성   
            int iResult = 0;

            // 02. 파라미터 생성
            Dictionary<string, object> arrParamNames = new Dictionary<string, object>();
            // TODO : [완료] 필요한 PARAM을 설정하세요.

            // 사용자 등록을 위해 필요한 데이터
            // @USER_ID
            arrParamNames.Add("@USER_ID", request.USER_ID);

            // @USER_PWD
            arrParamNames.Add("@USER_PWD", request.USER_PWD);

            // @USER_NM
            arrParamNames.Add("@USER_NM", request.USER_NM);

            // @USER_BIRTH
            arrParamNames.Add("@USER_BIRTH", request.USER_BIRTH);

            // @HOBBY
            arrParamNames.Add("@HOBBY", request.HOBBY);

            // @LIKE_THINGS
            arrParamNames.Add("@LIKE_THINGS", request.LIKE_THINGS);

            // @DISLIKE_THINGS
            arrParamNames.Add("@DISLIKE_THINGS", request.DISLIKE_THINGS);

            // @FAVORITE_MOVIE
            arrParamNames.Add("@FAVORITE_MOVIE", request.FAVORITE_MOVIE);

            // @FAVORITE_FOOD
            arrParamNames.Add("@FAVORITE_FOOD", request.FAVORITE_FOOD);

            // @FAVORITE_SEASON
            arrParamNames.Add("@FAVORITE_SEASON", request.FAVORITE_SEASON);

            // @PET
            arrParamNames.Add("@PET", request.PET);

            // @CREATE_USER
            arrParamNames.Add("@CREATE_USER", request.CREATE_USER);



            // 03. 쿼리 실행
            string strSPName = "UP_SAMPLE_USER_C";   // DB Connection 정보 
            iResult = SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["Data_Base"], strSPName, arrParamNames);

            return iResult;
        }

        /// <summary>
        /// USER 정보 수정
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int UpdateUser(UserModel request)
        {
            // 01. 반환  개체 생성   
            int iResult = 0;

            // 02. 파라미터 생성
            Dictionary<string, object> arrParamNames = new Dictionary<string, object>();
            // TODO : [완료] 필요한 PARAM을 설정하세요.

            // 사용자 정보 수정을 위해 필요한 데이터
            // @USER_SEQ
            arrParamNames.Add("@USER_ID", request.USER_ID);

            // @USER_NM
            arrParamNames.Add("@USER_NM", request.USER_NM);

            // @USER_BIRTH
            arrParamNames.Add("@USER_BIRTH", request.USER_BIRTH);

            // @HOBBY
            arrParamNames.Add("@HOBBY", request.HOBBY);

            // @LIKE_THINGS
            arrParamNames.Add("@LIKE_THINGS", request.LIKE_THINGS);

            // @DISLIKE_THINGS
            arrParamNames.Add("@DISLIKE_THINGS", request.DISLIKE_THINGS);

            // @FAVORITE_MOVIE
            arrParamNames.Add("@FAVORITE_MOVIE", request.FAVORITE_MOVIE);

            // @FAVORITE_FOOD
            arrParamNames.Add("@FAVORITE_FOOD", request.FAVORITE_FOOD);

            // @FAVORITE_SEASON
            arrParamNames.Add("@FAVORITE_SEASON", request.FAVORITE_SEASON);

            // @PET
            arrParamNames.Add("@PET", request.PET);

            // @UPDATE_USER
            //arrParamNames.Add("@UPDATE_USER", request.UPDATE_USER);

            // 03. 쿼리 실행
            string strSPName = "UP_SAMPLE_USER_U";   // DB Connection 정보
            iResult = SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["Data_Base"], strSPName, arrParamNames);

            return iResult;
        }

        /// <summary>
        /// USER 정보 삭제
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool DeleteUser(UserModel request)
        {
            // 01. 반환 개체 생성
            bool response = false;

            // 02. 파라미터 생성
            Dictionary<string, object> arrParamNames = new Dictionary<string, object>();
            // TODO : [완료] 필요한 PARAM을 설정하세요.

            // 사용자 삭제를 위해 필요한 데이터
            // @USER_SEQ
            arrParamNames.Add("@USER_ID", request.USER_ID);


            // 03. 쿼리 실행
            string strSPName = "UP_SAMPLE_USER_D";   // DB Connection 정보 
            int iResult = SqlHelper.ExecuteNonQuery(ConfigurationManager.AppSettings["Data_Base"], strSPName, arrParamNames);

            if (iResult > 0)
                response  = true;

            return response;
        }

    }
}