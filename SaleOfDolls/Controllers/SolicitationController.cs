using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleOfDolls.Data;
using SaleOfDolls.DTO;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SolicitationController : Controller
    {
        private readonly ISolicitationRepository _solicitationRepository;
        private readonly IMapper _mapper;

        public SolicitationController(ISolicitationRepository solicitationRepository, IMapper mapper)
        {
            _solicitationRepository = solicitationRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllSolicitation")]
        public async Task<IEnumerable<Solicitation>> GetAll()
        {
            try
            {
                return await _solicitationRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetSolicitationById")]
        public async Task<IActionResult> GetSolicitationById([FromQuery] long id)
        {
            try
            {
                var result = await _solicitationRepository.GetById(id);
                if (result != null)
                    return Ok(result);

                return Ok(new { message = $"SolicitationId = {id} não encontrado" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("InsertSolicitation")]
        public async Task<IActionResult> InsertSolicitation([FromBody] SolicitationDTO solicitationDTO)
        {
            try
            {
                var solicitation = _mapper.Map<Solicitation>(solicitationDTO);

                var code = (DateTime.Now.Year + DateTime.Now.Day + DateTime.Now.Second).ToString();
                solicitation.RequestNumber = long.Parse(code);

                var result = await _solicitationRepository.Add(solicitation);

                return Json(solicitationDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateSolicitation")]
        public async Task<IActionResult> UpdateSolicitation([FromQuery] long solicitationId, SolicitationDTO solicitationDTO)
        {
            try
            {
                var solicitation = await _solicitationRepository.GetById(solicitationId);

                if (solicitation == null)
                    return NotFound();

                solicitation = _mapper.Map(solicitationDTO, solicitation);

                var result = await _solicitationRepository.Update(solicitation);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSolicitation([FromQuery] long id)
        {
            try
            {
                var result = await _solicitationRepository.GetById(id);
                if (result == null)
                    return NotFound(new { message = $"SolicitationId = {id} não encontrado" });

                var solicitation = _solicitationRepository.Delete(result);

                return Json(new { message = $"Pedido excluído com sucesso", solicitation = solicitation.Result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}