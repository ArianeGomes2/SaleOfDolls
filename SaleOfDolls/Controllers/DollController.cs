using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleOfDolls.DTO;
using SaleOfDolls.Models;
using SaleOfDolls.Uow.Interface;

namespace SaleOfDolls.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class DollController : Controller
    {
        private readonly IDollRepository _dollRepository;
        private readonly IMapper _mapper;

        public DollController(IDollRepository dollRepository, IMapper mapper)
        {
            _dollRepository = dollRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllDoll")]
        public async Task<IEnumerable<Doll>> GetAll()
        {
            try
            {
                return await _dollRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetDollById")]
        public async Task<IActionResult> GetDollById([FromQuery] long id)
        {
            try
            {
                var result = await _dollRepository.GetById(id);
                if (result != null)
                    return Ok(result);

                return Ok(new { message = $"DollId = {id} não encontrado" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>

        [HttpPost("InsertDoll")]
        public async Task<IActionResult> InsertDoll([FromBody] DollDTO dollDTO)
        {
            try
            {
                var doll = _mapper.Map<Doll>(dollDTO);

                var result = await _dollRepository.Add(doll);

                return Json(dollDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateDoll")]
        public async Task<IActionResult> UpdateDoll([FromQuery] long dollId, DollDTO dollDTO)
        {
            try
            {
                var doll = await _dollRepository.GetById(dollId);

                if (doll == null)
                    return NotFound();

                doll = _mapper.Map(dollDTO, doll);

                var result = await _dollRepository.Update(doll);

                return Json(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoll([FromQuery] long id)
        {
            try
            {
                var result = await _dollRepository.GetById(id);
                if (result == null)
                    return NotFound(new { message = $"DollId = {id} não encontrado" });

                var doll = _dollRepository.Delete(result);

                return Json(new { message = $"Boneca excluída com sucesso", doll = doll.Result });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}