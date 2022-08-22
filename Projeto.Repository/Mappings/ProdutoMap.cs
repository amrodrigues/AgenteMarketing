using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Repository.Mappings
{
   public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(p => p.ProdutoID);

            Property(p => p.ProdutoID)
                    .HasColumnName("ProdutoId")
                    .IsRequired();

            Property(p => p.NomeProduto)
           .HasColumnName("NomeProduto")
           .HasMaxLength(100)
           .IsRequired();

        }
    }
}