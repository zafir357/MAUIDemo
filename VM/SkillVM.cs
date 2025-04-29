using System;
using LolToolkit;
using Model;

namespace VM
{
    public class SkillVM : PropertyChangedSender
    {
        public SkillType Type { get => Model.Type; }

        public Skill Model
        {
            get => _model;
            set
            {
                if (value != _model)
                {
                    _model = value;
                    OnPropertyChanged();
                }
            }
        }
        private Skill _model;

        public string Name
        {
            get => Model.Name;
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (value != Model.Description)
                {
                    Model.Description = value;
                    OnPropertyChanged();
                }
            }
        }

        public SkillVM(Skill model)
        {
            this.Model = model;
        }
    }
}

