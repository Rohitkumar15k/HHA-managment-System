namespace HHAManagementSystem.Models;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";
    public ICollection<CaregiverAssignment> Assignments { get; set; } = new List<CaregiverAssignment>();
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
