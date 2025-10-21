using dotnet_project.api.Dtos;
using dotnet_project.api.Entities;

namespace dotnet_project.api.Mapping;

public static class GenretMappting
{
    public static GenretDto ToDto(this Genre genre)
    {
        return new GenretDto(genre.Id, genre.Name);
    }
}
