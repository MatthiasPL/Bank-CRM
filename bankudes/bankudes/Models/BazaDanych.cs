using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace bankudes.Models
{
    public class BazaDanych
    {
        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\jeste\\Downloads\\bank.db;Version=3;");

        public bool dodajKlienta(string imie, string nazwisko, string pesel, string miasto, string ulica, string numer_domu, string numer_telefonu, string login, string haslo)
        {
            try
            {
                m_dbConnection.Open();

                String query = "INSERT INTO Klienci(klient_id, imie, nazwisko, pesel, miasto, ulica, numer_domu, numer_telefonu, login, haslo) VALUES (null, @imie, @nazwisko, @pesel, @miasto, @ulica, @numer_domu, @numer_telefonu, @login, @haslo)";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("imie", imie);
                command.Parameters.AddWithValue("nazwisko", nazwisko);
                command.Parameters.AddWithValue("pesel", pesel);
                command.Parameters.AddWithValue("miasto", miasto);
                command.Parameters.AddWithValue("ulica", ulica);
                command.Parameters.AddWithValue("numer_domu", numer_domu);
                command.Parameters.AddWithValue("numer_telefonu", numer_telefonu);
                command.Parameters.AddWithValue("login", login);
                command.Parameters.AddWithValue("haslo", haslo);

                command.ExecuteNonQuery();
                m_dbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public void dodajWalute(string nazwa_waluty, string skrot, double kupno, double sprzedaz)
        {
            try
            {
                m_dbConnection.Open();

                String query = "INSERT INTO Waluty(waluta_id, nazwa_waluty, skrot, kupno, sprzedaz) VALUES (null, @nazwa_waluty, @skrot, @kupno, @sprzedaz)";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("nazwa_waluty", nazwa_waluty);
                command.Parameters.AddWithValue("skrot", skrot);
                command.Parameters.AddWithValue("kupno", kupno);
                command.Parameters.AddWithValue("sprzedaz", sprzedaz);

                command.ExecuteNonQuery();
                m_dbConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public bool sprawdzCzyLoginHasloPoprawne(string login, string haslo)
        {
            try
            {
                m_dbConnection.Open();

                String query = "SELECT login, haslo FROM Klienci WHERE login = @login AND haslo = @haslo";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("haslo", haslo);
                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                if (result.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}