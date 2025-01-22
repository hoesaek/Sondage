using MySql.Data.MySqlClient;
using IniParser;
using IniParser.Model;
using System;
using System.Data;
using System.IO;

namespace Sondage
{
    internal class BDD
    {
        // Instance privée du Singleton
        private static BDD? _instance;

        // Chaîne de connexion à la base de données MySQL
        private static string? _connectionString;

        // Connexion MySQL
        private MySqlConnection? _connection;

        // Constructeur privé pour empêcher la création d'instances multiples
        private BDD()
        {
            try
            {
                // Créer un parseur
                var parser = new FileIniDataParser();
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");

                // Charger le fichier INI
                IniData data = parser.ReadFile(configPath);

                // Lire les données de configuration
                string dbHost = data["Database"]["Host"];
                string dbName = data["Database"]["Name"];
                string dbUsername = data["Database"]["Username"];
                string dbPassword = data["Database"]["Password"];

                // Construire la chaîne de connexion
                _connectionString = $"Server={dbHost};Database={dbName};User Id={dbUsername};Password={dbPassword};";
            }
            catch (Exception ex)
            {
                string error = "Erreur lors de l'initialisation de la base de données : \n" + ex.Message;
                throw new Exception(error, ex);
            }
        }

        // Propriété pour accéder à l'instance du Singleton
        public static BDD Instance
        {
            get
            {
                // Si l'instance n'existe pas, la créer
                if (_instance == null)
                {
                    _instance = new BDD();
                }
                return _instance;
            }
        }

        // Méthode pour obtenir la connexion MySQL
        public MySqlConnection GetConnection()
        {
            // Vérifier si la connexion est null ou fermée
            if (_connection == null || _connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                if (_connection != null)
                {
                    // Fermer et disposer de l'ancienne connexion si elle était ouverte
                    _connection.Close();
                    _connection.Dispose();
                }

                // Créer une nouvelle connexion
                _connection = new MySqlConnection(_connectionString);

                // Ouvrir la connexion
                _connection.Open();
            }
            return _connection;
        }

        // Méthode pour fermer la connexion MySQL
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
