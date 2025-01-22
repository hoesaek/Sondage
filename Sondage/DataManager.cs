using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Sondage
{
    internal class DataManager
    {

        /// <summary>
        /// Vérifie s'il existe un sondage actuellement en cours dans la base de données.
        /// </summary>
        /// <returns>True si un sondage est en cours, sinon False.</returns>
        public bool IsSondageEnCours()
        {
            bool enCours = false;
            string query = "SELECT COUNT(*) FROM sondage WHERE NOW() BETWEEN dateDebut AND dateFin";

            try
            {
                using (MySqlConnection conn = BDD.Instance.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        enCours = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la vérification du sondage en cours \n {ex.Message} \n", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return enCours;
        }

        /// <summary>
        /// Récupère les détails du sondage en cours, comme la question.
        /// </summary>
        /// <returns>La question du sondage en cours ou une chaîne vide en cas d'erreur.</returns>
        public static string GetSondageEnCoursDetails()
        {
            string query = "SELECT question FROM Sondage WHERE NOW() BETWEEN dateDebut AND dateFin LIMIT 1";
            try
            {
                return ExecuteScalarQuery(query)?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Récupère la liste des anciens sondages.
        /// </summary>
        /// <returns>Un DataTable contenant les anciens sondages (id, question, dateDebut, dateFin).</returns>
        public static DataTable GetAnciensSondages()
        {
            string query = "SELECT id, question, dateDebut, dateFin FROM Sondage WHERE dateFin < NOW() ORDER BY dateFin DESC";
            try
            {
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return new DataTable();
            }
        }

        // public static DataTable GetAnciensReponse(int idSondage) { }

        /// <summary>
        /// Crée un nouveau sondage dans la base de données, y compris les réponses associées.
        /// </summary>
        /// <param name="question">La question du sondage.</param>
        /// <param name="dateDebut">La date de début du sondage.</param>
        /// <param name="dateFin">La date de fin du sondage.</param>
        /// <param name="reponses">Un tableau de chaînes contenant les réponses possibles.</param>
        /// <returns>True si le sondage a été créé avec succès, sinon False.</returns>
        public static bool CreerNouveauSondage(string question, DateTime dateDebut, DateTime dateFin, string[] reponses)
        {
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

                    MySqlCommand cmdSondage = new MySqlCommand(querySondage, conn, transaction);
                    cmdSondage.Parameters.AddRange(parametersSondage);
                    cmdSondage.ExecuteNonQuery();

                    long sondageId = cmdSondage.LastInsertedId;

                    // 2. Insertion des réponses
                    if (reponses != null && reponses.Length > 0)
                    {
                        string queryReponse = "INSERT INTO Reponse (idSondage, reponse) VALUES (@idSondage, @reponse)";
                        foreach (string reponse in reponses)
                        {
                            MySqlParameter[] parametersReponse =
                            {
                        new MySqlParameter("@idSondage", sondageId),
                        new MySqlParameter("@reponse", reponse)
                    };

                            MySqlCommand cmdReponse = new MySqlCommand(queryReponse, conn, transaction);
                            cmdReponse.Parameters.AddRange(parametersReponse);
                            cmdReponse.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Erreur: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// Exécute une requête SQL qui retourne une valeur scalaire (comme COUNT, MAX, etc.).
        /// </summary>
        /// <param name="query">La requête SQL à exécuter.</param>
        /// <param name="parameters">Les paramètres associés à la requête.</param>
        /// <returns>Un objet contenant le résultat scalaire de la requête.</returns>
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

        /// <summary>
        /// Exécute une requête SQL qui ne retourne pas de données (INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">La requête SQL à exécuter.</param>
        /// <param name="parameters">Les paramètres associés à la requête.</param>
        /// <returns>Le nombre de lignes affectées par la requête.</returns>
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

        /// <summary>
        /// Exécute une requête SQL qui retourne un DataTable (SELECT).
        /// </summary>
        /// <param name="query">La requête SQL à exécuter.</param>
        /// <param name="parameters">Les paramètres associés à la requête.</param>
        /// <returns>Un DataTable contenant les résultats de la requête.</returns>
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
