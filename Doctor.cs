//namespace DoctorManagementSystem.Models;

//public class Doctor
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public string Specialization { get; set; }
//    public string ContactNumber { get; set; }
//}



using System.ComponentModel.DataAnnotations;

namespace DoctorManagementSystem.Models;

public class Doctor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Specialization is required")]
    [StringLength(50, ErrorMessage = "Specialization can't be longer than 50 characters")]
    public string Specialization { get; set; }

    [Required(ErrorMessage = "Contact number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string ContactNumber { get; set; }
}
