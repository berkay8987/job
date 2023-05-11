namespace STLapp.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Branch { get; set; } = string.Empty;

        public DateTime DateStartedWorking { get; set; } = DateTime.Now;
    }
}
