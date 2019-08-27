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
        private const string V = "Erro ao somar os valores firstNumber:,secondNumber:";

        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var soma = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));
                return Ok(soma.ToString());
            }
            return BadRequest($"Erro ao somar os valores firstNumber:{firstNumber},secondNumber:{secondNumber}");
        }

        bool IsNumeric(string number)
        {
            try
            {
                double decimalValue;
                return double.TryParse(number, System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo,out decimalValue);                
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;
            if(decimal.TryParse(number, out decimalValue)){
                return decimalValue;
            }
            return 0;
            //return Convert.ToDecimal(number);
        }
    }
}
