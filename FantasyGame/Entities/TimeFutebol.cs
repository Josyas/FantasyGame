namespace FantasyGame.Entities
{
    public class TimeFutebol
    {
        public int Id { get; set; }
        public string? NomeTime { get; set; }
        
        public List<Partida>? Partida { get; set; }
    }
}
