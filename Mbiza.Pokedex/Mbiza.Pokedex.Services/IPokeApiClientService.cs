using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mbiza.Pokedex
{
    public interface IPokeApiClientService
    {
        public Task<List<NamedApiResource<Pokemon>>> GetPokemonList(int limit, int offset);

        public Task<PokemonSpecies> GetPokemon(string name);
    }
}
