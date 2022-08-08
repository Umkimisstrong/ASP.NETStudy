using MostiSubject_MVC_Board.DataBase.Task;
using MostiSubject_MVC_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MostiSubject_MVC_Board.DataBase.Util;

namespace MostiSubject_MVC_Board.Controllers
{
    public class BoardController : Controller
    {


        /// <summary>
        /// List()
        /// 게시물 전체 내용이 출력되는 액션
        /// </summary>
        /// <param name="boardRequest"></param>
        /// <returns></returns>
        // GET: Board
        #region List()
        public ActionResult List(BoardRequest boardRequest, int? page)
        {
            // dao 객체 생성
            BoardDAO dao = new BoardDAO();


            // page 설정
            int pageSize = 10;
            int pageNumber = page ?? 1;


            // boardList 추출
            List<Board> boardList = dao.ReadBoard(boardRequest);

            // response 객체 생성 후 List 에 담기
            BoardResponse boardResponse = new BoardResponse()
            {
                BoardList = boardList
                , PageList = boardList.ToPagedList(pageNumber, pageSize)

            };

            // View 에 Model 을 담아 이동
            return View("List", boardResponse.PageList);
        }
        #endregion






        /// <summary>
        /// Create()
        /// 게시물 작성 View 로 이동하는 액션
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        #region Create()
        public ActionResult Create()
        {
            return View();
        }
        #endregion


        /// <summary>
        /// Create()
        /// 게시물 입력을 수행하는 액션
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        #region Create(Board board)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Board board)
        {
            // 모델이 유효하지 않다면
            if (!ModelState.IsValid)
            {
                // 해당 뷰로 다시 돌아간다.
                return View();
            }


            // ▼ 게시물 입력수행

            int result = 0;
            BoardDAO dao = new BoardDAO();


            try
            {
                result = dao.CreateBoard(board);

                if (result > 0)
                    return RedirectToAction("List");
                else
                {
                    ViewBag.errMsg = "알 수 없는 오류로 인해 게시물 작성에 실패했습니다. 다시 돌아가서 작성해주세요";
                    return View("Errors");
                }
            }
            catch (Exception ex)
            {
                string errMsg = ex.ToString();
                ViewBag.errMsg = errMsg;
                return View("Errors");
            }

        }
        #endregion

        /// <summary>
        /// Detail(string board_id, string page)
        /// 게시물 상세 페이지로 진입하는 액션
        /// HttpGet 으로 진입한 경우에 수행
        /// </summary>
        /// <param name="board_id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        #region Detail(string board_id, string page)
        [ActionName("Detail")]
        [HttpGet]
        public ActionResult Detail(string board_id, string page)
        {
            BoardDAO dao = new BoardDAO();

            BoardResponse response = new BoardResponse();

            response.boardDetail = dao.ReadBoard(int.Parse(board_id));
            response.page = int.Parse(page);

            return View("Detail", response);
        }
        #endregion


        /// <summary>
        /// Detail(string fileName)
        /// 게시물 상세페이지에서 file을 다운로드하는 액션
        /// HttpPost 로 진입한 경우에 수행
        /// </summary>
        /// <param name="fileName"></param>
        #region Detail(string fileName)
        [ActionName("Detail")]
        [HttpPost]
        public void Detail(string fileName)
        {
            // HttpContext 객체 생성
            HttpContext context = System.Web.HttpContext.Current;

            FileSystem fs = new FileSystem();

            // 현재 페이지에서 다운로드 수행
            fs.ProcessRequest(context);

        }
        #endregion


    }
}