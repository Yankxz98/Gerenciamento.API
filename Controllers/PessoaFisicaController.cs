using Gerenciamento.API.DTO;
using GerenciamentoAPI.Data;
using GerenciamentoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;



namespace Gerenciamento.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaFisicaController : ControllerBase
    {
        public readonly ApplicationDBContext _dbContext;

        public PessoaFisicaController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "ListaCompletaF")]    
        [SwaggerOperation(Summary = "Retorna uma lista completa de pessoas Fisicas", Description = "Retorna uma lista completa de CPF's disponíveis.", OperationId = "GetItems")]
        public async Task<IActionResult> Get()
        {
            var pessoaFisica = await _dbContext
                                            .PessoaFisicas
                                            .Include(a => a.Contatos)
                                            .ToListAsync();

            return Ok(pessoaFisica);
        }

        [HttpPost(Name = "CriaCadastroF")]
        [SwaggerOperation(Summary = "Cria um Cadastro de Pessoa Fisica", Description = "Cria um novo item com os dados fornecidos.", OperationId = "CreateItem")]
        public async Task<IActionResult> Create([FromBody] PessoaFisicaDTO pessoaFisicaDTO)
        {

            if (ModelState.IsValid)
            {
                PessoaFisica pessoaFisica = new PessoaFisica();
                pessoaFisica.IDCliente = pessoaFisicaDTO.IDCliente;
                pessoaFisica.NomeCompleto = pessoaFisicaDTO.NomeCompleto;
                pessoaFisica.CPF = pessoaFisicaDTO.CPF;
                pessoaFisica.DataNascimento = pessoaFisicaDTO.DataNascimento;
                pessoaFisica.Endereco = pessoaFisicaDTO.Endereco;
                pessoaFisica.Contatos = pessoaFisicaDTO.Contatos;


                try
                {

                    _dbContext.PessoaFisicas.Add(pessoaFisica);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = pessoaFisica.IDCliente }, pessoaFisica);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.ToString());
                }

            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Altera um Cadastro de Pessoa Fisica", Description = "Altera um item com os dados fornecidos.", OperationId = "AlterItem")]
        public async Task<IActionResult> Edit(int id, PessoaFisicaDTO pessoaFisicaDTO)
        {
            if (id != pessoaFisicaDTO.IDCliente)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var pessoaFisica = _dbContext.PessoaFisicas.Find(pessoaFisicaDTO.IDCliente);
                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                pessoaFisica.IDCliente = pessoaFisicaDTO.IDCliente;
                pessoaFisica.NomeCompleto = pessoaFisicaDTO.NomeCompleto;
                pessoaFisica.CPF = pessoaFisicaDTO.CPF;
                pessoaFisica.DataNascimento = pessoaFisicaDTO.DataNascimento;
                pessoaFisica.Endereco = pessoaFisicaDTO.Endereco;
                pessoaFisica.Contatos = pessoaFisicaDTO.Contatos;

                try
                {
                    _dbContext.Update(pessoaFisica);
                    await _dbContext.SaveChangesAsync();
                    return Ok(pessoaFisica);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }



            }
            return BadRequest();
        }


        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Busca um Cadastro de Pessoa Fisica", Description = "Busca um item com os dados fornecidos.", OperationId = "GetSelectedItem")]
        public async Task<ActionResult<PessoaFisica>> GetbyId(int id)
        {
            try
            {
                var pessoaFisica = _dbContext.PessoaFisicas
                .Include(a => a.Contatos)
                .FirstOrDefault(x => x.IDCliente == id);


                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                return Ok(pessoaFisica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
            }
        }


        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Deleta um Cadastro de Pessoa Fisica", Description = "Deleta o item com os dados fornecidos.", OperationId = "DeleteItem")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var PessoaFisica = await _dbContext.PessoaFisicas.FindAsync(id);
                if (PessoaFisica == null)
                {
                    return NotFound();
                }
                _dbContext.PessoaFisicas.Remove(PessoaFisica);
                await _dbContext.SaveChangesAsync();
                return Ok(PessoaFisica);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
