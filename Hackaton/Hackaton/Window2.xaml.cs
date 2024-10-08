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
    /// Lógica de interacción para Window2.xaml
    /// </summary>

    public partial class Window2 : Window
    {
        private int contPreguntas = 1; //CONTADOR DE PREGNUTAS
        private bool preguntaRespondida = false; // CONTROLAMOS SI LA PREGUNTA HA SIDO RESPONDIDA, OBLIGAMOS A RESPONDER SIEMPRE

        private List<Preguntas> preguntas;
        private Random random;
        private int score = 0; // PUNTUACIÓN
        private int questionsAnswered = 0; // CONTADOR PREGUNTAS RESPONDIDAS
        private List<Preguntas> preguntasMostradas; //RECOGE LAS PREGUNTAS YA MOSTRADAS, PARA IMPLEMENTAR QUE NO SE REPITAN.

        public Window2()
        {
            InitializeComponent();
            preguntasMostradas = new List<Preguntas>();
            preguntas = new List<Preguntas>
            {
                new Preguntas("6", "The Earth's atmosphere has …… layers.", false, "5", "6", "7", "4"),
                    new Preguntas("Hydrogen and helium, but they are very sparse.", "The exosphere contains gases like...", false, "Carbon", "Hydrogen", "Hydrogen and helium, but they are very sparse.", "Oxygen"),
                    new Preguntas("70%", "Water covers … of the Earth's surface.", false, "50%", "65%", "70%", "80%"),
                    new Preguntas("93 millon miles", "How far is the Sun from Earth?", false, "93 millon miles", "78 million miles", "94 million miles", "67 million miles"),
                    new Preguntas("4.5 billion years old", "The Sun is about…", false, "34 million years old", "4.5 billion years old", "6.7 billion years old", "7.8 billion years old"),
                    new Preguntas("The Moon passes between the Sun and the Earth", "A solar eclipse occurs when...", false, "The Sun passes between the Moon and the Earth", "The Earth passes between the Sun and the Moon", "The Moon passes between the Sun and the Earth", "It doesn’t happen"),
                    new Preguntas("Venus", "Which is the hottest planet in the solar system?", false, "Mars", "Venus", "Jupiter", "Pluto"),
                    new Preguntas(" 5,000,000,000", "In how many million years will the Sun run out of hydrogen and become a white dwarf?", false, "8,000,000,000", " 5,000,000,000", "7,000,000,000", "6,000,000,000"),
                    new Preguntas(" Jupiter", "Which of the following planets has the most moons?", false, "Jupiter", "Saturn", "Pluto", "Mars"),
                    new Preguntas("Laika", "What was the name of the first living being to go into outer space?", false, "Rayka", "Laika", "Neil Armstrong", "No one has ever gone"),
                    new Preguntas("Hydrogen", "What is the most abundant element in the universe?", false, "Helium", "Oxygen", "Hydrogen", "Carbon"),
                    new Preguntas("Big Bang Theory", "Which theory explains the origin of the universe?", false, "Big Bang Theory", "Quantum Theory", "Expansion Theory", "None of the above"),
                    new Preguntas("Milky Way", "What is the name of the galaxy where our solar system is located?", false, "Andromeda", "Triangulum", "Milky Way", "We are not in any galaxy"),
                    new Preguntas("White dwarf", "What type of star will the Sun become when it runs out of fuel?", false, "Neutron star", "Neutron star", "Black hole", "Supernova"),
                    new Preguntas("Very dense stars", "What are black holes?", false, "Very dense stars", "Regions of space with extremely strong gravity", "Stars in formation", "Clouds of interstellar gas"),
                    new Preguntas("Andromeda Galaxy", "What is the closest galaxy to the Milky Way?", false, "Andromeda Galaxy", "Sombrero Galaxy", "Large Magellanic Cloud", "Triangulum Galaxy"),
                    new Preguntas("Light year", "What is the distance that light travels in a year called?", false, "Stellar year", "Light year", "Astronomical unit", "Galactic year"),
                    new Preguntas("An explosion of a star in its final stage", "What is a supernova?", true, "An explosion of a star in its final stage", "A giant planet", "A comet entering an atmosphere", "A galaxy in formation"),
                    new Preguntas("Star", "Which of the following objects does not emit its own light?", false, "Star", "Comet", "Pulsar", "Black hole"),
                    new Preguntas("Gravity", "What force holds galaxies together?", false, "Nuclear force", " Gravity", "Electromagnetism", "Cosmic radiation"),
                    new Preguntas("Iron and nickel", "What is the Earth's core mainly composed of?", false, "Hydrogen", "Iron and nickel", "Silicon", "Carbon"),
                    new Preguntas("Mantle", "Which layer of the Earth lies between the crust and the core?", false, "Hydrosphere", "Mantle", " Atmosphere", "Outer core"),
                    new Preguntas("Pacific Ocean", "Which is the largest ocean on Earth?", false, "Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean"),
                    new Preguntas("Mount Everest", "What is the highest point above sea level on Earth ? ", false, "Mount Everest", "Mount Kilimanjaro", "Mount Aconcagua", "Mount McKinley"),
                    new Preguntas("A process by which certain gases trap heat in the atmosphere", "What is the \"greenhouse effect\"?", false, "A phenomenon that causes rain", "A process by which certain gases trap heat in the atmosphere", "Cloud formation", "A type of weather phenomenon"),
                    new Preguntas("Igneous rock", "What type of rock forms from the solidification of magma?", false, "Sedimentary rock", "Metamorphic rock", "Igneous rock", "Volcanic rock"),
                    new Preguntas("Troposphere", "Which layer of the atmosphere is where most weather phenomena occur?", false, "Stratosphere", "Mesosphere", "Troposphere", "Thermosphere"),
                    new Preguntas("Weathering", "What is the process by which rocks break down and turn into soil?", false, "Erosion", "Weathering", "Sedimentation", "Compaction"),
                    new Preguntas("Antarctica", "Which of the following is a continent?", false, " Greenland", "Antarctica", "Easter Island", "Borneo"),
                    new Preguntas("Corona", "What is the outermost layer of the solar atmosphere?", false, "Core", "Radiation zone", "Chromosphere", "Corona"),
            };

            random = new Random();
            LoadQuestion(); // CARGAMOS UNA PREGUNTA DE LA DIFICULTAD ELEGIDA, EN ESTA VENTANA ES LA INTERMEDIA, 2
        }

        private void LoadQuestion()
        {
            if (questionsAnswered >= 10)
            {
                ShowFinalScore();
                //SI HEOMS ALCANZADO EL LIMITE DE PREGUNTAS MOSTRAMOS LA PUNTUACIÓN FINAL
                return;
            }

            // COMPROBAMOS SI QUEDAN PREGUNTAS DISPONIBLES, EN CASO DE QUE NO HAYA MOSTRAMOS YA LA PUNTUACIÓN FINAL
            if (preguntasMostradas.Count == preguntas.Count)
            {
                MessageBox.Show("There are not more questions aveliable.", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                ShowFinalScore(); //PUNTUACIÓN FINAL SI NO HAY PREGUNTAS
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


        private void SetAnswers(Preguntas currentQuestion)
        {
            QuestionCont.Text = $"QUESTION {contPreguntas}/10";
            List<string> answers = new List<string>(currentQuestion.PosiblesRespuestas1); // OBTENEMOS RESPUESTAS DESDE EL OBJETO PREGUNTAS
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

            // QUITAMOS EL COLOR DE FONDO DEL OS BOTONES, HACEMOS RESET
            contPreguntas++;
            ResetButtonColors();
        }

        private void Shuffle(List<string> list)
        {
            // ESTE MÉTODO SIMPLEMENTE RESETEA LOS BOTONES.
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
                score += 20; // AUMENTAMOS LA PUNTUACIÓN DE 20 EN 20 EN DIFICULTAD 2
                UpdateScoreBar(); // ACTUALIZAMOS LA BARRA DE ABAJO DE LA PUNTUACIÓN
            }
            else
            {
                clickedButton.Background = Brushes.Red;
                ResultText.Text = $"Error! the correct answer is: {correctAnswer}";
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
            double percentage = (double)score / 200; // CALCULAMOS EL PORCENTAJE DE PUNTUACIÓN TOTAL
            ScoreBar.Width = percentage * 300; // AJUSTAMOS EL NUEVO ANCHO DE LA BARRA
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
                        button.IsEnabled = false; // DESHABILITAMOS OTROS BOTONES
                    }
                }
            }
        }

        private void ResetButtonColors()
        {
            // RESTAURAMOS BOTONES
            foreach (var child in (this.Content as Grid).Children)
            {
                if (child is Button button && button.Name.StartsWith("AnswerButton"))
                {
                    button.Background = Brushes.LightGray;
                }
            }

            // OCULTAMOS EL MENSAJE DEL RESULTADO DE LA PREGUNTA ANTERIOR
            ResultText.Visibility = Visibility.Collapsed;
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (!preguntaRespondida) // OBLIGAR AL USUARIO A RESPONDER, NO PUEDE PASAR A LA SIGUIENTE PREGUNTA.
            {
                MessageBox.Show("Please, answer the question before moving on.", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            // COGEMOS EL PANEL DE LOS BOTONES (EL STACKPANEL CLARO)
            StackPanel stackPanel = AnswerStackPanel;

            // HABILITAMOS DE NUEVO TODOS LOS BOTONES DE RESPUESTA
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