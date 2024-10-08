using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace HakatonFinal
{
    class Dificultad2
    {

        private Preguntas[] bateria2;

      
        public Dificultad2(Preguntas p1, Preguntas p2, Preguntas p3, Preguntas p4, Preguntas p5, Preguntas p6, Preguntas p7, Preguntas p8, Preguntas p9, Preguntas p10, Preguntas p11, Preguntas p12, Preguntas p13, Preguntas p14, Preguntas p15, Preguntas p16, Preguntas p17, Preguntas p18, Preguntas p19, Preguntas p20, Preguntas p21, Preguntas p22, Preguntas p23, Preguntas p24, Preguntas p25, Preguntas p26, Preguntas p27, Preguntas p28, Preguntas p29, Preguntas p30)
        {
            bateria2 = new Preguntas[30];
            bateria2[0] = p1;
            bateria2[1] = p2;
            bateria2[2] = p3;
            bateria2[3] = p4;
            bateria2[4] = p5;
            bateria2[5] = p6;
            bateria2[6] = p7;
            bateria2[7] = p8;
            bateria2[8] = p9;
            bateria2[9] = p10;

            bateria2[10] = p11;
            bateria2[11] = p12;
            bateria2[12] = p13;
            bateria2[13] = p14;
            bateria2[14] = p15;
            bateria2[15] = p16;
            bateria2[16] = p17;
            bateria2[17] = p18;
            bateria2[18] = p19;

            bateria2[19] = p20;
            bateria2[20] = p21;
            bateria2[21] = p22;
            bateria2[22] = p23;
            bateria2[23] = p24;
            bateria2[24] = p25;
            bateria2[25] = p26;
            bateria2[26] = p27;
            bateria2[27] = p28;
            bateria2[28] = p29;
            bateria2[29] = p30;
        }
        internal Preguntas[] Bateria2 { get => bateria2; set => bateria2 = value; }
    }
}