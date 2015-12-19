using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadisonMonkeys.ViewModels;
using Xamarin.Forms;

namespace MadisonMonkeys.Views
{
    public partial class MonkeyListPage : ContentPage
    {
        MonkeyListViewModel viewModel;

           
        public MonkeyListPage()
        {
            InitializeComponent();

            viewModel = new MonkeyListViewModel();

            ButtonGet.Clicked += async (sender, e) =>
            {
                try
                {
                    ButtonGet.IsEnabled = false;

                    await viewModel.GetMonkeysAsync();

                    ButtonGet.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    DisplayAlert(title: "Oh no!", message: "Unable to get monkeys: " + ex, cancel: "OK");
                }
            };

            List.ItemTapped += async (sender, e) =>
            {
                var monkey = e.Item;

                var details = new MonkeyPage();

                details.BindingContext = monkey;

                await Navigation.PushAsync(details);

                List.SelectedItem = null; //deselects the item
            };
            BindingContext = viewModel;
        }
    }
}
