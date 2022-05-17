using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Text;

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
            var abilities = pokemon.Abilities.Where(x => !x.IsHidden).ToList();
            var statList = pokemon.Stats.Where(x => x.Effort == 1).ToList();
            StringBuilder abilityList = new StringBuilder();
            StringBuilder stats = new StringBuilder();
            foreach(var ability in abilities)
            {
                if (abilityList.Length == 0)
                    abilityList.Append(ability.Ability.Name);
                else
                    abilityList.Append($", {ability.Ability.Name}");
            }
            foreach (var stat in statList)
            {
                if (stats.Length == 0)
                    stats.Append(stat.Stat.Name);
                else
                    stats.Append($", {stat.Stat.Name}");
            }
            return new ModelPokemon
            {
                Id = pokemon.Id,    
                Name = pokemon.Name,
                ImageFrontUrl = pokemon.Sprites.FrontShiny,
                ImageBackUrl = pokemon.Sprites.BackShiny,
                Weight = pokemon.Weight.ToString(),
                Abilities = abilityList.ToString(),
                Stats = stats.ToString()
            };
        }

        /// <summary>
        /// Get the list of pokemons
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ModelPokemon>> GetPokemonList(int limit, int offset)
        {
            List<ModelPokemon> pokemons = new List<ModelPokemon>();
            var pokemonList = await _pokeApiClient.GetPokemonList(limit, offset);
            foreach(var pokemon in pokemonList)
            {
                var detail = await GetPokemon(pokemon.Name);
                pokemons.Add(detail);
            }
            return pokemons;
        }

        /// <summary>
        /// Searches for the pokemons
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ModelPokemon>> SearchPokemons(string name, int limit, int offset)
        {
            List<ModelPokemon> pokemons = new List<ModelPokemon>();
            var pokemonList = await _pokeApiClient.SearchPokemons(name, limit, offset);
            foreach (var pokemon in pokemonList)
            {
                var detail = await GetPokemon(pokemon.Name);
                pokemons.Add(detail);
            }
            return pokemons;
        }

        #endregion
    }
}
