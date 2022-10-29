using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace devoir_3
{
    public static class DatabasePersonne
    {
        private static string LoadConnectionString(String id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }


        public static void createDatabase()
        {
            SQLiteConnection connection;
            using (connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                String sqlCreateTable = "CREATE TABLE IF NOT EXISTS Personne" +
                    "(id INTEGER PRIMARY KEY AUTOINCREMENT, Nom VARCHAR(15) NOT NULL, " +
                    "Prenom VARCHAR(100), " +
                    "Age INTEGER NOT NULL, Nationalite VARCHAR(25) NOT NULL," +
                    "AdresseRue VARCHAR(100), Ville VARCHAR(50)," +
                    "Pays VARCHAR(25) NOT NULL, Telephone VARCHAR(25), " +
                    "DateCree VARCHAR(25) NOT NULL);";

                SQLiteCommand command = new SQLiteCommand(sqlCreateTable, connection);
                command.ExecuteNonQuery();
            }
        }


        public static void InsertToDatabase(Personne personne)
        {
            
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string sqlInsert = "INSERT INTO Personne(Nom, Prenom, Age, " +
                    "Nationalite, AdresseRue, Ville, Pays," +
                    "Telephone, DateCree) VALUES(@Nom, @Prenom," +
                    "@Age, @Nationalite, @AdresseRue, @Ville, @Pays," +
                    "@Telephone, @DateCree);";

                SQLiteCommand command = new SQLiteCommand(sqlInsert, conn);
                command.Parameters.AddWithValue("@Nom", personne.Nom);
                command.Parameters.AddWithValue("@Prenom", personne.Prenom1 + " " + personne.Prenom2);
                command.Parameters.AddWithValue("@Age", personne.Age);
                command.Parameters.AddWithValue("@Nationalite", personne.Nationalite);
                command.Parameters.AddWithValue("@AdresseRue", personne.AdresseRue);
                command.Parameters.AddWithValue("@Ville", personne.Ville);
                command.Parameters.AddWithValue("@Pays", personne.Pays);
                command.Parameters.AddWithValue("@Telephone", personne.Telephone);
                command.Parameters.AddWithValue("@DateCree", personne.DateCreee);

                command.Prepare();
                command.ExecuteNonQuery();
            }
        }


        public static List<Personne> getListPersonne()
        {
            List<Personne> personnes = new List<Personne>();

            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string sqlSelect = "SELECT * FROM Personne;";
                SQLiteCommand command = new SQLiteCommand(sqlSelect, conn);

                SQLiteDataReader dataReader =  command.ExecuteReader();
                while (dataReader.Read())
                {
                    string nom = dataReader.GetString(1);
                    string prenom = dataReader.GetString(2);
                    int age = dataReader.GetInt32(4);
                    string nationalite = dataReader.GetString(5);
                    string adresse = dataReader.GetString(6);
                    string ville = dataReader.GetString(7);
                    string pays = dataReader.GetString(8);
                    string telephone = dataReader.GetString(9);
                    string date = dataReader.GetString(10);

                    Personne personne = new Personne(nom, prenom.Substring(0), prenom.Substring(1), age, nationalite, adresse, ville, pays, telephone, date);
                    personnes.Add(personne);
                }
                

            }

            return personnes;
        }


        public static DataTable GetData()
        {
            DataTable dataTable = new DataTable();
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();

                string sqlSelect = "SELECT Nom, Prenom, Age, Telephone FROM Personne;";
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlSelect, conn);
                dataAdapter.Fill(dataTable);
            }


            return dataTable;
        }
        
    }
}