using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models.Entity
{
    public class UserModel
    {

        // TODO : [완료] DB 테이블 정보를 참고하여, 모델 속성을 선언하세요.

        // 1. TB_SAMPLE_USER

        [Required(ErrorMessage = "ID가 입력되지 않았습니다.")]
        [DisplayName("USER_ID")]
        [StringLength(32, ErrorMessage = "아이디는 32글자를 초과할 수 없습니다."), MinLength(1, ErrorMessage = "아이디는 0글자 이하일 수 없습니다.")]
        // USER_ID / 유저 ID - NOT NULL, 32글자
        public string USER_ID { get; set; }

        [Required(ErrorMessage = "비밀번호가 입력되지 않았습니다.")]
        // USER_PWD / 유저 비밀번호 - NOT NULL, 32글자
        public string USER_PWD { get; set; }

        [Required(ErrorMessage = "이름이 입력되지 않았습니다.")]
        [DisplayName("USER_NM")]
        // USER_NM / 유저 이름 - NOT NULL, 32글자
        public string USER_NM { get; set; }

        [Required(ErrorMessage = "생일이 입력되지 않았습니다.")]
        [DisplayName("USER_BIRTH")]
        // USER_BIRTH / 유저 생일 - NOT NULL, 8글자
        public string USER_BIRTH { get; set; }

        // HOBBY / 유저 취미 - NULL, 2000
        public string HOBBY { get; set; }

        // LIKE_THINGS / 좋아하는 것 - NULL, 2000
        public string LIKE_THINGS { get; set; }

        // DISLIKE_THINGS / 좋아하지 않는 것 - NULL, 2000
        public string DISLIKE_THINGS { get; set; }

        // FAVORITE_MOVIE / 가장 좋아하는 영화 - NULL, 2000
        public string FAVORITE_MOVIE { get; set; }

        // FAVORITE_FOOD / 가장 좋아하는 음식 - NULL, 2000
        public string FAVORITE_FOOD { get; set; }

        // FAVORITE_SEASON / 가장좋아하는 계절 - NULL, 10, 4개중 하나만 받아야함 (SPRING, SUMMER, AUTUMN, WINTER)
        public string FAVORITE_SEASON { get; set; }

        // PET / 반려 동물 여부 - NULL, 1, 2개중 하나만 받아야함 (Y / N)
        [DisplayName("PET")]
        public string PET { get; set; }

        [DisplayName("CREATE_DATE")]
        // CREATE_DATE / 최초 생성일 - NOT NULL, datetime
        public DateTime CREATE_DATE { get; set; }

        // CREATE_USER / 최초 생성자 - NOT NULL, 32
        public string CREATE_USER { get; set; }

        [DisplayName("UPDATE_DATE")]
        // UPDATE_DATE / 최종 수정일 - NOT NULL, datetime
        public DateTime UPDATE_DATE { get; set; }

        // UPDATE_USER / 최종 수정자 - NOT NULL, 32
        public string UPDATE_USER { get; set; }

        

    }
}