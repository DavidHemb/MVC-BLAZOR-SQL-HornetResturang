using Business.Repository.IRepository;
using DataAccess.Models;
using Hornet_Models.ModelsDTO;
using Microsoft.AspNetCore.Mvc;

namespace Hornet_Proj_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_orderRepository.GetAll());
        }
        [HttpGet("GetAllOrderStatistics")]
        public IActionResult GetAllOrderStatistics()
        {
            return Ok(_orderRepository.GetAllOrderStatistics());
        }
        [HttpGet("GetAllOrderStatisticsForDate")]
        public IActionResult GetAllOrderStatisticsForDate()
        {
            return Ok(_orderRepository.GetAllOrderStatisticsForDate());
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderByOrderId(int orderId)
        {
            return Ok(_orderRepository.GetOrderByOrderId(orderId));
        }





        [HttpGet("GetAllById")]
        public IActionResult GetAllById(int id)
        {
            if (id != null)
            {
                return Ok(_orderRepository.GetAllById(id));
            }
            return BadRequest("Invalid data");
        }
        [HttpPost]
        public IActionResult Create(CreateOrderDTO createOrderDTO)
        {
            if (createOrderDTO == null)
            {
                return BadRequest("Invalid data");
            }

            var createdOrder = _orderRepository.Create(createOrderDTO);


            return CreatedAtAction(nameof(GetAll), createdOrder);
        }

        [HttpPost("UpdateOrderMessage/{orderId}")]
        public IActionResult Update([FromRoute] int orderId, [FromBody] string orderMessage)
        {


            return Ok(_orderRepository.UpdateOrderMessage(orderId, orderMessage));
        }
        [HttpPost("ConfirmOrder")]
        public IActionResult ConfirmOrder(Order order)
        {
            return Ok(_orderRepository.ConfirmOrder(order));
        }
        [HttpPost("UpdateIsTakeAway")]
        public IActionResult UpdateIsTakeAway(Order order)
        {
            return Ok(_orderRepository.UpdateIsTakeAway(order));
        }
        [HttpPost("UpdateIsReady")]
        public IActionResult UpdateIsReady(Order order)
        {
            return Ok(_orderRepository.UpdateIsReady(order));
        }

        [HttpPost("UpdateOrderProducts/{orderId}")]
        public IActionResult UpdateOrderProducts([FromRoute] int orderId, [FromBody] List<OrderProductDTO> orderProducts)
        {


            return Ok(_orderRepository.UpdateOrderProducts(orderId, orderProducts));
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(OrderProductDTO orderProduct)
        {

            return Ok(_orderRepository.AddProduct(orderProduct));
        }

        [HttpDelete("Delete/{orderId}")]
        public IActionResult Delete([FromRoute] int orderId)
        {
            if (orderId < 1)
            {
                return BadRequest("Invalid data");
            }

            return Ok(_orderRepository.Delete(orderId));
        }
        [HttpPost("AddProductToExistingOrder")]
        public IActionResult AddProductToExistingOrder([FromBody] OrderProduct orderProduct)
        {
            if (orderProduct == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(_orderRepository.AddProductToOrder(orderProduct));
        }
        [HttpPost("UpdateOrderProducts")]
        public IActionResult UpdateOrderProducts([FromBody] List<OrderProduct> orderProduct)
        {
            if (orderProduct == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(_orderRepository.UpdateOrderProducts(orderProduct));
        }
        [HttpPost("UpdateOrderMessage")]
        public IActionResult UpdateOrderMessage([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(_orderRepository.UpdateOrderMessage(order));
        }
        [HttpPost("DeleteOrder")]
        public IActionResult DeleteOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(_orderRepository.DeleteOrder(order));
        }
    }
}
