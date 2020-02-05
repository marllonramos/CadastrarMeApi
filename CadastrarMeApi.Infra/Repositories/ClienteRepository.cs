using System;
using System.Linq;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Infra.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace CadastrarMeApi.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastrarMeDataContext _context;

        public ClienteRepository(CadastrarMeDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> Listar()
        {
            return _context.Clientes.ToList();
        }
        public Cliente ListarPorId(Guid id)
        {
            return _context.Clientes
                .Where(c => c.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public void Inserir(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }
        public void Atualizar(Cliente cliente)
        {
            _context.Entry<Cliente>(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Excluir(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }
    }
}