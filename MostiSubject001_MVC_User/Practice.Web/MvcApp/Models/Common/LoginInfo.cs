using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Common
{
    public class LoginInfo
    {
        /// <summary>
        /// 로그인 ID
        /// </summary>
        public string LoginID { get; set; }

        /// <summary>
        /// 로그인 NM
        /// </summary>
        
        public string LoginNM { get; set; }

        /// <summary>
        /// 로그인 PWD
        /// </summary>

        public string LoginPWD { get; set; }
    }
}