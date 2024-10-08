using hackaton;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Hackaton
{
    public partial class FinalScoreWindow : Window
    {
        private int score; // PUNTUACIÓN JUGADOR
        private Jugador jugador; 

        public FinalScoreWindow(int score)
        {
            InitializeComponent();
            this.score = score; // GUARDAOMS PUNT
            ScoreText.Text = $"Your final score is: {score} points!"; // MOSTRAMOS PUNTUACIÓN RECOGIDA EN WINDOW ANTERIOR
            PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(PlayerNameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed; // VERIFICAMOS TEXTO DE INICIO
        }

        private void PlayerNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // OCULTAMOS PLACEHOLDER SI ESCRIBE EL USUARIO
            PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(PlayerNameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PlayerNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // OCULTAMOS PLACEHOLDER SI EL TEXTO RECIBE FOCO, CLICK
            PlaceholderTextBlock.Visibility = Visibility.Collapsed;
        }

        private void PlayerNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // MUESSTRA PLACEHOLDER SI CAJA VACÍA O SI USUARIO CLICK FUERA
            PlaceholderTextBlock.Visibility = string.IsNullOrWhiteSpace(PlayerNameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void SaveScore_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim(); // OBTENEMOS NOMBRE DE JUGADOR

            if (string.IsNullOrWhiteSpace(playerName))
            {
                MessageBox.Show("Please introduce your name without spaces, this field must be filled.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // LA CAJA ESTÁ VACÍA OBLIGAMOS AL USUARIO A ESCRIBIR ALGO
            }

            // CREAMOS NUEVO JUGADOR
            jugador = new Jugador(score, playerName);

            // VERIFICAMOS Y GUARDAMOS PUNTUACIÓN
            jugador.GuardarSiNombreValido(playerName);
        }


        private void ViewRanking_Click(object sender, RoutedEventArgs e)
        {
            // ABRIMOS RANKING DE PUNTUACIONES
            string rankings = LoadScoresFromFile();
            MessageBox.Show(rankings, "Score Ranking", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }

        private string LoadScoresFromFile()
        {
            // CARGAMOS LAS PUNTUACIONES YA GUARDADAS
            string path = "ranking.txt"; 
            string scores = "Score ranking:\n";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    scores += line + "\n"; // ADD A CADA PUNTUACIÓN LA CADENA DEL OS RESULTADOS.
                }
            }
            else
            {
                scores += "There aren't any score yet.";
            }

            return scores;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // CERRAMOS LA VENTANA SIN CARGAR LA PRIMERA PORQUE NO SE HA CERRADO.
          
        }
    }
}
