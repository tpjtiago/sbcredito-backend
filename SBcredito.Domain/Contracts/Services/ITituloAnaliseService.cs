using SBcredito.Domain.Entities;
using SBcredito.Domain.Models;

namespace SBcredito.Domain.Contracts.Services
{
    public interface ITituloAnaliseService
    {
        Task<TituloAnalise> Add(TituloAnaliseModel tituloAnaliseModel);
        Task<TituloAnaliseModel> GetbyId(int id);
        Task<List<TituloAnaliseModel>> GetAll();
        Task<TituloAnalise> Update(int id, TituloAnaliseModel tituloAnaliseModel);
        Task Remove(int id);
        Task<TotalAnaliseModel> GetTotal();
    }
}
