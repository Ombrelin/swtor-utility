using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WpfApp1
{
    [Serializable]
    class Personnage
    {
        //Liste de tous les personnages
        private static List<Personnage> personnages = new List<Personnage>();

        //Nom du personnage
        private String nom;

        //Classe du Personnage
        private Classe classe;

        //Compétences d'équipage
        private List<CompetenceEquipage> competences;

        //Constructeur
        public Personnage(String nom, Classe classe)
        {
            this.nom = nom;
            this.classe = classe;
            competences = new List<CompetenceEquipage>();
        }

        //Méthodes d'instance
        public String getNom()
        {
            return nom;
        }

        public Classe getClasse()
        {
            return classe;
        }

        public void addCompetence(CompetenceEquipage c, uint niveau)
        {
            c.setNiveau(niveau);
            competences.Add(c);
        }

        public CompetenceEquipage getCompetenceEquipage(int index)
        {
            if (index < 0 || index > 2)
            {
                throw new ArgumentException("index de compétence invalide");
            }
            return competences.ElementAt(index);
        }

        public uint getNiveau(int comp)
        {
            if(comp < 0 || comp > 2)
            {
                throw new ArgumentException("index de compétence invalide");
            }
            return competences.ElementAt(comp).getNiveau();
        }

        public Boolean hasMetier(String s)
        {
            for (int i = 0; i < 3; ++i)
            {
                if (competences.ElementAt(i).getNom() == s)
                {
                    return true;
                }
            }
            return false;
        }

        //Méthodes statiques
        public Faction getFaction()
        {
            return getClasse().getFaction();
        }

        public static void addPerso(Personnage p)
        {
            personnages.Add(p);
        }

        public static int getNbPersos()
        {
            return personnages.Count;
        }

        public static Personnage getPersonnage(int index)
        {
            return personnages.ElementAt(index);
        }

        public static Personnage getPersonnage(String nom)
        {
            for (int i = 0; i < personnages.Count(); ++i)
            {
                if (personnages.ElementAt(i).nom == nom)
                {
                    return personnages.ElementAt(i);
                }
            }
            return personnages.ElementAt(0);
        }

        public static List<Personnage> getpersos()
        {
            return personnages;
        }

        public static void setPersos(List<Personnage> list)
        {
            personnages = list;
        }

        public static void supprPerso(String nom)
        {
            for (int i = 0; i < personnages.Count; ++i)
            {
                if (personnages.ElementAt(i).nom == nom)
                {
                    personnages.Remove(personnages.ElementAt(i));
                }
            }
        }
    }
}
