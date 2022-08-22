using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repository.Mappings
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");

            HasKey(c => c.ContatoID);

            Property(c => c.ContatoID)
                .HasColumnName("ContatoId")
                .IsRequired();


            Property(c => c.Sexo)
             .HasColumnName("Sexo")
             .HasMaxLength(50)
             .IsRequired();

            Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            Property(c => c.CPF)
             .HasColumnName("CPF")
             .HasMaxLength(50)
             .IsRequired();

            Property(c => c.DataCadastro)
               .HasColumnName("DataCadastro")
               .IsRequired();

            Property(c => c.email)
          .HasColumnName("Email")
          .HasMaxLength(50)
          .IsRequired();

            Property(c => c.Nome)
    .HasColumnName("Nome")
    .HasMaxLength(100)
    .IsRequired();

        }
    }
}
