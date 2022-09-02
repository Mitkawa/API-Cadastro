using CadastroClientes.Data;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroClientes.Repository
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        public async Task<Cliente> GetClientesById(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.id == id);
        }
        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> UpdateCliente(Cliente ClienteAlterado)
        {
            _context.Entry(ClienteAlterado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return ClienteAlterado;
        }
        public async Task DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.id == id);

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
