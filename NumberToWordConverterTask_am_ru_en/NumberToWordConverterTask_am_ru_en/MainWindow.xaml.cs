using System;
using System.Windows;
using System.Windows.Controls;

namespace NumberToWordConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string isNegative = "";
                string number = txtNumber.Text;
                number = Convert.ToDouble(number).ToString();
                ComboBoxItem selectedLanguage = (ComboBoxItem)cmbLanguages.SelectedItem;
                string langCode = selectedLanguage.Tag.ToString();

                if (number.Contains("-"))
                {
                    switch (langCode)
                    {
                        case "en":
                            isNegative = "Minus ";
                            break;
                        case "am":
                            isNegative = "Մինուս ";
                            break;
                        case "ru":
                            isNegative = "Минус ";
                            break;
                    }
                    number = number.Substring(1, number.Length - 1);
                }
                if (number == "0")
                {
                    txtResult.Text = "Zero";
                }
                else
                {
                   txtResult.Text = " \n" + isNegative + NumberToWord.Converter.ConvertToWords(number, langCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
