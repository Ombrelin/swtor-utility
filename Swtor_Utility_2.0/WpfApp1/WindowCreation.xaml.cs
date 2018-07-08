using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Classe gardien = new Classe("Jedi Gardien");
        Classe senti = new Classe("Jedi Sentinelle");
        Classe ombre = new Classe("Ombre Jedi");
        Classe erudit = new Classe("Erudit Jedi");
        Classe malfrat = new Classe("Malfrat");
        Classe ft = new Classe("Franc-Tireur");
        Classe commando = new Classe("Commando");
        Classe avg = new Classe("Avant-Garde");
        Classe rava = new Classe("Ravageur Sith");
        Classe marau = new Classe("Maraudeur Sith");
        Classe soso = new Classe("Sorcier Sith");
        Classe assa = new Classe("Assassin Sith");
        Classe agent = new Classe("Agent Secret");
        Classe te = new Classe("Tireur d'Elite");
        Classe merco = new Classe("Mercenaire");
        Classe speco = new Classe("Spécialiste");

        CompetenceEquipage recup = new CompetenceEquipage("Récupération");
        CompetenceEquipage archeo = new CompetenceEquipage("Archéologie");
        CompetenceEquipage bioanalyse = new CompetenceEquipage("Bioanalyse");
        CompetenceEquipage piratage = new CompetenceEquipage("Piratage");
        CompetenceEquipage synthe = new CompetenceEquipage("Synthétisage");
        CompetenceEquipage diplo = new CompetenceEquipage("Diplomatie");
        CompetenceEquipage artifice = new CompetenceEquipage("Artifice");
        CompetenceEquipage armes = new CompetenceEquipage("Fabrication d'armes");
        CompetenceEquipage armures = new CompetenceEquipage("Fabrications d'Armures");
        CompetenceEquipage invest = new CompetenceEquipage("Investigation");
        CompetenceEquipage cyber = new CompetenceEquipage("Cybernétique");
        CompetenceEquipage bioch = new CompetenceEquipage("Biochimie");
        CompetenceEquipage commerce = new CompetenceEquipage("Commerce Illégal");
        CompetenceEquipage chasse = new CompetenceEquipage("Chasse au Trésor");

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //On interdit de redimmensionner
            this.MaxWidth = 946.667;
            this.MaxHeight = 750;
            this.MinWidth = 946.667;
            this.MinHeight = 750;
            //On charge dynamiquement la comboBox des classes
            comboClasse.Items.Add(gardien.getNom());
            comboClasse.Items.Add(senti.getNom());
            comboClasse.Items.Add(ombre.getNom());
            comboClasse.Items.Add(erudit.getNom());
            comboClasse.Items.Add(malfrat.getNom());
            comboClasse.Items.Add(ft.getNom());
            comboClasse.Items.Add(commando.getNom());
            comboClasse.Items.Add(avg.getNom());
            comboClasse.Items.Add(rava.getNom());
            comboClasse.Items.Add(marau.getNom());
            comboClasse.Items.Add(soso.getNom());
            comboClasse.Items.Add(assa.getNom());
            comboClasse.Items.Add(agent.getNom());
            comboClasse.Items.Add(te.getNom());
            comboClasse.Items.Add(merco.getNom());
            comboClasse.Items.Add(speco.getNom());
            //On initialise les trackBars
            barComp1.Maximum = 600;
            barComp1.Minimum = 0;
            barComp2.Maximum = 600;
            barComp2.Minimum = 0;
            barComp3.Maximum = 600;
            barComp3.Minimum = 0;
            //On remplit les tags
            checkArcheo.Tag = backArcheo;
            checkArmes.Tag = backArmes;
            checkArmures.Tag = backArmures;
            checkArtifice.Tag = backArtifice;
            checkBioanalyse.Tag = backBioanalyse;
            checkBioch.Tag = backBioch;
            checkChasse.Tag = backChasse;
            checkCommerce.Tag = backCommerce;
            checkCyber.Tag = backCyber;
            checkDiplo.Tag = backDiplo;
            checkInvest.Tag = backInvest;
            checkPiratage.Tag = backPiratage;
            checkRecup.Tag = backRecup;
            checkSynthe.Tag = backSynte;
            //On charge les icons
            iconArcheo.Source = ToBitmapSource(Properties.Resources.archeologie);
            iconArmes.Source = ToBitmapSource(Properties.Resources.fabricationArme);
            iconArmures.Source = ToBitmapSource(Properties.Resources.fabricationArmure);
            iconArtifice.Source = ToBitmapSource(Properties.Resources.artifice);
            iconBioanalyse.Source = ToBitmapSource(Properties.Resources.bioanalyse);
            iconBioch.Source = ToBitmapSource(Properties.Resources.biochimie);
            iconChasse.Source = ToBitmapSource(Properties.Resources.chasseTresor);
            iconCommerce.Source = ToBitmapSource(Properties.Resources.commerceIllegal);
            iconCyber.Source = ToBitmapSource(Properties.Resources.cyber);
            iconDiplo.Source = ToBitmapSource(Properties.Resources.diplomatie);
            iconPiratage.Source = ToBitmapSource(Properties.Resources.piratage);
            iconRecup.Source = ToBitmapSource(Properties.Resources.recuperation);
            iconSynte.Source = ToBitmapSource(Properties.Resources.synthetisage);
            iconInvest.Source = ToBitmapSource(Properties.Resources.investigation);
        }

        public BitmapSource ToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Position = 0;

                var result = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                result.Freeze();
                return result;
            }
        }

        private void barComp1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelComp1.Content = (int)barComp1.Value;
            
        }

        private void barComp2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelComp2.Content = (int)barComp2.Value;
            
        }

        private void barComp3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelComp3.Content = (int)barComp3.Value;
        }

        int nbOptions = 0;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            nbOptions++;
            if(nbOptions < 4)
            {
                Control control = (Control)c.Tag;
                control.Visibility = Visibility.Visible;
            }
            if (nbOptions == 1)
            {
                comp1.Text = c.Content.ToString();
            }
            else if(nbOptions == 2)
            {
                comp2.Text = c.Content.ToString();
            }
            else if (nbOptions == 3)
            {
                comp3.Text = c.Content.ToString();
            }
            if (nbOptions>3){
                c.IsChecked = false;
                MessageBox.Show("Impossible de séléctionner plus de 3 compétences d'équipage", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            nbOptions--;
            CheckBox c = (CheckBox)sender;
            Control control = (Control)c.Tag;
            control.Visibility = Visibility.Hidden;
            if (c.Content.ToString() == comp1.Text)
            {
                comp1.Text = "Compétence 1";
            }
            else if (c.Content.ToString() == comp2.Text)
            {
                comp2.Text = "Compétence 2";
            }
            else if (c.Content.ToString() == comp3.Text)
            {
                comp3.Text = "Compétence 3";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Vérification qu'on a bien pris 3 compétences
            if (nbOptions != 3)
            {
                MessageBox.Show("Veuillez séléctionner trois compétences d'équipage", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //vérification qu'on a bien saisi un nom
            else if (txtBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //Vérification qu'on a bien séléctionné une classe
            else if (comboClasse.SelectedItem == null)
            {
                MessageBox.Show("Veuillez Séléctionner une classe", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //On ajoute le personnage
            else
            {
                Personnage p = new Personnage(txtBoxNom.Text, new Classe(comboClasse.SelectedItem.ToString()));                
                List<CompetenceEquipage> comps = new List<CompetenceEquipage>();
                if ((bool)checkArcheo.IsChecked)
                {
                    comps.Add(archeo);
                }
                if ((bool)checkArmes.IsChecked)
                {
                    comps.Add(armes);
                }
                if ((bool)checkArmures.IsChecked)
                {
                    comps.Add(armures);
                }
                if ((bool)checkArtifice.IsChecked)
                {
                    comps.Add(artifice);
                }
                if ((bool)checkBioanalyse.IsChecked)
                {
                    comps.Add(bioanalyse);
                }
                if ((bool)checkBioch.IsChecked)
                {
                    comps.Add(bioch);
                }
                if ((bool)checkChasse.IsChecked)
                {
                    comps.Add(chasse);
                }
                if ((bool)checkCommerce.IsChecked)
                {
                    comps.Add(commerce);
                }
                if ((bool)checkCommerce.IsChecked)
                {
                    comps.Add(commerce);
                }
                if ((bool)checkCyber.IsChecked)
                {
                    comps.Add(cyber);
                }
                if ((bool)checkDiplo.IsChecked)
                {
                    comps.Add(diplo);
                }
                if ((bool)checkInvest.IsChecked)
                {
                    comps.Add(invest);
                }
                if ((bool)checkPiratage.IsChecked)
                {
                    comps.Add(piratage);
                }
                if ((bool)checkRecup.IsChecked)
                {
                    comps.Add(recup);
                }
                if ((bool)checkSynthe.IsChecked)
                {
                    comps.Add(synthe);
                }
                p.addCompetence(comps.ElementAt(0), (uint)barComp1.Value);
                p.addCompetence(comps.ElementAt(1), (uint)barComp2.Value);
                p.addCompetence(comps.ElementAt(2), (uint)barComp3.Value);
                Personnage.addPerso(p);
                //On réinitialise le formulaire
                barComp1.Value = 0;
                barComp2.Value = 0;
                barComp3.Value = 0;
                labelComp1.Content = "0";
                labelComp1.Content = "0";
                labelComp1.Content = "0";
                txtBoxNom.Text = "";
                comboClasse.Text = "";
                this.Close();
            }
            
        }

        private void check_MouseEnter(object sender, MouseEventArgs e)
        {
            /*CheckBox c = (CheckBox)sender;
            Control control = (Control)c.Tag;
            control.Visibility = Visibility.Visible;*/
        }

        private void check_MouseLeave(object sender, MouseEventArgs e)
        {
            /*CheckBox c = (CheckBox)sender;
            Control control = (Control)c.Tag;
            control.Visibility = Visibility.Hidden;*/
        }
    }
}
