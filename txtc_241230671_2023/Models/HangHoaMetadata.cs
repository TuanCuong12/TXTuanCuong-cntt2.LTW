using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace txtc_241230671_2023.Models;

[ModelMetadataType(typeof(HangHoaMetadata))]
public partial class HangHoa
{
}

public class HangHoaMetadata
{
    [Required(ErrorMessage = "Vui lòng chọn loại hàng.")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên hàng không được để trống.")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự.")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá.")]
    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000.")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên file ảnh.")]
    [RegularExpression(@"(?i)^[^\\/:*?""<>|]+\.(jpg|png|gif|tiff)$",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff.")]
    public string? Anh { get; set; }
}