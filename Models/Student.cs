using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity;

public class Student
{
  public int ID { get; set; }
  [DisplayName("Last Name")]
  public string LastName { get; set; }
  [DisplayName("First Name")]
  public string FirstName { get; set; }
  [DisplayName("Enrollment Date")]
  public DateTime EnrollmentDate { get; set; }
  public ICollection<Enrollment> Enrollments { get; set; }
}
