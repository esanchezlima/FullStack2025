namespace Library.Service.Application.Dtos
{
    public class AuthorsResourceParameters
    {
        public string? Genre { get; set; } = "";
        public string? SearchQuery { get; set; } = "";
        public string? OrderBy { get; set; } = "Name";
    }
}
