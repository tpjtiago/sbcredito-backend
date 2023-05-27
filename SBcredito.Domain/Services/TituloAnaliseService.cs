using AutoMapper;
using SBcredito.Domain.Contracts.Repositories;
using SBcredito.Domain.Contracts.Services;
using SBcredito.Domain.Entities;
using SBcredito.Domain.Models;
using SBcredito.Domain.Utils.ExceptionResponse;

namespace SBcredito.Domain.Services
{
    public class TituloAnaliseService : ITituloAnaliseService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TituloAnalise> _repository;
        public TituloAnaliseService(IMapper mapper, IRepository<TituloAnalise> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TituloAnalise> Add(TituloAnaliseModel championshipModel)
        {
            var result = await _repository.Add(_mapper.Map<TituloAnalise>(championshipModel));

            return result;

        }

        public async Task<TituloAnaliseModel> GetbyId(int id)
        {
            var result = await _repository.Get(id);

            return _mapper.Map<TituloAnaliseModel>(result);
        }

        public async Task<List<TituloAnaliseModel>> GetAll()
        {
            var result = await _repository.GetAll();

            return _mapper.Map<List<TituloAnaliseModel>>(result);
        }

        public async Task<TituloAnalise> Update(int id, TituloAnaliseModel championshipModel)
        {
            var titulo = await _repository.Get(id);

            if (titulo == null)
            {
                throw new NotFoundException($"Titulo não encontrado");
            }

            var tituloMap = _mapper.Map(championshipModel, titulo);

            var result = await _repository.Update(tituloMap);

            return result;
        }

        public async Task Remove(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<TotalAnaliseModel> GetTotal()
        {
            var totalAnaliseModel = new TotalAnaliseModel();
            var result = await _repository.GetAll();

            var total = result.Sum(c => c.ValorFace);

            totalAnaliseModel.Total = total;

            return totalAnaliseModel;
        }
    }
}
