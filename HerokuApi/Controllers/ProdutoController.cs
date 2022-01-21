using HerokuApi.infra;
using HerokuApi.infra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerokuApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ApiContext _context;

        public ProdutoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return Ok("Produto salvo com sucesso!");
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            var objProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (objProduto == null)
            {
                return BadRequest("Produto não encontrado!");
            }

            objProduto.Name = produto.Name;
            objProduto.Description = produto.Description;
            objProduto.Price = produto.Price;

            _context.Produtos.Update(objProduto);
            await _context.SaveChangesAsync();

            return Ok("Produto editado com sucesso!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var objProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            if (objProduto == null)
            {
                return BadRequest("Produto não encontrado!");
            }

            _context.Produtos.Remove(objProduto);
            await _context.SaveChangesAsync();

            return Ok("Produto excluido com sucesso!");
        }
    }
}
