using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaNumeros.VistasTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaNumerosPerfectos : ContentPage
    {
        // solo se pueden calcular los primeros 4 numeros perfectos
        // los otros dos tomarian muchisimo tiempo en tomarlos

        int limiteNumerosPerfectos = 6;
        int contadorNumerosPerfectos = 0;

        public VistaNumerosPerfectos()
        {
            InitializeComponent();

            lblTitulo.Text = $"Mostrar los primeros {limiteNumerosPerfectos} números perfectos";
            lblCalculando.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblCalculando.Text = $"Generando números perfectos.{Environment.NewLine}Este proceso puede llevar varios minutos.";
            stlNumerosPerfectos.Children.Clear();
            await ImprimirNumeros();
        }

        private async Task ImprimirNumeros()
        {
            // mientras sean 6 numeros perfectos
            int numeroAValidar = 1;

            while (contadorNumerosPerfectos < limiteNumerosPerfectos)
            {
                // buscando un numero perfecto
                int numDivisores = 0;

                for (int indiceDivisores = 1; indiceDivisores <= (numeroAValidar / 2); indiceDivisores++)
                {
                    if (numeroAValidar % indiceDivisores == 0)
                    {
                        numDivisores += indiceDivisores;
                    }
                }

                if (numDivisores == numeroAValidar)
                {
                    contadorNumerosPerfectos += 1;
                    
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        stlNumerosPerfectos.Children.Add(new Label
                        {
                            FontSize = 15,
                            FontFamily = "Arial",
                            Text = $"{contadorNumerosPerfectos}: {numeroAValidar}",
                            TextColor = Color.Black,
                            BackgroundColor = Color.White,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        });

                        await srclResultados.ScrollToAsync(stlNumerosPerfectos, ScrollToPosition.End, false);
                    });
                }

                numeroAValidar += 1;
            }
        }
    }
}