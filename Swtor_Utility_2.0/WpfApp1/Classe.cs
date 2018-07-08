using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    [Serializable]
    class Classe
    {
        //Nom de la classe
        private String nom;

        //Image de la classe
        private Bitmap image;

        //Faction de la classe
        private Faction faction;

        //Constructeur
        public Classe (String nom)
        {
            this.nom = nom;
            
            switch (nom)
            {
                case "Jedi Gardien":
                    image = Properties.Resources.Jedi_Gardien;                    
                    break;                    
                case "Jedi Sentinelle":
                    image = Properties.Resources.Jedi_Sentinelle;
                    break;
                case "Erudit Jedi":
                    image = Properties.Resources.Erudit_Jedi;
                    break;
                case "Ombre Jedi":
                    image = Properties.Resources.Ombre_Jedi;
                    break;
                case "Avant Garde":
                    image = Properties.Resources.Avant_Garde;
                    break;
                case "Commando":
                    image = Properties.Resources.Commando;
                    break;
                case "Malfrat":
                    image = Properties.Resources.Malfrat;
                    break;
                case "Franc Tireur":
                    image = Properties.Resources.Franc_Tireur;
                    break;
                case "Ravageur Sith":
                    image = Properties.Resources.Ravageur_Sith;
                    break;
                case "Maraudeur Sith":
                    image = Properties.Resources.Maraudeur_Sith;
                    break;
                case "Sorcier Sith":
                    image = Properties.Resources.Sorcier_Sith;
                    break;
                case "Assassin Sith":
                    image = Properties.Resources.Assassin_Sith;
                    break;
                case "Spécialiste":
                    image = Properties.Resources.Spécialiste;
                    break;
                case "Mercenaire":
                    image = Properties.Resources.Mercenaire;
                    break;
                case "Agent Secret":
                    image = Properties.Resources.Agent_Secret;
                    break;
                case "Tireur d'Elite":
                    image = Properties.Resources.Tireur_d_Elite;
                    break;
            }    
            
            if (nom.Contains("Jedi") || nom == "Avant-Garde" || nom == "Commando" || nom == "Malfrat" || nom == "Franc-Tireur")
            {
                faction = new Faction("République", Properties.Resources.republic);
            }
            else
            {
                faction = new Faction("Empire", Properties.Resources.empire);
            }
        }

        public String getNom()
        {
            return nom;
        }
        
        public Bitmap getImage()
        {
            return image;
        }
        
        public Faction getFaction()
        {
            return faction;
        }
    }
}
