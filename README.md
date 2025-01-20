# Projet de Gestion de Sondages

Ce projet est une application de gestion de sondages développée en C# avec une base de données MySQL. L'objectif est de permettre la création, la consultation et la gestion de sondages, ainsi que l'affichage des résultats en temps réel.

## Fonctionnalités Principales

1. **Créer un nouveau sondage**  
   - L'utilisateur peut saisir une question, des réponses possibles et définir une période pour le sondage (date de début et date de fin).
   - Les réponses sont stockées en base de données et liées au sondage.

2. **Afficher un sondage en cours**  
   - Si un sondage est actif (en cours dans la période définie), les détails du sondage s'affichent (question, réponses, et statistiques).

3. **Consulter les anciens sondages**  
   - L'application permet d'afficher la liste des sondages passés et leurs détails (question, réponses, dates, et résultats).

4. **Annuler un sondage**  
   - Un sondage en cours peut être annulé si nécessaire.

5. **Navigation dynamique**  
   - Mise à jour du menu et de l'affichage en fonction de l'état des sondages (en cours ou non).

## Structure du Projet

### Classes Principales

1. **DataManager**
   - Responsable de la gestion des interactions avec la base de données (requêtes SQL, transactions, etc.).
   - Méthodes principales :
     - `IsSondageEnCours()` : Vérifie si un sondage est actif.
     - `GetSondageEnCoursDetails()` : Récupère les détails du sondage actif.
     - `GetAnciensSondages()` : Récupère les anciens sondages.
     - `CreerNouveauSondage()` : Insère un nouveau sondage et ses réponses dans la base.
   
2. **Méthodes auxiliaires**
   - `ExecuteScalarQuery()` : Exécute une requête qui retourne une valeur scalaire, comme un COUNT, MAX, etc. (par exemple, pour vérifier si un sondage est en cours).
   - `ExecuteNonQuery()` : Exécute une requête qui ne retourne pas de données (comme INSERT, UPDATE, DELETE).
   - `ExecuteQuery()` : Exécute une requête SQL qui retourne plusieurs lignes de résultats, par exemple une liste de sondages dans un DataTable.
          
3. **BDD**
   - Singleton gérant la connexion MySQL.
   - Fournit une méthode `GetConnection()` pour obtenir une instance de la connexion, appele : `BDD.Instance.GetConnectiion();` où Instance verifie si une instance de connexion est en cours ou non afin d'avoir qu'une seule instance connecter à ma bdd
     - La méthode Singleton, qui peut être utilisée pour gérer l'instance unique d'une ressource, n'est pas destinée à remplacer des frameworks comme `EntityFramework`, qui gèrent l'accès aux bases de données..

4. **FormulairePrincipal**
   - Interface utilisateur principale.
   - En fonction de là où ce trouve l'utillisateur certains elements sont rendus visible alors que d'autre non afin de supplanter mon manque d'experiance dans la gestion de donner inter-formulaire et d'éviter les usines à gaz.

### Base de Données

#### Tables Principales

- **Sondage**
  - `id` (int, clé primaire)
  - `question` (varchar)
  - `dateDebut` (datetime)
  - `dateFin` (datetime)

- **Reponse**
  - `id` (int, clé primaire)
  - `idSondage` (int, clé étrangère vers Sondage)
  - `reponse` (varchar)

## Exemple d'Utilisation

1. **Créer un sondage**
   - Remplir le formulaire avec une question, des réponses et une période.
   - Valider pour enregistrer les données dans la base.

2. **Afficher un sondage actif**
   - Si un sondage est en cours, la question, les réponses et les statistiques s'affichent automatiquement.

3. **Consulter les anciens sondages**
   - Naviguer dans le menu pour afficher une liste des sondages terminés.

## Installation et Configuration

### Prérequis

- .NET Framework ou .NET Core SDK installé.
- Serveur MySQL opérationnel.

### Étapes

1. **Configurer la base de données**
   - Importer le fichier SQL (ex: `sondagge.sql`) pour créer les tables nécessaires.

2. **Configurer la chaîne de connexion**
   - Modifier la chaîne de connexion MySQL dans la classe `BDD` :
     ```csharp
     private const string connectionString = "Server=localhost;Database=sondages;Uid=csharp;Pwd=********;";
     ```

