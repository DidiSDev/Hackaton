using HakatonFinal;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Hackaton
{
    public partial class Window1 : Window
    {
        private int contPreguntas = 1; //CONTADOR DE PREGNUTAS
        private bool preguntaRespondida = false; // PREGUNTA HA SIDO RESPONDIDA?
        private List<Preguntas> preguntas;
        private Random random;
        private int score = 0; // PTS
        private int questionsAnswered = 0; // CONTs
        private List<Preguntas> preguntasMostradas; // PREGUNTAS SÍ MOSTRADAS

        public Window1()
        {
            InitializeComponent();
            preguntasMostradas = new List<Preguntas>();
            preguntas = new List<Preguntas>
            {
               new Preguntas("Yes", "Is the Earth a planet?", false, "No", "It doesn’t exist", "It is a satellite", "Yes"),

new Preguntas("Yes", "The Sun is a star", false, "No", "It doesn’t exist", "It is a black hole", "Yes"),

new Preguntas("3", "How many layers does the Earth have?", false, "4", "2", "6", "3"),

new Preguntas("8", "How many planets are there in the solar system?", false, "3", "6", "5", "8"),

new Preguntas("Mercury", "Which is the smallest planet in the solar system?", false, "Venus", "Saturn", "Pluto", "Mercury"),

new Preguntas("Third", "In which position in the solar system is planet Earth?", false, "Second", "Fourth", "Sixth", "Third"),

new Preguntas("The Sun", "What is the celestial body that illuminates the Earth?", false, "The Moon", "Mars", "Venus", "The Sun"),

new Preguntas("Planets", "What is the name of the celestial bodies that orbit around a star?", false, "Comets", "Galaxies", "Meteorites", "Planets"),

new Preguntas("Moon", "What is the name of our natural satellite?", false, "Star", "Volcano", "Asteroid", "Moon"),

new Preguntas("Sun", "What is the name of the closest star to Earth?", false, "Sirius", "Alpha Centauri", "Moon", "Sun"),

new Preguntas("Milky Way", "In which galaxy is the solar system located?", false, "Andromeda", "Triangulum", "Octagonal", "Milky Way"),

new Preguntas("Mars", "Which planet is known as the \"red planet\"?", false, "Mercury", "Jupiter", "Pluto", "Mars"),

new Preguntas("Jupiter", "What is the name of the largest planet in the solar system?", false, "Earth", "Uranus", "Mars", "Jupiter"),

new Preguntas("Mercury", "Which is the planet closest to the Sun?", false, "Venus", "Earth", "Mars", "Mercury"),

new Preguntas("Celestial bodies that emit light and heat", "What are stars?", false, "Small planets", "Natural satellites", "Space rocks", "Celestial bodies that emit light and heat"),

new Preguntas("Saturn", "Which planet in the solar system has rings visible from Earth?", false, "Neptune", "Jupiter", "Uranus", "Saturn"),

new Preguntas("Earth", "Which planet is known as the \"blue planet\"?", false, "Mars", "Neptune", "Venus", "Earth"),

new Preguntas("Venus", "Which is the second planet closest to the Sun?", false, "Mars", "Earth", "Jupiter", "Venus"),

new Preguntas("Solar eclipse", "What natural phenomenon occurs when the Moon blocks the Sun’s light?", false, "Lunar eclipse", "High tide", "Aurora borealis", "Solar eclipse"),

new Preguntas("Neptune", "Which is the planet farthest from the Sun in our solar system?", false, "Uranus", "Pluto", "Saturn", "Neptune"),

new Preguntas("Asia", "Which is the largest continent in the world?", false, "Africa", "North America", "Europe", "Asia"),

new Preguntas("Arctic Ocean", "Which is the smallest ocean in the world?", false, "Atlantic Ocean", "Indian Ocean", "Pacific Ocean", "Arctic Ocean"),

new Preguntas("An imaginary line that divides the Earth into northern and southern hemispheres", "What is the equator?", false, "A mountain range", "An ocean", "A season of the year", "An imaginary line that divides the Earth into northern and southern hemispheres"),

new Preguntas("Nitrogen", "What is the most abundant gas in Earth’s atmosphere?", false, "Oxygen", "Carbon dioxide", "Hydrogen", "Nitrogen"),

new Preguntas("Dead Sea", "What is the lowest point on Earth?", false, "Coral Barrier", "Grand Canyon", "Mount Everest", "Dead Sea"),

new Preguntas("Earthquake", "What natural phenomenon occurs when the Earth shakes?", false, "Storm", "Tornado", "Hurricane", "Earthquake"),

new Preguntas("National Aeronautics and Space Administration", "What does NASA stand for?", false, "National Association for Space Activities", "National Air and Space Agency", "North American Space Agency", "National Aeronautics and Space Administration"),

new Preguntas("Mercury-Redstone 3 (Freedom 7)", "What was NASA’s first manned space mission?", false, "Apollo 11", "Gemini 4", "Apollo 1", "Mercury-Redstone 3 (Freedom 7)"),

new Preguntas("1958", "In what year was NASA founded?", false, "1955", "1960", "1965", "1958"),

new Preguntas("Neil Armstrong", "Who was the first human to walk on the Moon during the Apollo 11 mission?", false, "John Glenn", "Buzz Aldrin", "Michael Collins", "Neil Armstrong")
            };

            random = new Random();
            LoadQuestion(); //CARGAMOS PREGUNTAS
        }

        private void LoadQuestion()
        {
            if (questionsAnswered >= 10)
            {
                ShowFinalScore();
                return;
            }

            // QUEDNA PREGUNTAS? EN CASO DE NO, FUERA
            if (preguntasMostradas.Count == preguntas.Count)
            {
                MessageBox.Show("There are no more questions available..", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowFinalScore();
                return;
            }

            // QUEREMOS PREGUNTAS QUE NO HAYAN SALIDO
            Preguntas currentQuestion;
            do
            {
                int randomIndex = random.Next(preguntas.Count);
                currentQuestion = preguntas[randomIndex];
            }
            while (preguntasMostradas.Contains(currentQuestion)); // ASEGURAMOS SELECICONAR PREGUNTA Q NO HAYA SALIDO YA

            preguntasMostradas.Add(currentQuestion); // AÑADIR PREGNUTA

            // MOSTRAR PREGUNTA
            QuestionText.Text = currentQuestion.PreguntaTitutlo;
            SetAnswers(currentQuestion); // RESPUESTAS

            // ANIMACIÓN TRANSICIÓN
            var slideIn = new ThicknessAnimation(new Thickness(800, 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5));
            QuestionText.BeginAnimation(MarginProperty, slideIn);
        }

        private void SetAnswers(Preguntas currentQuestion)
        {
            QuestionCont.Text = $"QUESTION {contPreguntas}/10";
            List<string> answers = new List<string>(currentQuestion.PosiblesRespuestas1); // TRAEMOS RESPUESTASDEL OBJETO PREGUNTS
            Shuffle(answers); // SHUFFLE BARAJA RESPUESTAS

            // ASIGNAMOS ALEATORIAMENTE LAS RESPUESTAS
            Button answerButton1 = FindName("AnswerButton1") as Button;
            Button answerButton2 = FindName("AnswerButton2") as Button;
            Button answerButton3 = FindName("AnswerButton3") as Button;
            Button answerButton4 = FindName("AnswerButton4") as Button;

            if (answerButton1 != null) answerButton1.Content = answers[0];
            if (answerButton2 != null) answerButton2.Content = answers[1];
            if (answerButton3 != null) answerButton3.Content = answers[2];
            if (answerButton4 != null) answerButton4.Content = answers[3];

            // REINICIAR COLOR FONDO
            contPreguntas++;
            ResetButtonColors();
        }

        private void Shuffle(List<string> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (preguntaRespondida) return; // SI YA RESPONDIÓ NO HACEMOS NADA

            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            // BUSCAMOS LA RESPUESTA CORRECTA
            var currentQuestion = preguntas.Find(q => q.PreguntaTitutlo == QuestionText.Text);
            if (currentQuestion == null) return;

            string selectedAnswer = clickedButton.Content.ToString();
            string correctAnswer = currentQuestion.Correcta;

            if (selectedAnswer == correctAnswer)
            {
                clickedButton.Background = Brushes.Green;
                ResultText.Text = "Correct!";
                score += 10; // AUMENTAMOS LA PUNTUACIÓN DE 10 EN 10 EN DIFICULTAD 1
                UpdateScoreBar(); // ACTUALIZAMOS LA BARRA DE ABAJO DE LA PUNTUACIÓN
            }
            else
            {
                clickedButton.Background = Brushes.Red;
                ResultText.Text = $"Error! The correct answer is: {correctAnswer}";
            }

            questionsAnswered++; // AUMENTAMOS EL CONTADOR DE RESPUESTAS RESPONDIDAS
            preguntaRespondida = true; // PREGUNTA MARCADA COMO RESPONDIDA

            ResultText.Visibility = Visibility.Visible; // MOSTRAR RESULTADO
            UpdateScoreBar(); // ACTUALIZAR BARRA DE PUNTUACIÓN

            // EN LA ÚLTIMA PREGUNTA RETRASAMOS 2 SEGUNDOS EL CONTADOR DE SHOWFINALSCORE 
            if (questionsAnswered >= 10)
            {
                SiguientePreg.Visibility = Visibility.Hidden; //OCULTAMOS SIG PREG
                // RETRASO
                DispatcherTimer delayTimer = new DispatcherTimer();
                delayTimer.Interval = TimeSpan.FromSeconds(2); // 2SEC
                delayTimer.Tick += (s, ev) =>
                {
                    delayTimer.Stop(); // PARAMOS TEMPORIZADOR

                    ShowFinalScore(); // LLAMAMOS A FINALSCORE()
                };
                delayTimer.Start(); // INICIAMOS EL TEMPORIZADOR CON RETRASO

                return; // SALIMOS, NO QUEREMOS MÁS PREGUNTAS
            }

            // SI NO ES LA ÚLTIMA PREGUNTA, DESHABILITAMOS EL RESTO DE BOTONES DE RESPUESTA
            DisableAnswerButtons(clickedButton); // DESHABILITAMOS EL RESTO DE BOTONES DE RESPUESTA
        }


        private void UpdateScoreBar()
        {
            double percentage = (double)score / 100; // CALCULAMOS EL PORCENTAJE TOTAL, EN NIVEL 1 SERÁ 100 DE SCORE
            ScoreBar.Width = percentage * 300; // ANCHO DE BARRA
        }

        private void ShowFinalScore()
        {
            // DESHABILITAMOS BOTONES, NO QUEREMOS QUE EL USUARIO INTERACTÚE CON LA CUENTA REGRESIVA MIENTRAS SE CARGA
            //LA PUNTUACIÓN
            DisableAnswerButtons(null);


            ResultText.Visibility = Visibility.Visible;

            // BARRA PROGRESO
            ScoreBar.Visibility = Visibility.Visible;
            UpdateScoreBar();

            // MUESTRO CONTADOR
            textoContador.Visibility = Visibility.Visible;

            // TEMPORIZADOR INT
            int countdown = 5;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); //1 SEGUNDO POR --


            timer.Tick += (s, e) =>
            {
                countdown--; // DECREMENTO
                textoContador.Text = $"Showing scores in {countdown} seconds..."; // ACTUALIZAOMS TEXTO

                // CONTADOR == 0 MOSTRAMOS VENTANA FinalScoreWindow
                if (countdown <= 0)
                {
                    timer.Stop(); // STOP TEMPORIZADO

                    // MOSTRAMOS PUNTUACIÓN FINAL
                    FinalScoreWindow finalScoreWindow = new FinalScoreWindow(score);
                    finalScoreWindow.Show();
                    this.Close(); // CERRAMOS ACTUAL
                }
            };

            timer.Start(); // TEMPORIZADOR FUERA
        }






        private void DisableAnswerButtons(Button clickedButton)
        {
            StackPanel stackPanel = AnswerStackPanel;

            if (stackPanel != null)
            {
                foreach (var child in stackPanel.Children)
                {
                    if (child is Button button && button.Name.StartsWith("AnswerButton") && button != clickedButton)
                    {
                        button.IsEnabled = false; // DESHABILITAMOS BOTONES
                    }
                }
            }
        }

        private void ResetButtonColors()
        {
            foreach (var child in AnswerStackPanel.Children)
            {
                if (child is Button button && button.Name.StartsWith("AnswerButton"))
                {
                    button.Background = Brushes.LightGray; // RESET COLORES
                }
            }

            // OCULTO MENSAJE ANTERIOR
            ResultText.Visibility = Visibility.Collapsed;
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (!preguntaRespondida) // OBLIGAR AL USUARIO A RESPONDER, NO PUEDE PASAR A LA SIGUIENTE PREGUNTA.
            {
                MessageBox.Show("Please, answer the question before moving on.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // REESTABLECEMOS ESTADO PARA SIGUIENTE PREGUNTA
            preguntaRespondida = false;

            // HABILITAMOS DE NUEVO LOS BOTONES DESHABILITADOS TRAS SELECCIONAR RESPUESTA
            EnableAnswerButtons();

            // CARGA LA NUEVA PREGUNTA
            LoadQuestion();
        }

        private void EnableAnswerButtons()
        {
            StackPanel stackPanel = AnswerStackPanel;

            if (stackPanel != null)
            {
                foreach (var child in stackPanel.Children)
                {
                    if (child is Button button && button.Name.StartsWith("AnswerButton"))
                    {
                        //REINICIAMOS
                        button.IsEnabled = true;
                        button.Background = Brushes.LightGray;
                    }
                }
            }
        }

        //IMAGEN ENTRANDOE NSLIDE IZQERDA


    }
}