	using System;
	using MadisonMonkeys.Models;

	using System.ComponentModel;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	using System.Linq;
	using System.Text;

	using System.Net.Http;
	using Newtonsoft.Json;


namespace MadisonMonkeys.ViewModels
{
    public class MonkeyListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Monkey> MonkeyList { get; set; }

        public MonkeyListViewModel()
        {
            MonkeyList = new ObservableCollection<Monkey>();
        }

        private bool busy = false;

        public bool IsBusy
        {
            get { return busy; }
            set {
                    if (busy == value)													
                        return;

                    busy = value;
                    OnPropertyChanged("IsBusy");
            }
        }

        //stub out main method - Thread safe
        public async Task GetMonkeysAsync() //doing stuff in the background
        {
            if (IsBusy)
                return;

            //Get Monkeys and stuff
            //IsBusy = true;
            //Get Monkeys and suff
            //IsBusy = false;
            try
            {
                IsBusy = true;

                var client = new HttpClient();

                var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

                var list = JsonConvert.DeserializeObject<List<Monkey>>(json); //Not using DeserializeObjectAsync because it's not compatiable with Xamarin

                foreach (var item in list)
                {
                    MonkeyList.Add(item);
                }

            }
            finally
            {
                IsBusy = false;
            }
        }

        #region INofifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed(this, new PropertyChangedEventArgs(name));

            //C# 6.0 - if this is changed then do this
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
