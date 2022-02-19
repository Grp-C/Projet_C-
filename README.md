# Projet .Net Pour la gestion et consultation d'une bibliotheque de Livres
- Langages  : C#, HTML, Javascript

- Serveur web : ASP.Net Core

- Logiciel Windows : WPF

# MEMBRES
- NOUHAILA AANAYA
- SOUMAYA BOUANOU
- OMAR BOUNOR
- ASMAE CHAH
- ZAKARIA DRIDI 


# FONCTIONNALITES


# Administration 

✔ - ajouter des livres dans la bibliothèque
✔ - supprimer des livres de la bibliothèque
✔ - Consulter la liste de tous les livres
✔ - Consulter la liste de tous les genres

Option : 

✔ - Faire une interface pour ajouter de nouveaux genres 
✔ - Modifier un livre existant


# Api


✔ - Récupérer un livre avec son contenu : /book/{id} 

✔ - Lister les genres disponibles: /genre

✔ - Lister les livres (sans le contenu) : 
   - Le résultat doit être paginé
  - La recherche doit aussi pouvoir être faite en spécifiant un genre

 ✔ -Utilisation de  :

- NSwagg (<https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-5.0&tabs=visual-studio>)

pour générer un fichier OpenApi automatiquement, cela accélèrera grandement le développement du client. 


# Application Windows

✔ - Lister les *N* premiers livres (vous pouvez définir la limite comme bon vous semble)
✔ - Afficher les détails d’un livre
✔ - Lire un livre

Options :

✔ - Lister tous les genres
✔ - Afficher les *N* premiers livres d’un genre (vous pouvez définir la limite comme bon vous semble)

✔ -À tout moment l’utilisateur doit pouvoir revenir à l’accueil, il n’est pas nécessaire de faire un bouton pour revenir à la page précédente


## Api
✔ - L’application doit pouvoir recevoir les livres depuis le serveur développé dans la partie précédente


