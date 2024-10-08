using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace HakatonFinal
{
    class Dificultad1
    {

        private Preguntas[] bateria1;

      

        public Dificultad1(Preguntas p1, Preguntas p2, Preguntas p3, Preguntas p4, Preguntas p5, Preguntas p6, Preguntas p7, Preguntas p8, Preguntas p9, Preguntas p10, Preguntas p11, Preguntas p12, Preguntas p13, Preguntas p14, Preguntas p15, Preguntas p16, Preguntas p17, Preguntas p18, Preguntas p19, Preguntas p20, Preguntas p21, Preguntas p22, Preguntas p23, Preguntas p24, Preguntas p25, Preguntas p26, Preguntas p27, Preguntas p28, Preguntas p29, Preguntas p30)
        {
            Bateria1 = new Preguntas[30];
            Bateria1[0] = p1;
            Bateria1[1] = p2;
            Bateria1[2] = p3;
            Bateria1[3] = p4;
            Bateria1[4] = p5;
            Bateria1[5] = p6;
            Bateria1[6] = p7;
            Bateria1[7] = p8;
            Bateria1[8] = p9;
            Bateria1[9] = p10;

            Bateria1[10] = p11;
            Bateria1[11] = p12;
            Bateria1[12] = p13;
            Bateria1[13] = p14;
            Bateria1[14] = p15;
            Bateria1[15] = p16;
            Bateria1[16] = p17;
            Bateria1[17] = p18;
            Bateria1[18] = p19;
            Bateria1[19] = p20;
            Bateria1[20] = p21;
            Bateria1[21] = p22;
            Bateria1[22] = p23;
            Bateria1[23] = p24;
            Bateria1[24] = p25;
            Bateria1[25] = p26;
            Bateria1[26] = p27;
            Bateria1[27] = p28;
            Bateria1[28] = p29;
            Bateria1[29] = p30;
        }

        internal Preguntas[] Bateria1 { get => bateria1; set => bateria1 = value; }
    }
}