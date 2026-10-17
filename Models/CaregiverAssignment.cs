namespace HHAManagementSystem.Models;

public class CaregiverAssignment
{
    public int Id { get; set; }
    public int CaregiverId { get; set; }
    public int PatientId { get; set; }
    public DateTime AssignedOn { get; set; } = DateTime.UtcNow;
    public Caregiver Caregiver { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}
