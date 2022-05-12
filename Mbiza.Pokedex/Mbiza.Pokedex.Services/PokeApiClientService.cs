using PokeApiNet;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mbiza.Pokedex
{
    public class PokeApiClientService : IPokeApiClientService
    {
        #region Properties

        private PokeApiClient _pokeApiClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PokeApiClientService"/> class.
        /// </summary>
        public PokeApiClientService()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PokeApiClientService"/> class.
        /// </summary>
        /// <param name="pokeApiClient"></param>
        public PokeApiClientService(PokeApiClient pokeApiClient)
        {
            _pokeApiClient = pokeApiClient;
        }

        #endregion

        #region Implemented Members

        /// <summary>
        /// Gets the pokemon
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<PokemonSpecies> GetPokemon(string name)
        {
            return await _pokeApiClient.GetResourceAsync<PokemonSpecies>(name);
        }

        /// <summary>
        /// Gets the pokemon list
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<List<NamedApiResource<Pokemon>>> GetPokemonList(int limit, int offset)
        {
            if (limit <= 0)
                limit = 100;

            var response = await _pokeApiClient.GetNamedResourcePageAsync<Pokemon>(limit, offset);
            return response.Results;
        }

        #endregion
    }
}
