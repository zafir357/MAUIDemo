using LolToolkit;
using Microsoft.Maui.Controls;
using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace VM
{
    public class DataManagerVM : PropertyChangedSender
    {
        private ObservableCollection<ChampionVM> ChampionsObs { get; set; } = new ObservableCollection<ChampionVM>();
        public ReadOnlyObservableCollection<ChampionVM> ChampionVMs { get; private set; }
        public int PageId 
        {
            get => _pageId;
            set
            {
                if(_pageId != value)
                {
                    _pageId = value;
                    OnPropertyChanged();
                    (PreviousPageCommand as Command).ChangeCanExecute();
                    (NextPageCommand as Command).ChangeCanExecute();
                    LoadData();
                }
            }
        
        }
        public int _pageId = 1;
        public int PageSize { get; set; } = 5;
        public int NbItem
        {
            get => _nbItem;
            set
            {
                if( _nbItem != value)
                {
                    _nbItem = value;
                    OnPropertyChanged();
                }
            }
        }
        public int _nbItem;

        public IDataManager DataManager
        {
            get => _dataManager;
            set
            {
                if (_dataManager == value) return;
                _dataManager = value;
                OnPropertyChanged();
                LoadData();
            }
        }
        private IDataManager _dataManager;

        public ICommand NextPageCommand { get; private set; }
        public ICommand PreviousPageCommand { get; private set; }

        public DataManagerVM(IDataManager dataManager)
        {
            DataManager = dataManager;
            ChampionVMs = new ReadOnlyObservableCollection<ChampionVM>(ChampionsObs);

            NextPageCommand = new Command(
                execute: () => { PageId++; },
                canExecute: () => { return NbItem - (PageSize * (PageId-1)) > PageSize ; }
                );
            PreviousPageCommand = new Command(
                execute: () => { PageId--; },
                canExecute: () => { return PageId > 1; }
                );
        }

        public async void LoadData()
        {
            ChampionsObs.Clear();
            NbItem = await DataManager.ChampionsMgr.GetNbItems();
            IEnumerable<Champion> champions = await DataManager.ChampionsMgr.GetItems(PageId - 1, PageSize);
            foreach (var item in champions)
            {
                ChampionsObs.Add(new ChampionVM(item));
            }
        }
    }
}

