namespace Logic.Models
{
    public interface IGebruiker
    {
        string Beschrijving { get; set; }
        string Email { get; set; }
        int GebruikerID { get; set; }
        string Naam { get; set; }
    }
}