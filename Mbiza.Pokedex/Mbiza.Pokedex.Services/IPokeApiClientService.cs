using PokeApiNet;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mbiza.Pokedex
{
    public interface IPokeApiClientService
    {
        public Task<List<NamedApiResource<Pokemon>>> SearchPokemons(string name, int limit, int offset);

        public Task<List<NamedApiResource<Pokemon>>> GetPokemonList(int limit, int offset);

        public Task<Pokemon> GetPokemon(string name);
    }
}
