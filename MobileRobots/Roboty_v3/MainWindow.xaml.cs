using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Threading;       

namespace Roboty_v3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();


        Roboty Robot0,Robot1,Robot2,Robot3,Robot4;
        bool removed0, removed1, removed2, removed3, removed4;
        bool key_aleft, key_adown, key_aup, key_aright;
        bool key_w, key_a, key_s, key_d;
        bool key_t, key_f, key_g, key_h;
        bool key_i, key_j, key_k, key_l;
        bool key_8, key_4, key_5, key_6;

        public MainWindow()
        {

            AllocConsole();
            InitializeComponent();
            List_CB.Items.Add("Robot0");
            List_CB.Items.Add("Robot1");
            List_CB.Items.Add("Robot2");
            List_CB.Items.Add("Robot3");
            List_CB.Items.Add("Robot4");
   

        }



        private void Connect_But_Click(object sender, RoutedEventArgs e)
        {
            if (List_CB.SelectedItem == "Robot0")
            {
                Robot0 = new Roboty("192.168.2.30", 8000);
                List_CB.Items.Remove("Robot0");
                removed0 = true;
            }
            if (List_CB.SelectedItem == "Robot1")
            {
                Robot1 = new Roboty("192.168.2.31", 8000);
                List_CB.Items.Remove("Robot1");
                removed1 = true;
            }
            if (List_CB.SelectedItem == "Robot2")
            {
                Robot2 = new Roboty("192.168.2.32", 8000);
                List_CB.Items.Remove("Robot2");
                removed2 = true;
            }
            if (List_CB.SelectedItem == "Robot3")
            {
                Robot3 = new Roboty("192.168.2.33", 8000);
                List_CB.Items.Remove("Robot3");
                removed3 = true;
            }
            if (List_CB.SelectedItem == "Robot4")
            {
                Robot4 = new Roboty("192.168.2.34", 8000);
                List_CB.Items.Remove("Robot4");
                removed4 = true;
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Robot0.clean_up();

            }
            catch (Exception) { }
            try
            {
                Robot1.clean_up();
            }
            catch (Exception) { }
            try
            {
                Robot2.clean_up();
            }
            catch (Exception) { }
            try
            {
                Robot3.clean_up();
            }
            catch (Exception) { }
            try
            {
                Robot4.clean_up();
            }
            catch (Exception) { }
        }


        private void List_CB_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (removed0 == true)
            {
                if (Robot0.getstatus() == false)
                {
                    List_CB.Items.Add("Robot0");
                    removed0 = false;
                }
            }
            if (removed1 == true)
            {
                if (Robot1.getstatus() == false)
                {
                    List_CB.Items.Add("Robot1");
                    removed1 = false;
                }
            }
            if (removed2 == true)
            {
                if (Robot2.getstatus() == false)
                {
                    List_CB.Items.Add("Robot2");
                    removed2 = false;
                }
            }
            if (removed3 == true)
            {
                if (Robot3.getstatus() == false)
                {
                    List_CB.Items.Add("Robot3");
                    removed3 = false;
                }
            }
            if (removed4 == true)
            {
                if (Robot4.getstatus() == false)
                {
                    List_CB.Items.Add("Robot4");
                    removed4 = false;
                }
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && key_aleft == false)
            {
                key_aleft = true;
                try
                {
                    Robot0.set_key(2, key_aleft);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.Right && key_aright == false)
            {
                key_aright = true;
                try
                {
                    Robot0.set_key(3, key_aright);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.Up && key_aup == false)
            {
                key_aup = true;
                try
                {
                    Robot0.set_key(0, key_aup);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.Down && key_adown == false)
            {
                key_adown = true;
                try
                {
                    Robot0.set_key(1, key_adown);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------

            if (e.Key == Key.A && key_a == false)
            {
                key_a = true;
                try
                {
                    Robot1.set_key(2, key_a);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.D && key_d == false)
            {
                key_d = true;
                try
                {
                    Robot1.set_key(3, key_d);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.W && key_w == false)
            {
                key_w = true;
                try
                {
                    Robot1.set_key(0, key_w);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.S && key_s == false)
            {
                key_s = true;
                try
                {
                    Robot1.set_key(1, key_s);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------

            if (e.Key == Key.F && key_f == false)
            {
                key_f = true;
                try
                {
                    Robot2.set_key(2, key_f);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.H && key_h == false)
            {
                key_h = true;
                try
                {
                    Robot2.set_key(3, key_h);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.T && key_t == false)
            {
                key_t = true;
                try
                {
                    Robot2.set_key(0, key_t);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.G && key_g == false)
            {
                key_g = true;
                try
                {
                    Robot2.set_key(1, key_g);
                }
                catch (Exception) { }
            }

            ////-----------------------------------------------------------------------------------

            if (e.Key == Key.J && key_j == false)
            {
                key_j = true;
                try
                {
                    Robot3.set_key(2, key_j);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.L && key_l == false)
            {
                key_l = true;
                try
                {
                    Robot3.set_key(3, key_l);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.I && key_i == false)
            {
                key_i = true;
                try
                {
                    Robot3.set_key(0, key_i);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.K && key_k == false)
            {
                key_k = true;
                try
                {
                    Robot3.set_key(1, key_k);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------
            
            if (e.Key == Key.NumPad4 && key_4 == false)
            {
                key_4 = true;
                try
                {
                    Robot4.set_key(2, key_4);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.NumPad6 && key_6 == false)
            {
                key_6 = true;
                try
                {
                    Robot4.set_key(3, key_6);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.NumPad8 && key_8 == false)
            {
                key_8 = true;
                try
                {
                    Robot4.set_key(0, key_8);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.NumPad5 && key_5 == false)
            {
                key_5 = true;
                try
                {
                    Robot4.set_key(1, key_5);
                }
                catch (Exception) { }
            }
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Window_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left && key_aleft == true)
            {
                key_aleft = false;
                try
                {
                    Robot0.set_key(2, key_aleft);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.Right && key_aright == true)
            {
                key_aright = false;
                try
                {
                    Robot0.set_key(3, key_aright);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.Up && key_aup == true)
            {
                key_aup = false;
                try
                {
                    Robot0.set_key(0, key_aup);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.Down && key_adown == true)
            {
                key_adown = false;
                try
                {
                    Robot0.set_key(1, key_adown);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------

            if (e.Key == Key.A && key_a == true)
            {
                key_a = false;
                try
                {
                    Robot1.set_key(2, key_a);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.D && key_d == true)
            {
                key_d = false;
                
                try
                {
                    Robot1.set_key(3, key_d);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.W && key_w == true)
            {
                key_w = false;
                
                try
                {
                    Robot1.set_key(0, key_w);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.S && key_s == true)
            {
                key_s = false;
                
                try
                {
                    Robot1.set_key(1, key_s);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------
 
            if (e.Key == Key.F && key_f == true)
            {
                key_f = false;
                try
                {
                    Robot2.set_key(2, key_f);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.H && key_h == true)
            {
                key_h = false;
                try
                {
                    Robot2.set_key(3, key_h);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.T && key_t == true)
            {
                key_t = false;
                try
                {
                    Robot2.set_key(0, key_t);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.G && key_g == true)
            {
                key_g = false;
                try
                {
                    Robot2.set_key(1, key_g);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------

            if (e.Key == Key.J && key_j == true)
            {
                key_j = false;
                try
                {
                    Robot3.set_key(2, key_j);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.L && key_l == true)
            {
                key_l = false;
                try
                {
                    Robot3.set_key(3, key_l);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.I && key_i == true)
            {
                key_i = false;
                try
                {
                    Robot3.set_key(0, key_i);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.K && key_k == true)
            {
                key_k = false;
                try
                {
                    Robot3.set_key(1, key_k);
                }
                catch (Exception) { }
            }

            //-----------------------------------------------------------------------------------

            if (e.Key == Key.NumPad4 && key_4 == true)
            {
                key_4 = false;
                try
                {
                    Robot4.set_key(2, key_4);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.NumPad6 && key_6 == true)
            {
                key_6 = false;
                try
                {
                    Robot4.set_key(3, key_6);
                }
                catch (Exception) { }
            }

            if (e.Key == Key.NumPad8 && key_8 == true)
            {
                key_8 = false;
                try
                {
                    Robot4.set_key(0, key_8);
                }
                catch (Exception) { }
            }
            if (e.Key == Key.NumPad5 && key_5 == true)
            {
                key_5 = false;
                try
                {
                    Robot4.set_key(1, key_5);
                }
                catch (Exception) { }
            }

        }

        private void Help_But_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sterowanie:\r"+
                             "Robot0 - klawisze strzałek,\r"+
                             "Robot1 - WASD,\r"+
                             "Robot2 - TFGH,\r"+
                             "Robot3 - IJKL,\r"+
                             "Robot4 - Num 8456.\r"+
                             "Aby sterowanie było możliwe główne okno musi być zaznaczone.");
        }

        



    }
}
