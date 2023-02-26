using MarketApp.Domain.Products;
using MarketApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action([FromRoute] Guid Id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();

        if (category == null) return Results.NotFound();

        context.Categories.Remove(category);

        context.SaveChanges();

        return Results.NoContent();
    }
}
