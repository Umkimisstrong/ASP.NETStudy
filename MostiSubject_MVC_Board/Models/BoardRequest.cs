using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MostiSubject_MVC_Board.Models
{
    public class BoardRequest
    {

        public string search_type { get; set; }
        public string search_word { get; set; }

        public int row_start { get; set; }
        public int row_end { get; set;}

    }
}