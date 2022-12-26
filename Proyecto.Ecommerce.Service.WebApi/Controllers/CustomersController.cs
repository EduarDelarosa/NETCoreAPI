using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Ecommerce.Application.DTO;
using Proyecto.Ecommerce.Application.Interface;
using System.Threading.Tasks;

namespace Proyecto.Ecommerce.Service.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerApplication _customerApplication;
        public CustomersController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        //#region Metodos Sincronos
        //[HttpPost]
        //public IActionResult Insert([FromBody]CustomersDTO customersDTO)
        //{
        //    if (customersDTO == null)
        //    {
        //        return BadRequest();
        //    }

        //    var response = _customerApplication.Insert(customersDTO);
        //    if(response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}

        //[HttpPut]
        //public IActionResult Update([FromBody] CustomersDTO customersDTO)
        //{
        //    if (customersDTO == null)
        //    {
        //        return BadRequest();
        //    }

        //    var response = _customerApplication.Update(customersDTO);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}

        //[HttpDelete("{customerId}")]
        //public IActionResult Delete(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId))
        //    {
        //        return BadRequest();
        //    }

        //    var response = _customerApplication.Delete(customerId);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}

        //[HttpGet("{customerId}")]
        //public IActionResult GetById(string customerId)
        //{
        //    if (string.IsNullOrEmpty(customerId))
        //    {
        //        return BadRequest();
        //    }

        //    var response = _customerApplication.GetById(customerId);
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var response = _customerApplication.GetAll();
        //    if (response.IsSuccess)
        //    {
        //        return Ok(response);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}
        //#endregion

        #region Metodos Asincronos
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest();
            }

            var response = await _customerApplication.InsertAsync(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDTO customersDTO)
        {
            if (customersDTO == null)
            {
                return BadRequest();
            }

            var response = await _customerApplication.UpdateAsync(customersDTO);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = await _customerApplication.DeleteAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }

            var response = await _customerApplication.GetByIdAsync(customerId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAsyncAll()
        {
            var response = await _customerApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
        #endregion
    }
}
