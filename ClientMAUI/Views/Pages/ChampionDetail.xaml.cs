using VM;

namespace ClientMAUI.Views.Pages;

public partial class ChampionDetail : ContentPage
{
	public ChampionVM champion;

	public ChampionDetail(ChampionVM champion)
	{
		this.champion = champion;
		InitializeComponent();
		BindingContext = champion;
	}

    private async void ToolbarItemModifier_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChampionEditPage(champion));
    }
}