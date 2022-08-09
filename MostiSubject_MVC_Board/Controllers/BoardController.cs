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
        /// Search()
        /// 검색 후 List 액션을 Redirect 하는 액션
        /// </summary>
        /// <param name="boardRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("Search")]
        public ActionResult Search(BoardRequest boardRequest)
        {

            return RedirectToAction("List", boardRequest);
        }


        /// <summary>
        /// List()
        /// 게시물 전체 내용이 출력되는 액션
        /// </summary>
        /// <param name="boardRequest"></param>
        /// <returns></returns>
        #region List()
        [ActionName("List")]
        [HttpGet]
        public ActionResult List(BoardRequest boardRequest, int? page)
        {
            // dao 객체 생성
            BoardDAO dao = new BoardDAO();

            // 검색 값 유지
            if (boardRequest.search_type != null && boardRequest.search_word != null)
            {
                ViewBag.search_type = boardRequest.search_type;
                ViewBag.search_word = boardRequest.search_word;
            }

            // page 설정
            int pageSize = 10;
            int pageNumber = page ?? 1;
            ViewBag.pageNumber = pageNumber;

            // boardList 추출
            List<Board> boardList = dao.ReadBoard(boardRequest);

            // response 객체 생성 후 List 에 담기
            BoardResponse boardResponse = new BoardResponse()
            {
                BoardList = boardList
                , PageList = boardList.ToPagedList(pageNumber, pageSize)

            };

            // View 에 Model 을 담아 이동
            return View(boardResponse.PageList);
        }
        #endregion



        


        /// <summary>
        /// Create()
        /// 게시물 작성 View 로 이동하는 액션
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        #region Create()
        public ActionResult Create(BoardRequest boardRequest, string page)
        {
            // 검색 값 유지
            if (boardRequest.search_type != null && boardRequest.search_word != null)
            {
                ViewBag.search_type = boardRequest.search_type;
                ViewBag.search_word = boardRequest.search_word;
            }

            // 페이지 유지
            ViewBag.pageNumber = page ?? "1";

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
        public ActionResult Detail(string board_id, string page, BoardRequest boardRequest)
        {
            // 페이지 유지
            if (string.IsNullOrEmpty(page))
                page = "1";

            ViewBag.pageNumber = page;

            // 검색 값 유지
            if (boardRequest.search_type != null && boardRequest.search_word != null)
            {
                ViewBag.search_type = boardRequest.search_type;
                ViewBag.search_word = boardRequest.search_word;
            }

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

        /// <summary>
        /// Update(string board_id, string page, BoardRequest boardRequest)
        /// 게시물 수정 View 로 이동하는 액션
        /// HttpGet 으로 진입한 경우에 수행
        /// </summary>
        /// <param name="board_id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        #region Update()
        [ActionName("Update")]
        [HttpGet]
        public ActionResult Update(string board_id, string page, BoardRequest boardRequest)
        {
            // 페이지 유지
            if (string.IsNullOrEmpty(page))
                page = "1";
            ViewBag.pageNumber = page;


            // 검색 값 유지 - ViewBag
            if (boardRequest.search_type != null && boardRequest.search_word != null)
            {
                ViewBag.search_type = boardRequest.search_type;
                ViewBag.search_word = boardRequest.search_word;
            }

            BoardDAO dao = new BoardDAO();

            Board board = dao.ReadBoard(int.Parse(board_id));

            return View("Update", board);
        }
        #endregion

        /// <summary>
        /// Update(Board board, BoardRequest boardRequest)
        /// 게시물을 수정하는 액션
        /// HttpPost로 진입한 경우에 수행
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        #region Update()
        [ActionName("Update")]
        [HttpPost]
        public ActionResult Update(Board board, BoardRequest boardRequest, string page)
        {
            BoardDAO dao = new BoardDAO();
            int result = 0;

            // 페이지 유지
            if (string.IsNullOrEmpty(page))
                page = "1";

            ViewBag.pageNumber = page;

            // Model 유효성 검증
            if (!ModelState.IsValid)
            {
                // Update View 에서는 기존 입력된 데이터가 있어야하므로 다시 Read 하여 Return 및 유효성을 검증한다.
                board = dao.ReadBoard(board.board_id);
                return View(board);
            }

            // 유효하다면 수정 ▼
            result = dao.UpdateBoard(board);

            if (result > 0)
            {
                return RedirectToAction("List", boardRequest);
            }

            return View("Errors");
        }
        #endregion


        /// <summary>
        /// Delete(string board_id)
        /// 게시물을 삭제하는 액션
        /// HttpPost로 진입한 경우에 수행(Ajax)
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns></returns>
        #region Delete()
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult Delete(string board_id)
        {
            BoardDAO dao = new BoardDAO();

            int result = dao.DeleteBoard(int.Parse(board_id));

            if(result > 0)
                return RedirectToAction("List");

            return View("Errors");
        }
        #endregion

    }
}