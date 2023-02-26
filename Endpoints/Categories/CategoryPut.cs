using MarketApp.Domain.Products;
using MarketApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action([FromRoute] Guid Id, CategoryDTO updatedCategory, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == Id).FirstOrDefault();

        if (category == null) return Results.NotFound();

        category.Name = updatedCategory.Name;
        category.IsActive = updatedCategory.IsActive;

        context.SaveChanges();

        return Results.Ok();
    }
}
