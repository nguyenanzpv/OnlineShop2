namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        public string Username { get; set; }

        [StringLength(32)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Tên")]
        [Required(ErrorMessage ="Tên không được để trống")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Email không được để trống")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "Email Format is wrong")]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Điện thoại")]
        [Required(ErrorMessage ="Điện thoại không được để trống")]
        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        [DisplayName("Người điều chỉnh")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage ="Trạng thái không được để trống")]
        public bool Status { get; set; }
        
    }
}
