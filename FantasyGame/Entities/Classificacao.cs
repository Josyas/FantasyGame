namespace FantasyGame.Entities
{
    public class Classificacao
    {
        public int Id { get; set; }
        public string? Campeao { get; set; }
        public string? Vice { get; set; }
        public string? Terceiro { get; set; }

        public Partida? Partidas { get; set; }
    }
}