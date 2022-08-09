using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MostiSubject_MVC_Board.Models
{
    public class BoardRequest
    {
        // 요청을 위한 BoardRequest 모델 
        public string search_type { get; set; }
        public string search_word { get; set; }

    }
}