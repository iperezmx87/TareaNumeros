using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaNumeros.VistasTabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaNumerosAmigos : ContentPage
    {
        int limiteNumerosAmigos = 20;

        int semillaNumerosAmigos = 200000;

        public VistaNumerosAmigos()
        {
            InitializeComponent();

            lblTitulo.Text = $"Mostrar los primeros {limiteNumerosAmigos} números amigos";
            lblCalculando.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblCalculando.Text = $"Generando números amigos.{Environment.NewLine}Este proceso puede llevar varios minutos.";
            stlNumerosAmigos.Children.Clear();

            await ImprimirNumeros();
        }

        private async Task ImprimirNumeros()
        {
            int[] sumas = new int[semillaNumerosAmigos];

            for (int indiceSuma = 1; indiceSuma < sumas.Length; indiceSuma++)
            {
                sumas[indiceSuma] = await SumaMultiplos(indiceSuma);
            }

            int contadorParejasAmigos = 0;

            for (int indiceParejas = 1; indiceParejas < sumas.Length; indiceParejas++)
            {
                int numero1 = sumas[indiceParejas];

                if (numero1 > 1 & numero1 < sumas.Length)
                {
                    int numero2 = sumas[numero1];

                    if (numero2 == indiceParejas && numero1 > numero2)
                    {
                        contadorParejasAmigos += 1;

                        await Device.InvokeOnMainThreadAsync(async () =>
                        {
                            stlNumerosAmigos.Children.Add(new Label {
                                FontSize = 15,
                                FontFamily = "Arial",
                                Text = $"{contadorParejasAmigos}: {numero2} - {numero1}",
                                TextColor = Color.Black,
                                BackgroundColor = Color.White,
                                HorizontalOptions = LayoutOptions.FillAndExpand
                            });

                            await srclResultados.ScrollToAsync(stlNumerosAmigos, ScrollToPosition.End, false);
                        });

                        if (contadorParejasAmigos == limiteNumerosAmigos)
                            break;
                    }
                }
            }

            await Device.InvokeOnMainThreadAsync(() =>
            {
                lblCalculando.Text = "Números calculados";
            });
        }

        private async Task<int> SumaMultiplos(int numeroASumar)
        {
            await Task.Delay(1);

            Int32 suma = 1;

            int mitad = numeroASumar / 2 + 1;

            for (int indiceSuma = 2; indiceSuma < mitad; indiceSuma++)
            {
                int residuo;

                int division = Math.DivRem(numeroASumar, indiceSuma, out residuo);

                if (residuo == 0)
                {
                    suma += division;
                }
            }

            return suma;
        }
    }
}