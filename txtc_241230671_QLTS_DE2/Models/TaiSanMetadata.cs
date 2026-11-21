using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace txtc_241230671_QLTS_DE2.Models;

[ModelMetadataType(typeof(TaiSanMetadata))]
public partial class TaiSan
{
}

public class TaiSanMetadata
{
    [Required(ErrorMessage = "Vui lòng chọn loại tài sản.")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên tài sản không được để trống.")]
    [StringLength(100, ErrorMessage = "Tên tài sản tối đa 100 ký tự.")]
    public string TenTs { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập nguyên giá.")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số trong khoảng từ 1 đến 2000 (triệu đồng).")]
    public decimal? NguyenGia { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên file ảnh.")]
    [RegularExpression(@"(?i)^[^\\/:*?""<>|]+\.(jpg|jpeg|png|webp)$",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp.")]
    public string? Anh { get; set; }
}