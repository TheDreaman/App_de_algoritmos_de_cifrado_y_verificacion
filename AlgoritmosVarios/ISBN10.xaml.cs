using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlgoritmosVarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ISBN10 : ContentPage
    {
        public ISBN10()
        {
            InitializeComponent();
        }
        private void InfoButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("El ISBN de diez dígitos", "El dígito de control de un ISBN de diez cifras se halla mediante " +
                "un cálculo basado en el módulo 11: Se multiplica cada uno de los nueve primeros dígitos por la posición que ocupan " +
                "en la secuencia numérica, es decir, el primero por 1, el segundo por dos y así sucesivamente hasta el noveno que se " +
                "multiplica por 9. Luego se suman estas multiplicaciones y el resultado se divide entre 11. Dicha división dejará un " +
                "resto entre 0 y 10. Si el resto está entre 0 y 9, este mismo valor es el del dígito de control. Pero si el resto es 10, " +
                "entonces se establece como dígito de control la letra X.", "OK");
        }
        private void InfoButton2_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("El ISBN de trece dígitos", "El dígito de control de un ISBN de trece cifras se calcula de un modo " +
                "diferente al del ISBN de 10 cifras, con un cálculo basado en el módulo 10: multiplicando el primero de los 12 " +
                "números iniciales por 1, el segundo por 3, el tercero por 1, el cuarto por 3, y así sucesivamente hasta llegar " +
                "al número 12; el dígito de control es el valor que se debe añadir a la suma de todos estos productos para hacerla " +
                "divisible por 10 (por ejemplo si la suma es 97, el dígito de control es 3, porque 97 + 3 = 100, que es divisible " +
                "por 10; si la suma es 86, el dígito de control será 4; si suman 120, será 0; y así en cualquier otro caso)", "OK");
        }
        private void CalculaButton_Clicked(object sender, EventArgs e)
        {
            //-------------------------ISBN-10 Digito Verificador------------------------------------
            var auxin = inISBN.Text;
            outISBNActual.Text = $"Digito verificador del ISBN: {auxin} = {CalcCheckDigit(auxin)}";
            outISBNHistory.Text += "\n" + $"Digito verificador del ISBN: {auxin} = {CalcCheckDigit(auxin)}";
        }
        //-----------------------ISBN-10 Digito Verificador-------------------------------------------
        static char CalcCheckDigit(string auxin)
        {
            char result = '?';

            if (!string.IsNullOrWhiteSpace(auxin))
            {
                auxin = auxin.Replace("-", "").Replace(" ", ""); 

                if (Regex.IsMatch(auxin, @"^\d*$")) 
                {
                    switch (auxin.Length)
                    {
                        case 9: 
                            result = CalcCheckDigitForISBN10(auxin);
                            break;
                        case 12: 
                            result = CalcCheckDigitForISBN13(auxin);
                            break;
                    }
                }
            }
            return result;
        }
        static char CalcCheckDigitForISBN10(string auxin)
        {
            char res = '?';

            int sum = 0;
            for (int i = 0, cont = auxin.Length + 1; i < auxin.Length; i++, cont--)
            {
                int number = auxin[i] - '0';
                sum += number * cont;
            }

            res = (char)(((11 - sum % 11) % 11) + '0');
            return res;
        }
        static char CalcCheckDigitForISBN13(string auxin)
        {
            char result = '?';

            int sum = 0;
            bool oddIndex = false;

            foreach (char c in auxin)
            {
                int number = c - '0';
                sum += number * (oddIndex ? 3 : 1);
                oddIndex = !oddIndex;
            }

            result = (char)(((10 - sum % 10) % 10) + '0');         
            return result;
        }
    }
}