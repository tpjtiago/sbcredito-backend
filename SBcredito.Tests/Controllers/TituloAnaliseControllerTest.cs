using Microsoft.AspNetCore.Mvc;
using Moq;
using SBcredito.API.Controllers;
using SBcredito.Domain.Contracts.Services;
using SBcredito.Domain.Entities;
using SBcredito.Domain.Models;
using SBcredito.Domain.Utils.ExceptionResponse;

namespace SBcredito.Tests.Controllers
{
    public class TituloAnaliseControllerTest
    {
        private readonly Mock<ITituloAnaliseService> _tituloAnaliseServiceMock;
        private readonly TituloAnaliseController _tituloAnaliseController;

        public TituloAnaliseControllerTest()
        {
            _tituloAnaliseServiceMock = new Mock<ITituloAnaliseService>();
            _tituloAnaliseController = new TituloAnaliseController(_tituloAnaliseServiceMock.Object);
        }

        [Fact]
        public async Task Post_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var model = new TituloAnaliseModel();
            var entity = new TituloAnalise();
            _tituloAnaliseServiceMock.Setup(s => s.Add(model)).ReturnsAsync(entity);

            // Act
            var result = await _tituloAnaliseController.Post(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(entity, okResult.Value);
            _tituloAnaliseServiceMock.Verify(s => s.Add(model), Times.Once);
        }

        [Fact]
        public async Task GetById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 100;

            var tituloAnaliseServiceMock = new Mock<ITituloAnaliseService>();
            tituloAnaliseServiceMock.Setup(x => x.GetbyId(id))
                .ReturnsAsync((TituloAnaliseModel)null);

            var controller = new TituloAnaliseController(tituloAnaliseServiceMock.Object);

            // Act
            var result = await controller.GetById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var id = 1;
            TituloAnaliseModel tituloAnaliseModel = DataTest();

            var tituloAnaliseServiceMock = new Mock<ITituloAnaliseService>();
            tituloAnaliseServiceMock.Setup(x => x.GetbyId(id))
                .ReturnsAsync(tituloAnaliseModel);

            var controller = new TituloAnaliseController(tituloAnaliseServiceMock.Object);

            // Act
            var result = await controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TituloAnaliseModel>(okResult.Value);
            Assert.Equal(tituloAnaliseModel, model);
        }
        [Fact]
        public async Task Get_ModelsExist_ReturnsOkResult()
        {
            // Arrange
            var tituloAnaliseModels = new List<TituloAnaliseModel>
            {
                new TituloAnaliseModel
                {
                    CNPJ = "59095115000150",
                    NomeSacado = "Angela Silva",
                    Telefone = "15997246345",
                    CEP = 18031350,
                    EnderecoCobranca = "Alameda Araguaia, 200",
                    Estado = "SP",
                    Cidade = "Barueri",
                    Bairro = "Jardim Tulipas",
                    DataEmissao = DateTime.Now,
                    ValorFace = 1000,
                    ValorDesconto = 10
                },               
            };

            var tituloAnaliseServiceMock = new Mock<ITituloAnaliseService>();
            tituloAnaliseServiceMock.Setup(x => x.GetAll())
                .ReturnsAsync(tituloAnaliseModels);

            var controller = new TituloAnaliseController(tituloAnaliseServiceMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var models = Assert.IsType<List<TituloAnaliseModel>>(okResult.Value);
            Assert.Equal(tituloAnaliseModels, models);
        }

        [Fact]
        public async Task Get_NoModels_ReturnsNotFoundResult()
        {
            // Arrange
            var tituloAnaliseServiceMock = new Mock<ITituloAnaliseService>();
            tituloAnaliseServiceMock.Setup(x => x.GetAll())
                .ReturnsAsync((List<TituloAnaliseModel>)null);

            var controller = new TituloAnaliseController(tituloAnaliseServiceMock.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Put_ExistingIdAndValidModel_ReturnsOkResult()
        {
            // Arrange
            var id = 1;
            var model = new TituloAnaliseModel();
            var updatedEntity = new TituloAnalise();
            _tituloAnaliseServiceMock.Setup(s => s.Update(id, model)).ReturnsAsync(updatedEntity);

            // Act
            var result = await _tituloAnaliseController.Put(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(updatedEntity, okResult.Value);
            _tituloAnaliseServiceMock.Verify(s => s.Update(id, model), Times.Once);
        }

        [Fact]
        public async Task Put_NonExistingId_ThrowsNotFoundException()
        {
            // Arrange
            var id = 1;
            var model = new TituloAnaliseModel();
            _tituloAnaliseServiceMock.Setup(s => s.Update(id, model)).ThrowsAsync(new NotFoundException("Titulo não encontrado"));

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _tituloAnaliseController.Put(id, model));
            _tituloAnaliseServiceMock.Verify(s => s.Update(id, model), Times.Once);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _tituloAnaliseController.Delete(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
            _tituloAnaliseServiceMock.Verify(s => s.Remove(id), Times.Once);
        }

        [Fact]
        public async Task Delete_NonExistingId_ThrowsNotFoundException()
        {
            // Arrange
            var id = 1;
            _tituloAnaliseServiceMock.Setup(s => s.Remove(id)).ThrowsAsync(new NotFoundException("Titulo não encontrado"));

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _tituloAnaliseController.Delete(id));
            _tituloAnaliseServiceMock.Verify(s => s.Remove(id), Times.Once);
        }

        private static TituloAnaliseModel DataTest()
        {
            return new TituloAnaliseModel
            {
                CNPJ = "59095115000150",
                NomeSacado = "Tiago Pedro",
                Telefone = "15997246345",
                CEP = 18031350,
                EnderecoCobranca = "João Benedito de Almeida",
                Estado = "SP",
                Cidade = "Sorocaba",
                Bairro = "Jardim Piazza de Roma II",
                DataEmissao = DateTime.Now,
                ValorFace = 1000,
                ValorDesconto = 10
            };
        }
    }
}
