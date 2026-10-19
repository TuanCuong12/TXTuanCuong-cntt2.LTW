using System;
using System.ComponentModel.DataAnnotations;
namespace TXTC_lesson7.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [   
            Display (Name = "Họ tên"),
            Required(ErrorMessage = "Họ tên ko để trống"),
            MinLength(6, ErrorMessage = "Họ tên phải có ít nhất 6 ký tự"),
            MaxLength(20, ErrorMessage = "Họ tên không được vượt quá 20 ký tự")
        ]
        public string FullName { get; set; }
        [
            Display(Name = "Email"),
            Required(ErrorMessage = "Email ko để trống"),
            EmailAddress(ErrorMessage = "Email không hợp lệ"),
            DataType(DataType.EmailAddress)
        ]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại"),
            DataType(DataType.PhoneNumber),
            RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại Không đúng định dạng"),
            Required(ErrorMessage = "Số điện thoại ko để trống")
        ]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ"),
            Required(ErrorMessage = "Địa chỉ ko để trống"),
            StringLength(36, ErrorMessage = "Địa chỉ không được vượt quá 36 ký tự")
        ]
        public string Address { get; set; }
        [Display(Name = "Ảnh đại diện"),
            DataType(DataType.ImageUrl)
        ]
        public string Avatar { get; set; }
        [Display(Name = "Ngày sinh"),
            DataType(DataType.Date),
            Required(ErrorMessage = "Ngày sinh ko để trống")
        ]
        public DateTime BirthDay { get; set; }
        [Display(Name = "Giới tính"),
            Required(ErrorMessage = "Giới tính ko để trống")
        ]
        public string Gender { get; set; }
        [Display(Name = "Mật khẩu"),
            Required(ErrorMessage = "Mật khẩu ko để trống"),
            MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự"),
            DataType(DataType.Password)
        ]
        public string Password { get; set; }
        [Display(Name = "Link Facebook"),
            Required(ErrorMessage = "Link Facebook ko để trống"),
            Url(ErrorMessage = "Link Facebook không hợp lệ")
        ]
        public string Facebook { get; set; }
    }
}
