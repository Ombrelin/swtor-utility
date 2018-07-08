using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WpfApp1
{
    [Serializable]
    class CompetenceEquipage
    {
        //Nom de la Compétence d'équipage
        private String nom;

        //Niveau du personnage dans la compétence d'équipage
        private uint niveau;

        //Image de la compétence d'équipage
        private Bitmap icon;

        //Constructeur
        public CompetenceEquipage(String nom)
        {
            this.nom = nom;
            this.niveau = 1;
            switch (nom)
            {
                case "Récupération":
                    icon = Properties.Resources.recuperation;
                    break;
                case "Archéologie":
                    icon = Properties.Resources.archeologie;
                    break;
                case "Bioanalyse":
                    icon = Properties.Resources.bioanalyse;
                    break;
                case "Piratage":
                    icon = Properties.Resources.piratage;
                    break;
                case "Synthétisage":
                    icon = Properties.Resources.synthetisage;
                    break;
                case "Diplomatie":
                    icon = Properties.Resources.diplomatie;
                    break;
                case "Artifice":
                    icon = Properties.Resources.artifice;
                    break;
                case "Fabrication d'armes":
                    icon = Properties.Resources.fabricationArme;
                    break;
                case "Investigation":
                    icon = Properties.Resources.investigation;
                    break;
                case "Cybernétique":
                    icon = Properties.Resources.cyber;
                    break;
                case "Biochimie":
                    icon = Properties.Resources.biochimie;
                    break;
                case "Commerce Illégal":
                    icon = Properties.Resources.commerceIllegal;
                    break;
                case "Chasse au Trésor":
                    icon = Properties.Resources.chasseTresor;
                    break;
                case "Fabrication d'Armures":
                    icon = Properties.Resources.fabricationArmure;
                    break;
            }
        }

        public String getNom()
        {
            return nom;
        }

        public uint getNiveau()
        {
            return niveau;
        }

        public void setNiveau(uint niveau)
        {
            this.niveau = niveau;
        }
        
        public Bitmap getIcon()
        {
            return icon;
        }
        
    }
}
