using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyToDoList.DataBase
{
    /// <summary>
    /// TB_TODO Entity
    /// property 정의
    /// </summary>
    public class ToDoDTO
    {
        public int todo_id { get; set; }
        public string u_todo { get; set; }
        public string todo_status { get; set; }

    }
}