using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlgoritmosVarios
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MenuPestanas();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
