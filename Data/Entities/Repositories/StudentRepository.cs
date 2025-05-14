using APIExamplePRN232.Data.Database;

namespace APIExamplePRN232.Data.Entities.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _context;

        public StudentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll() => _context.Students.ToList();
        public Student GetById(int id) => _context.Students.Find(id);
        public void Add(Student student) => _context.Students.Add(student);
        public void Update(Student student) => _context.Students.Update(student);
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
                _context.Students.Remove(student);
        }

        public void Save() => _context.SaveChanges();
    }
}
