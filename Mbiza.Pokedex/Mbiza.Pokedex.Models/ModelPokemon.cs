namespace Mbiza.Pokedex
{
    public class ModelPokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Habitat { get; set; }

        public string Color { get; set; }

        public string ImageUrl { get; set; }

        public bool IsBaby { get; set; }

        public bool IsLegendary { get; set; }

        public bool IsMythical { get; set; }
    }
}
