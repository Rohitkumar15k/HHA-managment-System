using HHAManagementSystem.Data;
using HHAManagementSystem.DTOs;
using HHAManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Controllers;

[Authorize]
public class VisitsController : Controller
{
    private readonly IVisitService _service;
    private readonly AppDbContext _context;

    public VisitsController(IVisitService service, AppDbContext context)
    {
        _service = service;
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _service.GetAllAsync());

    public async Task<IActionResult> Create()
    {
        ViewBag.Caregivers = await _context.Caregivers.Where(x => x.IsActive).ToListAsync();
        ViewBag.Patients = await _context.Patients.ToListAsync();
        return View(new VisitDto { VisitDate = DateTime.Now.AddDays(1) });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VisitDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Caregivers = await _context.Caregivers.Where(x => x.IsActive).ToListAsync();
            ViewBag.Patients = await _context.Patients.ToListAsync();
            return View(dto);
        }

        await _service.SaveAsync(dto);
        return RedirectToAction(nameof(Index));
    }
}
