using System;
using System.ComponentModel;
using System.Windows.Input;
using VM;
using LolToolkit;

namespace ClientMAUI.VMApp
{
	public class ChampionEditPageVM : PropertyChangedSender
	{
		public ChampionVM ChampionVM { get; set; }
        public ICommand AddSkillCommand { get; private set; }
        public ICommand SaveCommand { get; }
        public string SkillName {
            get => _skillName;
            set
            {
                if(value != _skillName)
                {
                    _skillName = value;
                    OnPropertyChanged();
                    (AddSkillCommand as Command).ChangeCanExecute();
                }
            }
        }
        private string _skillName = "";

		public ChampionEditPageVM(ChampionVM championVM)
		{
			this.ChampionVM = championVM;


            AddSkillCommand = new Command(
                canExecute: () =>
                {
                    return this.SkillName.Trim() != "" && this.SkillName != null;
                },
                execute: () =>
                {
                    ChampionVM.AddSkill(SkillName);
                    SkillName = "";
                });
            SaveCommand = new Command(Save);
        }
        private async void Save()
        {
            ChampionVM.SaveEdit(); // <— applies edits to domain model
            await Shell.Current.DisplayAlert("Saved", "Champion updated.", "OK");

            // 3) Revenir à la page précédente (si tu le veux)
            await Shell.Current.GoToAsync("..");
            // Optionally navigate back:
            // Shell.Current.GoToAsync("..");
        }
    }
}

