using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace Mbiza.Pokedex
{
    public class PokedexService : IPokedexService
    {
        #region Properties

        private readonly IPokeApiClientService _pokeApiClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexService"/> class.
        /// </summary>
        /// <param name="pokeApiClient"></param>
        public PokedexService(IPokeApiClientService pokeApiClient)
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
        public async Task<ModelPokemon> GetPokemon(string name)
        {
            var pokemon = await _pokeApiClient.GetPokemon(name);            
            return new ModelPokemon
            {
                Id = pokemon.Id,    
                Name = pokemon.Name,
                Habitat = pokemon.Habitat.Name,
                Color = pokemon.Color.Name,
                IsBaby = pokemon.IsBaby,
                IsMythical = pokemon.IsMythical,
                IsLegendary = pokemon.IsLegendary
            };
        }

        /// <summary>
        /// Get the list of pokemons
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPokemonList(int limit, int offset)
        {
            var pokemonList = await _pokeApiClient.GetPokemonList(limit, offset);
            var js = JsonSerializer.Serialize(pokemonList);
            Console.WriteLine(js);
            return pokemonList.Select(x => x.Name);
        }

        #endregion
    }
}
