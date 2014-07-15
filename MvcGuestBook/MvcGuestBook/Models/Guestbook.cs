using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGuestBook.Models
{
    public class Guestbook
    {
        [Key]
        public int No { get; set; }
        [Required]
        public string Message { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

        public virtual Member Member { get; set; }

        //[NotMapped]
        //public string FamilyName {
        //    get
        //    {
        //        return this.Name.Substring(0, 1);
        //    }
        //    set
        //    {
        //        this.Name = value.Substring(0, 1) + this.Name.Substring(1);
        //    }
        //}
    }
   //[MetadataType(typeof(MemberMetadata))]
    public class Member
    {
        // private class MemberMetadata
        // {
        public int ID { get; set; }

        [Required]   //加入 [Required] ，將此欄位設為必填欄位
        [MaxLength(5)]
        public string Name { get; set; }

        [MaxLength(200)]
       // [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1.3}\.| (([\w-]+\.)+))([a-zA-Z]{2,4})$", ErrorMessage = "請輸入正確的Email格式")]
        public string Email { get; set; }

       //[Range(1, 3, ErrorMessage = "請選擇代表圖示")]
       //public int EmotionIcon { get; set; }

        public ICollection<Guestbook> Guestbooks { get; set; }
        //}
    }

}