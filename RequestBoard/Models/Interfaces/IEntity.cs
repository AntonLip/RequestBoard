namespace RequestBoard.Models.Interfaces
{
    public interface IEntity<Tid>
    {
        Tid Id { get; set; }
    }
}
