using System;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaNumeros.VistasTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaNumerosPrimos : ContentPage
    {
        int limiteNumerosPrimos = 1000;

        public VistaNumerosPrimos()
        {
            InitializeComponent();

            lblTitulo.Text = $"Mostrar los primeros {limiteNumerosPrimos} números primos";
            lblCalculando.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblCalculando.Text = "Generando números primos...";
            stlNumerosPrimos.Children.Clear();

            await ImprimirNumeros();
        }

        private async Task ImprimirNumeros()
        {
            // notacion camel case
            // los nombres de las variables se escriben asi:
            // int numero = 0;
            // int otroNumero = 1;
            // int esteEsUnNumeroQueSirveParaSumar = -1;

            // cuantos numeros se han encontrado
            int contadorNumerosEncontrados = 0;

            // numero a buscar, este ira aumentando en cada ciclo
            int contadorNumeros = 2;

            StringBuilder numeroBuilder = new StringBuilder();

            // mientras el contador de numeros encontrados sea menor al limite
            while (contadorNumerosEncontrados < limiteNumerosPrimos)
            {
                // buscar los numeros
                if (CalculaNumeroPrimo(contadorNumeros))
                {
                    // se encontro un numero primo, se aumenta el contador de encontrados
                    contadorNumerosEncontrados += 1;

                    // se pone ese numero en el texto final a mostrar
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        stlNumerosPrimos.Children.Add(new Label
                        {
                            FontSize = 15,
                            FontFamily = "Arial",
                            Text = $"{contadorNumerosEncontrados}: {contadorNumeros}",
                            TextColor = Color.Black,
                            BackgroundColor = Color.White,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        });

                        await srclResultados.ScrollToAsync(stlNumerosPrimos, ScrollToPosition.End, false);
                    });
                }

                // se aumenta la semilla para seguir buscando
                contadorNumeros += 1;
            }

            // se pone el texto en el la vista editor
            await Device.InvokeOnMainThreadAsync(() =>
            {
                lblCalculando.Text = "Números primos generados";
            });
        }

        private bool CalculaNumeroPrimo(int numeroACalcular)
        {
            bool esPrimo = true;

            // se hacen calculos de residuo de los numeros anteriores al numero a calcular
            for (int indicePrimo = 2; indicePrimo < numeroACalcular; indicePrimo++)
            {
                // si el residuo es igual a cero, ya no es primo
                if (numeroACalcular % indicePrimo == 0)
                {
                    esPrimo = false;
                    break;
                }
            }

            return esPrimo;
        }
    }
}