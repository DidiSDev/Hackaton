using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HakatonFinal
{
    class Dificultad3
    {

        private Preguntas[] bateria3;
        public Dificultad3(Preguntas p1, Preguntas p2, Preguntas p3, Preguntas p4, Preguntas p5, Preguntas p6, Preguntas p7, Preguntas p8, Preguntas p9, Preguntas p10, Preguntas p11, Preguntas p12, Preguntas p13, Preguntas p14, Preguntas p15, Preguntas p16, Preguntas p17, Preguntas p18, Preguntas p19, Preguntas p20, Preguntas p21, Preguntas p22, Preguntas p23, Preguntas p24, Preguntas p25, Preguntas p26, Preguntas p27, Preguntas p28, Preguntas p29, Preguntas p30)
        {
            bateria3 = new Preguntas[30];
            bateria3[0] = p1;
            bateria3[1] = p2;
            bateria3[2] = p3;
            bateria3[3] = p4;
            bateria3[4] = p5;
            bateria3[5] = p6;
            bateria3[6] = p7;
            bateria3[7] = p8;
            bateria3[8] = p9;
            bateria3[9] = p10;

            bateria3[10] = p11;
            bateria3[11] = p12;
            bateria3[12] = p13;
            bateria3[13] = p14;
            bateria3[14] = p15;
            bateria3[15] = p16;
            bateria3[16] = p17;
            bateria3[17] = p18;
            bateria3[18] = p19;

            bateria3[19] = p20;
            bateria3[20] = p21;
            bateria3[21] = p22;
            bateria3[22] = p23;
            bateria3[23] = p24;
            bateria3[24] = p25;
            bateria3[25] = p26;
            bateria3[26] = p27;
            bateria3[27] = p28;
            bateria3[28] = p29;
            bateria3[29] = p30;
        }

        internal Preguntas[] Bateria3 { get => bateria3; set => bateria3 = value; }
    }
}