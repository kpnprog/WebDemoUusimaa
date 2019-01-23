using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLtesti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aloitetaan tietokannan kasittely.");
            string yhteysmerkkijono = "Server=localhost\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
            SqlConnection yhteys = new SqlConnection(yhteysmerkkijono);

            yhteys.Open();
            Console.WriteLine("Tietokantayhteys ajettu");

            string sql = "SELECT * FROM Customers WHERE Country = 'Finland'";
            SqlCommand komento = new SqlCommand(sql, yhteys);

            SqlDataReader lukija = komento.ExecuteReader();
            while (lukija.Read())
            {
                string asnro = lukija.GetString(0);
                string nimi = lukija.GetString(1);
                string maa = lukija.GetString(8);

                Console.WriteLine($"{asnro}\t{nimi}\t{maa}");
            }

            Console.WriteLine("Tietokantakysely suoritettu.");

            Console.ReadLine();

            

        }
    }
}
