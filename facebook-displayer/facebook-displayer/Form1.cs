using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using System.IO.Ports;

namespace facebook_displayer
{
    public partial class Facebook_displayer : Form
    {
        /* ----------------------------------------------- */
        /* -- DEKLARACJA ZMIENNYCH POMOCNICZYCH -- */
        public bool wyslano_calosc = false;
        public bool jest_nowe = true;
        public bool pom = false;
        public string user_info = "";
        public string caly_tekst = "";
        public string nowy_tekst = "";
        public string tekst;
        public double i = 0;
        public bool auto_login = false;
        string access_token;
        /* !! DEKLARACJA ZMIENNYCH POMOCNICZYCH !! */
        /* ----------------------------------------------- */


        /* ----------------------------------------------- */
        /* -- METODY ZWIĄZANE Z GŁÓWNYM OKNEM APLIKACJI -- */
        public Facebook_displayer() //Konstruktor klasy
        {
            WebBrowser WebFacebook = new WebBrowser();
            serialPort1 = new SerialPort();
            InitializeComponent();
        }

        private void Facebook_Displayer_Load(object sender, EventArgs e) //Wykonanywane po załadowaniu okna aplikacji
        {
            getAvailablePorts();
        }

        private void Facebook_displayer_FormClosing(object sender, FormClosingEventArgs e) //Wykonane po zamknięciu aplikacji
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        public void getAvailablePorts() //funkcja pobierająca aktualnie podłączone porty
        {
            box_port_names.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            box_port_names.Items.AddRange(ports);
        }
        /* !! METODY ZWIĄZANE Z GŁÓWNYM OKNEM APLIKACJI !! */
        /* ----------------------------------------------- */


        /* ----------------------------------------------- */
        /* -- ZAKŁADKA - LOGOWANIE -- */
        private void btnSignIn_Click(object sender, EventArgs e) //przycisk łączący z serwerem http facebooka
        {
            string OAuthURL = @"https://www.facebook.com/dialog/oauth?client_id=1373520086004317&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&scope=user_birthday,user_likes,user_hometown,user_location,user_events";
            WebFacebook.Navigate(OAuthURL);
        }

        private void btn_autoSignIn_Click(object sender, EventArgs e)
        {
            string OAuthURL = @"https://www.facebook.com/dialog/oauth?client_id=1373520086004317&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&scope=user_birthday,user_likes,user_hometown,user_location,user_events";
            auto_login = true;
            WebFacebook.Navigate(OAuthURL);

        }
        private void WebFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) //funkcja pobierająca token uzytkownika
        {
            if (WebFacebook.Url.AbsoluteUri.Contains("access_token"))
            {
                string url1 = WebFacebook.Url.AbsoluteUri;
                string url2 = url1.Substring(url1.IndexOf("access_token") + 13);
                access_token = url2.Substring(0, url2.IndexOf("&"));

                FacebookClient fb = new FacebookClient(access_token);
                dynamic data = fb.Get("me?fields=name,birthday,education,gender,email");
                if (auto_login == false) MessageBox.Show("Zalogowano jako " + data.name + ", ur. " + data.birthday);
                user_info = "usr=" + data.name + "$" + "dat=" + data.birthday + "$";
                btn_Get_List.Enabled = true;
                btnSignIn.Enabled = false;
                btn_autoSignIn.Enabled = false;
                btnClear.Enabled = true;

                if (auto_login == true) 
                {
                    btn_Get_List_Click(sender, e);
                    btn_auto_wysylanie.Text = "On";
                    btn_open_port_Click(sender, e);
                }
            }

        }
        /* !! ZAKŁADKA - LOGOWANIE !! */
        /* ----------------------------------------------- */


