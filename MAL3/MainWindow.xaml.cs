using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAL3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MalAppDBEntities context = new MalAppDBEntities();
        CollectionViewSource anime_ilosc_ver2ViewSource;
        CollectionViewSource animelist_1538511199_3585579ViewSource;
        public MainWindow()
        {
            InitializeComponent();
            anime_ilosc_ver2ViewSource = (CollectionViewSource)FindResource("anime_ilosc_ver2ViewSource");
            animelist_1538511199_3585579ViewSource = (CollectionViewSource)FindResource("animelist_1538511199_3585579ViewSource");
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.anime_ilosc_ver2.Load();
            context.animelist_1538511199_3585579.Load();
            anime_ilosc_ver2ViewSource.Source = context.anime_ilosc_ver2.Local;
            animelist_1538511199_3585579ViewSource.Source = context.animelist_1538511199_3585579.Local;
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            anime_ilosc_ver2ViewSource.View.MoveCurrentToFirst();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            anime_ilosc_ver2ViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            anime_ilosc_ver2ViewSource.View.MoveCurrentToNext();
        }
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            anime_ilosc_ver2ViewSource.View.MoveCurrentToLast();
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            context.SaveChanges();
        }
    }
}
