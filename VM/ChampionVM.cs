using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;
using LolToolkit;

namespace VM
{
    public class ChampionVM : PropertyChangedSender
    {
        public Champion Model
        {
            get => _model;
            set
            {
                if (_model != null)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }
        private Champion _model;

        public string Name
        {
            get => _model.Name;
        }

        public string Bio
        {
            get => Model.Bio;
            set
            {
                if (_model.Bio.Equals(value)) return;
                _model.Bio = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get => Model.Image.Base64;
            set
            {
                if (_model.Icon.Equals(value)) return;
                _model.Image.Base64 = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => Model.Icon;
            set
            {
                if (_model.Icon.Equals(value)) return;
                _model.Icon = value;
                OnPropertyChanged();
            }
        }

        public IReadOnlyDictionary<String, int> Characteristics
        {
            get => Model.Characteristics;
        }

        public ObservableCollection<SkillVM> Skills
        {
            get => _skillVMs;
        }
        private ObservableCollection<SkillVM> _skillVMs = new ObservableCollection<SkillVM>(new HashSet<SkillVM>());

        public ICommand AddSkillCommand { get; private set; }

        public string Class
        {
            get => Model.Class.ToString();
        }

        public ChampionVM(Champion model)
        {
            _model = model;
            foreach (Skill s in Model.Skills)
            {
                _skillVMs.Add(new SkillVM(s));
            }
        }

        public void AddSkill(string name)
        {
            Skill s = new Skill(name, SkillType.Unknown);
            SkillVM sVM = new SkillVM(s);
            Model.AddSkill(s);
            _skillVMs.Add(sVM);
        }
    }

}