        /* -- ZAKŁADKA - LISTA POWIADOMIEŃ -- */
        /* ----------------------------------------------- */
        private void btn_Get_List_Click(object sender, EventArgs e) //pobieranie listy z facebooka
        {
            try
            {
                /*--------POBIERANIE POWIADOMIEŃ--------*/ //
                timer1.Start();
                string token_auto = txtBoxToken.Text;
                if (token_auto == "") { MessageBox.Show("Nieprawidłowy Access Token!"); this.Close(); }
                FacebookClient fb = new FacebookClient(token_auto);
                dynamic user_notifications = fb.Get("/me/notifications");
                int likes_count = (int)user_notifications.data.Count;

                if (likes_count > 5) likes_count = 5; //ogranieczenie komunikatów do 5


                caly_tekst = "";
                lstNotificationList.Items.Clear();
                btn_wyslij_liste.Enabled = true;


                if (wyslano_calosc == false)
                {
                    for (int i = 0; i < likes_count; i++)
                    {
                        caly_tekst += "msg=" + user_notifications.data[i].title + "$";
                        string notification_name = user_notifications.data[i].title;
                        string notification_date = user_notifications.data[i].created_time;
                        lstNotificationList.Items.Add("[" + notification_date + "] " + notification_name);
                    }

                    caly_tekst += user_info;
                    caly_tekst = sprawdz_znak(caly_tekst);
                    txtBox1.Text = caly_tekst;
                    nowy_tekst = "msg=" + user_notifications.data[0].title + "$";
                    nowy_tekst = sprawdz_znak(nowy_tekst);
                    wyslano_calosc = true;
                }
                else if (wyslano_calosc == true)
                {

                    for (int i = 0; i < likes_count; i++)
                    {
                        caly_tekst += "msg=" + user_notifications.data[i].title + "$";
                        string notification_name = user_notifications.data[i].title;
                        string notification_date = user_notifications.data[i].created_time;
                        lstNotificationList.Items.Add("[" + notification_date + "] " + notification_name);
                    }
                    caly_tekst += user_info;
                    caly_tekst = sprawdz_znak(caly_tekst);
                    txtBox1.Text = caly_tekst;
                    string do_sprawdzania = "msg=" + user_notifications.data[0].title + "$";

                    do_sprawdzania = sprawdz_znak(do_sprawdzania);
                    nowy_tekst = sprawdz_znak(nowy_tekst);
                    if (nowy_tekst != do_sprawdzania)
                    {
                        jest_nowe = true;
                        pom = true;
                        nowy_tekst = "msg=" + user_notifications.data[0].title + "$";


                        nowy_tekst = sprawdz_znak(nowy_tekst);
                    }

                }
                /*--------------------------------------------------------------*/
            }
            catch (UnauthorizedAccessException)
            {
                txtBox1.Clear();
                txtBox1.Text = "UnauthorizedAccessException";
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lstNotificationList.Items.Clear();
            timer1.Stop();
        }
        /* !! ZAKŁADKA - LISTA POWIADOMIEŃ !! */
        /* ----------------------------------------------- */


        /* -- ZAKŁADKA - SERIAL PORT -- */
        /* ----------------------------------------------- */
        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_Get_List_Click(sender, e);

            if (serialPort1.IsOpen)
            {
                if (btn_auto_wysylanie.Text == "On" && btn_wyslij_liste.Enabled == true)
                {
                    btn_send_list_Click(sender, e);
                }
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen == true)
                {
                    if (box_sended_data.Text != "")
                    {
                        serialPort1.WriteLine(box_sended_data.Text);
                        tekst = box_sended_data.Text;
                        box_sended_data.Clear();
                    }
                }
                else
                {
                    box_sended_data.Text = "Port jest zamkniety!";
                }
            }
            catch (TimeoutException)
            {
                box_received_data.Text = "Timeout Exception";
            }
        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen == true)
                {
                    box_received_data.Text = serialPort1.ReadExisting();
                }
                else
                {
                    box_received_data.Text = "Port jest zamkniety!";
                }
            }
            catch (TimeoutException)
            {
                box_received_data.Text = "Timeout Exception";
            }
        }

        private void btn_open_port_Click(object sender, EventArgs e)
        {
            try
            {
                if (auto_login == true)           // | 
                {                                 // | auto wybranie portu
                    box_port_names.Text = "COM4"; // | 
                    box_baud_rate.Text = "115200";// |
                }
                if (box_port_names.Text == "" || box_baud_rate.Text == "")
                {
                    box_received_data.Text = "Wybierz port";
                }
                else
                {
                    box_sended_data.Text = "";
                    if (caly_tekst != "")
                    {
                        btn_wyslij_liste.Enabled = true;
                    }
                    else if (caly_tekst == "")
                    {
                        btn_wyslij_liste.Enabled = false;
                    }
                    serialPort1.PortName = box_port_names.Text;
                    serialPort1.BaudRate = Convert.ToInt32(box_baud_rate.Text);
                    serialPort1.Open();
                    progressBar1.Value = 100;
                    btn_send.Enabled = true;
                    btn_read.Enabled = true;
                    box_sended_data.Enabled = true;
                    btn_open_port.Enabled = false;
                    btn_close_port.Enabled = true;
                    box_received_data.Clear();
                }
            }
            catch (UnauthorizedAccessException)
            {
                box_received_data.Text = "Unauthorized Access Exception";
            }
        }

        private void btn_close_port_Click(object sender, EventArgs e)
        {
            tekst = "";
            serialPort1.Close();
            progressBar1.Value = 0;
            btn_send.Enabled = false;
            btn_read.Enabled = false;
            btn_close_port.Enabled = false;
            btn_open_port.Enabled = true;
            box_sended_data.Enabled = false;
            btn_wyslij_liste.Enabled = false;
            box_received_data.Clear();
            box_sended_data.Clear();
        }

        private void btn_send_list_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen == true)
                {
                    btn_wyslij_liste.Enabled = true;
                    if (jest_nowe == true)
                    {
                        if (pom == false)
                        {
                            caly_tekst = sprawdz_znak(caly_tekst); 
                            serialPort1.WriteLine(caly_tekst);
                            caly_tekst = sprawdz_znak(caly_tekst);
                            tekst = caly_tekst;
                        }
                        else if (pom == true)
                        {
                            nowy_tekst = sprawdz_znak(nowy_tekst);
                            serialPort1.WriteLine(nowy_tekst);
                            nowy_tekst = sprawdz_znak(nowy_tekst);
                            tekst = nowy_tekst;

                        }
                        jest_nowe = false;
                        btn_read_Click(sender, e);
                    }
                }
                else
                {
                    box_sended_data.Text = "Port jest zamkniety!";
                }
            }
            catch (TimeoutException)
            {
                box_received_data.Text = "Timeout Exception";
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            getAvailablePorts();
        }

        private void btn_auto_send(object sender, EventArgs e)
        {
            if (btn_auto_wysylanie.Text == "On")
            {
                btn_auto_wysylanie.Text = "Off";
            }
            else if (btn_auto_wysylanie.Text == "Off")
            {
                btn_auto_wysylanie.Text = "On";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        /* !! ZAKŁADKA - SERIAL PORT !! */
        /* ----------------------------------------------- */

        public string sprawdz_znak(string data) //sprawdza czy string zawiera polskie znaki
        {
            data = data.Replace('ą', 'a').Replace('Ą', 'A');
            data = data.Replace('ć', 'c').Replace('Ć', 'C');
            data = data.Replace('Ę', 'E').Replace('ę', 'e');
            data = data.Replace('Ł', 'L').Replace('ł', 'l');
            data = data.Replace('Ń', 'N').Replace('ń', 'n');
            data = data.Replace('Ó', 'O').Replace('ó', 'o');
            data = data.Replace('Ś', 'S').Replace('ś', 's');
            data = data.Replace('Ż', 'Z').Replace('ż', 'z');
            data = data.Replace('Ź', 'Z').Replace('ź', 'z');
            return data;

        }

    }
}
