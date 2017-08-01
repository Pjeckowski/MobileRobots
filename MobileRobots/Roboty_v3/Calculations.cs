using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboty_v3
{
    class Calculations
    {
        int[] tab;
        string Value_s,pom_s;
        int  pom, pom1, i;

        public Calculations()
        {
            tab = new int[8];
        }


        public string get_message(int l_eng,int r_eng,bool aup, bool adown,bool aleft, bool aright,int P_MAX,bool rd,bool gd)//no i korekty
        {

            l_eng = 0;
            r_eng= 0;
            
            if (aup == true && adown == false)
            {
                    l_eng = P_MAX;
                    r_eng = P_MAX;
            }

            if (aup == false && adown == true )
            {
                l_eng = -P_MAX;
                r_eng = -P_MAX;
            }

            if (aleft == true && aright == false)
            {
                if (l_eng == 0 && r_eng == 0)
                {
                    l_eng = -15;
                    r_eng = 15;
                }

                if (l_eng > 0 && r_eng > 0)
                {
                    l_eng -=30 ;
                }
                if (l_eng < 0 && r_eng < 0)
                {
                    l_eng += 30;
                }
            }

            if (aleft == false && aright == true)
            {
                if (l_eng == 0 && r_eng == 0)
                {
                    l_eng = 15;
                    r_eng = -15;
                }

                if (l_eng > 0 && r_eng > 0)
                {
                    r_eng -= 30;
                }
                if (l_eng < 0 && r_eng < 0)
                {
                    r_eng += 30;
                }
            }

            if (rd == true && gd == true)
            {
                return "[03" + Dec2Hex(l_eng) + Dec2Hex(r_eng) + "]";
            }
            else if (rd == true && gd == false)
            {
                return "[02" + Dec2Hex(l_eng) + Dec2Hex(r_eng) + "]";
            }
            else if (rd == false && gd == true)
            {
                return "[01" + Dec2Hex(l_eng) + Dec2Hex(r_eng) + "]";
            }
            else
            {
                return "[00" + Dec2Hex(l_eng) + Dec2Hex(r_eng) + "]";
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Dec2Hex(int value)
        {
            pom = pom1 = 0;

            if (value < 0)
            {
                tab[7] = 1;
                pom = 128 + value;
                for (i = 0; i <= 6; i++) tab[i] = 0;
                i = 0;
                while (pom != 0)
                {
                    if (pom % 2 == 0) tab[i] = 0;
                    else tab[i] = 1;
                    pom = pom / 2;
                    i++;
                }
            }

            if (value >= 0)
            {
                tab[7] = 0;
                for (i = 0; i <= 6; i++) tab[i] = 0;
                i = 0;
                pom = value;
                while (pom != 0)
                {
                    if (pom % 2 == 0) tab[i] = 0;
                    else tab[i] = 1;
                    pom = pom / 2;
                    i++;
                }
            }

            for (i = 0; i <= 3; i++)
            {
                pom += (int)(tab[i] * Math.Pow(2, i));
                pom1 += (int)(tab[i + 4] * Math.Pow(2, i));
            }

            switch (pom)
            {
                case 15:
                    {
                        Value_s = "F";
                        break;
                    }
                case 14:
                    {
                        Value_s = "E";
                        break;
                    }
                case 13:
                    {
                        Value_s = "D";
                        break;
                    }
                case 12:
                    {
                        Value_s = "C";
                        break;
                    }
                case 11:
                    {
                        Value_s = "B";
                        break;
                    }
                case 10:
                    {
                        Value_s = "A";
                        break;
                    }
                default:
                    {
                        Value_s = pom.ToString();
                        break;
                    }
            }
            switch (pom1)
            {
                case 15:
                    {
                        pom_s = "F";
                        break;
                    }
                case 14:
                    {
                        pom_s = "E";
                        break;
                    }
                case 13:
                    {
                        pom_s = "D";
                        break;
                    }
                case 12:
                    {
                        pom_s = "C";
                        break;
                    }
                case 11:
                    {
                        pom_s = "B";
                        break;
                    }
                case 10:
                    {
                        pom_s = "A";
                        break;
                    }
                default:
                    {
                        pom_s = pom1.ToString();
                        break;
                    }
            }
            return (pom_s + Value_s);
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   

       

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    }


}
