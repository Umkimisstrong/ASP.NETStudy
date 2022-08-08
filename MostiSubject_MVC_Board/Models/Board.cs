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
        // 아이디, 제목, 내용, 조회수, 생성일, 작성자, 삭제여부, 행번호, file객체, fileName

        public int board_id { get; set; }

        [Display(Name = "제목")]
        [Required(ErrorMessage = "제목을 입력해주세요")]
        [StringLength(300, ErrorMessage = "제목은 300자를 넘을 수 없습니다.")]
        public string title { get; set; }

        [Display(Name = "내용")]
        [Required(ErrorMessage = "내용을 입력해주세요")]
        [StringLength(8000, ErrorMessage = "내용은 8000자를 넘을 수 없습니다.")]
        public string content { get; set; }

        
        public int hitCount { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime board_date { get; set; }

        [Display(Name = "작성자")]
        [Required(ErrorMessage = "ID가 필요합니다.")]
        [StringLength(200, ErrorMessage = "ID 는 200자를 넘을 수 없습니다.")]
        public string u_id { get; set; }

        public int del_check { get; set; }
    
        public int rownum { get; set; }


        public HttpPostedFileBase files { get; set; }

        public string fileName { get; set; }

    }
}