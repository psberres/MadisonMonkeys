using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refractored.Xam.TTS;
using Xamarin.Forms;

namespace MadisonMonkeys.Views
{
    public partial class MonkeyPage : ContentPage
    {
        public MonkeyPage()
        {
            InitializeComponent();
        }


        public void OnButtonClicked(object sender, EventArgs args){

            //((Button) sender).Text = "You Clicked the button!";

            //Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak("Hello Gabriella and Jacob");
            Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak(Label1.Text);

        }
    }
}
