using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmniStore.OrderService.Data;
using OmniStore.OrderService.DTOs;
using OmniStore.OrderService.Models;
using OmniStore.OrderService.Services;
namespace OmniStore.OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;
        public OrdersController(AppDbContext context, IMapper mapper, IBlobService blobService) {
            _context = context;
            _mapper = mapper;
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto incomingDto) {

            var newOrder = _mapper.Map<Order>(incomingDto);
            newOrder.OrderDate = DateTime.UtcNow;
            newOrder.Status = "Pending";


            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateOrder), new { id = newOrder.Id }, newOrder);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("{id}/invoice")]
        public async Task<IActionResult> UploadInvoice(int id, IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var order = await _context.Orders.FindAsync(id);   
            if(order == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            var blobUrl = await _blobService.UploadInvoiceAsync(id, file);

            order.InvoiceUrl = blobUrl;

            await _context.SaveChangesAsync();
            return Ok(new { InvoiceUrl = blobUrl });
        }
    }
}