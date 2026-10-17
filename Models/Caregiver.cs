namespace HHAManagementSystem.Models;

public class Caregiver
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public ICollection<CaregiverAssignment> Assignments { get; set; } = new List<CaregiverAssignment>();
    public ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
