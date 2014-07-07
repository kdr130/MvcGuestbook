using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGuestBook.Models
{
    public class Guestbook
    {
        public int Id { get; set; }
        [Required]   //加入 [Required] ，將此欄位設為必填欄位
        public string 姓名 { get; set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string 內容 { get; set; }

    }
}