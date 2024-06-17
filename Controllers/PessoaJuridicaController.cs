using Gerenciamento.API.DTO;
using GerenciamentoAPI.Data;
using GerenciamentoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Gerenciamento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PessoaJuridicaController : ControllerBase
    {
        public readonly ApplicationDBContext _dbContext;

        public PessoaJuridicaController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "ListaCompleta")]
        [SwaggerOperation(Summary = "Retorna uma lista completa de CNPJ", Description = "Retorna uma lista completa de CNPJ's disponíveis.", OperationId = "GetItems")]
        public async Task<IActionResult> Get()
        {
            var pessoaJuridica = await _dbContext
                                            .PessoaJuridicas
                                            .Include(a => a.Contatos)
                                            .ToListAsync();
            if (pessoaJuridica.Count == 0)
            {
                return NotFound();
            }
            return Ok(pessoaJuridica);
        }

        [HttpPost(Name = "Cria Cadastro")]
        [SwaggerOperation(Summary = "Cria um Cadastro de CNPJ", Description = "Cria um novo item com os dados fornecidos.", OperationId = "CreateItem")]
        public async Task<IActionResult> Create([FromBody] PessoaJuridicaDTO pessoaJuridicaDTO)
        {

            if (ModelState.IsValid)
            {
                PessoaJuridica pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.IDCliente = pessoaJuridicaDTO.IDCliente;
                pessoaJuridica.RazaoSocial = pessoaJuridicaDTO.RazaoSocial;
                pessoaJuridica.CNPJ = pessoaJuridicaDTO.CNPJ;
                pessoaJuridica.NomeFantasia = pessoaJuridicaDTO.NomeFantasia;
                pessoaJuridica.Endereco = pessoaJuridicaDTO.Endereco;
                pessoaJuridica.Contatos = pessoaJuridicaDTO.Contatos;

                try
                {

                    _dbContext.PessoaJuridicas.Add(pessoaJuridica);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = pessoaJuridica.IDCliente }, pessoaJuridica);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.ToString());
                }

            }
            return BadRequest();
        }


        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Altera um Cadastro de CNPJ", Description = "Altera um item com os dados fornecidos.", OperationId = "AlterItem")]
        public async Task<IActionResult> Edit(int id, PessoaJuridicaDTO pessoaJuridicaDTO)
        {
            if (id != pessoaJuridicaDTO.IDCliente)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var pessoaJuridica = _dbContext.PessoaJuridicas.Find(pessoaJuridicaDTO.IDCliente);
                if (pessoaJuridica == null)
                {
                    return NotFound();
                }

                pessoaJuridica.IDCliente = pessoaJuridicaDTO.IDCliente;
                pessoaJuridica.RazaoSocial = pessoaJuridicaDTO.RazaoSocial;
                pessoaJuridica.CNPJ = pessoaJuridicaDTO.CNPJ;
                pessoaJuridica.NomeFantasia = pessoaJuridicaDTO.NomeFantasia;
                pessoaJuridica.Endereco = pessoaJuridicaDTO.Endereco;
                pessoaJuridica.Contatos = pessoaJuridicaDTO.Contatos;

                try
                {
                    _dbContext.Update(pessoaJuridica);
                    await _dbContext.SaveChangesAsync();
                    return Ok(pessoaJuridica);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return BadRequest();
        }


        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca um Cadastro de CNPJ", Description = "Busca um item com os dados fornecidos.", OperationId = "GetSelectedItem")]
        public async Task<ActionResult<PessoaJuridica>> GetbyId(int id)
        {
            try
            {
                var pessoaJuridica = _dbContext.PessoaJuridicas
                .Include(a => a.Contatos)
                .FirstOrDefault(x => x.IDCliente == id);

                if (pessoaJuridica == null)
                {
                    return NotFound();
                }
                return Ok(pessoaJuridica);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }


        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Deleta um Cadastro de CNPJ", Description = "Deleta o item com os dados fornecidos.", OperationId = "DeleteItem")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pessoaJuridica = await _dbContext.PessoaJuridicas.FindAsync(id);
                if (pessoaJuridica == null)
                {
                    return NotFound();
                }
                _dbContext.PessoaJuridicas.Remove(pessoaJuridica);
                await _dbContext.SaveChangesAsync();
                return Ok(pessoaJuridica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

}

