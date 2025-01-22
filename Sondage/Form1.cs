using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Importer la bibliothèque MySQL

namespace Sondage
{
    public partial class Form1 : Form
    {
        DataManager DataManager = new DataManager();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // loadLeftSideBar()
            ShowSondageEnCours();
            // setProggressBar();
        }

        /// <summary>
        /// Gère l'affichage du sondage en cours si un sondage est actif.
        /// </summary>
        public void ShowSondageEnCours()
        {
            bool sondageEnCours = DataManager.IsSondageEnCours();

            if (sondageEnCours)
            {
                ShowQuestionSondageEnCours();
                ShowReponsesSondageEnCours();
                ShowStatsSondageEnCours();
            }
        }

        /// <summary>
        /// Affiche le formulaire permettant de créer un nouveau sondage 
        /// si aucun sondage n'est en cours.
        /// </summary>
        public void ShowFormulaireCreerSondage()
        {
            if (!DataManager.IsSondageEnCours())
            {
                // Afficher le formulaire de création de sondage
            }
        }

        /// <summary>
        /// Affiche la liste des anciens sondages récupérés depuis la base de données.
        /// </summary>
        public void ShowListeSondagesAnciens()
        {
            var anciensSondages = DataManager.GetAnciensSondages();
            // Afficher les sondages
        }

        /// <summary>
        /// Affiche la question du sondage en cours.
        /// </summary>
        public void ShowQuestionSondageEnCours()
        {
            // Affiche la question du sondage en cours
        }

        /// <summary>
        /// Récupère et affiche les réponses associées au sondage en cours.
        /// </summary>
        /// <returns>Tableau de chaînes représentant les réponses du sondage.</returns>
        public string[] ShowReponsesSondageEnCours()
        {
            string[] sondages =
            {
        "Réponse 1",
        "Réponse 2",
        "Réponse 3",
        "Réponse 4"
    };

            return sondages;
        }

        /// <summary>
        /// Affiche les statistiques du sondage en cours, par exemple la progression.
        /// </summary>
        public void ShowStatsSondageEnCours()
        {
            // Affiche les statistiques du sondage en cours
        }

        /// <summary>
        /// Crée un nouveau sondage avec la question, les dates et les réponses spécifiées.
        /// </summary>
        /// <param name="question">La question du sondage.</param>
        /// <param name="dateDebut">La date de début du sondage.</param>
        /// <param name="dateFin">La date de fin du sondage.</param>
        /// <param name="reponse">Un tableau des réponses possibles.</param>
        public void CreerSondage(string question, DateTime dateDebut, DateTime dateFin, string[] reponse)
        {
            DataManager.CreerNouveauSondage(question, dateDebut, dateFin, reponse);
        }

        /// <summary>
        /// Valide le sondage actuel en cours de création.
        /// </summary>
        public void ValiderSondage()
        {
            // Valide le sondage en cours
        }

        /// <summary>
        /// Annule un sondage en cours s'il n'est plus pertinent.
        /// </summary>
        public void AnnulerSondage()
        {
            // Annule le sondage en cours si nécessaire
        }

        /// <summary>
        /// Met à jour dynamiquement le menu de navigation pour refléter les sondages disponibles.
        /// </summary>
        public void MettreAJourMenuSondage()
        {
            // Mettre à jour le menu pour inclure ou exclure les sondages
        }

        /// <summary>
        /// Met à jour l'affichage du sondage en cours, comme la progression ou d'autres données.
        /// </summary>
        public void MettreAJourAffichageSondageEnCours()
        {
            // Actualiser l'affichage du sondage en cours si nécessaire
        }

        /// <summary>
        /// Affiche les détails d'un ancien sondage en fonction de son identifiant.
        /// </summary>
        /// <param name="sondageId">L'identifiant du sondage à consulter.</param>
        public void ConsulterSondageDetails(int sondageId)
        {
            // Afficher les détails d'un sondage spécifique
        }

        /// <summary>
        /// Affiche un message d'erreur dans une boîte de dialogue.
        /// </summary>
        /// <param name="message">Le message d'erreur à afficher.</param>
        public void AfficherErreur(string message)
        {
            // Affiche un message d'erreur
        }

        /// <summary>
        /// Affiche un message de succès dans une boîte de dialogue.
        /// </summary>
        /// <param name="message">Le message de succès à afficher.</param>
        public void AfficherSucces(string message)
        {
            // Affiche un message de succès
        }



        /// <summary>
        /// Gère l'événement déclenché lorsque l'utilisateur sélectionne l'option "Nouveau Sondage" dans le menu.
        /// Cette méthode est appelée lorsqu'un clic est effectué sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement, généralement un élément de menu.</param>
        /// <param name="e">Les données de l'événement associées au clic.</param>
        private void nouveauSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour créer ou afficher un nouveau sondage
            // Exemple : ouvrir une fenêtre pour entrer les détails d'un nouveau sondage.
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque l'utilisateur sélectionne l'option "Consulter un Ancien Sondage" dans le menu.
        /// Cette méthode est appelée lorsqu'un clic est effectué sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement, généralement un élément de menu.</param>
        /// <param name="e">Les données de l'événement associées au clic.</param>
        private void consulterUnAncienSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour afficher une liste des anciens sondages disponibles
            // Exemple : ouvrir une fenêtre ou charger une vue avec les anciens sondages.
        }

        /// <summary>
        /// Gère l'événement déclenché lorsque l'utilisateur sélectionne l'option "Ajouter un Nouveau Sondage" dans le menu.
        /// Cette méthode est appelée lorsqu'un clic est effectué sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'événement, généralement un élément de menu.</param>
        /// <param name="e">Les données de l'événement associées au clic.</param>
        private void ajouterUnNouveauSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour ajouter un nouveau sondage
            // Exemple : appeler la méthode pour afficher un formulaire ou valider les données saisies.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataManager.IsSondageEnCours())
                {
                    MessageBox.Show("Il y a un sondage en cours");
                }
                else
                {
                    MessageBox.Show("Il n'y a pas de sondage en cours");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            //fermer la connexion a la bdd lorsque l'on quitte le formulaire
            BDD.Instance.CloseConnection();
        }
    }
}
