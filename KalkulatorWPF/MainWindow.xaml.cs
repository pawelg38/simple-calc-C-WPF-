using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace KalkulatorWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<string> wyrazenie = new Queue<string>();
        Queue<string> historia = new Queue<string>();
        bool kolejnaLiczba2 = false;
        bool flagaWykonano = false;
        string dzialanie;
        double skladnik2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.BorderThickness = new Thickness(2);
            button.BorderBrush = Brushes.Red;
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                button.BorderThickness = new Thickness(0);
            }
            catch (Exception)
            {

            }
        }
        private void Button_Click_Num(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Num:");
            Button btn = (Button)sender;
            Debug.WriteLine("wcisnieto: " + btn.Content.ToString());
            //sprawdzamy czy zawartosc textBlock.Text == 0
            //jesli tak to czysc jego zawartosc
            if (textBlock1.Text == "0")
            {
                textBlock1.Text = "";
            }
            //chcemy podac kolejna liczbe
            //sprawdzam czy jest to rozpoczecie pisania kolejnej liczby
            //jesli tak to wyczysc pozostalosc po poprzedniej
            if (kolejnaLiczba2)
            {
                textBlock1.Text = "";
                kolejnaLiczba2 = false;
            }
            textBlock1.Text += btn.Content.ToString();
            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("obecna liczba: " + textBlock1.Text);
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
        }
        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Plus:");
            Debug.WriteLine(kolejnaLiczba2);
            //sprawdzamy czy kolejnaLiczba2 == false
            //jesli tak to nie oczekujemy kolejnej liczby, wiec wykonujemy obliczenia
            //jesli nie to czekamy na kolejna liczbe
            if (kolejnaLiczba2 == false)
            {
                //uzupelniam dane w kolejce oraz historii
                historia.Enqueue(textBlock1.Text);
                historia.Enqueue("+");
                textBlock0.Text = "";
                foreach (string item in historia)
                {
                    textBlock0.Text += item;
                }
                wyrazenie.Enqueue(textBlock1.Text);
                wyrazenie.Enqueue("+");
                //sprawdzamy czy rozmiar kolejki == 4
                //jesli tak to wykonaj mozliwe dzialanie i zwolnij kolejke
                if (wyrazenie.Count() == 4)
                {
                    Oblicz();
                    Debug.WriteLine("wrocilem do Button_Click_Plus");
                }
            }

            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            kolejnaLiczba2 = true;
        }
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Minus:");
            Debug.WriteLine(kolejnaLiczba2);
            //sprawdzamy czy kolejnaLiczba2 == false
            //jesli tak to nie oczekujemy kolejnej liczby, wiec wykonujemy obliczenia
            //jesli nie to czekamy na kolejna liczbe
            if (kolejnaLiczba2 == false)
            {
                //uzupelniam dane w kolejce oraz historii
                historia.Enqueue(textBlock1.Text);
                historia.Enqueue("-");
                textBlock0.Text = "";
                foreach (string item in historia)
                {
                    textBlock0.Text += item;
                }
                wyrazenie.Enqueue(textBlock1.Text);
                wyrazenie.Enqueue("-");
                //sprawdzamy czy rozmiar kolejki == 4
                //jesli tak to wykonaj mozliwe dzialanie i zwolnij kolejke
                if (wyrazenie.Count() == 4)
                {
                    Oblicz();
                    Debug.WriteLine("wrocilem do Button_Click_Minus");
                }
            }

            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            kolejnaLiczba2 = true;
        }
        private void Button_Click_Multi(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Multi:");
            Debug.WriteLine(kolejnaLiczba2);
            //sprawdzamy czy kolejnaLiczba2 == false
            //jesli tak to nie oczekujemy kolejnej liczby, wiec wykonujemy obliczenia
            //jesli nie to czekamy na kolejna liczbe
            if (kolejnaLiczba2 == false)
            {
                //uzupelniam dane w kolejce oraz historii
                historia.Enqueue(textBlock1.Text);
                historia.Enqueue("*");
                textBlock0.Text = "";
                foreach (string item in historia)
                {
                    textBlock0.Text += item;
                }
                wyrazenie.Enqueue(textBlock1.Text);
                wyrazenie.Enqueue("*");
                //sprawdzamy czy rozmiar kolejki == 4
                //jesli tak to wykonaj mozliwe dzialanie i zwolnij kolejke
                if (wyrazenie.Count() == 4)
                {
                    Oblicz();
                    Debug.WriteLine("wrocilem do Button_Click_Multi");
                }
            }

            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            kolejnaLiczba2 = true;
        }
        private void Button_Click_Div(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Div:");
            Debug.WriteLine(kolejnaLiczba2);
            //sprawdzamy czy kolejnaLiczba2 == false
            //jesli tak to nie oczekujemy kolejnej liczby, wiec wykonujemy obliczenia
            //jesli nie to czekamy na kolejna liczbe
            if (kolejnaLiczba2 == false)
            {
                //uzupelniam dane w kolejce oraz historii
                historia.Enqueue(textBlock1.Text);
                historia.Enqueue("/");
                textBlock0.Text = "";
                foreach (string item in historia)
                {
                    textBlock0.Text += item;
                }
                wyrazenie.Enqueue(textBlock1.Text);
                wyrazenie.Enqueue("/");
                //sprawdzamy czy rozmiar kolejki == 4
                //jesli tak to wykonaj mozliwe dzialanie i zwolnij kolejke
                if (wyrazenie.Count() == 4)
                {
                    Oblicz();
                    Debug.WriteLine("wrocilem do Button_Click_Div");
                }
            }

            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            kolejnaLiczba2 = true;
        }
        private void Oblicz()
        {
            Debug.WriteLine("Oblicz2:");
            //sprawdzam poprawnosc na wejsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            double skladnik11 = double.Parse(wyrazenie.Dequeue());
            string dzialanie2 = wyrazenie.Dequeue();
            double skladnik22 = double.Parse(wyrazenie.Dequeue());
            double wynik = 0;

            switch (dzialanie2)
            {
                case "+":
                    {
                        try
                        {
                            wynik = skladnik11 + skladnik22;
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    }
                case "-":
                    {
                        try
                        {
                            wynik = skladnik11 - skladnik22;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    }
                case "*":
                    {
                        try
                        {
                            wynik = skladnik11 * skladnik22;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    }
                case "/":
                    {
                        try
                        {
                            wynik = skladnik11 / skladnik22;
                        }
                        catch (DivideByZeroException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                    }
                default:
                    {
                        Debug.WriteLine("cos poszlo nie tak");
                        wynik = 0;
                        break;
                    }
            }
            Debug.WriteLine("{0} {1} {2} = {3} KONIEC OBLICZEN!", skladnik11, dzialanie2, skladnik22, wynik);
            //sprawdzamy czy w kolejce cos pozostalo
            //jesli tak to wyciagamy to, wkladamy wynik i wkladamy spowrotem to co bylo
            //jesli nie to wkladamy wynik
            if (wyrazenie.Count() == 1)
            {
                dzialanie = wyrazenie.Dequeue();
                wyrazenie.Enqueue(wynik.ToString());
                wyrazenie.Enqueue(dzialanie);
            }
            else
            {
                wyrazenie.Enqueue(wynik.ToString());
            }
            textBlock1.Text = wynik.ToString();
            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("wychodze z Oblicz");
        }

        private void Button_Click_Equels(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button_Click_Equels:");
            Debug.WriteLine(kolejnaLiczba2);
            if (kolejnaLiczba2 == true)
            {
                wyrazenie.Enqueue(textBlock1.Text);
                historia.Enqueue(textBlock1.Text);
                textBlock0.Text = "";
                foreach (string item in historia)
                {
                    textBlock0.Text += item;
                }
                Oblicz();
            }
            else
            {
                Debug.WriteLine("jestem tutaj na reszcie!");
                string przedOstatniaLiczba = historia.Dequeue();
                string ostatnieDzialanie = historia.Dequeue();
                string ostatniaLiczba = historia.Dequeue();
                string ostatniWynik = wyrazenie.Peek();
                wyrazenie.Enqueue(ostatnieDzialanie);
                wyrazenie.Enqueue(ostatniaLiczba);
                Oblicz();
                historia.Enqueue(ostatniWynik);
                historia.Enqueue(ostatnieDzialanie);
                historia.Enqueue(ostatniaLiczba);
            }
            textBlock0.Text = "";
            foreach (string item in historia)
            {
                textBlock0.Text += item;
            }
            textBlock0.Text += "=";

            //sprawdzam poprawnosc na wyjsciu
            Debug.WriteLine("Kolejka:");
            foreach (string item in wyrazenie)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            Debug.WriteLine("Historia:");
            foreach (string item in historia)
            {
                Debug.WriteLine("item :" + item + ":");
            }
            kolejnaLiczba2 = false;
        }

        private void Button_Click_Comma(object sender, RoutedEventArgs e)
        {
            textBlock1.Text += ",";
        }

        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            wyrazenie.Clear();
            historia.Clear();
            textBlock0.Text = "";
            textBlock1.Text = "0";
            skladnik2 = 0;
            dzialanie = "";
        }
    }
}
