namespace DataLayer.DTOs
{
    // DTO này cung cấp thông tin chi tiết về một lượt đăng ký
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
    }
}