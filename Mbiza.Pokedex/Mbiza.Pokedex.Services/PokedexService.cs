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
            var imageFront = pokemon.Sprites.FrontShiny;
            var imageBack = pokemon.Sprites.BackShiny;
            var abilities = pokemon.Abilities.Where(x => !x.IsHidden).ToList();
            StringBuilder abilityList = new StringBuilder();
            foreach(var ability in abilities)
            {
                if (abilityList.Length == 0)
                    abilityList.Append(ability.Ability.Name);
                else
                    abilityList.Append($", {ability.Ability.Name}");
            }
            List<string> strList = abilities.Select(x => x.Ability.Name).ToList();
            return new ModelPokemon
            {
                Id = pokemon.Id,    
                Name = pokemon.Name,
                ImageFrontUrl = imageFront,
                ImageBackUrl = imageBack,
                Weight = pokemon.Weight.ToString(),
                Abilities = abilityList.ToString()
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
                pokemons.Add(new ModelPokemon { Name = pokemon.Name });
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
                pokemons.Add(new ModelPokemon { Name = pokemon.Name });
            }
            return pokemons;
        }

        #endregion
    }
}
