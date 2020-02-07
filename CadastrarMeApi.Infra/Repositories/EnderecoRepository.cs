using System;
using System.Linq;
using System.Collections.Generic;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Infra.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace CadastrarMeApi.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CadastrarMeDataContext _context;
        public EnderecoRepository(CadastrarMeDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Endereco> Listar()
        {
            return _context.Enderecos.AsNoTracking().ToList();
        }
        public Endereco ListarPorId(Guid id)
        {
            return _context.Enderecos
                .Where(e => e.Id == id)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public Endereco ListarPorCliente(Guid id)
        {
            return _context.Enderecos
                .Include(e => e.Cliente)
                .Where(e => e.ClienteId == id)
                .AsNoTracking()
                .FirstOrDefault();
        }
        public void Inserir(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }
        public void Atualizar(Endereco endereco)
        {
            _context.Entry<Endereco>(endereco).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Excluir(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
        }
    }
}