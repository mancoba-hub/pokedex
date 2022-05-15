using PokeApiNet;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
        public async Task<Pokemon> GetPokemon(string name)
        {
            return await _pokeApiClient.GetResourceAsync<Pokemon>(name);
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

        /// <summary>
        /// Searches for the pokemons
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<List<NamedApiResource<Pokemon>>> SearchPokemons(string name, int limit, int offset)
        {
            List<NamedApiResource<Pokemon>> pokemonList = new List<NamedApiResource<Pokemon>>();
            NamedApiResource<Pokemon> pokemon = new NamedApiResource<Pokemon>();
            bool canContinue = false;
            do
            {
                pokemonList = await GetPokemonList(limit, offset);
                pokemonList = pokemonList.Where(x => x.Name.Contains(name)).ToList();
                if (pokemonList.Any())
                    canContinue = true;
                else
                    offset += limit;
            }
            while (!canContinue);

            return pokemonList;
        }

        #endregion
    }
}
