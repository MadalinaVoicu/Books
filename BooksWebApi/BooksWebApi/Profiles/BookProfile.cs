using AutoMapper;

namespace BooksWebApi.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Author, ExternalModels.AuthorDTO>();
            CreateMap<ExternalModels.AuthorDTO, Entities.Author>();

            CreateMap<Entities.Book, ExternalModels.BookDTO>();
            CreateMap<ExternalModels.BookDTO, Entities.Book>();
        }
    }
}
