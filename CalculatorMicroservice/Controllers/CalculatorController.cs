using Microsoft.AspNetCore.Mvc;

namespace CalculatorMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Add")]
        public IActionResult Add(int firstOperand, int secondOperand)
        {
            return Ok(new ApiResult { Success= true, Answer= firstOperand+ secondOperand });
        }
        [HttpGet(Name = "Substract")]
        public IActionResult Substract(int firstOperand, int secondOperand)
        {
            return Ok(new ApiResult { Success = true, Answer = firstOperand - secondOperand });
        }
        [HttpGet(Name = "Multiply")]
        public IActionResult Multiply(int firstOperand, int secondOperand)
        {
            return Ok(new ApiResult { Success = true, Answer = firstOperand * secondOperand });
        }
        [HttpGet(Name = "Divide")]
        public IActionResult Divide(double firstOperand, int secondOperand)
        {
            return Ok(new ApiResult { Success = true, Answer = firstOperand / secondOperand });
        }
    }
}