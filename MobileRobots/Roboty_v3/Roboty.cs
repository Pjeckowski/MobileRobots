using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Roboty_v3
{
    class Roboty
    {
        Window1 Robot_Window;
        Thread Robot_Thread;
        string IP;
        int Port;
        bool status;
        bool aup, adown, aleft, aright,connected;
        Communication Communi;
        Calculations Calc;
        string Received;
        string Message;
       
        public  Roboty(string IP, int Port)
        {
            Calc = new Calculations();
            Communi = new Communication();
            this.IP=IP;
            this.Port=Port;
            status = true;
            Robot_Window = new Window1(IP, Port);
            Robot_Window.Show();
            Robot_Thread = new Thread(new ThreadStart(robot_tm));
            Robot_Thread.SetApartmentState(ApartmentState.STA);
            Robot_Thread.Start();
            
        }
        public void clean_up()
        {
            Robot_Window.Close();
        }
        public bool getstatus()
        {
            return status;
        }

        public void robot_tm()
        {
            while (Robot_Window.getstatus() == true)
            {
               
                if (connected == false)
                {
                    if (Communi.set_connection(IP, Port) == true)
                    {
                        connected = true;
                        Robot_Window.set_connection_status(true);
                    }
                        
                }
                if (connected == true)
                {
                    Message = Calc.get_message(0, 0, aup, adown, aleft, aright, Robot_Window.get_vmax(), Robot_Window.get_rd(), Robot_Window.get_gd());
                    if (Communi.send(Message) == false)
                    {
                        connected = false;
                        Robot_Window.set_connection_status(false);
                    }
                }
                Thread.Sleep(70);
                if (connected == true)
                {
                    Received=Communi.receive();
                    if (Received == "Fail")
                    {
                        connected = false;
                        Robot_Window.set_connection_status(false);
                    }
                    else
                    {
                        Console.WriteLine(Received);
                        Robot_Window.set_battery_img(Int32.Parse(Received.Substring(5, 2) + Received.Substring(3, 2), System.Globalization.NumberStyles.HexNumber));
                        Robot_Window.set_sensors(Int32.Parse(Received.Substring(9,2)+Received.Substring(7,2),System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(Received.Substring(9, 2) + Received.Substring(7, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(Received.Substring(13, 2) + Received.Substring(11, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(Received.Substring(17, 2) + Received.Substring(15, 2), System.Globalization.NumberStyles.HexNumber),
                            Int32.Parse(Received.Substring(21, 2) + Received.Substring(19, 2), System.Globalization.NumberStyles.HexNumber));
                    }
                }
                Thread.Sleep(70);                
                Console.WriteLine("Dzialam");
            }

            Communi.clear_client_obj();
            Console.WriteLine("PAPA");
            status = false;
        }

        public void set_key(int key, bool keystatus)
        {
            Robot_Window.set_key(key, keystatus);
            if (key == 0)
                if (keystatus) aup = true;
                else aup = false;
            if (key == 1)
                if (keystatus) adown = true;
                else adown = false;
            if (key == 2)
                if (keystatus) aleft = true;
                else aleft = false;
            if (key == 3)
                if (keystatus) aright = true;
                else aright = false;        
        }
 
    }
}
