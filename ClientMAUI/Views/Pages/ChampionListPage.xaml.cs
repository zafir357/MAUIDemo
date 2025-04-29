using ClientMAUI.VMApp;
using VM;

namespace ClientMAUI.Views.Pages;

public partial class ChampionListPage : ContentPage
{
    public ChampionListPageVM VMApp { get; private set; }

	public ChampionListPage(DataManagerVM dataManager)
	{
        VMApp = new ChampionListPageVM(dataManager, Navigation);
        InitializeComponent();
        BindingContext = VMApp;
	}
}