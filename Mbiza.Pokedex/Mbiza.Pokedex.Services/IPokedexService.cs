using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mbiza.Pokedex
{
    public interface IPokedexService
    {
        public Task<IEnumerable<string>> GetPokemonList(int limit, int offset);

        public Task<ModelPokemon> GetPokemon(string name);
    }
}
