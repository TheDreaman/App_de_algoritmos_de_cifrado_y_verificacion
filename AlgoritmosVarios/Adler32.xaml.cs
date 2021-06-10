using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlgoritmosVarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Adler32 : ContentPage
    {
        public Adler32()
        {
            InitializeComponent();
        }
        private void InfoButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Adler32", "Una suma de comprobación de Adler-32 se obtiene calculando dos sumas de comprobación A y B de 16 bits y concatenando sus bits en un entero de 32 bits.A es la suma de todos los bytes del flujo más uno, y B esla suma de los valores individuales de A de cada paso.","OK");
        }
        private void CalculaButton_Clicked(object sender, EventArgs e)
        {
            //-------------------------ADLER32--------------------------------------
            if (inAdler.Text == null)
            {
                outAdlerActual.Text = "Ingrese algo antes";
                outAdlerHistory.Text += "\n" + "Ingrese algo antes";
            }
            else
            {
                var res = Adler(inAdler.Text);
                string aux = res.ToString();
                int tohex = Int32.Parse(aux);
                string hex = tohex.ToString("x");
                if (hex.Length < 8)
                {
                    hex = "0" + hex;
                }
                outAdlerActual.Text = $"{hex}";
                outAdlerHistory.Text += "\n" + $"Palabra: {inAdler.Text} Hash: {hex}";
            }            
        }
        //-----------------------ADLER32-------------------------------------------
        private static uint Adler(string str)
        {
            const int mod = 65521;
            uint a = 1, b = 0;
            foreach (char c in str)
            {
                a = (a + c) % mod;
                b = (b + a) % mod;
            }
            return (b << 16) | a;
        }
    }
}