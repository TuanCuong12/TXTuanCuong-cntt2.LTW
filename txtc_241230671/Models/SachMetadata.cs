using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace txtc_241230671.Models;

[ModelMetadataType(typeof(SachMetadata))]
public partial class Sach
{
}

public class SachMetadata
{
    [Display(Name = "Thể loại")]
    [Required(ErrorMessage = "Vui lòng chọn thể loại.")]
    public int MaTl { get; set; }

    [Display(Name = "Tên sách")]
    [Required(ErrorMessage = "Tên sách không được để trống.")]
    [StringLength(100, ErrorMessage = "Tên sách tối đa 100 ký tự.")]
    public string TenSach { get; set; } = null!;

    [Display(Name = "Giá (nghìn đồng)")]
    [Required(ErrorMessage = "Vui lòng nhập giá.")]
    [Range(50, 1000, ErrorMessage = "Giá phải nằm trong khoảng từ 50 đến 1000.")]
    public decimal? Gia { get; set; }

    [Display(Name = "Tên file ảnh")]
    [Required(ErrorMessage = "Vui lòng nhập tên file ảnh.")]
    [RegularExpression(@"(?i)^[^\\/:*?""<>|]+\.(jpg|jpeg|png|webp)$",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp.")]
    public string? Anh { get; set; }
}