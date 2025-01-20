using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Sondage
{
    internal class DataManager
    {
        
        // Fonction pour vérifier s'il existe un sondage en cours avec la connexion singleton
        public bool IsSondageEnCours()
        {
            bool enCours = false;
            string query = "SELECT COUNT(*) FROM sondage WHERE NOW() BETWEEN dateDebut AND dateFin";

            try
            {
                // Utilisation de la connexion de la classe BDD via le Singleton
                using (MySqlConnection conn = BDD.Instance.GetConnection())
                {
                    // Création de la commande MySQL avec la requête et la connexion
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Exécution de la requête et récupération du résultat
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        enCours = count > 0; // Si un sondage est en cours, count > 0
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs de connexion ou d'exécution
                MessageBox.Show($"Erreur lors de la vérification du sondage en cours: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return enCours;
        }
        // Récupère les détails du sondage en cours
        public static string GetSondageEnCoursDetails()
        {
            string query = "SELECT question FROM Sondage WHERE NOW() BETWEEN dateDebut AND dateFin LIMIT 1";
            try
            {
                return ExecuteScalarQuery(query).ToString();
            }
            catch (Exception ex)
            {
                // Log ou message d'erreur
                Console.WriteLine($"Erreur: {ex.Message}");
                return string.Empty;
            }
        }
        // Fonction auxiliaire pour exécuter une requête SQL qui retourne une valeur scalaire (comme COUNT, MAX, etc.)
        private static object ExecuteScalarQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = BDD.Instance.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }
        // Créer un nouveau sondage
        public static bool CreerNouveauSondage(string question, DateTime dateDebut, DateTime dateFin, string[] reponses)
        {
            // Début de la transaction pour garantir l'intégrité des données
            using (var conn = BDD.Instance.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Insertion du sondage
                    string querySondage = "INSERT INTO Sondage (question, dateDebut, dateFin) VALUES (@question, @dateDebut, @dateFin)";
                    MySqlParameter[] parametersSondage =
                    [
                        new MySqlParameter("@question", question),
                        new MySqlParameter("@dateDebut", dateDebut),
                        new MySqlParameter("@dateFin", dateFin)
                    ];

                    // Exécution de la requête d'insertion du sondage
                    MySqlCommand cmdSondage = new MySqlCommand(querySondage, conn, transaction);
                    cmdSondage.Parameters.AddRange(parametersSondage);
                    cmdSondage.ExecuteNonQuery();

                    // Récupération de l'id du sondage inséré
                    long sondageId = cmdSondage.LastInsertedId;

                    // 2. Insertion des réponses
                    if (reponses != null && reponses.Length > 0)
                    {
                        string queryReponse = "INSERT INTO Reponse (idSondage, reponse) VALUES (@idSondage, @reponse)";

                        foreach (string reponse in reponses)
                        {
                            MySqlParameter[] parametersReponse =
                            [
                                new MySqlParameter("@idSondage", sondageId),
                                new MySqlParameter("@reponse", reponse)
                            ];

                            // Exécution de la requête pour insérer chaque réponse
                            MySqlCommand cmdReponse = new MySqlCommand(queryReponse, conn, transaction);
                            cmdReponse.Parameters.AddRange(parametersReponse);
                            cmdReponse.ExecuteNonQuery();
                        }
                    }

                    // Si tout a réussi, on valide la transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // En cas d'erreur, on annule la transaction
                    transaction.Rollback();
                    Console.WriteLine($"Erreur: {ex.Message}");
                    return false;
                }
            }
        }
        // Récupère les anciens sondages
        public static DataTable GetAnciensSondages()
        {
            string query = "SELECT id, question, dateDebut, dateFin FROM Sondage WHERE dateFin < NOW() ORDER BY dateFin DESC";
            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                // Log ou message d'erreur
                Console.WriteLine($"Erreur: {ex.Message}");
                return new DataTable();
            }
        }
        // Fonction auxiliaire pour exécuter une requête SQL qui ne retourne pas de données (INSERT, UPDATE, DELETE)
        private static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = BDD.Instance.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Fonction auxiliaire pour exécuter une requête SQL qui retourne un DataTable (SELECT)
        private static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = BDD.Instance.GetConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
