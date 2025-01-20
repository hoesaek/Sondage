using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Importer la bibliothèque MySQL

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
                // Affiche les détails du sondage en cours
                ShowQuestionSondageEnCours();
                ShowReponsesSondageEnCours();
                ShowStatsSondageEnCours();
            }
        }

        public void ShowFormulaireCreerSondage()
        {
            // Si aucun sondage n'est en cours, permet à l'utilisateur de créer un nouveau sondage
            if (!DataManager.IsSondageEnCours())
            {
                // Afficher le formulaire de création de sondage
            }
        }

        public void ShowListeSondagesAnciens()
        {
            // Affiche la liste des anciens sondages à l'utilisateur
            var anciensSondages = DataManager.GetAnciensSondages();
            // Afficher les sondages
        }

        public void ShowQuestionSondageEnCours()
        {
            // Affiche la question du sondage en cours
        }

        public void ShowReponsesSondageEnCours()
        {
            // Affiche les réponses du sondage en cours
        }

        public void ShowStatsSondageEnCours()
        {
            // Affiche les statistiques du sondage en cours
        }

        public void CreerSondage(string question, DateTime dateDebut, DateTime dateFin)
        {
            // Crée un nouveau sondage avec les informations spécifiées
            DataManager.CreerNouveauSondage(question, dateDebut, dateFin);
        }

        public void ValiderSondage()
        {
            // Valide le sondage en cours (soumettre les réponses)
        }

        public void AnnulerSondage()
        {
            // Annule le sondage en cours si nécessaire
        }

        public void MettreAJourMenuSondage()
        {
            // Actualiser dynamiquement le menu de navigation pour inclure ou exclure les sondages
        }

        public void MettreAJourAffichageSondageEnCours()
        {
            // Actualiser l'affichage du sondage en cours si nécessaire (ex: progression)
        }

        public void ConsulterSondageDetails(int sondageId)
        {
            // Afficher les détails d'un ancien sondage spécifique
        }

        public void AfficherErreur(string message)
        {
            // Afficher un message d'erreur
        }

        public void AfficherSucces(string message)
        {
            // Afficher un message de succès
        }


    }
}
