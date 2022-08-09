using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MostiSubject_MVC_Board.Models
{
    public class BoardResponse
    {
        // 응답을 위한 BoardResponse 모델
        public List<Board> BoardList { get; set; }
        public IPagedList<Board> PageList { get; set; }
        public Board boardDetail { get; set; }
        public int page { get; set; }
    }
}