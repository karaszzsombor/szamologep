using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }

        private void GombokElhelyezese()
        {
            for(int i = 0; i < 4; i++)
            {
                btn_grid.RowDefinitions.Add(new RowDefinition());
                btn_grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            string[,] text = 
            {
                {"7", "8", "9", "/" },
                {"4", "5", "6", "*" },
                {"1", "2", "3", "-" },
                {"Clr","0","=", "+" },
            };
            for(int i = 0;i < 4; i++)
            {
                for (int j = 0; j < 4; j++) 
                { 
                    string label = text[i,j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3),
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if (label == "Clr")
                    {
                        btn.Background = Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue; 
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Button_Click;


                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);


                    btn_grid.Children.Add(btn);


                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked_btn = (Button)sender;
            string felirat = clicked_btn.Content.ToString();

            if (char.IsDigit(felirat[0]))
            {
                if(txb_screen.Text == "0")
                {
                    txb_screen.Text = "";
                }
                txb_screen.Text += felirat;
            }

            else if(felirat == "Clr")
            {
                txb_screen.Text = "0";
            }

            else if(felirat == "/" || felirat == "*" || felirat == "-" || felirat == "+")
            {
                if (char.IsDigit(txb_screen.Text[txb_screen.Text.Length-1]))
                {
                    txb_screen.Text += felirat;
                }
            }
            else if(felirat == "=")
            {
                if ("+-*/".Contains(txb_screen.Text.Last()))
                {
                    MessageBox.Show("NAGY KEREK ERROR LMFAO", "", MessageBoxButton.AbortRetryIgnore, MessageBoxImage.Error);
                }
                    double num1 = 0;
                    double num2 = 0;
                    double num3 = 0;

                if (txb_screen.Text.Contains("*"))
                {
                    while (txb_screen.Text.Contains("*"))
                    {
                        num1 = 0;
                        num2 = 0;
                        num3 = 0;

                        int szorzas_index = txb_screen.Text.LastIndexOf('*');

                        int a = szorzas_index + 1;
                        while (a < txb_screen.Text.Length && (char.IsDigit(txb_screen.Text[a]) || txb_screen.Text[a]=='.')) //szorzás utáni szám
                        {
                            a++;
                        }
                        num1 = Double.Parse(txb_screen.Text.Substring(szorzas_index+1, a-szorzas_index-1));


                        int b = szorzas_index - 1;
                        while (b >= 0 && (char.IsDigit(txb_screen.Text[b]) || txb_screen.Text[b]=='.')) //szorzás előtti szám
                        {
                            b--;
                        }
                        num2 = Double.Parse(txb_screen.Text.Substring(b + 1, szorzas_index - 1 - b));

                        num3 = num1 * num2;

                        int rightLen = Convert.ToString(num1).Length;
                        int leftLen = Convert.ToString(num2).Length;
                        int start = szorzas_index - leftLen;
                        int length = leftLen + 1 + rightLen;
                        txb_screen.Text = txb_screen.Text.Substring(0, start) + num3 + txb_screen.Text.Substring(start + length);

                    }
                }
                if (txb_screen.Text.Contains("/"))
                {
                    while (txb_screen.Text.Contains("/"))
                    {
                        num1 = 0;
                        num2 = 0;
                        num3 = 0;

                        int osztas_index = txb_screen.Text.LastIndexOf('/');

                        int a = osztas_index + 1;
                        while (a < txb_screen.Text.Length && (char.IsDigit(txb_screen.Text[a]) || txb_screen.Text[a] == '.')) //osztás utáni szám
                        {
                            a++;
                        }
                        num1 = Double.Parse(txb_screen.Text.Substring(osztas_index+1, a-osztas_index-1));


                        int b = osztas_index - 1;
                        
                        while (b >= 0 && (char.IsDigit(txb_screen.Text[b]) || txb_screen.Text[b] == '.')) //osztás előtti szám
                        {
                            b--;
                        }
                        num2 = Double.Parse(txb_screen.Text.Substring(b+1, osztas_index-1 - b));

                        num3 = num2 / num1;

                        int rightLen = Convert.ToString(num1).Length;
                        int leftLen = Convert.ToString(num2).Length;
                        int start = osztas_index - leftLen;
                        int length = leftLen + 1 + rightLen;
                        txb_screen.Text = txb_screen.Text.Substring(0, start) + num3 + txb_screen.Text.Substring(start + length);

                    }
                }
                if (txb_screen.Text.Contains("-"))
                {
                    while (txb_screen.Text.Contains("-"))
                    {
                        num1 = 0;
                        num2 = 0;
                        num3 = 0;

                        int kivonas_index = txb_screen.Text.LastIndexOf('-');
                        if (kivonas_index == 0)
                        {
                            break;
                        }


                        int a = kivonas_index + 1;
                        while (a < txb_screen.Text.Length && (char.IsDigit(txb_screen.Text[a]) || txb_screen.Text[a] == '.')) //osztás utáni szám
                        {
                            a++;
                        }
                        num1 = Double.Parse(txb_screen.Text.Substring(kivonas_index + 1, a - kivonas_index - 1));


                        int b = kivonas_index - 1;

                        while (b >= 0 && (char.IsDigit(txb_screen.Text[b]) || txb_screen.Text[b] == '.')) //osztás előtti szám
                        {
                            b--;
                        }
                        num2 = Double.Parse(txb_screen.Text.Substring(b + 1, kivonas_index - 1 - b));

                        num3 = num2 - num1;

                        int rightLen = Convert.ToString(num1).Length;
                        int leftLen = Convert.ToString(num2).Length;
                        int start = kivonas_index - leftLen;
                        int length = leftLen + 1 + rightLen;
                        txb_screen.Text = txb_screen.Text.Substring(0, start) + num3 + txb_screen.Text.Substring(start + length);
                    }
                }
            }
        }
    }
}