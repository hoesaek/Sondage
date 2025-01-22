using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Importer la biblioth�que MySQL

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
        /// G�re l'affichage du sondage en cours si un sondage est actif.
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
        /// Affiche le formulaire permettant de cr�er un nouveau sondage 
        /// si aucun sondage n'est en cours.
        /// </summary>
        public void ShowFormulaireCreerSondage()
        {
            if (!DataManager.IsSondageEnCours())
            {
                // Afficher le formulaire de cr�ation de sondage
            }
        }

        /// <summary>
        /// Affiche la liste des anciens sondages r�cup�r�s depuis la base de donn�es.
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
        /// R�cup�re et affiche les r�ponses associ�es au sondage en cours.
        /// </summary>
        /// <returns>Tableau de cha�nes repr�sentant les r�ponses du sondage.</returns>
        public string[] ShowReponsesSondageEnCours()
        {
            string[] sondages =
            {
        "R�ponse 1",
        "R�ponse 2",
        "R�ponse 3",
        "R�ponse 4"
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
        /// Cr�e un nouveau sondage avec la question, les dates et les r�ponses sp�cifi�es.
        /// </summary>
        /// <param name="question">La question du sondage.</param>
        /// <param name="dateDebut">La date de d�but du sondage.</param>
        /// <param name="dateFin">La date de fin du sondage.</param>
        /// <param name="reponse">Un tableau des r�ponses possibles.</param>
        public void CreerSondage(string question, DateTime dateDebut, DateTime dateFin, string[] reponse)
        {
            DataManager.CreerNouveauSondage(question, dateDebut, dateFin, reponse);
        }

        /// <summary>
        /// Valide le sondage actuel en cours de cr�ation.
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
            // Annule le sondage en cours si n�cessaire
        }

        /// <summary>
        /// Met � jour dynamiquement le menu de navigation pour refl�ter les sondages disponibles.
        /// </summary>
        public void MettreAJourMenuSondage()
        {
            // Mettre � jour le menu pour inclure ou exclure les sondages
        }

        /// <summary>
        /// Met � jour l'affichage du sondage en cours, comme la progression ou d'autres donn�es.
        /// </summary>
        public void MettreAJourAffichageSondageEnCours()
        {
            // Actualiser l'affichage du sondage en cours si n�cessaire
        }

        /// <summary>
        /// Affiche les d�tails d'un ancien sondage en fonction de son identifiant.
        /// </summary>
        /// <param name="sondageId">L'identifiant du sondage � consulter.</param>
        public void ConsulterSondageDetails(int sondageId)
        {
            // Afficher les d�tails d'un sondage sp�cifique
        }

        /// <summary>
        /// Affiche un message d'erreur dans une bo�te de dialogue.
        /// </summary>
        /// <param name="message">Le message d'erreur � afficher.</param>
        public void AfficherErreur(string message)
        {
            // Affiche un message d'erreur
        }

        /// <summary>
        /// Affiche un message de succ�s dans une bo�te de dialogue.
        /// </summary>
        /// <param name="message">Le message de succ�s � afficher.</param>
        public void AfficherSucces(string message)
        {
            // Affiche un message de succ�s
        }



        /// <summary>
        /// G�re l'�v�nement d�clench� lorsque l'utilisateur s�lectionne l'option "Nouveau Sondage" dans le menu.
        /// Cette m�thode est appel�e lorsqu'un clic est effectu� sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'�v�nement, g�n�ralement un �l�ment de menu.</param>
        /// <param name="e">Les donn�es de l'�v�nement associ�es au clic.</param>
        private void nouveauSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour cr�er ou afficher un nouveau sondage
            // Exemple : ouvrir une fen�tre pour entrer les d�tails d'un nouveau sondage.
        }

        /// <summary>
        /// G�re l'�v�nement d�clench� lorsque l'utilisateur s�lectionne l'option "Consulter un Ancien Sondage" dans le menu.
        /// Cette m�thode est appel�e lorsqu'un clic est effectu� sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'�v�nement, g�n�ralement un �l�ment de menu.</param>
        /// <param name="e">Les donn�es de l'�v�nement associ�es au clic.</param>
        private void consulterUnAncienSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour afficher une liste des anciens sondages disponibles
            // Exemple : ouvrir une fen�tre ou charger une vue avec les anciens sondages.
        }

        /// <summary>
        /// G�re l'�v�nement d�clench� lorsque l'utilisateur s�lectionne l'option "Ajouter un Nouveau Sondage" dans le menu.
        /// Cette m�thode est appel�e lorsqu'un clic est effectu� sur le menu correspondant.
        /// </summary>
        /// <param name="sender">L'objet source de l'�v�nement, g�n�ralement un �l�ment de menu.</param>
        /// <param name="e">Les donn�es de l'�v�nement associ�es au clic.</param>
        private void ajouterUnNouveauSondageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Logique pour ajouter un nouveau sondage
            // Exemple : appeler la m�thode pour afficher un formulaire ou valider les donn�es saisies.
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
