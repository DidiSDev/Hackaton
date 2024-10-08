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
    /// <summary>
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        private int contPreguntas = 1; //CONTADOR DE PREGNUTAS
        private bool preguntaRespondida = false; // CONTROLAMOS SI LA PREGUNTA HA SIDO RESPONDIDA
        private List<Preguntas> preguntas;
        private Random random;
        private int score = 0; // PUNTUACIÓN
        private int questionsAnswered = 0; // CONTADOR PREGUNTAS RESPONDIDAS
        private List<Preguntas> preguntasMostradas; // RECOGE LAS PREGUNTAS YA MOSTRADAS

        public Window3()
        {
            InitializeComponent();
            preguntasMostradas = new List<Preguntas>();
            preguntas = new List<Preguntas>
            {
                new Preguntas("35 kilometers", "The mesosphere has a thickness of…", false, "10 kilometers", "60 kilometers", "120 kilometers", "35 kilometers"),

new Preguntas("4500 degrees Fahrenheit", "In the thermosphere, the temperature in this layer can reach:", false, "5400 degrees Fahrenheit", "5600 degrees Fahrenheit", "4600 degrees Fahrenheit", "4500 degrees Fahrenheit"),

new Preguntas("63 km/h", "When is it called a 'tropical storm'?", false, "64 km/h", "65 km/h", "It doesn’t exist", "63 km/h"),

new Preguntas("Yes, but only one", "Can you see stars during the day?", false, "Yes", "No", "I’m not sure", "Yes, but only one"),

new Preguntas("71% hydrogen, 27% helium, and 2% heavier elements", "Gases of the Sun…", false, "71% helium, 27% hydrogen, and 2% heavier elements", "78% hydrogen, 19% helium, and 2% heavier elements", "It has none", "71% hydrogen, 27% helium, and 2% heavier elements"),

new Preguntas("Gravity", "The Sun holds our entire solar system together thanks to…", false, "The other planets", "The Sun doesn’t hold it together", "Anderson's law", "Gravity"),

new Preguntas("58.7 days", "What is the rotation period of Mercury?", false, "34.6 days", "67.89 days", "59.3 days", "58.7 days"),

new Preguntas("Carbon dioxide and some nitrogen", "What is the atmosphere of Venus made of?", false, "Oxygen", "Nitrogen dioxide and some carbon", "Hydrogen and carbon", "Carbon dioxide and some nitrogen"),

new Preguntas("Microscopic and a few meters large", "What size are the particles that make up Saturn’s ring system?", false, "Macroscopic", "Microscopic", "There are no particles", "Microscopic and a few meters large"),

new Preguntas("149,600,000 million km", "What is the average distance from the Sun to the Earth?", false, "146,600,000 million km", "148,600,000 million km", "147,600,000 million km", "149,600,000 million km"),

new Preguntas("Barred spiral", "What type of galaxy is the Milky Way?", false, "Elliptical", "Simple spiral", "Helicoidal spiral", "Barred spiral"),

new Preguntas("A supermassive black hole emitting radiation", "What is a quasar?", false, "A very old star", "A planet in formation", "Main element in a star", "A supermassive black hole emitting radiation"),

new Preguntas("Astronomical unit (AU)", "What is the most commonly used unit of measurement for astronomical distances within our solar system?", false, "Light years", "Kilometers/h", "Meters/s²", "Astronomical unit (AU)"),

new Preguntas("Nuclear fusion", "What is the main process that produces the Sun's energy?", false, "Nuclear fission", "Radioactive decay", "Pyruvate oxidation", "Nuclear fusion"),

new Preguntas("A neutron star that emits periodic radiation", "What is a pulsar?", false, "A type of galaxy", "A dwarf planet", "A component of an atom", "A neutron star that emits periodic radiation"),

new Preguntas("It forms a black hole", "What is the likely fate of a star with a mass greater than the Sun at the end of its life?", false, "It becomes a white dwarf", "It forms a neutron star", "It creates a supernova", "It forms a black hole"),

new Preguntas("The bending of light by the gravity of a massive object", "What phenomenon is known as 'gravitational lensing'", false, "The expansion of the universe", "The collision of two galaxies", "The generation of new galaxies", "The bending of light by the gravity of a massive object"),

new Preguntas("Remnants of the Big Bang", "What is cosmic microwave background radiation?", false, "Emissions from young stars", "Radio waves from the galaxy", "Pulses of sunlight", "Remnants of the Big Bang"),

new Preguntas("Iron", "What element is formed in the core of massive stars before they explode as supernovas?", false, "Hydrogen", "Helium", "Mercury", "Iron"),

new Preguntas("Ionized hydrogen", "What is the main component of emission nebulae?", false, "Cosmic dust", "Cosmic rays", "Metallic elements", "Ionized hydrogen"),

new Preguntas("Hubble's law", "Which law describes the expansion of the universe?", false, "Kepler's law", "The law of universal gravitation", "The principle of energy conservation", "Hubble's law"),

new Preguntas("A rapidly spinning black hole", "What is a Kerr black hole?", false, "A static black hole", "A black hole with an electric charge", "A black hole in formation", "A rapidly spinning black hole"),

new Preguntas("O-type stars", "What are the young, hot, blue stars found in open clusters called?", false, "T Tauri stars", "Main-sequence stars", "Neonatal stars", "O-type stars"),

new Preguntas("Its brightness varies regularly", "What is the main characteristic of a Cepheid variable star?", false, "It changes position in the sky", "It becomes a supernova", "It emits dark matter", "Its brightness varies regularly"),

new Preguntas("A term that describes the accelerated expansion of the universe", "What is the 'cosmological constant' in Einstein’s theory of relativity?", false, "A value that describes the speed of light", "The force of gravitational attraction", "Formula for body lift", "A term that describes the accelerated expansion of the universe"),

new Preguntas("Irregular galaxies", "What are galaxies with no defined shape called?", false, "Spiral galaxies", "Elliptical galaxies", "Phantom galaxies", "Irregular galaxies"),

new Preguntas("A ring of matter surrounding a black hole or star", "What is an 'accretion disk'?", false, "A cloud of interstellar dust", "A star cluster", "The orbit of a planet around its star", "A ring of matter surrounding a black hole or star"),

new Preguntas("1 parsec", "What is the distance in parsecs to a star with a parallax of 1 arcsecond?", false, "10 parsecs", "0.1 parsecs", "100 parsecs", "1 parsec"),

new Preguntas("The Doppler effect due to the expansion of the universe", "What phenomenon causes starlight to shift towards the red in the spectrum?", false, "The absorption of light by stellar dust", "The collision of stars", "The rotation of galaxies", "The Doppler effect due to the expansion of the universe"),

new Preguntas("The boundary beyond which nothing, not even light, can escape", "What is the 'event horizon' of a black hole?", false, "The zone where light can still escape", "The outermost region of a black hole", "The outer region of a black hole", "The boundary beyond which nothing, not even light, can escape"),
            };

            random = new Random();
            LoadQuestion(); // CARGAMOS UNA PREGUNTA
        }

        private void LoadQuestion()
        {
            if (questionsAnswered >= 10)
            {
                ShowFinalScore();
                return;
            }

            // COMPROBAMOS SI QUEDAN PREGUNTAS DISPONIBLES
            if (preguntasMostradas.Count == preguntas.Count)
            {
                MessageBox.Show("There are not more questions aveliable.", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowFinalScore(); // PUNTUACIÓN FINAL SI NO HAY PREGUNTAS
                return;
            }

            // SELECCIONAMOS UNA PREGUNTA QUE NO SE HAYA SELECCIONADO ANTERIORMENTE
            Preguntas currentQuestion;
            do
            {
                int randomIndex = random.Next(preguntas.Count);
                currentQuestion = preguntas[randomIndex];
            }
            while (preguntasMostradas.Contains(currentQuestion)); // MIENTRAS LA PREGUNTA NO SE HAYA MOSTRADO ANTES

            preguntasMostradas.Add(currentQuestion); // AÑADIMOS LA PREGUNTA

            // LA MOSTRAMOS
            QuestionText.Text = currentQuestion.PreguntaTitutlo;
            SetAnswers(currentQuestion); // ESTABLECEMOS RESPUESTAS

            // ANIMACIÓN PARA TRANSICIÓN DE SIGUIENTE PREGUNTA CON DESPLAZAMIENTO SLIDE LATERAL
            var slideIn = new ThicknessAnimation(new Thickness(800, 0, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(0.5));
            QuestionText.BeginAnimation(MarginProperty, slideIn);
        }
        private void UpdateScoreBar()
        {
            double percentage = (double)score / 300; // CALCULAMOS EL PORCENTAJE DE PUNTUACIÓN TOTAL
            ScoreBar.Width = percentage * 300; // AJUSTAMOS EL NUEVO ANCHO DE LA BARRA
        }
        private void SetAnswers(Preguntas currentQuestion)
        {
            QuestionCont.Text = $"QUESTION {contPreguntas}/10";
            List<string> answers = new List<string>(currentQuestion.PosiblesRespuestas1); // OBTENEMOS RESPUESTAS
            Shuffle(answers); // MEZCLAMOS RESPUESTAS

            // ASIGNACIÓN DEL AS RESPUESTAS A LOS BOTONES DE RESPUESTA
            Button answerButton1 = FindName("AnswerButton1") as Button;
            Button answerButton2 = FindName("AnswerButton2") as Button;
            Button answerButton3 = FindName("AnswerButton3") as Button;
            Button answerButton4 = FindName("AnswerButton4") as Button;

            if (answerButton1 != null) answerButton1.Content = answers[0];
            if (answerButton2 != null) answerButton2.Content = answers[1];
            if (answerButton3 != null) answerButton3.Content = answers[2];
            if (answerButton4 != null) answerButton4.Content = answers[3];

            contPreguntas++;
            ResetButtonColors(); // RESET
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
                score += 30; // AUMENTAMOS LA PUNTUACIÓN DE 10 EN 10 EN DIFICULTAD 1
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
                SiguientePreg.Visibility = Visibility.Hidden;
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
                    if (child is Button button && button != clickedButton)
                    {
                        button.IsEnabled = false; // DESHABILITAMOS OTROS BOTONES
                    }
                }
            }
        }

        private void ResetButtonColors()
        {
            foreach (var child in (this.Content as Grid).Children)
            {
                if (child is Button button && button.Name.StartsWith("AnswerButton"))
                {
                    button.Background = Brushes.LightGray;
                }
            }
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (!preguntaRespondida)
            {
                MessageBox.Show("Please,answeryhe question before moving on.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // REESTABLECEMOS ESTADO PARA SIGUIENTE PREGUNTA
            preguntaRespondida = false;
            EnableAnswerButtons(); // HABILITAMOS DE NUEVO LOS BOTONES
            LoadQuestion(); // CARGA LA NUEVA PREGUNTA
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
                        button.IsEnabled = true; // HABILITAR
                        button.Background = Brushes.LightGray; // REINICIAR COLOR
                    }
                }
            }
        }
    }
}