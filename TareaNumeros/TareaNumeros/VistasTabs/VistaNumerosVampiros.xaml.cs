using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaNumeros.VistasTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaNumerosVampiros : ContentPage
    {
        int limiteNumerosVampiros = 8;
        int contadorNumerosVampiros = 0;

        public VistaNumerosVampiros()
        {
            InitializeComponent();

            lblTitulo.Text = $"Mostrar los primeros {limiteNumerosVampiros} números vampiros";
            lblCalculando.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblCalculando.Text = $"Generando números vampiros.{Environment.NewLine}Este proceso puede llevar varios minutos.";
            stlNumerosVampiros.Children.Clear();
            await ImprimirNumeros();
        }

        private async Task ImprimirNumeros()
        {
            //while (contadorNumerosVampiros < limiteNumerosVampiros)
            //{

            //}

            await Device.InvokeOnMainThreadAsync(() =>
            {
                lblCalculando.Text = "Números calculados";
            });
        }
    }
}