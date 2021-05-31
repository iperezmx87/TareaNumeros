using Xamarin.Forms;

namespace TareaNumeros
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new VistaPrincipal();
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
