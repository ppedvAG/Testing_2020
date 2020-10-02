using ppedv.MittagsHunger.BusinessLogic;
using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.UI.WPF.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.MittagsHunger.UI.WPF.ViewModel
{
    public class GerichteViewModel : INotifyPropertyChanged
    {
        Core core = new Core(new Data.EF.EfRepository());
        private Gericht selectedGericht;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Gericht> GerichtListe { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand SaveCommand2 { get; set; }

        public Gericht SelectedGericht
        {
            get => selectedGericht;
            set
            {
                selectedGericht = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGericht)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LieferantInfo)));
            }
        }

        public string LieferantInfo
        {
            get
            {
                if (SelectedGericht == null)
                    return "---";
                return $"{SelectedGericht?.Lieferant?.Name} [{SelectedGericht?.Lieferant?.Gerichte.Count}]";
            }
        }

        public GerichteViewModel()
        {
            GerichtListe = new ObservableCollection<Gericht>(core.Repository.GetAll<Gericht>());

            SaveCommand = new SaveCommand(core);

            SaveCommand2 = new RelayCommand(x => core.Repository.SaveAll());
        }

    }
}
