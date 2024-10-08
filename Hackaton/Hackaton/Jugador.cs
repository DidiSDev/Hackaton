using System;
using System.IO;
using System.Windows;

namespace hackaton
{
    internal class Jugador
    {
        private string nombre;
        private int puntos;

        public Jugador(int p, string n)
        {
            this.nombre = n;
            this.puntos = p;
        }

        public void añadirRanking()
        {
            bool metido = false;
            string linea = $"{nombre} - {puntos}";

            try
            {
                // CREAR ARCHIVO SI NO EXISTE
                if (!File.Exists("ranking.txt"))
                {
                    File.WriteAllText("ranking.txt", string.Empty);
                }

                // LEER RANKING ACTUAL
                string[] lineasExistentes = File.ReadAllLines("ranking.txt");

                using (StreamWriter est = new StreamWriter("temp.txt"))
                {
                    foreach (string lineaExistente in lineasExistentes)
                    {
                        if (comparar(linea, lineaExistente) == 1 && !metido)
                        {
                            est.WriteLine(linea);
                            metido = true;
                        }
                        est.WriteLine(lineaExistente);
                    }

                    // AÑADIR JUGADOR AL FINAL SI NO EXISTE EN EL FICHERO .TXT YA CREADO
                    if (!metido)
                    {
                        est.WriteLine(linea);
                    }
                }

                
                File.Delete("ranking.txt");
                File.Move("temp.txt", "ranking.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving ranking: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool comp_nombre(string nombre)
        {
            bool enc = false;

            try
            {
                // LEER SOLO SI EXISTE
                if (!File.Exists("ranking.txt")) return false;

                using (StreamReader read = File.OpenText("ranking.txt"))
                {
                    string linea;
                    while ((linea = read.ReadLine()) != null)
                    {
                        if (nombre.Equals(linea.Split(" - ")[0]))
                        {
                            MessageBox.Show("You can't use that name, it's already taken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            enc = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to check name: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return enc; // TRUE DEVUELTO SI EXISTE
        }

        public void GuardarSiNombreValido(string nombre)
        {
            if (!comp_nombre(nombre))
            {
                añadirRanking(); // GUARDAR SÓLO SI NO EXISTE EL NOMBRE.
                MessageBox.Show("Score saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private int comparar(string linea2, string linea)
        {
            int n1 = int.Parse(linea.Split(" - ")[1]);
            int n2 = int.Parse(linea2.Split(" - ")[1]);

            if (n1 > n2) return 0;
            if (n2 > n1) return 1;
            return 2; 
        }
    }
}
