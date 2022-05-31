using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleOfDolls.DTO;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllClient")]
        public async Task<IEnumerable<Client>> GetAll()
        {
            try
            {
                return await _clientRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetClientById")]
        public async Task<IActionResult> GetClientById([FromQuery] long id)
        {
            try
            {
                var result = await _clientRepository.GetById(id);
                if (result != null)
                    return Ok(result);

                return Ok(new { message = $"ClientId = {id} não encontrado" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertClient")]
        public async Task<IActionResult> InsertClient([FromBody] ClientDTO clientDTO)
        {
            try
            {
                var client = _mapper.Map<Client>(clientDTO);

                var result = await _clientRepository.Add(client);

                return Json(clientDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromQuery] long clientId, ClientDTO clientDTO)
        {
            try
            {
                var client = await _clientRepository.GetById(clientId);

                if (client == null)
                    return NotFound();

                client = _mapper.Map(clientDTO, client);

                var result = await _clientRepository.Update(client);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient([FromQuery] long id)
        {
            try
            {
                var result = await _clientRepository.GetById(id);
                if (result == null)
                    return NotFound(new { message = $"ClientId = {id} não encontrado" });

                var client = _clientRepository.Delete(result);

                return Json(new { message = $"CPF excluído com sucesso", client = client.Result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}