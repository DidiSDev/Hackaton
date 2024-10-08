using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakatonFinal
{
    class Preguntas
    {

        private string correcta, preguntaTitutlo;//aqui defino la respuesta a la pregunta y el enuciado de la pregunta y la tematica de la misma.                                        
        private Boolean repetida;
        private string[] PosiblesRespuestas;
        public Preguntas(string correct, string titulo,/*t dificultad*/Boolean rep, String PosibleR1, String PosibleR2, String PosibleR3, String PosibleR4)
        {
            Correcta = correct;
            PreguntaTitutlo = titulo;
            Repetida = rep;
            PosiblesRespuestas1 = new string[4];
            PosiblesRespuestas1[0] = PosibleR1;
            PosiblesRespuestas1[1] = PosibleR2;
            PosiblesRespuestas1[2] = PosibleR3;
            PosiblesRespuestas1[3] = PosibleR4;

        }

        public string[] PosiblesRespuestas1 { get => PosiblesRespuestas; set => PosiblesRespuestas = value; }
        public bool Repetida { get => repetida; set => repetida = value; }
        public string Correcta { get => correcta; set => correcta = value; }
        public string PreguntaTitutlo { get => preguntaTitutlo; set => preguntaTitutlo = value; }


    }
}