namespace DAL.DTO
{
    public interface IGebruikerDTO
    {
        string Beschrijving { get; set; }
        string Email { get; set; }
        int GebruikerID { get; set; }
        string Naam { get; set; }
        string ProfielFoto { get; set; }
    }
}