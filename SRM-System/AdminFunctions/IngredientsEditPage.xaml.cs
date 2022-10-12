using SRM_System.Models;
using SRM_System.Services;

namespace SRM_System.AdminFunctions;

public partial class IngredientsEditPage : ContentPage
{
	public IngredientsEditPage()
	{
		InitializeComponent();

		ingredientsService.GetIngregients();
		IngredientsCollectionView.ItemsSource = IngredientsCollection.Ingredients;
	}
	IngredientsService ingredientsService = new IngredientsService();

	private void OnDeleteIngredientClick(object sender, EventArgs e)
	{
		try
		{
            ingredientsService.RemoveIngredient(IngredientsCollection
                .Ingredients[IngredientsCollection
                .Ingredients.IndexOf((Ingredient)IngredientsCollectionView
                .SelectedItem)]
                .Key);

            IngredientsCollection.Ingredients
                .RemoveAt(IngredientsCollection.Ingredients
                .IndexOf((Ingredient)IngredientsCollectionView.SelectedItem));
        }
        catch
        {

        }
    }
	private async void OnIngredientAddClicked(object sender, EventArgs e)
	{
        if (NameEntry.Text != null && IdEntry.Text != null && QuantityEntry.Text != null && UnitEntry.Text != null)
        { 
            IngredientsCollection.Ingredients.Add(new Ingredient
            {
                Id = IdEntry.Text,
                Quantity = QuantityEntry.Text,
                Unit = UnitEntry.Text,
                Name = NameEntry.Text,
            });
            await ingredientsService
                .AddIngredient(IngredientsCollection.Ingredients[IngredientsCollection.Ingredients.Count - 1]);
        }
    }

    private async void ToRefreshingIngredientsRefresh(object sender, EventArgs e)
    {
        IngredientsRefresh.IsRefreshing = true;

        await ingredientsService.GetIngregients();

        IngredientsRefresh.IsRefreshing = false;
    }
}