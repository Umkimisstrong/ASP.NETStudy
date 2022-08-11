using Mosti.Fundamentals.ExtensionMethods;
using MvcApp.DB;
using MvcApp.Models.Common;
using MvcApp.Models.Entity;
using MvcApp.Models.Request;
using MvcApp.Models.Response;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;


/// <summary>
/// 1. User Controller
/// 2. User 의 정보를 C.R.U.D 및 로그인 액션을 수행하는 컨트롤러
/// </summary>
namespace MvcApp.Controllers
{
    /// <summary>
    /// 유저 관리 Controller
    /// </summary>
    public class UserController : Controller
    {
        /// <summary>
        /// 아무것도 없는 빈 액션
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 로그인 View 로 이동하는 액션 수행
        /// </summary>
        /// <returns></returns>
        [ActionName("Login")]
        public ActionResult LoginUser()
        {
            // 세션이 종료되지 않고 로그아웃 된 경우
            
            if(Session["USER_ID"]!=null)
                ViewBag.log = "nolog";     // 알림 창을 통해 로그인 하라는 메세지를 띄워주는 변수



            return View("LoginUser");
        }


        /// <summary>
        /// 로그인 유효성 검사 액션 수행
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("LoginValidate")]
        public ActionResult LoginValidateUser(string id, string pwd)
        {
            // SampleUserDao 객체 생성
            SampleUserDao dao = new SampleUserDao();
            UserModel request = new UserModel();
            request.USER_ID = id;

            // 결과 담기
            DataSet ds = dao.ReadUser(request);

            int logCheck = 0;
            // ID가 존재한다면 ds에 담긴다. -> 비밀번호검증만하자
            if (ds?.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                // UserList 객체 생성
                List<UserModel> UserList = new List<UserModel>();

                // 사용자가 입력한 Id가 존재할 때,
                // 해당 Id 가 갖는 Pwd 받기위한 변수 선언 및 초기화
                string realPwd = "";

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    // realPwd 담기
                    realPwd = row["USER_PWD"].ToString();
                }

                // 입력한 pwd 와 실제 pwd 가 일치하지 않는 경우
                if (!realPwd.Equals(pwd))
                {
                    logCheck = 1;
                    ViewBag.flag = logCheck;
                    return View("LoginUser");
                }

                // 로그인에 성공하면 해당 id로 세션생성
                Session["USER_ID"] = id;

                // List 액션 수행
                return RedirectToAction("List");
            }
            
