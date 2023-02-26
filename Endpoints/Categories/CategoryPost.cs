using MarketApp.Domain.Products;
using MarketApp.Infra.Data;

namespace MarketApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(CategoryDTO newCategory, ApplicationDbContext context)
    {
        var category = new Category
        {
            Name = newCategory.Name,
            CreatedBy = "Alberto",
            CreatedOn = DateTime.Now,
            EditedBy = "Alberto",
            EditedOn = DateTime.Now
        };

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}
