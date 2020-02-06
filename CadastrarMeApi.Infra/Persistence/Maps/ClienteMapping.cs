using System;
using CadastrarMeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastrarMeApi.Infra.Persistence.Maps
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("Cliente");

            builder
                .Property(x => x.Id);

            builder
                .Property(x => x.Nome)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder
                .Property(x => x.CPF)
                .HasColumnName("Cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(x => x.DtNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Endereco>(e => e.ClienteId);
        }
    }
}