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
    public partial class Modulo11 : ContentPage
    {
        public Modulo11()
        {
            InitializeComponent();
        }
        private void InfoButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Módulo 11 (código de control)", "El método denominado módulo 11 detecta errores en un solo dígito e intercambios " +
                "simples o dobles. Se basa en aplicar un factor de chequeo ponderado a cada dígito del número original. " +
                "El cálculo se realiza como sigue:\n 1. A cada dígito del número base se le asigna un factor de chequeo ponderado. " +
                "Dicho factor será 2 para el dígito menos significativo (el que está más a la derecha) y, en orden, 3, 4, 5, 6, 7 para " +
                "los siguientes. Si hubiera más de 6 dígitos la secuencia se repetiría de modo que el séptimo dígito se multiplicaría por 2, " +
                "el octavo por 3, etc. \n 2. Cada dígito del número base se multiplica por el factor de chequeo asignado. \n 3. Se suman los " +
                "resultados de todas las multiplicaciones. \n 4. Al resultado de la suma se le calcula el módulo 11(de ahí el nombre del método), " +
                "es decir, el resto de la división entera entre 11. \n 5. A 11 se le resta el módulo calculado en el punto anterior.Si el " +
                "resultado de la resta es < 10, dicho resultado es el dígito de control que buscábamos.Si el resultado es 11 el dígito de " +
                "control es 0 y si el resultado es 10 el dígito de control resultante es 1.", "OK");
        }
        private void CalculaButton_Clicked(object sender, EventArgs e)
        {
            //-----------------------MODULO 11 Codigo de control para cadenas de 9 digitos-------------------------------------------
            if (inMod11.Text == null)
            {
                outMod11Actual.Text = "Ingrese algo antes";
                outMod11History.Text += "\n" + "Ingrese algo antes";
            }
            else if (inMod11.Text.Length != 9)
            {
                outMod11Actual.Text += "Número no valido (" + inMod11.Text + ")";
                outMod11History.Text += "\n" + "Número no valido (" + inMod11.Text + ")";
            }            
            else
            {
                outMod11Actual.Text += "Número ingresado: " + cad9Modulo11(inMod11.Text);
                outMod11History.Text += "\n" + "Número ingresado: " + inMod11.Text + " Dígito verificador: " + cad9Modulo11(inMod11.Text);
            }
            
        }
        //-----------------------MODULO 11 Codigo de control para cadenas de 9 digitos-------------------------------------------
        static string cad9Modulo11(string numero)
        {
            int[] factor = new int[] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int contador = 0;
            long suma = 0, numEx;
            numero = numero.Replace("-", "").Replace(" ", ""); 
            if (numero.Length != 9)
            {
                return ("Número no valido");
            }
            bool end = false;
            while (end == false)
            {
                numEx = int.Parse(new string(numero[contador], 1));
                suma += numEx * factor[contador];
                contador++;
                if (contador == numero.Length)
                {
                    end = true;
                }
            }
            int resultado = (int)(11 - (suma % 11));
            if (resultado == 10)
                resultado = 1;
            else if (resultado == 11)
                resultado = 0;
            return resultado.ToString();
        }
    }
}