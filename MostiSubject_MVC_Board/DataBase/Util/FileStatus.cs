using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MostiSubject_MVC_Board.DataBase.Util
{
    /// <summary>
    /// FileStatus 클래스
    /// 주요속성 : string fileName / bool check
    /// </summary>
    public class FileStatus
    {
        public string fileName { get; set; }
        public bool check { get; set; }
    }
}