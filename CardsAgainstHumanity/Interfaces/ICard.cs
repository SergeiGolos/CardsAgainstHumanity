namespace CardsAgainstHumanity.Interfaces
{
    public interface ICard
    {
        string Id { get; set; }    
        string Text { get; set; }
        int Count { get; set; }    
    }
}