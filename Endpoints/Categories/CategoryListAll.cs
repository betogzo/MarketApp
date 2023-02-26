using MarketApp.Domain.Products;
using MarketApp.Infra.Data;

namespace MarketApp.Endpoints.Categories;

public class CategoryListAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();

        if (!categories.Any()) return Results.NotFound();

        //Hiding sensitive data
        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, IsActive = c.IsActive });

        return Results.Ok(response);
    }
}
