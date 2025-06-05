namespace NguyenManhTanHuynh_SE17D05_A01_BE.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountEmail { get; set; } = string.Empty;
        public int AccountRole { get; set; }
    }
}