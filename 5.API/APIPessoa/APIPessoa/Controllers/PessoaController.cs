using API.Aplication.DTOs;
using API.Aplication.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIPessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        
        private readonly IPessoaServico _pessoaController;
        public PessoaController(IPessoaServico pessoaServico)
        {
            _pessoaController = pessoaServico;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaDto pessoaDto)
        {
            var result = await _pessoaController.CreateAsync(pessoaDto);
            if (result.Sucesso)
                return Ok(pessoaDto);

            return BadRequest(result);
        }
    }
}
