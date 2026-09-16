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
            int a = 0;
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
                var Lista = txb_screen.Text;
                if (txb_screen.Text.Contains("*"))
                {

                }
            }
        }
    }
}