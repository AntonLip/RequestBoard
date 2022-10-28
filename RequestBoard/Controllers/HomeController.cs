using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RequestBoard.Models;
using RequestBoard.Models.DbModels;
using RequestBoard.Models.Interfaces.IRepository;

namespace RequestBoard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBusinessLayer _businnesLayer;

    public HomeController(ILogger<HomeController> logger, IBusinessLayer businnesLayer)
    {
        _logger = logger;
        _businnesLayer = businnesLayer;
    }

    public IActionResult Index()
    {
        return View();
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
            var models = _businnesLayer.GetAllRequestToRestore();
            return View(models);
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
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
