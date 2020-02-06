using System;
using CadastrarMeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastrarMeApi.Infra.Persistence.Maps
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .ToTable("Endereco");

            builder
                .Property(x => x.Id);

            builder
                .Property(x => x.Logradouro)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Bairro)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder
                .Property(x => x.Cidade)
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder
                .Property(x => x.Estado)
                .HasColumnType("varchar(40)")
                .IsRequired();
        }
    }
}