using MostiSubject_MVC_Board.DataBase.Task;
using MostiSubject_MVC_Board.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MostiSubject_MVC_Board.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult List(BoardRequest boardRequest)
        {
            BoardDAO dao = new BoardDAO();

            List<Board> boardList = dao.ReadBoard(boardRequest.search_type, boardRequest.search_word);

            BoardResponse boardResponse = new BoardResponse()
            {
                BoardList = boardList
            };


            return View("List", boardResponse);
        }









        public ActionResult Create()
        {
            return View();
        }







    }
}