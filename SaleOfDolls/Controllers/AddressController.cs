using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleOfDolls.DTO;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllAddress")]
        public async Task<IEnumerable<Address>> GetAll()
        {
            try
            {
                return await _addressRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetAddressById")]
        public async Task<IActionResult> GetAddressById([FromQuery] long id)
        {
            try
            {
                var result = await _addressRepository.GetById(id);
                if (result != null)
                    return Ok(result);

                return Ok(new { message = $"AddressId = {id} não encontrado" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertAddress")]
        public async Task<IActionResult> InsertAddress([FromBody] AddressDTO addressDTO)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDTO);

                var result = await _addressRepository.Add(address);

                return Json(addressDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress([FromQuery] long addressId, AddressDTO addressDTO)
        {
            try
            {
                var address = await _addressRepository.GetById(addressId);

                if (address == null)
                    return NotFound();

                address = _mapper.Map(addressDTO, address);
                
                var result = await _addressRepository.Update(address);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress([FromQuery] long id)
        {
            try
            {
                var result = await _addressRepository.GetById(id);
                if (result == null)
                    return NotFound(new { message = $"AddresId = {id} não encontrado" });

                var address = _addressRepository.Delete(result);

                return Json(new { message = $"Endereço excluído com sucesso", address = address.Result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}