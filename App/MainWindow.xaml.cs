using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Practice
{
    public partial class MainWindow : Window
    {
        private bool invalidOperation;

        public MainWindow()
        {
            InitializeComponent();
            foreach(var button in Buttons.Children)
                if(button is Button)
                    ((Button)button).Click += OnClick;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var text = ((Button)e.OriginalSource).Content.ToString();

            if (invalidOperation)
            {
                Text.Text = string.Empty;
                invalidOperation = false;
            }

            switch (text)
            {
                case "C":
                    Text.Clear();
                    break;
                case "X":
                    if (Text.Text.Length > 1)
                        Text.Text = Text.Text.Substring(0, Text.Text.Length - 1);
                    break;
                case "=":
                    try
                    {
                        Text.Text = new DataTable().Compute(Text.Text, null).ToString();
                    }
                    catch
                    {
                        Text.Text = "Недопустимая операция в арифмитическом выражении";
                        invalidOperation = true;
                    }
                    break;
                default:
                    Text.Text += text;
                    break;
            }
        }
    }
}
