using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;

namespace TiTranslit
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        #region Public Prop

        public string OriginText { get; set; }
        public string TranslitText { get; set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            OriginText = "";
            TranslitText = "";
        }     

        #endregion
        
        #region Commands

        public ICommand TextChangeCommand => new ActionCommand(() =>
        {
            TranslitText = OriginText != string.Empty 
                ? Utils.Translit(OriginText) 
                : string.Empty;
        });

        #endregion
        
        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}