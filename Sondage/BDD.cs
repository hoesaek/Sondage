using MySql.Data.MySqlClient;
using System;

namespace Sondage
{
    internal class BDD
    {
        // Instance privée du Singleton
        private static BDD? _instance;

        // Chaîne de connexion à la base de données MySQL
        private static string _connectionString = "Server=localhost;Database=sondage;User Id=c#;Password=8c!3h)|a>al6;";

        // Connexion MySQL
        private MySqlConnection? _connection;

        // Constructeur privé pour empêcher la création d'instances multiples
        private BDD()
        {
            // Initialisation de la connexion
            _connection = new MySqlConnection(_connectionString);
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
            if (_connection == null || _connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        // Méthode pour fermer la connexion MySQL
        public void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
