using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace bankudes.Models
{
    public class BazaDanych
    {
        //SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
        string m_dbConnection = "server=localhost;user id=root;database=bank;";
        public bool dodajKlienta(string imie, string nazwisko, string pesel, string miasto, string ulica, string numer_domu, string numer_telefonu, string login, string haslo)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "INSERT INTO Klienci(klient_id, imie, nazwisko, pesel, miasto, ulica, numer_domu, numer_telefonu, login, haslo) VALUES (null, @imie, @nazwisko, @pesel, @miasto, @ulica, @numer_domu, @numer_telefonu, @login, @haslo)";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("imie", imie);
                        cmd.Parameters.Add("nazwisko", nazwisko);
                        cmd.Parameters.Add("pesel", pesel);
                        cmd.Parameters.Add("miasto", miasto);
                        cmd.Parameters.Add("ulica", ulica);
                        cmd.Parameters.Add("numer_domu", numer_domu);
                        cmd.Parameters.Add("numer_telefonu", numer_telefonu);
                        cmd.Parameters.Add("login", login);
                        cmd.Parameters.Add("haslo", haslo);
                        cmd.ExecuteNonQuery();
                        /*using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                            }
                        }*/
                        con.Close();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return false;
            }
        }



        /*try
        {

            MySqlCommand cmd=


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
            //m_dbConnection.Close();
            return false;
        }*/
    
        public void dodajWalute(string nazwa_waluty, string skrot, double kupno, double sprzedaz)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "INSERT INTO Waluty(waluta_id, nazwa_waluty, skrot, kupno, sprzedaz) VALUES (null, @nazwa_waluty, @skrot, @kupno, @sprzedaz)";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("nazwa_waluty", nazwa_waluty);
                        cmd.Parameters.Add("skrot", skrot);
                        cmd.Parameters.Add("kupno", kupno);
                        cmd.Parameters.Add("sprzedaz", sprzedaz);
                        cmd.ExecuteNonQuery();
                        /*using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                            }
                        }*/
                        con.Close();
                    }
               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
            }
    }


        /*  try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
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
                //m_dbConnection.Close();
                Console.WriteLine(ex.ToString());
            }
        }*/
        public bool sprawdzCzyLoginHasloPoprawne(string login, string haslo)
        {
            MySqlConnection dbConn = new MySqlConnection("server=localhost;user id=root;database=bank;Allow User Variables=True;");

            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = "SELECT login, haslo FROM Klienci WHERE login = '" + login + "' AND haslo = '" + haslo + "'";

            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return false;
            }

            MySqlDataReader reader = cmd.ExecuteReader();
            string str = "";
            /*while (reader.Read())
            {
                str += reader.ToString();
            }*/
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            /*string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;user id=root;database=bank";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();

                string insertQuery = "SELECT login, haslo FROM Klienci WHERE login = '"+login+"' AND haslo = '"+haslo+"'";
                MySqlCommand myCommand = new MySqlCommand(insertQuery, cnn);
                //myCommand.Parameters.Add("haslo", haslo);
                //myCommand.Parameters.Add("login", login);
                //myCommand.ExecuteNonQuery();
                MySqlDataReader sdr = myCommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    cnn.Close();
                    return true;
                }
                else
                {
                    cnn.Close();
                    return false;
                }

                //MessageBox.Show("Connection Open ! ");
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show("Can not open connection ! ");
            }
            return false;*/
            /*string connectionString = "Server=localhost;Uid=root;Database=bank;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string insertQuery = "SELECT login, haslo FROM Klienci WHERE login = @login AND haslo = @haslo";
            MySqlCommand myCommand = new MySqlCommand(insertQuery, connection);
            myCommand.Parameters.Add("haslo", haslo);
            myCommand.Parameters.Add("login", login);
            //myCommand.ExecuteNonQuery();
            MySqlDataReader sdr = myCommand.ExecuteReader();
            if (sdr.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
            connection.Close();*/

            /*try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "SELECT login, haslo FROM Klienci WHERE login = @login AND haslo = @haslo";
                    using (MySqlCommand cmd = new MySqlCommand(query,con))
                    {
                        //cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("haslo", haslo);
                        cmd.Parameters.Add("login", login);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.HasRows)
                            {
                                con.Close();
                                return true;
                            }
                            else
                            {
                                con.Close();
                                return false;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return false;
            }*/







            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT login, haslo FROM Klienci WHERE login = @login AND haslo = @haslo";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("haslo", haslo);
                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                if (result.HasRows)
                {
                    m_dbConnection.Close();
                    return true;
                }
                else
                {
                    m_dbConnection.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }*/
        }
        public string pobierzImie(string login)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "SELECT imie, nazwisko FROM Klienci WHERE login = @login";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("login", login);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            string str = "";
                            while (result.Read())
                            {
                                str += result.GetString(0);
                            }
                            con.Close();
                            return str;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }




            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT imie, nazwisko FROM Klienci WHERE login = @login";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                while(result.Read())
                {
                    str += result.GetString(0);
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }*/
        }

        public string pobierzDaneOsobowe(string login)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "SELECT imie, nazwisko, pesel, miasto, ulica, numer_domu, numer_telefonu, login, haslo FROM Klienci WHERE login = @login";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("login", login);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            string str = "";
                            while (result.Read())
                            {
                                str += result.GetString(0) + " " + result.GetString(1) + "<br />" + result.GetString(3) + ", " + result.GetString(4) + " " + result.GetString(5) + "<br />PESEL: " + result.GetInt64(2) + "<br />" + result.GetInt64(6);
                            }
                            con.Close();
                            return str;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }



            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT imie, nazwisko, pesel, miasto, ulica, numer_domu, numer_telefonu, login, haslo FROM Klienci WHERE login = @login";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                while (result.Read())
                {
                    str += result.GetString(0) + " " + result.GetString(1) + "<br />" + result.GetString(3) + ", " + result.GetString(4) + " " + result.GetString(5) + "<br />PESEL: " + result.GetInt64(2) + "<br />" + result.GetInt64(6);
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }*/
        }

        public string pobierzIdKlienta(string login)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    String query = "SELECT klient_id FROM Klienci WHERE login = @login";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add("login", login);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            string str = "";
                            while (result.Read())
                            {
                                str += result.GetInt64(0).ToString();
                            }
                            con.Close();
                            return str;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "0";
            }




            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT klient_id FROM Klienci WHERE login = @login";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                while (result.Read())
                {
                    str += result.GetInt64(0).ToString();
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "0";
            }*/
        }

        public List<string> pobierzKonta(string login)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                   // cmd.Connection = con;
                        //con.Open();
                        cmd.Parameters.Add("login", login);
                        cmd.ExecuteNonQuery();
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            List<string> str = new List<string>();
                            while (result.Read())
                            {
                                str.Add(" Saldo: " + result.GetDouble(0) + " " + result.GetString(1));
                            }
                            con.Close();
                            return str;
                        }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }




            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT Konta.saldo, Typy_kont.nazwa_konta, Waluty.skrot FROM Klienci INNER JOIN Konta ON Klienci.klient_id = Konta.klient_id INNER JOIN Typy_kont ON Konta.typ_konta_id = Typy_kont.typ_konta_id, Waluty WHERE login = @login";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);

                command.Parameters.AddWithValue("login", login);

                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                while (result.Read())
                {
                    str += result.GetString(1) + " Saldo: " + result.GetInt64(0) + " " + result.GetString(2) + "<br />";
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }*/
        }

        public List<string> pobierzIdKont(string klient_id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT konto_id from konta WHERE klient_id = @id";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("id", klient_id);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        List<string> str = new List<string>();
                        while (result.Read())
                        {
                            str.Add(result.GetInt64(0).ToString());
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }
        }

        public List<string> pobierzKontaNiezerowe(string login)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login AND saldo > 0";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("login", login);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        List<string> str = new List<string>();
                        while (result.Read())
                        {
                            str.Add(" Saldo: " + result.GetDouble(0) + " " + result.GetString(1));
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }
        }

        public List<string> pobierzIDKontNiezerowych(string klient_id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT konto_id from konta WHERE klient_id = @id AND saldo > 0";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("id", klient_id);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        List<string> str = new List<string>();
                        while (result.Read())
                        {
                            str.Add(result.GetInt64(0).ToString());
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }
        }

        public List<string> zaladujCheckBoxy()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    con.Open();
                   // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT nazwa_konta, opis from Typy_kont";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                   // {
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            List<string> str = new List<string>();
                            int id = 0;
                            while (result.Read())
                            {
                                str.Add(result.GetString(0) + " - " + result.GetString(1));// + "\r\n";
                                id++;
                            }
                            con.Close();
                            return str;
                        }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }

            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT nazwa_konta, opis from Typy_kont";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                int id = 0;
                while (result.Read())
                {
                    str += result.GetString(0) + " - " + result.GetString(1) + "\r\n";
                    id++;
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }*/
        }

        public List<string> zaladujWaluty()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    con.Open();
                    //String query = "SELECT skrot, nazwa_waluty from Waluty";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT skrot, nazwa_waluty from Waluty";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                        using (MySqlDataReader result = cmd.ExecuteReader())
                        {
                            List<string> str = new List<string>();
                            int id = 0;
                            while (result.Read())
                            {
                            str.Add(result.GetString(0) + " - " + result.GetString(1));// + "\r\n";
                                id++;
                            }
                            con.Close();
                            return str;
                    }
                   //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return new List<string>(new string[] { "null" });
            }


            /*try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
                m_dbConnection.Open();

                String query = "SELECT skrot, nazwa_waluty from Waluty";
                SQLiteCommand command = new SQLiteCommand(query, m_dbConnection);
                SQLiteDataReader result = command.ExecuteReader();
                string str = "";
                int id = 0;
                while (result.Read())
                {
                    str += result.GetString(0)+"\r\n";
                    id++;
                }
                m_dbConnection.Close();
                return str;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
               // m_dbConnection.Close();
                return "null";
            }*/
        }

        public string pobierzSprzedazWaluty(string skrot)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT sprzedaz FROM waluty WHERE skrot = @skrot";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("skrot", skrot);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        string str = "";
                        while (result.Read())
                        {
                            str = result.GetDouble(0).ToString();
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }
        }

        public string pobierzKupnoWaluty(string skrot)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT kupno FROM waluty WHERE skrot = @skrot";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("skrot", skrot);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        string str = "";
                        while (result.Read())
                        {
                            str = result.GetDouble(0).ToString();
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return "null";
            }
        }

        public double pobierzSaldo(string id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {
                    //String query = "SELECT konta.saldo, waluty.skrot FROM klienci INNER JOIN konta ON klienci.klient_id = konta.klient_id INNER JOIN waluty ON konta.waluta_id = waluty.waluta_id WHERE login = @login";
                    //using (MySqlCommand cmd = new MySqlCommand(query))
                    //{
                    con.Open();
                    // String query = "SELECT nazwa_konta, opis from Typy_kont";
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT saldo FROM konta WHERE konto_id = @id";
                    // cmd.Connection = con;
                    //con.Open();
                    cmd.Parameters.Add("id", id);
                    cmd.ExecuteNonQuery();
                    using (MySqlDataReader result = cmd.ExecuteReader())
                    {
                        double str = 0;
                        while (result.Read())
                        {
                            str = result.GetDouble(0);
                        }
                        con.Close();
                        return str;
                    }
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return 0;
            }
        }

        public bool Przelew(double kwota,double saldo,string id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(m_dbConnection))
                {                  
                    con.Open();                    
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Konta SET saldo = @saldo WHERE konto_id = @id; ";          
                              
                    cmd.Parameters.Add("saldo", saldo+kwota);
                    cmd.Parameters.Add("id", id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //m_dbConnection.Close();
                return false;
            }
        }

        public bool dodajKonto(string klient_id, string typ_konta_id, string waluta_id)
        {
            using (MySqlConnection con = new MySqlConnection(m_dbConnection))
            {
                con.Open();
                using (MySqlTransaction tr = con.BeginTransaction())
                {
                    using (MySqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Transaction = tr;
                        cmd.CommandText = "INSERT INTO konta(konto_id, klient_id, typ_konta_id, saldo, waluta_id) VALUES(null, @klient_id, @typ_konta_id, 0, @waluta_id)";
                        cmd.Parameters.Add("klient_id", klient_id);
                        cmd.Parameters.Add("typ_konta_id", typ_konta_id);
                        cmd.Parameters.Add("waluta_id", waluta_id);
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
                con.Close();
            }
            return true;
        }



            /*SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=C:\\Users\\Ja\\Downloads\\bank.db;Version=3;");
            using (SQLiteConnection con = new SQLiteConnection(m_dbConnection))
            {
                con.Open();

                using (SQLiteTransaction tr = con.BeginTransaction())
                {
                    using (SQLiteCommand cmd = con.CreateCommand())
                    {

                        cmd.Transaction = tr;
                        cmd.CommandText = "INSERT INTO Konta(konto_id, klient_id, typ_konta_id, saldo, waluta_id) VALUES(null, @klient_id, @typ_konta_id, 0, @waluta_id)";
                        cmd.Parameters.AddWithValue("klient_id", klient_id);
                        cmd.Parameters.AddWithValue("typ_konta_id", typ_konta_id);
                        cmd.Parameters.AddWithValue("waluta_id", waluta_id);
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit();
                }

                con.Close();
            }
            return true;*/
    }
}