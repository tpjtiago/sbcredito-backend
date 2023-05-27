using SBcredito.Domain.Contracts;

namespace SBcredito.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
