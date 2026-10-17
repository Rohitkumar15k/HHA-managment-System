using HHAManagementSystem.DTOs;
using HHAManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HHAManagementSystem.Controllers;

[Authorize]
public class CaregiversController : Controller
{
    private readonly ICaregiverService _service;

    public CaregiversController(ICaregiverService service) => _service = service;

    public async Task<IActionResult> Index() => View(await _service.GetAllAsync());

    public async Task<IActionResult> Create() => View(new CaregiverDto { IsActive = true });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CaregiverDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _service.SaveAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item == null ? NotFound() : View(item);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CaregiverDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _service.SaveAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
