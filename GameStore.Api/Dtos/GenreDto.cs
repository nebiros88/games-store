using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class GenreDto(
  int Id,
  [Required] string Name
);
