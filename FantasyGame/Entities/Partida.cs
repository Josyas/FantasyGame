namespace FantasyGame.Entities
{
    public class Partida
    {
        public int Id { get; set; } 
        public string? Times { get; set; }
        public string? Resultados { get; set; }

        public int IdTimeFutebol { get; set; }  
        public TimeFutebol? TimeFutebol { get; set; }
        public List<Classificacao>? Classificacao { get; set; }    
    }
}
