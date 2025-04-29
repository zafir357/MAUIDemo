using ClientMAUI.Views.Pages;
using System.Windows.Input;
using VM;

namespace ClientMAUI.VMApp
{
    public class ChampionListPageVM
    {

        public DataManagerVM DataManagerVM { get; private set; }
        public ICommand ItemTappedCommand { get; private set; }
        private INavigation _navigation;

        public ChampionListPageVM(DataManagerVM dataManager, INavigation navigaton)
        {
            DataManagerVM = dataManager;
            _navigation = navigaton;

            ItemTappedCommand = new Command(
                async (object item) => 
                {
                    await _navigation.PushAsync(new ChampionDetail(item as ChampionVM));
                });
        }
    }
}
