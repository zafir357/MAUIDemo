using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;
using LolToolkit;
using Microsoft.Maui.Platform;

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
            set
            {
                if (_model.Name.Equals(value)) return;
                _model.Name = value;
                OnPropertyChanged();
            }
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
   // ✅ final Save that applies the edits to the domain model
    public void SaveEdit()
    {
        Model.Bio   = Bio ?? string.Empty;
            if (!Enum.TryParse<ChampionClass>(Class, true, out var parsed))
                parsed = ChampionClass.Unknown;
            Model.Class = parsed;
            Model.Icon  = Icon;



        // ---- Sync skills (reset & re-add; simplest) ----
        foreach (var existing in Model.Skills.ToList())
            Model.RemoveSkill(existing);

        foreach (var sVM in _skillVMs)
            Model.AddSkill(new Skill(sVM.Name, sVM.Type) { Description = sVM.Description });
    }

    }

}