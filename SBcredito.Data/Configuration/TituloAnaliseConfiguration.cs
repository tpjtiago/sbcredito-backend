using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBcredito.Domain.Entities;

namespace SBcredito.Data.Configuration
{
    public class TituloAnaliseConfiguration : IEntityTypeConfiguration<TituloAnalise>
    {
        public void Configure(EntityTypeBuilder<TituloAnalise> builder)
        {
            builder
                .ToTable("TitleReview")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.CNPJ)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.NomeSacado)
                .HasColumnName("Name")
                .IsRequired();

            builder
                .Property(x => x.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.CEP)
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property(x => x.EnderecoCobranca)
                .HasMaxLength(150)
                .HasColumnName("BillingAddress")
                .IsRequired();

            builder
                .Property(x => x.Estado)
                .HasMaxLength(2)
                .HasColumnName("State")
                .IsRequired();

            builder
                .Property(x => x.Cidade)
                .HasMaxLength(100)
                .HasColumnName("City")
                .IsRequired();

            builder
                .Property(x => x.Bairro)
                .HasMaxLength(100)
                .HasColumnName("Neighborhood")
                .IsRequired();

            builder
                .Property(x => x.DataEmissao)
                .HasColumnName("DateIssued")
                .IsRequired();

            builder
                .Property(x => x.ValorFace)
                .HasColumnName("FaceValue ")
                .IsRequired();

            builder
                .Property(x => x.ValorDesconto)
                .HasColumnName("DiscountValue")
                .IsRequired();
        }
    }
}
