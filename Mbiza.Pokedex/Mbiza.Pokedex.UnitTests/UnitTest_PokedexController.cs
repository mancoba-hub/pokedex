using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mbiza.Pokedex.UnitTests
{
    [TestClass]
    public class UnitTest_PokedexController
    {
        #region Properties

        private PokedexController _pokedexController;
        private Mock<ILogger<PokedexController>> _loggerPokedexControllerMock;
        private Mock<IPokedexService> _pokedexServiceMock;
        private Mock<IConfiguration> _configurationMock;

        #endregion

        #region Initialize

        [TestInitialize]
        public void InitializePage()
        {
            _loggerPokedexControllerMock = new Mock<ILogger<PokedexController>>(MockBehavior.Strict);
            _pokedexServiceMock = new Mock<IPokedexService>(MockBehavior.Strict);
            _configurationMock = new Mock<IConfiguration>();
            _configurationMock = GetConfiguration(_configurationMock);
        }

        #endregion

        #region Unit Tests

        [TestMethod]
        public void TestMethod_Get_Success()
        {
            //Arrange
            var pokemonList = GetPokemonList();

            _pokedexServiceMock.Setup(x => x.GetPokemonList(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(pokemonList));

            _pokedexController = new PokedexController(_loggerPokedexControllerMock.Object, _pokedexServiceMock.Object, _configurationMock.Object);

            //Act
            var response = _pokedexController.Get();

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestMethod_GetPokemon_Success()
        {
            //Arrange
            string pokemonName = "victreebel";
            var pokemon = GetPokemon();

            _pokedexServiceMock.Setup(x => x.GetPokemon(It.IsAny<string>())).Returns(Task.FromResult(pokemon));

            _pokedexController = new PokedexController(_loggerPokedexControllerMock.Object, _pokedexServiceMock.Object, _configurationMock.Object);

            //Act
            var response = _pokedexController.GetPokemon(pokemonName);

            //Assert
            Assert.IsNotNull(response);

            var poke = response.Result;
            Assert.AreEqual(pokemonName, poke.Value.Name);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the configuration
        /// </summary>
        /// <param name="configurationMock"></param>
        /// <returns></returns>
        private Mock<IConfiguration> GetConfiguration(Mock<IConfiguration> configurationMock)
        {
            Mock<IConfigurationSection> _configurationSectionLimitMock = new Mock<IConfigurationSection>();
            Mock<IConfigurationSection> _configurationSectionOffsetMock = new Mock<IConfigurationSection>();

            string limit = "100";
            _configurationSectionLimitMock.Setup(x => x.Value).Returns(limit);
            configurationMock.Setup(x => x.GetSection("Pokedex:Limit")).Returns(_configurationSectionLimitMock.Object);

            string offset = "0";
            _configurationSectionOffsetMock.Setup(x => x.Value).Returns(offset);
            configurationMock.Setup(x => x.GetSection("Pokedex:Offset")).Returns(_configurationSectionOffsetMock.Object);

            return configurationMock;
        }

        /// <summary>
        /// Gets the pokemon list
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ModelPokemon> GetPokemonList()
        {
            return new List<ModelPokemon>
            {
                new ModelPokemon { Name = "ivysaur" },
                new ModelPokemon { Name = "venusaur"},
                new ModelPokemon { Name = "charmander"},
                new ModelPokemon { Name = "charmeleon"},
                new ModelPokemon { Name = "charizard"},
                new ModelPokemon { Name = "squirtle"},
                new ModelPokemon { Name = "wartortle"},
                new ModelPokemon { Name = "blastoise"},
                new ModelPokemon { Name = "caterpie"},
                new ModelPokemon { Name = "metapod"},
                new ModelPokemon { Name = "butterfree"},
                new ModelPokemon { Name = "weedle"},
                new ModelPokemon { Name = "kakuna"},
                new ModelPokemon { Name = "beedrill"},
                new ModelPokemon { Name = "pidgey"},
                new ModelPokemon { Name = "pidgeotto"},
                new ModelPokemon { Name = "pidgeot"},
                new ModelPokemon { Name = "rattata"}
            };
        }

        /// <summary>
        /// Gets the pokemon
        /// </summary>
        /// <returns></returns>
        private ModelPokemon GetPokemon()
        {
            return new ModelPokemon
            {
                Id = 71,
                Name = "victreebel",
                Color = "green",
                Habitat = "forest",
                IsBaby = false,
                IsLegendary = false,
                IsMythical = false
            };
        }

        #endregion
    }
}
