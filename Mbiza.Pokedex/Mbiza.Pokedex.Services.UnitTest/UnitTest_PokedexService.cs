using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokeApiNet;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mbiza.Pokedex.Services.UnitTest
{
    [TestClass]
    public class UnitTest_PokedexService
    {
        #region Properties

        private Mock<IPokedexService> _pokedexServiceMock;
        private Mock<IPokeApiClientService> _pokeapiClientMock;
        private string _pokemonDetails;

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the page
        /// </summary>
        [TestInitialize]
        public void InitializePage()
        {
            _pokedexServiceMock = new Mock<IPokedexService>(MockBehavior.Strict);
            _pokeapiClientMock = new Mock<IPokeApiClientService>(MockBehavior.Loose);
            _pokemonDetails = "{\"Id\":71,\"Name\":\"victreebel\",\"Order\":77,\"GenderRate\":4,\"CaptureRate\":45,\"BaseHappiness\":70,\"IsBaby\":false,\"IsLegendary\":false,\"IsMythical\":false,\"HatchCounter\":20,\"HasGenderDifferences\":false,\"FormsSwitchable\":false,\"GrowthRate\":{\"Name\":\"medium-slow\",\"Url\":\"https://pokeapi.co/api/v2/growth-rate/4/\"},\"PokedexNumbers\":[{\"EntryNumber\":71,\"Pokedex\":{\"Name\":\"national\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/1/\"}},{\"EntryNumber\":71,\"Pokedex\":{\"Name\":\"kanto\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/2/\"}},{\"EntryNumber\":66,\"Pokedex\":{\"Name\":\"original-johto\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/3/\"}},{\"EntryNumber\":66,\"Pokedex\":{\"Name\":\"updated-johto\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/7/\"}},{\"EntryNumber\":28,\"Pokedex\":{\"Name\":\"kalos-mountain\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/14/\"}},{\"EntryNumber\":71,\"Pokedex\":{\"Name\":\"letsgo-kanto\",\"Url\":\"https://pokeapi.co/api/v2/pokedex/26/\"}}],\"EggGroups\":[{\"Name\":\"plant\",\"Url\":\"https://pokeapi.co/api/v2/egg-group/7/\"}],\"Color\":{\"Name\":\"green\",\"Url\":\"https://pokeapi.co/api/v2/pokemon-color/5/\"},\"Shape\":{\"Name\":\"blob\",\"Url\":\"https://pokeapi.co/api/v2/pokemon-shape/5/\"},\"EvolvesFromSpecies\":{\"Name\":\"weepinbell\",\"Url\":\"https://pokeapi.co/api/v2/pokemon-species/70/\"},\"EvolutionChain\":{\"Url\":\"https://pokeapi.co/api/v2/evolution-chain/29/\"},\"Habitat\":{\"Name\":\"forest\",\"Url\":\"https://pokeapi.co/api/v2/pokemon-habitat/2/\"},\"Generation\":{\"Name\":\"generation-i\",\"Url\":\"https://pokeapi.co/api/v2/generation/1/\"},\"Names\":[{\"Name\":\"\\u30A6\\u30C4\\u30DC\\u30C3\\u30C8\",\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"Name\":\"Utsubot\",\"Language\":{\"Name\":\"roomaji\",\"Url\":\"https://pokeapi.co/api/v2/language/2/\"}},{\"Name\":\"\\uC6B0\\uCE20\\uBCF4\\uD2B8\",\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"Name\":\"\\u5927\\u98DF\\u82B1\",\"Language\":{\"Name\":\"zh-Hant\",\"Url\":\"https://pokeapi.co/api/v2/language/4/\"}},{\"Name\":\"Empiflor\",\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"Name\":\"Sarzenia\",\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"Name\":\"Victreebel\",\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"Name\":\"Victreebel\",\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"Name\":\"Victreebel\",\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"Name\":\"\\u30A6\\u30C4\\u30DC\\u30C3\\u30C8\",\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"Name\":\"\\u5927\\u98DF\\u82B1\",\"Language\":{\"Name\":\"zh-Hans\",\"Url\":\"https://pokeapi.co/api/v2/language/12/\"}}],\"PalParkEncounters\":[{\"BaseScore\":70,\"Rate\":20,\"Area\":{\"Name\":\"forest\",\"Url\":\"https://pokeapi.co/api/v2/pal-park-area/1/\"}}],\"FlavorTextEntries\":[{\"FlavorText\":\"Said to live in\\nhuge colonies\\ndeep in jungles,\\falthough no one\\nhas ever returned\\nfrom there.\",\"Version\":{\"Name\":\"red\",\"Url\":\"https://pokeapi.co/api/v2/version/1/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Said to live in\\nhuge colonies\\ndeep in jungles,\\falthough no one\\nhas ever returned\\nfrom there.\",\"Version\":{\"Name\":\"blue\",\"Url\":\"https://pokeapi.co/api/v2/version/2/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Lures prey with\\nthe sweet aroma of\\nhoney. Swallowed\\fwhole, the prey is\\nmelted in a day,\\nbones and all.\",\"Version\":{\"Name\":\"yellow\",\"Url\":\"https://pokeapi.co/api/v2/version/3/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"ACID that has dis\\u00AD\\nsolved many prey\\nbecomes sweeter,\\fmaking it even\\nmore effective at\\nattracting prey.\",\"Version\":{\"Name\":\"gold\",\"Url\":\"https://pokeapi.co/api/v2/version/4/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"This horrifying\\nplant POK\\u00E9MON at\\u00AD\\ntracts prey with\\faromatic honey,\\nthen melts them in\\nits mouth.\",\"Version\":{\"Name\":\"silver\",\"Url\":\"https://pokeapi.co/api/v2/version/5/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Once ingested into\\nthis POK\\u00E9MON\\u0027s\\nbody, even the\\fhardest object\\nwill melt into\\nnothing.\",\"Version\":{\"Name\":\"crystal\",\"Url\":\"https://pokeapi.co/api/v2/version/6/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"VICTREEBEL has a long vine that\\nextends from its head. This vine is\\nwaved and flicked about as if it were\\fan animal to attract prey. When an\\nunsuspecting prey draws near, this\\nPOK\\u00E9MON swallows it whole.\",\"Version\":{\"Name\":\"ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/7/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"VICTREEBEL has a long vine that\\nextends from its head. This vine is\\nwaved and flicked about as if it were\\fan animal to attract prey. When an\\nunsuspecting prey draws near, this\\nPOK\\u00E9MON swallows it whole.\",\"Version\":{\"Name\":\"sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/8/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"The long vine extending from its head is\\nwaved about as if it were a living thing to\\nattract prey. When an unsuspecting victim\\napproaches, it is swallowed whole.\",\"Version\":{\"Name\":\"emerald\",\"Url\":\"https://pokeapi.co/api/v2/version/9/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Lures prey into its mouth with a honeylike\\naroma. The helpless prey is melted with\\na dissolving fluid.\",\"Version\":{\"Name\":\"firered\",\"Url\":\"https://pokeapi.co/api/v2/version/10/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Said to live in huge colonies deep in\\njungles, although no one has ever\\nreturned from there.\",\"Version\":{\"Name\":\"leafgreen\",\"Url\":\"https://pokeapi.co/api/v2/version/11/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honeylike scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"diamond\",\"Url\":\"https://pokeapi.co/api/v2/version/12/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honeylike scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"pearl\",\"Url\":\"https://pokeapi.co/api/v2/version/13/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honeylike scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"platinum\",\"Url\":\"https://pokeapi.co/api/v2/version/14/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Acid that has dissolved many prey\\nbecomes sweeter, making it even\\nmore effective at attracting prey.\",\"Version\":{\"Name\":\"heartgold\",\"Url\":\"https://pokeapi.co/api/v2/version/15/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"This horrifying plant Pok\\u00E9mon attracts\\nprey with aromatic honey,\\nthen melts them in its mouth.\",\"Version\":{\"Name\":\"soulsilver\",\"Url\":\"https://pokeapi.co/api/v2/version/16/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Sa bouche s\\u00E9cr\\u00E8te un fluide \\u00E0\\nl\\u2019odeur de miel, qui s\\u2019av\\u00E8re \\u00EAtre\\nun acide extr\\u00EAmement corrosif.\",\"Version\":{\"Name\":\"black\",\"Url\":\"https://pokeapi.co/api/v2/version/17/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honeylike scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"black\",\"Url\":\"https://pokeapi.co/api/v2/version/17/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"Sa bouche s\\u00E9cr\\u00E8te un fluide \\u00E0\\nl\\u2019odeur de miel, qui s\\u2019av\\u00E8re \\u00EAtre\\nun acide extr\\u00EAmement corrosif.\",\"Version\":{\"Name\":\"white\",\"Url\":\"https://pokeapi.co/api/v2/version/18/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honeylike scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"white\",\"Url\":\"https://pokeapi.co/api/v2/version/18/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honey-like scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"black-2\",\"Url\":\"https://pokeapi.co/api/v2/version/21/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"It pools in its mouth a fluid with\\na honey-like scent, which is really\\nan acid that dissolves anything.\",\"Version\":{\"Name\":\"white-2\",\"Url\":\"https://pokeapi.co/api/v2/version/22/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u30B8\\u30E3\\u30F3\\u30B0\\u30EB\\u306E\\u3000\\u304A\\u304F\\u3061\\u306B\\u3000\\u30A6\\u30C4\\u30DC\\u30C3\\u30C8\\n\\u3070\\u304B\\u308A\\u3000\\u3044\\u308B\\u3000\\u3061\\u305F\\u3044\\u304C\\u3000\\u3042\\u3063\\u3066\\n\\u3044\\u3063\\u305F\\u3089\\u3000\\uFF12\\u3069\\u3068\\u3000\\u304B\\u3048\\u3063\\u3066\\u3053\\u308C\\u306A\\u3044\\u3002\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uC815\\uAE00\\uC758 \\uC548\\uCABD\\uC5D0 \\uC6B0\\uCE20\\uBCF4\\uD2B8\\uB9CC\\n\\uC788\\uB294 \\uC9C0\\uB300\\uAC00 \\uC788\\uC5B4\\uC11C\\n\\uD55C \\uBC88 \\uAC00\\uBA74 \\uB450 \\uBC88 \\uB2E4\\uC2DC \\uB3CC\\uC544\\uC62C \\uC218 \\uC5C6\\uB2E4.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"On dit qu\\u2019il vit en colonie dans la jungle, mais\\npersonne n\\u2019en est jamais revenu vivant pour\\nle confirmer.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Dieses Pok\\u00E9mon soll in gro\\u00DFen Kolonien\\ntief im Dschungel leben, doch niemand\\nkann dies best\\u00E4tigen.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Dicen que vive en grandes colonias en el interior de\\nlas junglas, aunque nadie ha podido verificarlo.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Pare che viva in grandi colonie nel cuore della giungla,\\nma nessuno \\u00E8 mai tornato da l\\u00EC per raccontarlo.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Said to live in huge colonies deep in jungles,\\nalthough no one has ever returned from there.\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u30B8\\u30E3\\u30F3\\u30B0\\u30EB\\u306E\\u3000\\u5965\\u5730\\u306B\\u3000\\u30A6\\u30C4\\u30DC\\u30C3\\u30C8\\n\\u3070\\u304B\\u308A\\u3000\\u3044\\u308B\\u3000\\u5730\\u5E2F\\u304C\\u3000\\u3042\\u3063\\u3066\\n\\u884C\\u3063\\u305F\\u3089\\u3000\\uFF12\\u5EA6\\u3068\\u3000\\u5E30\\u3063\\u3066\\u3053\\u308C\\u306A\\u3044\\u3002\",\"Version\":{\"Name\":\"x\",\"Url\":\"https://pokeapi.co/api/v2/version/23/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u305F\\u3044\\u306A\\u3044\\u306B\\u3000\\u3068\\u308A\\u3053\\u307E\\u308C\\u305F\\u3000\\u3082\\u306E\\u306F\\n\\u3069\\u3093\\u306A\\u306B\\u3000\\u304B\\u305F\\u304F\\u3066\\u3082\\u3000\\u3088\\u3046\\u304B\\u3044\\u3048\\u304D\\u3067\\n\\u3042\\u3068\\u304B\\u305F\\u306A\\u304F\\u3000\\u3068\\u304B\\u3055\\u308C\\u3066\\u3057\\u307E\\u3046\\u3002\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uCCB4\\uB0B4\\uB85C \\uAC70\\uB46C\\uB4E4\\uC778 \\uAC83\\uC740\\n\\uC544\\uBB34\\uB9AC \\uB2E8\\uB2E8\\uD560\\uC9C0\\uB77C\\uB3C4 \\uC6A9\\uD574\\uC561\\uC73C\\uB85C\\n\\uD754\\uC801\\uB3C4 \\uC5C6\\uC774 \\uB179\\uC5EC\\uBC84\\uB9B0\\uB2E4.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"Tout corps ing\\u00E9r\\u00E9 par ce Pok\\u00E9mon est\\nsyst\\u00E9matiquement dissous en bouillie.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Selbst die h\\u00E4rtesten Objekte werden zersetzt,\\nwenn der K\\u00F6rper sie erst aufgenommen hat.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Cuando este Pok\\u00E9mon ingiere algo, incluso el objeto\\nm\\u00E1s duro se disolver\\u00E1 al instante.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Anche l\\u2019oggetto pi\\u00F9 resistente si scioglie non appena\\nviene ingerito da questo Pok\\u00E9mon.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Once ingested into this Pok\\u00E9mon\\u2019s body,\\neven the hardest object will melt into nothing.\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u4F53\\u5185\\u306B\\u3000\\u53D6\\u308A\\u3053\\u307E\\u308C\\u305F\\u3000\\u3082\\u306E\\u306F\\n\\u3069\\u3093\\u306A\\u306B\\u3000\\u786C\\u304F\\u3066\\u3082\\u3000\\u6EB6\\u89E3\\u6DB2\\u3067\\n\\u8DE1\\u5F62\\u306A\\u304F\\u3000\\u6EB6\\u304B\\u3055\\u308C\\u3066\\u3057\\u307E\\u3046\\u3002\",\"Version\":{\"Name\":\"y\",\"Url\":\"https://pokeapi.co/api/v2/version/24/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u3042\\u305F\\u307E\\u306B\\u3000\\u3064\\u3044\\u305F\\u3000\\u306A\\u304C\\u3044\\u3000\\u3064\\u308B\\u3092\\u3000\\u3061\\u3044\\u3055\\u306A\\n\\u3044\\u304D\\u3082\\u306E\\u306E\\u3000\\u3088\\u3046\\u306B\\u3000\\u3046\\u3054\\u304B\\u3057\\u3000\\u3048\\u3082\\u306E\\u3092\\u3000\\u3055\\u305D\\u3046\\u3002\\n\\u3061\\u304B\\u3065\\u3044\\u3066\\u304D\\u305F\\u3000\\u3068\\u3053\\u308D\\u3092\\u3000\\u3071\\u304F\\u308A\\u3068\\u3000\\u3072\\u3068\\u306E\\u307F\\u3002\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uBA38\\uB9AC\\uC5D0 \\uB2EC\\uB9B0 \\uAE34 \\uB369\\uAD74\\uC744 \\uC791\\uC740\\n\\uC0DD\\uBB3C\\uCC98\\uB7FC \\uC6C0\\uC9C1\\uC5EC\\uC11C \\uBA39\\uC774\\uB97C \\uC720\\uC778\\uD55C\\uB2E4.\\n\\uAC00\\uAE4C\\uC774 \\uC654\\uC744 \\uB54C \\uB365\\uC11D \\uD55C \\uBC88\\uC5D0 \\uC0BC\\uD0A8\\uB2E4.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"Empiflor est dot\\u00E9 d\\u2019une longue liane qui part de sa t\\u00EAte.\\nCette liane se balance et remue comme un animal pour attirer\\nses proies. Lorsque l\\u2019une d\\u2019elles s\\u2019approche un peu trop pr\\u00E8s,\\nce Pok\\u00E9mon l\\u2019avale enti\\u00E8rement.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Aus Sarzenias Kopf ragt eine lange Ranke hervor, die es\\nbewegt, als w\\u00E4re sie ein kleines Lebewesen. N\\u00E4hert sich\\nahnungslose Beute dieser Falle, verschlingt Sarzenia\\nsie im Ganzen.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Victreebel tiene una enredadera que le sale de la cabeza y\\nque agita a modo de se\\u00F1uelo para atraer a sus presas y as\\u00ED\\nengullirlas por sorpresa cuando estas se aproximan incautas.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Victreebel \\u00E8 dotato di una lunga liana che parte dalla testa.\\nIl Pok\\u00E9mon la sventola e la agita come fosse un\\u2019esca\\nper attirare la preda. Quando la preda ignara\\nsi avvicina, il Pok\\u00E9mon la inghiotte in un sol boccone.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Victreebel has a long vine that extends from its head.\\nThis vine is waved and flicked about as if it were an animal to\\nattract prey. When an unsuspecting prey draws near, this\\nPok\\u00E9mon swallows it whole.\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u982D\\u306B\\u3000\\u3064\\u3044\\u305F\\u3000\\u9577\\u3044\\u3000\\u3064\\u308B\\u3092\\u3000\\u5C0F\\u3055\\u306A\\n\\u751F\\u304D\\u7269\\u306E\\u3000\\u3088\\u3046\\u306B\\u3000\\u52D5\\u304B\\u3057\\u3000\\u7372\\u7269\\u3092\\u3000\\u8A98\\u3046\\u3002\\n\\u8FD1\\u3065\\u3044\\u3066\\u304D\\u305F\\u3000\\u3068\\u3053\\u308D\\u3092\\u3000\\u3071\\u304F\\u308A\\u3068\\u3000\\u3072\\u3068\\u306E\\u307F\\u3002\",\"Version\":{\"Name\":\"omega-ruby\",\"Url\":\"https://pokeapi.co/api/v2/version/25/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u3042\\u305F\\u307E\\u306B\\u3000\\u3064\\u3044\\u305F\\u3000\\u306A\\u304C\\u3044\\u3000\\u3064\\u308B\\u3092\\u3000\\u3061\\u3044\\u3055\\u306A\\n\\u3044\\u304D\\u3082\\u306E\\u306E\\u3000\\u3088\\u3046\\u306B\\u3000\\u3046\\u3054\\u304B\\u3057\\u3000\\u3048\\u3082\\u306E\\u3092\\u3000\\u3055\\u305D\\u3046\\u3002\\n\\u3061\\u304B\\u3065\\u3044\\u3066\\u304D\\u305F\\u3000\\u3068\\u3053\\u308D\\u3092\\u3000\\u3071\\u304F\\u308A\\u3068\\u3000\\u3072\\u3068\\u306E\\u307F\\u3002\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uBA38\\uB9AC\\uC5D0 \\uB2EC\\uB9B0 \\uAE34 \\uB369\\uAD74\\uC744 \\uC791\\uC740\\n\\uC0DD\\uBB3C\\uCC98\\uB7FC \\uC6C0\\uC9C1\\uC5EC\\uC11C \\uBA39\\uC774\\uB97C \\uC720\\uC778\\uD55C\\uB2E4.\\n\\uAC00\\uAE4C\\uC774 \\uC654\\uC744 \\uB54C \\uB365\\uC11D \\uD55C \\uBC88\\uC5D0 \\uC0BC\\uD0A8\\uB2E4.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"Empiflor est dot\\u00E9 d\\u2019une longue liane qui part de sa t\\u00EAte.\\nCette liane se balance et remue comme un animal pour attirer\\nses proies. Lorsque l\\u2019une d\\u2019elles s\\u2019approche un peu trop pr\\u00E8s,\\nce Pok\\u00E9mon l\\u2019avale enti\\u00E8rement.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Aus Sarzenias Kopf ragt eine lange Ranke hervor, die es\\nbewegt, als w\\u00E4re sie ein kleines Lebewesen. N\\u00E4hert sich\\nahnungslose Beute dieser Falle, verschlingt Sarzenia\\nsie im Ganzen.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Victreebel tiene una enredadera que le sale de la cabeza y\\nque agita a modo de se\\u00F1uelo para atraer a sus presas y as\\u00ED\\nengullirlas por sorpresa cuando estas se aproximan incautas.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Victreebel \\u00E8 dotato di una lunga liana che parte dalla testa.\\nIl Pok\\u00E9mon la sventola e la agita come fosse un\\u2019esca\\nper attirare la preda. Quando la preda ignara si avvicina,\\nil Pok\\u00E9mon la inghiotte in un sol boccone.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Victreebel has a long vine that extends from its head.\\nThis vine is waved and flicked about as if it were an animal\\nto attract prey. When an unsuspecting prey draws near,\\nthis Pok\\u00E9mon swallows it whole.\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u982D\\u306B\\u3000\\u3064\\u3044\\u305F\\u3000\\u9577\\u3044\\u3000\\u3064\\u308B\\u3092\\u3000\\u5C0F\\u3055\\u306A\\n\\u751F\\u304D\\u7269\\u306E\\u3000\\u3088\\u3046\\u306B\\u3000\\u52D5\\u304B\\u3057\\u3000\\u7372\\u7269\\u3092\\u3000\\u8A98\\u3046\\u3002\\n\\u8FD1\\u3065\\u3044\\u3066\\u304D\\u305F\\u3000\\u3068\\u3053\\u308D\\u3092\\u3000\\u3071\\u304F\\u308A\\u3068\\u3000\\u3072\\u3068\\u306E\\u307F\\u3002\",\"Version\":{\"Name\":\"alpha-sapphire\",\"Url\":\"https://pokeapi.co/api/v2/version/26/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u30DF\\u30C4\\u306E\\u3000\\u304B\\u304A\\u308A\\u3067\\u3000\\u3048\\u3082\\u306E\\u3092\\u3000\\u3055\\u305D\\u3046\\u3002\\n\\u304F\\u3061\\u306E\\u306A\\u304B\\u306B\\u3000\\u3044\\u308C\\u305F\\u3082\\u306E\\u306F\\u3000\\uFF11\\u306B\\u3061\\u3067\\n\\u30DB\\u30CD\\u307E\\u3067\\u3000\\u3068\\u304B\\u3057\\u3066\\u3057\\u307E\\u3046\\u3068\\u3044\\u3046\\u3002\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uAFC0 \\uB0C4\\uC0C8\\uB85C \\uBA39\\uC774\\uB97C \\uB04C\\uC5B4\\uB4E4\\uC778\\uB2E4.\\n\\uC785\\uC548\\uC5D0 \\uB123\\uC740 \\uAC83\\uC740 \\uD558\\uB8E8 \\uB9CC\\uC5D0\\n\\uBF08\\uAE4C\\uC9C0 \\uB179\\uC5EC\\uBC84\\uB9B0\\uB2E4\\uACE0 \\uD55C\\uB2E4.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"\\u6703\\u7528\\u82B1\\u871C\\u7684\\u9999\\u6C23\\u5F15\\u8A98\\u7375\\u7269\\u3002\\n\\u64DA\\u8AAA\\u88AB\\u7260\\u541E\\u9032\\u4E86\\u5634\\u88E1\\u7684\\u6771\\u897F\\n\\u53EA\\u8981\\uFF11\\u5929\\u5C31\\u6703\\u6EB6\\u89E3\\u5230\\u9023\\u9AA8\\u982D\\u90FD\\u4E0D\\u5269\\u3002\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"zh-Hant\",\"Url\":\"https://pokeapi.co/api/v2/language/4/\"}},{\"FlavorText\":\"Il attire ses proies avec une odeur de miel\\net les avale tout enti\\u00E8res. Il les dig\\u00E8re en un\\njour seulement, les os y compris.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Es lockt Beute mit einem Duft an, der an Honig\\nerinnert. Was in sein Maul gelangt, wird samt\\nKnochen binnen eines Tages zersetzt.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Atrae a su presa con un dulce aroma a miel.\\nUna vez atrapada en la boca, la disuelve en tan\\nsolo un d\\u00EDa, huesos incluidos.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Attira le prede con il dolce aroma del miele,\\nle inghiotte e nel giro di un giorno le scioglie\\ncompletamente, ossa incluse.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Lures prey with the sweet aroma of honey.\\nSwallowed whole, the prey is dissolved in a day,\\nbones and all.\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u30DF\\u30C4\\u306E\\u3000\\u9999\\u308A\\u3067\\u3000\\u7372\\u7269\\u3092\\u3000\\u8A98\\u3046\\u3002\\n\\u53E3\\u306E\\u4E2D\\u306B\\u3000\\u5165\\u308C\\u305F\\u3082\\u306E\\u306F\\u3000\\uFF11\\u65E5\\u3067\\n\\u30DB\\u30CD\\u307E\\u3067\\u3000\\u6EB6\\u304B\\u3057\\u3066\\u3057\\u307E\\u3046\\u3068\\u3044\\u3046\\u3002\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u7528\\u82B1\\u871C\\u7684\\u9999\\u5473\\u5F15\\u8BF1\\u730E\\u7269\\u3002\\n\\u636E\\u8BF4\\u88AB\\u5B83\\u541E\\u5165\\u5634\\u91CC\\u7684\\u4E1C\\u897F\\uFF0C\\n\\u53EA\\u89811\\u5929\\u5C31\\u4F1A\\u6EB6\\u89E3\\u5230\\u8FDE\\u9AA8\\u5934\\u90FD\\u4E0D\\u5269\\u3002\",\"Version\":{\"Name\":\"lets-go-pikachu\",\"Url\":\"https://pokeapi.co/api/v2/version/31/\"},\"Language\":{\"Name\":\"zh-Hans\",\"Url\":\"https://pokeapi.co/api/v2/language/12/\"}},{\"FlavorText\":\"\\u30DF\\u30C4\\u306E\\u3000\\u304B\\u304A\\u308A\\u3067\\u3000\\u3048\\u3082\\u306E\\u3092\\u3000\\u3055\\u305D\\u3046\\u3002\\n\\u304F\\u3061\\u306E\\u306A\\u304B\\u306B\\u3000\\u3044\\u308C\\u305F\\u3082\\u306E\\u306F\\u3000\\uFF11\\u306B\\u3061\\u3067\\n\\u30DB\\u30CD\\u307E\\u3067\\u3000\\u3068\\u304B\\u3057\\u3066\\u3057\\u307E\\u3046\\u3068\\u3044\\u3046\\u3002\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"FlavorText\":\"\\uAFC0 \\uB0C4\\uC0C8\\uB85C \\uBA39\\uC774\\uB97C \\uB04C\\uC5B4\\uB4E4\\uC778\\uB2E4.\\n\\uC785\\uC548\\uC5D0 \\uB123\\uC740 \\uAC83\\uC740 \\uD558\\uB8E8 \\uB9CC\\uC5D0\\n\\uBF08\\uAE4C\\uC9C0 \\uB179\\uC5EC\\uBC84\\uB9B0\\uB2E4\\uACE0 \\uD55C\\uB2E4.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"FlavorText\":\"\\u6703\\u7528\\u82B1\\u871C\\u7684\\u9999\\u6C23\\u5F15\\u8A98\\u7375\\u7269\\u3002\\n\\u64DA\\u8AAA\\u88AB\\u7260\\u541E\\u9032\\u4E86\\u5634\\u88E1\\u7684\\u6771\\u897F\\n\\u53EA\\u8981\\uFF11\\u5929\\u5C31\\u6703\\u6EB6\\u89E3\\u5230\\u9023\\u9AA8\\u982D\\u90FD\\u4E0D\\u5269\\u3002\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"zh-Hant\",\"Url\":\"https://pokeapi.co/api/v2/language/4/\"}},{\"FlavorText\":\"Il attire ses proies avec une odeur de miel\\net les avale tout enti\\u00E8res. Il les dig\\u00E8re en un\\njour seulement, les os y compris.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"FlavorText\":\"Es lockt Beute mit einem Duft an, der an Honig\\nerinnert. Was in sein Maul gelangt, wird samt\\nKnochen binnen eines Tages zersetzt.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"FlavorText\":\"Atrae a su presa con un dulce aroma a miel.\\nUna vez atrapada en la boca, la disuelve en tan\\nsolo un d\\u00EDa, huesos incluidos.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"FlavorText\":\"Attira le prede con il dolce aroma del miele,\\nle inghiotte e nel giro di un giorno le scioglie\\ncompletamente, ossa incluse.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"FlavorText\":\"Lures prey with the sweet aroma of honey.\\nSwallowed whole, the prey is dissolved in a day,\\nbones and all.\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"FlavorText\":\"\\u30DF\\u30C4\\u306E\\u3000\\u9999\\u308A\\u3067\\u3000\\u7372\\u7269\\u3092\\u3000\\u8A98\\u3046\\u3002\\n\\u53E3\\u306E\\u4E2D\\u306B\\u3000\\u5165\\u308C\\u305F\\u3082\\u306E\\u306F\\u3000\\uFF11\\u65E5\\u3067\\n\\u30DB\\u30CD\\u307E\\u3067\\u3000\\u6EB6\\u304B\\u3057\\u3066\\u3057\\u307E\\u3046\\u3068\\u3044\\u3046\\u3002\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"FlavorText\":\"\\u7528\\u82B1\\u871C\\u7684\\u9999\\u5473\\u5F15\\u8BF1\\u730E\\u7269\\u3002\\n\\u636E\\u8BF4\\u88AB\\u5B83\\u541E\\u5165\\u5634\\u91CC\\u7684\\u4E1C\\u897F\\uFF0C\\n\\u53EA\\u89811\\u5929\\u5C31\\u4F1A\\u6EB6\\u89E3\\u5230\\u8FDE\\u9AA8\\u5934\\u90FD\\u4E0D\\u5269\\u3002\",\"Version\":{\"Name\":\"lets-go-eevee\",\"Url\":\"https://pokeapi.co/api/v2/version/32/\"},\"Language\":{\"Name\":\"zh-Hans\",\"Url\":\"https://pokeapi.co/api/v2/language/12/\"}}],\"FormDescriptions\":[],\"Genera\":[{\"Genus\":\"\\u30CF\\u30A8\\u3068\\u308A\\u30DD\\u30B1\\u30E2\\u30F3\",\"Language\":{\"Name\":\"ja-Hrkt\",\"Url\":\"https://pokeapi.co/api/v2/language/1/\"}},{\"Genus\":\"\\uD30C\\uB9AC\\uC7A1\\uC774\\uD3EC\\uCF13\\uBAAC\",\"Language\":{\"Name\":\"ko\",\"Url\":\"https://pokeapi.co/api/v2/language/3/\"}},{\"Genus\":\"\\u6355\\u8805\\u5BF6\\u53EF\\u5922\",\"Language\":{\"Name\":\"zh-Hant\",\"Url\":\"https://pokeapi.co/api/v2/language/4/\"}},{\"Genus\":\"Pok\\u00E9mon Carnivore\",\"Language\":{\"Name\":\"fr\",\"Url\":\"https://pokeapi.co/api/v2/language/5/\"}},{\"Genus\":\"Fliegentod\",\"Language\":{\"Name\":\"de\",\"Url\":\"https://pokeapi.co/api/v2/language/6/\"}},{\"Genus\":\"Pok\\u00E9mon Matamoscas\",\"Language\":{\"Name\":\"es\",\"Url\":\"https://pokeapi.co/api/v2/language/7/\"}},{\"Genus\":\"Pok\\u00E9mon Moschivoro\",\"Language\":{\"Name\":\"it\",\"Url\":\"https://pokeapi.co/api/v2/language/8/\"}},{\"Genus\":\"Flycatcher Pok\\u00E9mon\",\"Language\":{\"Name\":\"en\",\"Url\":\"https://pokeapi.co/api/v2/language/9/\"}},{\"Genus\":\"\\u30CF\\u30A8\\u3068\\u308A\\u30DD\\u30B1\\u30E2\\u30F3\",\"Language\":{\"Name\":\"ja\",\"Url\":\"https://pokeapi.co/api/v2/language/11/\"}},{\"Genus\":\"\\u6355\\u8747\\u5B9D\\u53EF\\u68A6\",\"Language\":{\"Name\":\"zh-Hans\",\"Url\":\"https://pokeapi.co/api/v2/language/12/\"}}],\"Varieties\":[{\"IsDefault\":true,\"Pokemon\":{\"Name\":\"victreebel\",\"Url\":\"https://pokeapi.co/api/v2/pokemon/71/\"}}]}";
        }

        #endregion

        #region Unit Tests

        [TestMethod]
        public void TestMethod_GetPokemonList_Success()
        {
            //Arrange
            int limit = 5;
            int offset = 0;
            _pokedexServiceMock.Setup(x => x.GetPokemonList(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(It.IsAny<IEnumerable<string>>()));

            var pokemonList = GetPokemonList();

            _pokeapiClientMock.Setup(x => x.GetPokemonList(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(pokemonList));

            IPokedexService pokedexService = new PokedexService(_pokeapiClientMock.Object);

            //Act
            var response = pokedexService.GetPokemonList(limit, offset).Result;

            //Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void TestMethod_GetPokemon_Success()
        {
            //Arrange
            string pokemonName = "victreebel";
            PokemonSpecies pokemonSpecies = JsonSerializer.Deserialize<PokemonSpecies>(_pokemonDetails);

            _pokedexServiceMock.Setup(x => x.GetPokemon(It.IsAny<string>())).Returns(Task.FromResult(It.IsAny<ModelPokemon>()));
            _pokeapiClientMock.Setup(x => x.GetPokemon(It.IsAny<string>())).Returns(Task.FromResult(pokemonSpecies));

            IPokedexService pokedexService = new PokedexService(_pokeapiClientMock.Object);

            //Act
            var response = pokedexService.GetPokemon(pokemonName).Result;

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(pokemonName, response.Name);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the pokemon list
        /// </summary>
        /// <returns></returns>
        private List<NamedApiResource<Pokemon>> GetPokemonList()
        {
            return new List<NamedApiResource<Pokemon>>()
                                  {
                                      new NamedApiResource<Pokemon>()
                                      {
                                          Name = "bulbasaur"
                                      },
                                      new NamedApiResource<Pokemon>()
                                      {
                                          Name = "charmander"
                                      },
                                      new NamedApiResource<Pokemon>()
                                      {
                                          Name = "geodude"
                                      },
                                      new NamedApiResource<Pokemon>()
                                      {
                                          Name = "ninetales"
                                      },
                                      new NamedApiResource<Pokemon>()
                                      {
                                          Name = "alakazam"
                                      }
                                  };
        }

        #endregion
    }
}
