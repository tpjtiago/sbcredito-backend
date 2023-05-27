using AutoMapper;
using Moq;
using SBcredito.Domain.Contracts.Repositories;
using SBcredito.Domain.Entities;
using SBcredito.Domain.Models;
using SBcredito.Domain.Services;
using SBcredito.Domain.Utils.ExceptionResponse;

namespace SBcredito.Tests.Services
{
    public class TituloAnaliseServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IRepository<TituloAnalise>> _repositoryMock;
        private readonly TituloAnaliseService _tituloAnaliseService;

        public TituloAnaliseServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepository<TituloAnalise>>();
            _tituloAnaliseService = new TituloAnaliseService(_mapperMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsAddedEntity()
        {
            // Arrange
            var model = new TituloAnaliseModel();
            var entity = new TituloAnalise();
            _mapperMock.Setup(m => m.Map<TituloAnalise>(model)).Returns(entity);
            _repositoryMock.Setup(r => r.Add(entity)).ReturnsAsync(entity);

            // Act
            var result = await _tituloAnaliseService.Add(model);

            // Assert
            Assert.Equal(entity, result);
            _mapperMock.Verify(m => m.Map<TituloAnalise>(model), Times.Once);
            _repositoryMock.Verify(r => r.Add(entity), Times.Once);
        }

        [Fact]
        public async Task GetbyId_ExistingId_ReturnsMappedModel()
        {
            // Arrange
            var id = 1;
            var entity = new TituloAnalise();
            var model = new TituloAnaliseModel();
            _repositoryMock.Setup(r => r.Get(id)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<TituloAnaliseModel>(entity)).Returns(model);

            // Act
            var result = await _tituloAnaliseService.GetbyId(id);

            // Assert
            Assert.Equal(model, result);
            _repositoryMock.Verify(r => r.Get(id), Times.Once);
            _mapperMock.Verify(m => m.Map<TituloAnaliseModel>(entity), Times.Once);
        }

        [Fact]
        public async Task GetAll_ReturnsMappedModels()
        {
            // Arrange
            var entities = new List<TituloAnalise> { new TituloAnalise(), new TituloAnalise() };
            var models = new List<TituloAnaliseModel> { new TituloAnaliseModel(), new TituloAnaliseModel() };
            _repositoryMock.Setup(r => r.GetAll()).ReturnsAsync(entities);
            _mapperMock.Setup(m => m.Map<List<TituloAnaliseModel>>(entities)).Returns(models);

            // Act
            var result = await _tituloAnaliseService.GetAll();

            // Assert
            Assert.Equal(models, result);
            _repositoryMock.Verify(r => r.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<TituloAnaliseModel>>(entities), Times.Once);
        }

        [Fact]
        public async Task Update_ExistingId_ReturnsUpdatedEntity()
        {
            // Arrange
            var id = 1;
            var model = new TituloAnaliseModel();
            var entity = new TituloAnalise();
            var updatedEntity = new TituloAnalise();
            _repositoryMock.Setup(r => r.Get(id)).ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map(model, entity)).Returns(updatedEntity);
            _repositoryMock.Setup(r => r.Update(updatedEntity)).ReturnsAsync(updatedEntity);

            // Act
            var result = await _tituloAnaliseService.Update(id, model);

            // Assert
            Assert.Equal(updatedEntity, result);
            _repositoryMock.Verify(r => r.Get(id), Times.Once);
            _mapperMock.Verify(m => m.Map(model, entity), Times.Once);
            _repositoryMock.Verify(r => r.Update(updatedEntity), Times.Once);
        }

        [Fact]
        public async Task Update_NonExistingId_ThrowsNotFoundException()
        {
            // Arrange
            var id = 1;
            var model = new TituloAnaliseModel();
            _repositoryMock.Setup(r => r.Get(id)).ReturnsAsync((TituloAnalise)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _tituloAnaliseService.Update(id, model));
            _repositoryMock.Verify(r => r.Get(id), Times.Once);
            _mapperMock.Verify(m => m.Map(model, It.IsAny<TituloAnalise>()), Times.Never);
            _repositoryMock.Verify(r => r.Update(It.IsAny<TituloAnalise>()), Times.Never);
        }

        [Fact]
        public async Task Remove_ExistingId_CallsRepositoryDelete()
        {
            // Arrange
            var id = 1;

            // Act
            await _tituloAnaliseService.Remove(id);

            // Assert
            _repositoryMock.Verify(r => r.Delete(id), Times.Once);
        }
    }
}
