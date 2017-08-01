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
using System.Windows.Shapes;
using System.Drawing;
namespace Roboty_v3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        delegate void set_label_delegate(string data);
        delegate void set_key_delegate(int key, bool keystatus);
        delegate void set_battery_delegate(int battery);
        delegate void set_connection_delegate(bool status);
        delegate void set_sensor_delegate(int s1, int s2, int s3, int s4, int s5);

        set_label_delegate lab_del;
        object LD_obj;
        set_key_delegate key_del;
        object[] KD_obj;
        set_battery_delegate bat_del;
        object BD_obj;
        set_connection_delegate con_del;
        object CD_obj;
        set_sensor_delegate sen_del;
        object[] SD_obj;

        BitmapImage Aup_True, Aup_False, Adown_True, Adown_False, Aleft_True, Aleft_False, Aright_True, Aright_False;
        BitmapImage B5, B4, B3, B2, B1, B0, BN;
        BitmapImage Connected, Disconnected;
        
        Color G1,G2,G3,Y1,Y2,Y3,R1;

        bool status, gd, rd;
        int V_max, bat;


        
        public Window1(string IP,int Port)
        {
            Aup_True = new BitmapImage();
            Aup_True.BeginInit();
            Aup_True.UriSource = new Uri("grafika/aup_active.jpg", UriKind.Relative);
            Aup_True.EndInit();
            Aup_False = new BitmapImage();
            Aup_False.BeginInit();
            Aup_False.UriSource = new Uri("grafika/aup.jpg", UriKind.Relative);
            Aup_False.EndInit();
            Adown_True = new BitmapImage();
            Adown_True.BeginInit();
            Adown_True.UriSource = new Uri("grafika/adown_active.jpg", UriKind.Relative);
            Adown_True.EndInit();
            Adown_False = new BitmapImage();
            Adown_False.BeginInit();
            Adown_False.UriSource = new Uri("grafika/adown.jpg", UriKind.Relative);
            Adown_False.EndInit();
            Aleft_True = new BitmapImage();
            Aleft_True.BeginInit();
            Aleft_True.UriSource = new Uri("grafika/al_active.jpg", UriKind.Relative);
            Aleft_True.EndInit();
            Aleft_False = new BitmapImage();
            Aleft_False.BeginInit();
            Aleft_False.UriSource = new Uri("grafika/al.jpg", UriKind.Relative);
            Aleft_False.EndInit();
            Aright_True = new BitmapImage();
            Aright_True.BeginInit();
            Aright_True.UriSource = new Uri("grafika/ar_active.jpg", UriKind.Relative);
            Aright_True.EndInit();
            Aright_False = new BitmapImage();
            Aright_False.BeginInit();
            Aright_False.UriSource = new Uri("grafika/ar.jpg", UriKind.Relative);
            Aright_False.EndInit();

            B5 = new BitmapImage();
            B5.BeginInit();
            B5.UriSource = new Uri("grafika/b5.jpg", UriKind.Relative);
            B5.EndInit();
            B4 = new BitmapImage();
            B4.BeginInit();
            B4.UriSource = new Uri("grafika/b4.jpg", UriKind.Relative);
            B4.EndInit();
            B3 = new BitmapImage();
            B3.BeginInit();
            B3.UriSource = new Uri("grafika/b3.jpg", UriKind.Relative);
            B3.EndInit();
            B2 = new BitmapImage();
            B2.BeginInit();
            B2.UriSource = new Uri("grafika/b2.jpg", UriKind.Relative);
            B2.EndInit();
            B1 = new BitmapImage();
            B1.BeginInit();
            B1.UriSource = new Uri("grafika/b1.jpg", UriKind.Relative);
            B1.EndInit();
            B0 = new BitmapImage();
            B0.BeginInit();
            B0.UriSource = new Uri("grafika/b0.jpg", UriKind.Relative);
            B0.EndInit();
            BN = new BitmapImage();
            BN.BeginInit();
            BN.UriSource = new Uri("grafika/bn.jpg", UriKind.Relative);
            BN.EndInit();

            Connected = new BitmapImage();
            Connected.BeginInit();
            Connected.UriSource = new Uri("grafika/connected.jpg", UriKind.Relative);
            Connected.EndInit();

            Disconnected = new BitmapImage();
            Disconnected.BeginInit();
            Disconnected.UriSource = new Uri("grafika/disconnected.jpg", UriKind.Relative);
            Disconnected.EndInit();

            G1 = new Color();
            G1 = Color.FromRgb(66, 245, 13);
            G2 = new Color();
            G2 = Color.FromRgb(97, 245, 13);
            G3 = new Color();
            G3 = Color.FromRgb(182, 245, 13);
            Y1 = new Color();
            Y1 = Color.FromRgb(213, 245, 13);
            Y2 = new Color();
            Y2 = Color.FromRgb(245, 213, 13);
            Y3 = new Color();
            Y3 = Color.FromRgb(245, 130, 13);
            R1 = new Color();
            R1 = Color.FromRgb(245, 45, 13);

            LD_obj = new object();
            KD_obj = new object[2];
            BD_obj = new object();
            CD_obj = new object();
            SD_obj = new object[5];
            
            key_del = set_key;
            bat_del = set_battery_img;
            con_del = set_connection_status;
            sen_del = set_sensors;
            status = true;

            InitializeComponent();

            info_Label.Content = IP + ": " + Port.ToString();
            V_Max_Value_Label.Content = "30";
            V_Max_Slider.Value =V_max= 30;

            if (IP == "192.168.2.30") Window_Look.Title = "Robot 0";
            if (IP == "192.168.2.31") Window_Look.Title = "Robot 1";
            if (IP == "192.168.2.32") Window_Look.Title = "Robot 2";
            if (IP == "192.168.2.33") Window_Look.Title = "Robot 3";
            if (IP == "192.168.2.34") Window_Look.Title = "Robot 4";
            
        }

        public int get_vmax()
        {
            return V_max;
        }

        public bool getstatus()
        {
            return status;
        }

        public bool get_gd()
        {
            return gd;
        }

        public bool get_rd()
        {
            return rd;
        }

        public void set_key(int key, bool keystatus)
        {
            if (Aup_Img.Dispatcher.CheckAccess())
            {
                if (key == 0)
                {
                    if (keystatus == true)
                    {
                        Aup_Img.Source = Aup_True;

                        if (Adown_Img.Source != Adown_True)
                        {
                            Right_Motor_PB.Value = V_Max_Slider.Value;
                            Left_Motor_PB.Value = V_Max_Slider.Value;
                        }
                        else
                        {
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                    }
                    else
                    {
                        Aup_Img.Source = Aup_False;

                        if (Adown_Img.Source == Adown_True)
                        {
                            Right_Motor_PB.Value = V_Max_Slider.Value;
                            Left_Motor_PB.Value = V_Max_Slider.Value;
                        }
                        else
                        { 
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                    }
                    
                }
                if (key == 1)
                {
                    if (keystatus == true)
                    {
                        Adown_Img.Source = Adown_True;
                        if(Aup_Img.Source == Aup_True)
                        {
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                        else
                        {
                            Right_Motor_PB.Value = V_Max_Slider.Value;
                            Left_Motor_PB.Value = V_Max_Slider.Value;
                        }
                    }
                    else
                    {
                        Adown_Img.Source = Adown_False;
                        if (Aup_Img.Source == Aup_True)
                        {
                            Right_Motor_PB.Value = V_Max_Slider.Value;
                            Left_Motor_PB.Value = V_Max_Slider.Value;
                        }
                        else
                        {
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                    }
                }
                if (key == 2)
                {
                    if (keystatus == true)
                    {
                        Aleft_Img.Source = Aleft_True;

                        if (Aup_Img.Source == Aup_True && Adown_Img.Source == Adown_False)
                        {
                            Left_Motor_PB.Value = Math.Abs(Left_Motor_PB.Value - 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_True)
                        {
                            Left_Motor_PB.Value = Math.Abs(Left_Motor_PB.Value - 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = 15;
                            Left_Motor_PB.Value = 15;
                        }

                    }
                    else
                    {
                        Aleft_Img.Source = Aleft_False;


                        if (Aup_Img.Source == Aup_True && Adown_Img.Source == Adown_False)
                        {
                            Left_Motor_PB.Value = Math.Abs(Left_Motor_PB.Value + 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_True)
                        {
                            Left_Motor_PB.Value = Math.Abs(Left_Motor_PB.Value + 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                    }
                }
                if (key == 3)
                {
                    if (keystatus == true)
                    {
                        Aright_Img.Source = Aright_True;

                        if (Aup_Img.Source == Aup_True && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = Math.Abs(Right_Motor_PB.Value - 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_True)
                        {
                            Right_Motor_PB.Value = Math.Abs(Right_Motor_PB.Value - 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = 15;
                            Left_Motor_PB.Value = 15;
                        }
                    }
                    else
                    {
                        Aright_Img.Source = Aright_False;

                        if (Aup_Img.Source == Aup_True && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = Math.Abs(Right_Motor_PB.Value + 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_True)
                        {
                            Right_Motor_PB.Value = Math.Abs(Right_Motor_PB.Value + 30);
                        }

                        if (Aup_Img.Source == Aup_False && Adown_Img.Source == Adown_False)
                        {
                            Right_Motor_PB.Value = 0;
                            Left_Motor_PB.Value = 0;
                        }
                    }
                }
            }
            else
            {
                KD_obj[0] = key;
                KD_obj[1] = keystatus;

                Aup_Img.Dispatcher.BeginInvoke(key_del, KD_obj);
            }

        }

        public void set_battery_img(int battery)
        {
            if (Aup_Img.Dispatcher.CheckAccess())
            {
                if (battery >= 4900 && bat != 5)
                {
                    Battery_Img.Source = B5;
                    bat = 5;
                }

                else if (battery >= 4750 && battery < 4850 && bat != 4)
                {
                    Battery_Img.Source = B4;
                    bat = 4;
                }

                else if (battery >= 4600 && battery < 4750 && bat != 3)
                {
                    Battery_Img.Source = B3;
                    bat = 3;
                }

                else if (battery >= 4450 && battery < 4600 && bat != 2)
                {
                    Battery_Img.Source = B2;
                    bat = 2;
                }

                else if (battery >= 4300 && battery < 4450 && bat != 1)
                {
                    Battery_Img.Source = B1;
                    bat = 1;
                }

                else if (battery < 4300 && battery > 3000 && bat != 0)
                {
                    Battery_Img.Source = B0;
                    bat = 0;
                }

                else if (battery < 3000 && bat != -1)
                {
                    Battery_Img.Source = BN;
                    bat = -1;
                }
            }
            else
            {
                BD_obj = battery;

                Aup_Img.Dispatcher.BeginInvoke(bat_del, BD_obj);

            }
        }

        public void set_connection_status(bool status)
        {
            if (Cennection_Img.Dispatcher.CheckAccess())
            {
                if (status==true)
                {
                    Cennection_Img.Source = Connected;
                }
                else
                {
                    Cennection_Img.Source = Disconnected;
                    Battery_Img.Source = BN;
                    bat = -1;
                }
            }
            else
            {
                CD_obj = status;
                Cennection_Img.Dispatcher.BeginInvoke(con_del, CD_obj);
            }
        }

        public void set_sensors(int s1, int s2, int s3, int s4, int s5)
        {
            if (Sensor1_PG.Dispatcher.CheckAccess())
            {
                Sensor1_PG.Value = s1;
                Sensor2_PG.Value = s2;
                Sensor3_PG.Value = s3;
                Sensor4_PG.Value = s4;
                Sensor5_PG.Value = s5;
            }
            else
            {
                SD_obj[0] = s1;
                SD_obj[1] = s2;
                SD_obj[2] = s3;
                SD_obj[3] = s4;
                SD_obj[4] = s5;

                Sensor1_PG.Dispatcher.BeginInvoke(sen_del, SD_obj);
            }
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            status = false;
        }


        private void V_Max_Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (V_Max_Slider.Value <= 40)
            {
                V_Max_Slider.Background = new SolidColorBrush(G1);
            }
            if (V_Max_Slider.Value > 40 && V_Max_Slider.Value <=50)
            {
                V_Max_Slider.Background = new SolidColorBrush(G2);
            }
            if (V_Max_Slider.Value > 50 && V_Max_Slider.Value <= 60)
            {
                V_Max_Slider.Background = new SolidColorBrush(G3);
            }
            if (V_Max_Slider.Value > 60 && V_Max_Slider.Value <= 70)
            {
                V_Max_Slider.Background = new SolidColorBrush(Y1);
            }
            if (V_Max_Slider.Value > 70 && V_Max_Slider.Value <= 80)
            {
                V_Max_Slider.Background = new SolidColorBrush(Y2);
            }
            if (V_Max_Slider.Value > 80 && V_Max_Slider.Value <= 90)
            {
                V_Max_Slider.Background = new SolidColorBrush(Y3);
            }
            if (V_Max_Slider.Value > 90)
            {
                V_Max_Slider.Background = new SolidColorBrush(R1);
            }

            V_Max_Value_Label.Content = ((int)V_Max_Slider.Value).ToString();
            V_max = (int)V_Max_Slider.Value;
        }

        private void Red_D_CheckB_Checked(object sender, RoutedEventArgs e)
        {
            rd = true;
        }

        private void Red_D_CheckB_Unchecked(object sender, RoutedEventArgs e)
        {
            rd = false;        
        }

        private void Green_D_CheckB_Unchecked(object sender, RoutedEventArgs e)
        {
            gd = false;
        }

        private void Green_D_CheckB_Checked(object sender, RoutedEventArgs e)
        {
            gd = true;
        }

        private void Red_D_Img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (rd == true)
            {
                rd = false;
                Red_D_CheckB.IsChecked = false;
            }
            else
            {
                rd = true;
                Red_D_CheckB.IsChecked = true;
            }
        }

        private void Green_D_Img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (gd == true)
            {
                gd = false;
                Green_D_CheckB.IsChecked = false;
            }
            else
            {
                gd = true;
                Green_D_CheckB.IsChecked = true;
            }

        }
        
    }
}
