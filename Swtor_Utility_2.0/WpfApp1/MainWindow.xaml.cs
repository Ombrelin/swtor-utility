using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateList()
        {
            listBoxPersos.Items.Clear();
            for (int i = 0; i < Personnage.getNbPersos(); ++i)
            {
                listBoxPersos.Items.Add(Personnage.getPersonnage(i).getNom());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 creation = new Window1();
            creation.Show();
        }

        private void Window_Activation(object sender, EventArgs e)
        {
            updateList();
        }

        private void Swtor_Utility_Loaded(object sender, RoutedEventArgs e)
        {
            this.MinHeight = 720;
            this.MinWidth = 1280;
            this.MaxHeight = 720;
            this.MaxWidth = 1280;
            page.Visibility = Visibility.Hidden;
            comboComp.Items.Add("Récupération");
            comboComp.Items.Add("Archéologie");
            comboComp.Items.Add("Bioanalyse");
            comboComp.Items.Add("Piratage");
            comboComp.Items.Add("Synthétisage");
            comboComp.Items.Add("Diplomatie");
            comboComp.Items.Add("Artifice");
            comboComp.Items.Add("Fabrication d'armes");
            comboComp.Items.Add("Investigation");
            comboComp.Items.Add("Cybernétique");
            comboComp.Items.Add("Biochimie");
            comboComp.Items.Add("Commerce Illégal");
            comboComp.Items.Add("Chasse au Trésor");
            comboComp.Items.Add("Fabrication d'Armures");
            comboComp.Items.Add("Tous");

            try
            {
                //Lecture du fichier binaire
                BinaryFormatter formatter1 = new BinaryFormatter();
                FileStream fluxEcriture = new FileStream("persos.dat", FileMode.OpenOrCreate, FileAccess.Read);
                List<Personnage> list1 = (List<Personnage>)formatter1.Deserialize(fluxEcriture);
                Personnage.setPersos(list1);
                fluxEcriture.Close();
            }
            catch { }
            progressComp1.Maximum = 600;
            progressComp2.Maximum = 600;
            progressComp3.Maximum = 600;
            progressComp1.Minimum = 0;
            progressComp2.Minimum = 0;
            progressComp3.Minimum = 0;
            updateList();
        }

        private void Swtor_Utility_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
                //Ecriture dans un fichier binaire
                BinaryFormatter formatter2 = new BinaryFormatter();
                FileStream fluxLecture = new FileStream("persos.dat", FileMode.OpenOrCreate, FileAccess.Write);
                List<Personnage> list2 = Personnage.getpersos();
                formatter2.Serialize(fluxLecture, list2);
                fluxLecture.Close();
        } 

        private void listBoxPersos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            page.Visibility = Visibility.Visible;
            try
            {
                Personnage p = Personnage.getPersonnage(listBoxPersos.SelectedItem.ToString());
                labelNom.Text = p.getNom();
                labelClasse.Text = p.getClasse().getNom();
                imgClasse.Source = ToBitmapSource(p.getClasse().getImage());
                imageComp1.Source = ToBitmapSource(p.getCompetenceEquipage(0).getIcon());
                imageComp2.Source = ToBitmapSource(p.getCompetenceEquipage(1).getIcon());
                imageComp3.Source = ToBitmapSource(p.getCompetenceEquipage(2).getIcon());
                progressComp1.Value = p.getCompetenceEquipage(0).getNiveau();
                progressComp2.Value = p.getCompetenceEquipage(1).getNiveau();
                progressComp3.Value = p.getCompetenceEquipage(2).getNiveau();
                imgFaction.Source = ToBitmapSource(p.getFaction().getIcon());
            }
            catch { }
             
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

        private void comboComp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Personnage p;
            listBoxPersos.Items.Clear();
            for(int i=0;i < Personnage.getNbPersos(); ++i)
            {
                p = Personnage.getPersonnage(i);
                if (p.hasMetier(comboComp.SelectedItem.ToString()))
                {
                    listBoxPersos.Items.Add(p.getNom());
                }
            }
            if(comboComp.SelectedItem.ToString() == "Tous")
            {
                updateList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            page.Visibility = Visibility.Hidden;
            try
            {
                Personnage.supprPerso(listBoxPersos.SelectedItem.ToString());
            } catch { }
            updateList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer tous vos personnage","Confirmation",MessageBoxButton.YesNo,MessageBoxImage.Warning);
            if (reponse == MessageBoxResult.Yes)
            {
                page.Visibility = Visibility.Hidden;
                foreach (var item in listBoxPersos.Items)
                {
                    Personnage.supprPerso(item.ToString());
                }
                updateList();
            }
        }
    }
}