using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Entities;

namespace Projeto.Repository.Mappings
{
    public class VendaContatoMap : EntityTypeConfiguration<VendaContato>
    {
        public VendaContatoMap()
        {
            ToTable("VendaContato");

            HasKey(p => p.VendaContatoID);

            Property(p => p.VendaContatoID)
                    .HasColumnName("VendaContatoId")
                    .IsRequired();

            //HasKey(p => p.ContatoID);

            //Property(p => p.ContatoID)
            //        .HasColumnName("ContatoId")
            //        .IsRequired();

            Property(p => p.DataVenda)
        .HasColumnName("DataVenda")
        .IsRequired();

            Property(p => p.Valor)
        .HasColumnName("Valor")
        .IsRequired();


            HasRequired(p => p.Contato)
            .WithMany()
            .HasForeignKey(p => p.ContatoID);
        }
    }
}