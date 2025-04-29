using VM;
using ClientMAUI.VMApp;

namespace ClientMAUI.Views.Pages;

public partial class ChampionEditPage : ContentPage
{
	public ChampionVM ChampionVM;
	public ChampionEditPageVM ChampionEditPageVM;

	public ChampionEditPage(ChampionVM champion)
	{
		this.ChampionEditPageVM = new ChampionEditPageVM(champion);
		this.ChampionVM = champion;
		InitializeComponent();
		BindingContext = this.ChampionEditPageVM;
	}
}