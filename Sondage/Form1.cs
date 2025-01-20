using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Importer la biblioth�que MySQL

namespace Sondage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void ShowSondageEnCours()
        {
            bool sondageEnCours = DataManager.GetAnciensSondages();
            if (sondageEnCours)
            {
                // Affiche les d�tails du sondage en cours
                ShowQuestionSondageEnCours();
                ShowReponsesSondageEnCours();
                ShowStatsSondageEnCours();
            }
        }

        public void ShowFormulaireCreerSondage()
        {
            // Si aucun sondage n'est en cours, permet � l'utilisateur de cr�er un nouveau sondage
            if (!DataManager.IsSondageEnCours())
            {
                // Afficher le formulaire de cr�ation de sondage
            }
        }

        public void ShowListeSondagesAnciens()
        {
            // Affiche la liste des anciens sondages � l'utilisateur
            var anciensSondages = DataManager.GetAnciensSondages();
            // Afficher les sondages
        }

        public void ShowQuestionSondageEnCours()
        {
            // Affiche la question du sondage en cours
        }

        public void ShowReponsesSondageEnCours()
        {
            // Affiche les r�ponses du sondage en cours
        }

        public void ShowStatsSondageEnCours()
        {
            // Affiche les statistiques du sondage en cours
        }

        public void CreerSondage(string question, DateTime dateDebut, DateTime dateFin)
        {
            // Cr�e un nouveau sondage avec les informations sp�cifi�es
            DataManager.CreerNouveauSondage(question, dateDebut, dateFin);
        }

        public void ValiderSondage()
        {
            // Valide le sondage en cours (soumettre les r�ponses)
        }

        public void AnnulerSondage()
        {
            // Annule le sondage en cours si n�cessaire
        }

        public void MettreAJourMenuSondage()
        {
            // Actualiser dynamiquement le menu de navigation pour inclure ou exclure les sondages
        }

        public void MettreAJourAffichageSondageEnCours()
        {
            // Actualiser l'affichage du sondage en cours si n�cessaire (ex: progression)
        }

        public void ConsulterSondageDetails(int sondageId)
        {
            // Afficher les d�tails d'un ancien sondage sp�cifique
        }

        public void AfficherErreur(string message)
        {
            // Afficher un message d'erreur
        }

        public void AfficherSucces(string message)
        {
            // Afficher un message de succ�s
        }


    }
}
