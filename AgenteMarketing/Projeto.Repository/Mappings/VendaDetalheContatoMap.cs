using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Projeto.Repository.Mappings
{
   public class VendaDetalheContatoMap : EntityTypeConfiguration<VendaDetalheContato>
    {
        public VendaDetalheContatoMap()
        {
            ToTable("VendaDetalheContato");

            HasKey(p => p.VendaDetalheContatoid);

            Property(p => p.VendaDetalheContatoid)
                    .HasColumnName("VendaDetalheContatoId")
                    .IsRequired();


            //HasKey(p => p.VendaContatoId);

            //Property(p => p.VendaContatoId)
            //        .HasColumnName("VendaContatoId")
            //        .IsRequired();

            //Property(p => p.ProdutoId)
            //    .HasColumnName("ProdutoId")
            //    .IsRequired();

            Property(p => p.Quantidade)
      .HasColumnName("Quantidade")
      .IsRequired();

            Property(p => p.Valor)
        .HasColumnName("Valor")
        .IsRequired();


            HasRequired(p => p.VendaContato)
                     .WithMany()
                     .HasForeignKey(p => p.VendaContatoId);

            HasRequired(p => p.Produto)
                   .WithMany()
                   .HasForeignKey(p => p.ProdutoId);
        }
    }
}