3. **Lancer l'application**
   - Compiler et exécuter le projet à partir de Visual Studio ou d'une autre IDE compatible.

# Schema de mon projet afin de rendre modulaire les vues ainsi que l'utilisation des donnees

                                       ┌──────────────────────────────────┐
                                       │            MainForm              │
                                       │ (Interface principale de l app)  │
                                       └──────────────────────────────────┘
                                                   │            |
                           ┌────────────────────────────────────────────────────┐
                           │                  Menu Principal                    │
                           │    - Nouveau Sondage        - Consulter Sondages   │
                           │    - Sondage en Cours       - Autres Options       │
                           └────────────────────────────────────────────────────┘
                                                   │            |
                ┌────────────────────────────────────────────────────────────────────────────┐
                │                             Vues et Formulaires                            │
                │ ┌───────────────────────┐  ┌────────────────────┐  ┌────────────────────┐  │
                │ │  Formulaire de        │  │ Liste des anciens  │  │ Sondage en cours   │  │
                │ │ création de sondage   │  │ sondages           │  │ (visualisation)    │  │
                │ └───────────────────────┘  └────────────────────┘  └────────────────────┘  │
                └────────────────────────────────────────────────────────────────────────────┘
                                                   │            |
                        ┌──────────────────────────────────────────────────────────────┐
                        │                           Gestion des Données                │
                        │ - DataManager : interface avec la base de données pour gérer │
                        │   les sondages (création, récupération, mise à jour).        │
                        └──────────────────────────────────────────────────────────────┘
                                                   │            |
                      ┌───────────────────────────────────────────────────────────────────┐
                      │    Gestion des Sondages                                           │
                      │   - Création de sondage (ajouter question, réponses, dates)       │
                      │   - Consultation des anciens sondages (affichage, détails)        │
                      │   - Vérification et affichage du sondage en cours                 │
                      └───────────────────────────────────────────────────────────────────┘
                                                   │            |
                                ┌────────────────────────────────────────┐
                                │   Interaction avec la base de données  │
                                │     (MySQL, SQL, etc.)                 │
                                └────────────────────────────────────────┘
-----------------------------------------------------------------------------------------------------------------------------------------------------------

                                     ┌─────────────────────────────────────────────────────────────────────────┐
                                     │                            Application                                  │
                                     └─────────────────────────────────────────────────────────────────────────┘
                                                                         │
        ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
        │                                                                │                                             │                             
   ┌─────────────────────────────────────────┐  ┌───────────────────────────────────────────────┐   ┌───────────────────────────────────────────────┐
   │            Menu Principal               │  │    Formulaire Nouveau Sondage (visualisation) │   │    Liste des Anciens Sondages (DataGridView)  │
   │        (MenuStrip)                      │  │                                               │   │                                               │
   ├─────────────────────────────────────────┤  ├───────────────────────────────────────────────┤   ├───────────────────────────────────────────────┤
   │ - Nouveau Sondage (Bouton)              │  │ - Question                                    │   │ - Affichage des anciens sondages              │
   │ - Consulter Sondages Anciens (Bouton)   │  │ - Date Début                                  │   │   (et leurs réponses qui seront affichées     │
   │ - Sondage en Cours (Label/Message)      │  │ - Date Fin                                    │   │    à la place du sondage en cours)            │
   └─────────────────────────────────────────┘  │ - Réponses                                    │   └───────────────────────────────────────────────┘
                                                │ - Bouton Soumettre                            |
                                                └───────────────────────────────────────────────┘
                                                                         │
                                                      ┌────────────────────────────────────┐
                                                      │  Sondage en Cours (Visualisation)  │
                                                      ├────────────────────────────────────┤
                                                      │ - Question du Sondage              │
                                                      │ - Réponses en Cours                │
                                                      │ - Statistiques du Sondage          │
                                                      └────────────────────────────────────┘

--------------------------------------------------------------------------------------------------------------------------------------------------------

## Technologies Utilisées

- **Langage :** C#
- **Base de données :** MySQL
- **IDE :** Visual Studio
- **Bibliothèques :** MySql.Data pour les connexions à la base de données

## Contributeurs

- **Développeur principal :** hoesaek
- **Contributeurs :** hoesaek

# Projet open-source ^^





