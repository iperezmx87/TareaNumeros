using System;
using System.Text;
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

            // imprimir los numeros
            ImprimirNumeros();
        }

        private void ImprimirNumeros()
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
            while (contadorNumerosEncontrados <= limiteNumerosPrimos)
            {
                // buscar los numeros
                if (CalculaNumeroPrimo(contadorNumeros))
                {
                    // se pone ese numero en el texto final a mostrar
                    numeroBuilder.Append($"{contadorNumerosEncontrados}: {contadorNumeros}{Environment.NewLine}");

                    // se encontro un numero primo, se aumenta el contador de encontrados
                    contadorNumerosEncontrados += 1;
                }

                // se aumenta la semilla para seguir buscando
                contadorNumeros += 1;
            }

            // se pone el texto en el la vista editor
            edtNumerosPrimos.Text = numeroBuilder.ToString();
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