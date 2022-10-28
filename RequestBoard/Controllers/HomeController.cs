using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RequestBoard.Models;
using RequestBoard.Models.DbModels;
using RequestBoard.Models.Interfaces.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace RequestBoard.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBusinessLayer _businnesLayer;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(ILogger<HomeController> logger, IBusinessLayer businnesLayer, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
        _businnesLayer = businnesLayer;
    }
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        return View(user);
    }
    public IActionResult RequestTypeList()
    {
        try
        {
            var models = _businnesLayer.GetAllRequestType();
            return View(models);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    public IActionResult RequestList()
    {
        try
        {
            if (User.IsInRole("Admin"))
            {
                var models = _businnesLayer.GetAllRequestToRestore();
                return View(models);
            }
            else
            {
                var userId = _userManager.GetUserId(User);
                var models = _businnesLayer.GetRequestsByUserId(userId);
                return View(models);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    [HttpGet]
    public IActionResult CreateRequest()
    {
        try
        {
            var requestList = _businnesLayer.GetAllRequestType();
            ViewBag.RequestTypes = new SelectList(requestList, "Id", "Name");
            return View();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    public IActionResult DeleteRequest(Guid id)
    {
        try
        {
            var request = _businnesLayer.RemoveRequestToRestore(id);
            return request is null ? NotFound() : RedirectToAction("RequestList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    [HttpPost]
    public IActionResult CreateRequest(RequestToRestore model)
    {
        if (model is null)
            return BadRequest();
        try
        {
            model.UserId = _userManager.GetUserId(User);
            model.Stage = Stages.Принято;
            var request = _businnesLayer.AddRequestToRestore(model);
            if (request is null)
                return NotFound();
            return RedirectToAction("RequestList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    [HttpGet]
    public IActionResult CreateRequestType()
    {
        return View();
    }
    [HttpPost]
    public IActionResult CreateRequestType(RequestType model)
    {
        try
        {
            var item = _businnesLayer.AddRequestType(model);
            return item is null ? BadRequest() : RedirectToAction("RequestTypeList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    public IActionResult RemoveRequestType(Guid id)
    {
        try
        {
            var item = _businnesLayer.RemoveRequestType(id);
            return item is null ? BadRequest() : RedirectToAction("RequestTypeList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    public IActionResult RejectRequest(Guid id)
    {
        try
        {
            _businnesLayer.RejectRequest(id);
            return RedirectToAction("RequestList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return NotFound();
        }
    }
    public IActionResult FullfillRequest(Guid id)
    {
        try
        {
            _businnesLayer.FullfillRequest(id);
            return RedirectToAction("RequestList");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    public IActionResult Find(string searchString)
    {
        try
        {
           var models =  _businnesLayer.FindRequestByName(searchString);
            return View("RequestList", model:models);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return RedirectToAction("Index");
        }
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
