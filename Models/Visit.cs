namespace HHAManagementSystem.Models;

public class Visit
{
    public int Id { get; set; }
    public int CaregiverId { get; set; }
    public int PatientId { get; set; }
    public DateTime VisitDate { get; set; }
    public string Status { get; set; } = "Scheduled";
    public string Notes { get; set; } = "";
    public Caregiver Caregiver { get; set; } = null!;
    public Patient Patient { get; set; } = null!;
}
