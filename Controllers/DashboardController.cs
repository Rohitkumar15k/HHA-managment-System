using HHAManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        ViewBag.Caregivers = await _context.Caregivers.CountAsync();
        ViewBag.Patients = await _context.Patients.CountAsync();
        ViewBag.Visits = await _context.Visits.CountAsync();
        return View();
    }
}
