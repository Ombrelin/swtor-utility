using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WpfApp1
{
    [Serializable]
    class Faction
    {
        //Nom de la faction
        private String nom;

        //Image de la faction
        private Bitmap icon;

        //Constructeur
        public Faction (String nom, Bitmap icon){
            this.nom = nom;
            this.icon = icon;
        }

        public String getNom()
        {
            return nom;
        }
        
        public Bitmap getIcon()
        {
            return icon;
        }
        
    }
}
