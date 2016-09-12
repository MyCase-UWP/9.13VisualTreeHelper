using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _9._12VisualTreeHelper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var data = new Data();
            this.DataContext = data;
        }

        private void DeleteLollyButton_Click(object sender, RoutedEventArgs e)
        {
            //get the parent ListViewItemPresenter of sender
            var element = sender as Button;
            ListViewItemPresenter parent = VisualTreeHelper.GetParent(element) as ListViewItemPresenter;
            //get ListViewItemPresenter's data (it is a Lolly)
            Lolly data = parent.Content as Lolly;

            //get the ItemsPresenter of sender
            var parent2 = VisualTreeHelper.GetParent(parent);
            parent2 = VisualTreeHelper.GetParent(parent2);
            ItemsPresenter p = VisualTreeHelper.GetParent(parent2) as ItemsPresenter;

            //get ItemsPresenter's data
            Jar data2 = p.DataContext as Jar;
            data2.Lollies.Remove(data);
        }

        private void DeleteJarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBoxButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }

    public class Data {
        private ObservableCollection<Box> boxes;

        public ObservableCollection<Box> Boxes
        {
            get { return boxes; }
        }

        public Data() {
            boxes = new ObservableCollection<Box>();
            boxes.Add(new Box() {Name = "Box1"});
            boxes.Add(new Box() {Name = "Box2"});
        }
    }

    public class Box {
        private ObservableCollection<Jar> jars;
        public ObservableCollection<Jar> Jars
        {
            get { return jars; }
        }

        private string name;
        public String Name {
            get { return name; }
            set { this.name = value; }
        }

        public Box() {
            jars = new ObservableCollection<Jar>();
            jars.Add(new Jar() {Name = "Jar1" });
            jars.Add(new Jar() {Name= " Jar2" });
        }
    }

    public class Jar {
        private ObservableCollection<Lolly> lollies;
        public ObservableCollection<Lolly> Lollies {
            get { return lollies; }
        }

        private string name;
        public String Name
        {
            get { return name; }
            set { this.name = value; }
        }

        public Jar()
        {
            lollies = new ObservableCollection<Lolly>();
            lollies.Add(new Lolly() {Name="lolly1" });
            lollies.Add(new Lolly() {Name="lolly2" });
        }
    }

    public class Lolly {
        private string name;
        public String Name
        {
            get { return name; }
            set { this.name = value; }
        }
    }
}
