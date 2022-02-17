using System.Collections.ObjectModel;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>() {
            
             new Book() { Id = 1, Name = "L'espion français", Author = "Cédric Bannel ", Price = 19.90, Content = " Il existe au sein de la DGSE une entité dédiée aux missions tellement sensibles qu'elles ne peuvent être confiées à ses membres officiels. Edgar, trente-trois ans, parisien, est l'un de ces agents de l'ombre très spéciaux. S'il tombe, il tombera seul.Sa prochaine destination : la frontière entre l'Iran et l'Afghanistan.Là,dans une des tours du silence de l'antique foi zoroastrienne, sa cible l'attend" },
             new Book() { Id = 2, Name = "Shibumi", Author = "Trevanian ", Price = 12.0, Content = "Nicholaï Hel est l'assassin le plus doué de son époque et l'homme le plus recherché du monde. Son secret réside dans sa détermination à atteindre une forme rare d'excellence personnelle : le shibumi. Après avoir été élevé dans le Japon de l'après-guerre et initié à l'art subtil du go, il est désormais retiré dans sa forteresse du Pays basque. Il se retrouve alors traqué par une organisation internationale de terreur et d'anéantissement - la Mother Company - et doit se préparer à un ultime affrontement." },
             new Book() { Id = 3, Name = "La compagnie - le grand roman de la ciaLa compagnie - le grand roman de la cia", Author = "Robert Littell", Price = 17.6, Content = "Dans ce redoutable thriller politique, Robert Littell restitue un demi-siècle de notre histoire. Entre fiction et réalité, personnages fictifs et figures historiques (Kennedy, Eltsine, mais aussi Ben Laden), il dévoile les mécanismes et les dérapages de l'une des organisations les plus tristement célèbres au monde, la CIA. Un roman d'espionnage magistralement orchestré, qui place Littell aux côtés des maîtres du genre, John le Carré en tête." },
             new Book() { Id = 4, Name = "Lonesome dove t.1", Author = "Larry Mcmurtry", Price = 29.90, Content = "À Lonesome Dove, Texas, les héros sont fatigués. Augustus McCrae et Woodrow Call ont remisé leurs armes après de longues années passées à combattre les Comanches. En cette année 1880, pourtant, l'aventure va les rattraper lorsqu'ils décident de voler du bétail au Mexique et de le convoyer jusque dans le Montana pour y établir un ranch. Commence alors un immense périple à travers l'Ouest, au cours duquel le convoi affrontera de violentes tempêtes, des bandes de tueurs et d'Indiens rebelles... et laissera de nombreux hommes derrière lui." },

        };




        

        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
    }
}
