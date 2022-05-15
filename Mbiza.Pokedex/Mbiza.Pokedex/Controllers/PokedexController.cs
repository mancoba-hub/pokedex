using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mbiza.Pokedex
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    public class PokedexController : ControllerBase
    {
        #region Properties

        private readonly ILogger<PokedexController> _loggerControler;
        private readonly IPokedexService _pokedexService;
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public PokedexController(ILogger<PokedexController> loggerControler, IPokedexService pokedexService, IConfiguration configuration)
        {
            _loggerControler = loggerControler;
            _pokedexService = pokedexService;
            _configuration = configuration;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the list of pokemons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ModelPokemon>> Get()
        {
            try
            {
                int limit = _configuration["Pokedex:Limit"].ToInt32();
                int offset = _configuration["Pokedex:Offset"].ToInt32();

                return await _pokedexService.GetPokemonList(limit, offset);
            }
            catch (Exception exc)
            {
                _loggerControler.LogError($"Error occured while getting pokemons : {exc.ToString()}");
                throw;
            }
        }

        /// <summary>
        /// Gets the pokemon details
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<ModelPokemon>> GetPokemon(string name)
        {
            try
            {
                return await _pokedexService.GetPokemon(name);
            }
            catch (Exception exc)
            {
                _loggerControler.LogError($"Error occured while getting pokemons : {exc.ToString()}");
                throw;
            }
        }

        /// <summary>
        /// Searches for the pokemons
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/search/{name}")]
        public async Task<IEnumerable<ModelPokemon>> SearchPokemon(string name)
        {
            try
            {
                int limit = _configuration["Pokedex:Limit"].ToInt32();
                int offset = _configuration["Pokedex:Offset"].ToInt32();

                return await _pokedexService.SearchPokemons(name, limit, offset);
            }
            catch (Exception exc)
            {
                _loggerControler.LogError($"Error occured while getting pokemons : {exc.ToString()}");
                throw;
            }
        }

        #endregion
    }
}