            // ds 에 아무것도 없다면 ID 가 없다는 결론
            ViewBag.flag = logCheck;
            return View("LoginUser");
        }

        /// <summary>
        /// 로그아웃 액션 수행
        /// </summary>
        /// <returns></returns>
        [ActionName("Logout")]
        public ActionResult LogoutUser()
        {
            Session.Clear();
            return View("LoginUser");
        }

        /// <summary>
        /// 1. 신규 유저 등록 시 Ajax로 ID 중복 여부 확인 액션 수행
        /// 2. Ajax 요청을 통해 진입했기 때문에, 세션이 없을 시 Json으로 logCheck 을 nolog 로 반환
        /// 3. Ajax 에서 nolog 를 받아 location.href = 로그인URL 로 이동
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("CheckUser")]
        public ActionResult CheckUser(string id)
        {
            // Session 을 검증할 logCheck 변수 선언 및 초기화
            var logCheck = "";

            if (Session["USER_ID"] == null)
            {
                // Session 이 없다면 : logCheck = nolog
                logCheck = "nolog";
                // Json으로 logCheck 을 보낸다. 
                return Json(logCheck);
            }


            // SampleUserDao 객체 생성
            SampleUserDao dao = new SampleUserDao();

            // id 세팅
            UserModel request = new UserModel();
            request.USER_ID = id;

            // 입력한 id로 1명의 데이터 추출
            // 결과 담기
            DataSet ds = dao.ReadUser(request);

            // 메세지를 담기위한 변수 선언 및 초기화
            var msg = "";

            // ID가 존재한다면 ds에 담긴다
            if (ds?.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                // Json 을 통해 값 전달, ID 입력 하단부에 출력
                msg = "이미 존재하는 아이디입니다.";
                return Json(msg);
            }

            // Json 을 통해 값 전달, ID 입력 하단부에 출력
            msg = "사용 가능한 아이디 입니다.";
            return Json(msg);
        }




        /// <summary>
        /// 유저 목록 조회
        /// </summary>
        /// <returns></returns>
        // TODO : [완료] 유저 목록을 조회하고, 목록정보를 화면에 띄웁니다.
        [ActionName("List")]
        public ActionResult ListUser(UserRequest request)
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
            {
                // 없으면 ViewBag 에 nolog를 던지고
                ViewBag.log = "nolog";
                // 로그인 화면으로 이동
                return View("LoginUser");
            }
            else
                ViewBag.log = "log";


            // 01. request 객체 생성
            // UserRequest request = new UserRequest();
            // 최초에는 새로운 request 객체를 생성했으나, 검색이 추가되면서 매개변수로 request 를 받는다. 
            // 해당 request 안에는 검색값을 포함한 데이터가 들어있다.
            // 검색값이 없다면 전체 리스트를 조회하도록 SampleUserDao 가 구성되어있다.

            // --- 비지니스 로직, 특정 과업을 처리하기 위한 객체 dao ---
            // 02. SampleUserDao 객체 생성
            SampleUserDao dao = new SampleUserDao();

            
            // DataSet 을 반환하는 dao 의 ListUser() 메소드 실행
            DataSet ds = dao.ListUser(request);

            // --- 검색 값 유지를 위한 객체 response ---
            // UserResponse 모델의 객체 생성, 속성 담기
            UserResponse response = new UserResponse()
            {
                //SEARCH_DATE_FROM = request.SEARCH_DATE_FROM,          --> SEARCH_DATE_FROM : 특정 데이터(날짜)의 경우 FORMAT 이 변경되어 사용하는 경우가 있으므로,
                                                                        //                           원본데이터 SEARCH_DATE_FROM 을 사용하는 것이 아닌, 변형된 데이터를 세팅한다.
                                                                        //                           따라서 해당 데이터는 Model 설계 시 getter 는 항상 null 을 반환하도록 한다.
                                                                        //                           원본 데이터를 직접 get 해서 사용하지 않도록 하는 의미도 있다.

                                                                        //  SEARCH_DATE_TO   : 마찬가지
                SEARCH_DATE_FROM = request.CREATE_TIME_YMDHM_FROM,
                SEARCH_DATE_TO = request.CREATE_TIME_YMDHM_TO,
                SEARCH_TYPE = request.SEARCH_TYPE,
                SEARCH_WORD = request.SEARCH_WORD,
                ROW_COUNT = request.ROW_COUNT,
                PAGE_NUMBER = request.PAGE_NUMBER,
                PET = request.PET,
                FAVORITE_SEASON = request.FAVORITE_SEASON,
            };
            

            // ds의 Table이 null 이 아니면서 Rows 가 있는 경우에
            if (ds?.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                // TODO : [완료] 모델 설정이 다되면 주석해제후 확인해보세요.
                // ds를 List화 해서 response 에 담고
                response.UserList = ds.Tables[0].ToListT<UserModel>();
                response.IsResult = true;
                // 사용자에게 보여줄 수 있는 flag, 사용하진 않는다.
            }
            // ListUser View 에 태워보낸다.
            return View("ListUser", response);

        }



        /// <summary>
        /// 유저 목록 검색 조회
        /// </summary>
        /// <returns></returns>
        // TODO : [과제] 유저의 상세 정보를 검색 조건에 따라 조회하고, 화면에 띄웁니다.
        [HttpPost]
        [ActionName("SEARCH")]
        public ActionResult SearchUser(UserRequest request) 
        {
            // 세션이 만료된 채로 검색 시
            // 리스트 출력 영역에 로그인 페이지로 이동되는 현상 발견
            // 따라서 Ajax 요청 시
            // Json 으로 logCheck 을 nolog 로 반환함으로써
            // success 시 해당 data 로 분기
            // nolog 시 location.href = "로그인URL" 로 보내어진다.
            // 세션 확인
            var logCheck = "";
            if (Session["USER_ID"] == null)
            {
                logCheck = "nolog";
                return Json(logCheck);
            }

            // 세션이 존재한다면,
            // 검색값들을 토대로 List 액션을 수행한다.
            return RedirectToAction("List", request);
        }

        /// <summary>
        /// 유저 상세 조회 화면
        /// </summary>
        /// <returns></returns>
        // TODO : [완료] 유저의 상세 정보를 조회하고, 화면에 띄웁니다.
        // TODO : [완료] Action 명은 "Details" 로 지정하세요.
        [HttpPost]
        [ActionName("Details")]
        public ActionResult DetailsUser(string id, UserRequest request) 
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
            {
                ViewBag.log = "nolog";
                return View("LoginUser");
            }
            else
            { 
                ViewBag.log = "log";
            }
            // UserModel 객체 request 생성
            UserModel model = new UserModel();

            // UserModel 의 USER_ID 를 받음
            model.USER_ID = id;

            // SampleUserDAO 의 ReadUser() 메소드를 사용하기 위한 dao 객체 생성
            SampleUserDao dao = new SampleUserDao();

            // ReadUser() 메소드가 반환하는 DataSet 을 담기위한 ds 객체 생성
            DataSet ds = new DataSet();

            //                  ↕ 연결해도 된다.  -- DataSet ds = dao.ReadUser(model);

            // ds 에 담기
            ds = dao.ReadUser(model);

            // UserResponse 객체 response를 생성
            UserResponse response = new UserResponse()
            {
                SEARCH_DATE_FROM = request.CREATE_TIME_YMDHM_FROM,
                SEARCH_DATE_TO = request.CREATE_TIME_YMDHM_TO,
                SEARCH_TYPE = request.SEARCH_TYPE,
                SEARCH_WORD = request.SEARCH_WORD,
                ROW_COUNT = request.ROW_COUNT,
                PAGE_NUMBER = request.PAGE_NUMBER,
                PET = request.PET,
                FAVORITE_SEASON = request.FAVORITE_SEASON
            }; 

            // response 에 List 를 반환하기 위한 ds 조건 설정 ▼▼▼
            // ds의 Table 이 null 이 아니면서, ds 의 Table의 0번째 의 행의 갯수가 0 초과일때(user 1명을 조회하고 나온 결과가 있을때)
            if (ds?.Tables != null && ds.Tables[0].Rows.Count > 0)
            {
                // response 해당 모델이 가진 List<UserModel> 에 ds 담기
                // response.UserList = ds.Tables[0].ToListT<UserModel>();

                // Entity 는 하나의 Model 을 반환하는 메소드로, Details 액션의 경우 리스트가 필요하지 않기 때문에 이 메소드를 쓰는것이 낫다.
                response.userModel = ds.Tables[0].Rows[0].ToEntity<UserModel>();    
                

                // DataRow 로 받기
                // DataRow 
                // = ds.Tables[0].Rows[0].ToEntity<UserModel>();

                response.IsResult = true;
            }
            
            // 완료되면 response 객체를 갖고 DetailsUser 로 이동

            return View("DetailsUser", response);
        }




        /// <summary>
        /// 유저 정보 등록/수정 화면
        /// </summary>
        /// <returns></returns>
        // TODO : [완료] 등록과 수정을 처리할 화면을 띄웁니다.
        // TODO : [완료] Action 명은 "Write" 로 지정하세요.
        // TODO : [완료] flag 값으로 모드를 사용해 화면을 다르게 표출하세요.                -- ViewBag
        // TODO : [완료] Model이 아닌 데이터 보존방식을 이용해, 화면을 바인딩을 제어하세요. -- ViewBag
        [HttpPost]
        [ActionName("Write")]
        public ActionResult WriteUser(string mode, string USER_ID, UserRequest request)
        {
            // 세션 확인
            string logUser = "";
            if (Session["USER_ID"] == null)
            {
                ViewBag.log = "nolog";
                return View("LoginUser");
            }
            else
            { 
                logUser = Session["USER_ID"].ToString();
                ViewBag.log = "log";
            }

            // mode 가 CREATE 이면 : 등록 VIEW 로 리턴 
            // mode 가 UPDATE 이면 : 수정 VIEW 로 리턴
            bool flag = true;

            /*      --> DropDownList 를 사용하기 위한 구문
            List<SelectListItem> season_list = GetDropDownList("FAVORITE_SEASON");
            List<SelectListItem> pet_list = GetDropDownList("PET");
            */

            //      --> DropDownList 에 출력할 List 를 담기
            //ViewBag.FAVORITE_SEASON = season_list;
            //ViewBag.PET = pet_list;

            if (mode.Equals("CREATE"))
            {
                // 등록 View
                ViewBag.flag = flag;
                ViewBag.logUser = logUser;

                UserResponse response = new UserResponse()
                {
                    SEARCH_DATE_FROM = request.CREATE_TIME_YMDHM_FROM,
                    SEARCH_DATE_TO = request.CREATE_TIME_YMDHM_TO,
                    SEARCH_TYPE = request.SEARCH_TYPE,
                    SEARCH_WORD = request.SEARCH_WORD,
                    ROW_COUNT = request.ROW_COUNT,
                    PAGE_NUMBER = request.PAGE_NUMBER,
                    PET = request.PET,
                    FAVORITE_SEASON = request.FAVORITE_SEASON
                };

                return View("WriteUser", response);
            }
            else if (mode.Equals("UPDATE"))
            {
                // 수정 View 
                flag = false;
                ViewBag.flag = flag;

                // 수정 View 에 가져갈 기존 User 의 데이터 추출 ▼

                // SampleUserDao 객체 생성
                SampleUserDao dao = new SampleUserDao();

                // DataSet 객체 생성
                DataSet ds = new DataSet();

                // UserModel 객체 생성
                UserModel model = new UserModel();

                // 넘겨받은 USER_SEQ 세팅
                model.USER_ID = USER_ID;

                // dao 의 ReadUser() 를 통해 DataSet 반환
                ds = dao.ReadUser(model);

                // UserResponse 객체 생성 후 ds 를 List 에 담을준비
                UserResponse response = new UserResponse()
                {
                    SEARCH_DATE_FROM = request.CREATE_TIME_YMDHM_FROM,
                    SEARCH_DATE_TO = request.CREATE_TIME_YMDHM_TO,
                    SEARCH_TYPE = request.SEARCH_TYPE,
                    SEARCH_WORD = request.SEARCH_WORD,
                    ROW_COUNT = request.ROW_COUNT,
                    PAGE_NUMBER = request.PAGE_NUMBER,
                    PET = request.PET,
                    FAVORITE_SEASON = request.FAVORITE_SEASON
                };

                // List 에담아서 수정 View 로 가져감
                // ds 에 담겨서 데이터가 존재한다면 
                if (ds.Tables != null && ds.Tables[0].Rows.Count > 0)
                    response.UserList = ds.Tables[0].ToListT<UserModel>();  // 담고
                
                return View("WriteUser", response);     // WriteUser View 로 response 객체(List<UserModel>) 가져감
            }
            else
                return View("Error");
            
        }



        /// <summary>
        /// 유저 정보 등록 액션 수행 
        /// </summary>
        /// <returns></returns>
        // TODO : [완료] 유저정보를 등록
        [HttpPost]
        [ActionName("CREATE")]
        public ActionResult CreateUser(UserModel model)
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
            {
                ViewBag.log = "nolog";
                return View("LoginUser");
            }

            int result = 0;
            SampleUserDao dao = new SampleUserDao();
            result = dao.CreateUser(model);
            if(result > 0)
                return RedirectToAction("List");

            return RedirectToAction("List");

        }

        /// <summary>
        /// 유저 정보 수정 액션 수행
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Update")]
        public ActionResult UpdateUser(UserModel model)
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
            {
                ViewBag.log = "nolog";
                return View("LoginUser");
            }
            else
                ViewBag.log = "log";
            int result = 0;

            // SampleUserDao 객체 생성
            SampleUserDao dao = new SampleUserDao();

            // 수정 액션 처리 -> 수정된 행 갯수 반환
            result = dao.UpdateUser(model);

            // 수정이 성공하면
            if (result > 0)
                return RedirectToAction("List");

            return View("Home/Index");
        }


        /// <summary>
        /// 유저 정보 삭제 
        /// </summary>
        /// <returns></returns>
        // TODO : [완료] 유저 정보를 삭제 처리합니다.
        // TODO : [완료] 삭제 처리는 ajax를 이용해 처리합니다. EX) 삭제 후, 리스트 검색 조건 유지 후 재 바인딩
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUser(string USER_ID)
        {
            // 세션 확인
            if (Session["USER_ID"] == null)
            {
                ViewBag.log = "nolog";
                return View("LoginUser");
            }
            else
                ViewBag.log = "log";

            // SampleUserDao 의 DeleteUser(UserModel) 는 bool 을 반환하고,
            // 해당 bool 을 활용하기 위한 flag 용 bool 생성
            bool delCheck = false;

            // UserModel 객체 생성
            UserModel request = new UserModel();

            // 삭제 하기위해 넘겨받은 USER_SEQ 를        Model 의 USER_SEQ로 설정
            request.USER_ID = USER_ID;

            // SampleUserDao 객체 생성
            SampleUserDao dao = new SampleUserDao();

            // 삭제
            delCheck = dao.DeleteUser(request);

            // 삭제완료되면 List 액션을 Redirect
            if (delCheck)
                return RedirectToAction("List");

            // 안되면 에러
            return View("Error");



        }





        // TODO : [질문] DropDown 박스 정보는 메서드를 이용하여 세팅합니다.
        private List<SelectListItem> GetDropDownList(string type)
        {
            // List<SelectListItem> 은 DropDownList를 편리하게 작성하게 하기 위한(DB 컬럼들과 동일한 맥락)
            // 메소드로, 원하는 View 에 간단한 List 형태로 가져가서 출력할 수 있다.


            List<SelectListItem> lstDropDown = new List<SelectListItem>();
            // TODO : [질문] DropDown 박스 정보 세팅 후 반환될 수 있도록 처리


            if (type == "FAVORITE_SEASON")
            {   
                // 좋아하는 계절의 경우
                TextValueItem textValueItem = new TextValueItem();
                textValueItem.TextField = "-- 선택 --";
                textValueItem.ValueField = "";
                lstDropDown.Add( new SelectListItem{ Text = textValueItem.TextField , Value = textValueItem.ValueField});

                textValueItem.TextField = "봄";
                textValueItem.ValueField = "SPRING";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

                textValueItem.TextField = "여름";
                textValueItem.ValueField = "SUMMER";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

                textValueItem.TextField = "가을";
                textValueItem.ValueField = "AUTUMN";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

                textValueItem.TextField = "겨울";
                textValueItem.ValueField = "WINTER";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });                


            }
            else if (type == "PET")
            {
                // 애완동물 유/무의 경우
                TextValueItem textValueItem = new TextValueItem();
                textValueItem.TextField = "-- 선택 --";
                textValueItem.ValueField = "";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

                textValueItem.TextField = "없음";
                textValueItem.ValueField = "N";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

                textValueItem.TextField = "있음";
                textValueItem.ValueField = "Y";
                lstDropDown.Add(new SelectListItem { Text = textValueItem.TextField, Value = textValueItem.ValueField });

            }
            return lstDropDown;
        }


    }
}