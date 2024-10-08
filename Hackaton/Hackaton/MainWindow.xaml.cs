using Hackaton;
using System.Windows;

namespace HakatonFinal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // BOTONES DE DIFICULTAD HABILITADOS TRAS EL CLICK EN START
            Dfacil.IsEnabled = true;
            Dmedia.IsEnabled = true;
            Ddificil.IsEnabled = true;
        }
        //Y
        private void Easy_Click(object sender, RoutedEventArgs e)
        { 
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
