using Domain.Dtos;
using Domain.Entits;
using Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController:ControllerBase
{
    private OrderServices _orderService;
    public OrderController()
    {
        _orderService = new OrderServices();
    }   
    
    [HttpGet("Orders")]
    public List<Order> GetOrders()
    {
        var orders = _orderService.GetOrders();
        return orders;
    }

    [HttpGet("InformationAboutCustomerANDOrders")]
    public List<GetOrderDto> InformationAboutCustomerANDOrders()
    {
        return _orderService.InformationAboutCustomerANDOrders();
    }

    [HttpGet("ALLOrdersByApple")]
    public List<GetOrderDto> ALLOrdersByApple()
    {
        return _orderService.ALLOrdersByApple();
    }
    
    
    [HttpGet("ALLOrdersUpTo")]
    public List<GetOrderDto> ALLOrdersUpTo()
    {
        return _orderService.ALLOrdersUpTo1000h();
    }

    [HttpGet("Leftjoin")]
    public List<GetOrderDto> ALLCustomerleft()
    {
      return  _orderService.ALLCustomerleft();
    }
    [HttpGet("Rigtjoin")]
    public List<GetOrderDto> ALLCustomerRight()
    {
        return  _orderService.ALLCustomerRight();
    }
    [HttpGet("FuLLjoin")]
    public List<GetOrderDto> ALLCustomerFull()
    {
        return  _orderService.ALLCustomerFull();
    }
    
}