using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket.TicketManagement.Domain.Entities;

namespace Ticket.TicketManagement.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}
