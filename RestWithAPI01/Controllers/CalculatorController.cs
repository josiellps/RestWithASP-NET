using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber},secondNumber:{secondNumber}");
        }

        [HttpGet("Subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = (ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber},secondNumber:{secondNumber}");
        }

        [HttpGet("Division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = (ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber},secondNumber:{secondNumber}");
        }

        [HttpGet("Multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber},secondNumber:{secondNumber}");
        }

        [HttpGet("squeare-root/{firstNumber}")]
        public IActionResult SqueareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var soma = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber}");
        }

        bool IsNumeric(string number)
        {
            try
            {
                double decimalValue;
                return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out decimalValue);
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
            //return Convert.ToDecimal(number);
        }
    }
}
