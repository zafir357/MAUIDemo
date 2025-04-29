using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LolToolkit
{
    public class PropertyChangedSender : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}