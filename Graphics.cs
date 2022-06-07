using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoAhorcado
{
    internal class Graphics
    {
        public string Gallow()
        {
            string onlyGallow = "";
            string spaces = new string(' ',8);
            string woodGallow = new string('▄', 17);
            string rope = "║";
            onlyGallow = woodGallow+"\n"+spaces+rope;
            return onlyGallow;
        }

        public string Head()
        {
            string spaces = new string(' ', 6);
            string onlyHead = "";
            onlyHead = Gallow() + "\n";
            onlyHead += spaces + "/¯¯¯\\"+"\n";
            onlyHead += spaces + "│º º│\n";
            onlyHead += spaces + "│ - │\n";
            onlyHead += spaces + "└───┘\n";

            return onlyHead;
        }

        public string HeadHanged()
        {
            string spaces = new string(' ', 6);
            string onlyHeadHanged = "";
            onlyHeadHanged =  spaces + "/¯¯¯\\" + "\n";
            onlyHeadHanged += spaces + "│+ +│\n";
            onlyHeadHanged += spaces + "│ O │\n";
            onlyHeadHanged += spaces + "└───┘\n";

            return onlyHeadHanged;
        }

        public string Body()
        {
            string onlyBody = "";
            string spaces = new string(' ', 8);
            //onlyBody = Gallow() + "\n";
            onlyBody +=  Head();
            for (int i = 0; i < 5; i++)
            {
                onlyBody += spaces+"║\n";
            }
            //onlyBody = spaces + "║\n";
            return onlyBody;
        }

        public string LeftArm()
        {
            string onlyLeftArm = "";
            //onlyLeftArm = Gallow();
            onlyLeftArm += Head();
            
            string spaces = new string(' ', 4);
            onlyLeftArm += spaces + spaces + "║\n";
            onlyLeftArm += spaces + "════╣\n";
            for (int i = 0; i < 3; i++)
            {
                onlyLeftArm += spaces + spaces + "║\n";
            }
            
            return onlyLeftArm;
        }

        public string RightArm()
        {
            string onlyRigthArm = "";
            string spaces = new string(' ', 4);         
            onlyRigthArm += Head();            
            onlyRigthArm += spaces + spaces + "║\n";
            onlyRigthArm += spaces + "════╬════\n";
            for (int i = 0; i < 3; i++)
            {
                onlyRigthArm += spaces + spaces + "║\n";
            }

            return onlyRigthArm;
        }

        public string LeftLeg()
        {
            string onlyLeftLeg = "";
            string spaces = new string(' ', 4);
            onlyLeftLeg += Head();
            onlyLeftLeg += spaces + spaces + "║\n";
            onlyLeftLeg += spaces + "════╬════\n";
            for (int i = 0; i < 2; i++)
            {
                onlyLeftLeg += spaces + spaces + "║\n";
            }
            onlyLeftLeg += spaces + "   ╔╝\n";
            for (int i = 0; i < 4; i++)
            {
                onlyLeftLeg += spaces + "   ║\n";
            }
            return onlyLeftLeg;
        }

        public string RightLeg()
        {
            string onlyRightLeg = "";
            string spaces = new string(' ', 4);
            onlyRightLeg = Gallow();
            onlyRightLeg += "\n" + HeadHanged();
            onlyRightLeg += spaces + spaces + "║\n";
            onlyRightLeg += spaces + "════╬════\n";
            for (int i = 0; i < 2; i++)
            {
                onlyRightLeg += spaces + spaces + "║\n";
            }
            onlyRightLeg += spaces + "   ╔╩╗\n";
            for (int i = 0; i < 4; i++)
            {
                onlyRightLeg += spaces + "   ║ ║\n";
            }

            return onlyRightLeg;
        }

        public string Boxes(string palabra)
        {
            string box = "";
            string boxSup = "┌";
            string boxMiddle = "│";
            string boxInf = "└";
            int largo = palabra.Length;
            for (int i = 0; i < palabra.Length; i++)
            {
                if (i==palabra.Length-1)
                {
                    boxSup += "─┐\n";
                    boxMiddle += $"{palabra[i]}│\n";
                    boxInf += "─┘\n";
                }
                else
                {
                    boxSup += "─┬";
                    boxMiddle += $"{palabra[i]}│";
                    boxInf += "─┴";
                }                
            }
            box = boxSup + boxMiddle + boxInf;

            return box;
        }
        public string Gana()
        {
            string mensaje = "";
            mensaje  = "█ █  █████  ███  █   █  ███   █ █\n";            
            mensaje += "     █     █   █ ██  █ █   █  █ █\n";
            mensaje += "█ █  █ ███ █████ █ █ █ █   █  █ █\n";
            mensaje += "█ █  █   █ █   █ █  ██ █   █     \n";
            mensaje += "█ █  █████ █   █ █   █  ███   █ █\n";
            return mensaje;
        }

        public string Pierde()
        {
            string mensaje = "";            
            mensaje  = "████  █████ ████  ████  █  ███ \n";
            mensaje += "█   █ █     █   █ █   █ █ █   █\n";
            mensaje += "████  ████  ████  █   █ █ █   █\n";
            mensaje += "█     █     █  █  █   █ █ █   █\n";
            mensaje += "█     █████ █   █ ████  █  ███  █ █ █ \n";
            return mensaje;
        }
    }   //End class
}   // End namespace
