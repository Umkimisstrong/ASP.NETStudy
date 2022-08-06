using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MostiSubject_MVC_Board.Models
{
    /// <summary>
    /// Board
    /// 게시판 원본 Model
    /// </summary>
    public class Board
    {
        // 테이블 데이터
        // 아이디, 제목, 내용, 조회수, 생성일, 작성자, 삭제여부

        public int board_id { get; set; }

        [Required]
        [StringLength(300)]
        public string title { get; set; }

        [Required]
        [StringLength(8000)]
        public string content { get; set; }

        
        public int hitCount { get; set; }

        public DateTime board_date { get; set; }

        [Required]
        [StringLength(200)]
        public string u_id { get; set; }

        public int del_check { get; set; }
    

    }
}