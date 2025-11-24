using System;
using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
  public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("genres").WithParameterValidation();

    group.MapGet("/", async (GameStoreContext dbContext) =>
    {
      var genres = await dbContext.Genres
        .Select(genre => genre.ToDto()).AsNoTracking().ToListAsync();

      return Results.Ok(genres);
    });

    return group;

  }
}
