namespace DataLayer.DTOs
{
    // DTO này chỉ chứa thông tin an toàn, không bao giờ lộ mật khẩu
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}