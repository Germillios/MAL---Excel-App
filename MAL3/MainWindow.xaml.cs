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
        CollectionViewSource anime_ilosc_ver2ViewSource, animelist_1538511199_3585579ViewSource, manga_iloscViewSource, mangalist_1538511219_3585579ViewSource;
        CollectionViewSource selectedViewSource;
        public MainWindow()
        {
            InitializeComponent();
            //List<anime_ilosc_ver2> items = new List<anime_ilosc_ver2>();
            //items.Add(new anime_ilosc_ver2 { Nazwa = "Anime 20" });
            //SearchResultsA.ItemsSource = items;
            anime_ilosc_ver2ViewSource = (CollectionViewSource)FindResource("anime_ilosc_ver2ViewSource");
            animelist_1538511199_3585579ViewSource = (CollectionViewSource)FindResource("animelist_1538511199_3585579ViewSource");
            manga_iloscViewSource = (CollectionViewSource)FindResource("manga_iloscViewSource");
            mangalist_1538511219_3585579ViewSource = (CollectionViewSource)FindResource("mangalist_1538511219_3585579ViewSource");
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.anime_ilosc_ver2.Load();
            context.animelist_1538511199_3585579.Load();
            context.manga_ilosc.Load();
            context.mangalist_1538511219_3585579.Load();
            anime_ilosc_ver2ViewSource.Source = context.anime_ilosc_ver2.Local;
            animelist_1538511199_3585579ViewSource.Source = context.animelist_1538511199_3585579.Local;
            manga_iloscViewSource.Source = context.manga_ilosc.Local;
            mangalist_1538511219_3585579ViewSource.Source = context.mangalist_1538511219_3585579.Local;
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            selectedViewSource.View.MoveCurrentToFirst();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            selectedViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            selectedViewSource.View.MoveCurrentToNext();
        }
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            selectedViewSource.View.MoveCurrentToLast();
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            context.SaveChanges();
            selectedViewSource.View.Refresh();
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (AnimeSelected.IsChecked == true)
            {
                anime_ilosc_ver2 new_anime_Ilosc_Ver2 = new anime_ilosc_ver2
                {
                    Title = titleTextBoxNew.Text,
                    Score = int.Parse(scoreTextBoxNew.Text),
                    Watched_episodes = int.Parse(watched_episodes_or_read_chaptersTextBoxNew.Text),
                    Episodes = int.Parse(episodes_or_chaptersTextBoxNew.Text),
                    Type = typeTextBoxNew.Text,
                    My_status = my_statusTextBoxNew.Text,
                    Genres = genresTextBoxNew.Text,
                    Additional_information = additional_informationTextBoxNew.Text
                };
                int length = context.anime_ilosc_ver2.Local.Count();
                int pos = length;
                context.anime_ilosc_ver2.Local.Insert(pos, new_anime_Ilosc_Ver2);
                context.SaveChanges();
                AppTabControl.SelectedItem = AnimeList;
                anime_ilosc_ver2ViewSource.View.Refresh();
                anime_ilosc_ver2ViewSource.View.MoveCurrentTo(new_anime_Ilosc_Ver2);
            }
            if (MangaSelected.IsChecked == true)
            {
                manga_ilosc new_manga_Ilosc = new manga_ilosc
                {
                    Title = titleTextBoxNew.Text,
                    Score = int.Parse(scoreTextBoxNew.Text),
                    Read_chapters = int.Parse(watched_episodes_or_read_chaptersTextBoxNew.Text),
                    Chapters = int.Parse(episodes_or_chaptersTextBoxNew.Text),
                    Read_volumes = int.Parse(read_volumesTextBoxNew.Text),
                    Volumes = int.Parse(volumesTextBoxNew.Text),
                    Type = typeTextBoxNew.Text,
                    My_status = my_statusTextBoxNew.Text,
                    Genres = genresTextBoxNew.Text,
                    Additional_information = additional_informationTextBoxNew.Text
                };
                int length = context.manga_ilosc.Local.Count();
                int pos = length;
                context.manga_ilosc.Local.Insert(pos, new_manga_Ilosc);
                context.SaveChanges();
                AppTabControl.SelectedItem = MangaList;
                manga_iloscViewSource.View.Refresh();
                manga_iloscViewSource.View.MoveCurrentTo(new_manga_Ilosc);
            }
            foreach (UIElement element in newItemTextBoxesPanel.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox textBoxes = (TextBox)element;
                    if (textBoxes != null)
                        textBoxes.Text = String.Empty;
                }
                if (element.GetType() == typeof(StackPanel))
                {
                    StackPanel stackPanel = element as StackPanel;
                    foreach (UIElement elementSP in stackPanel.Children)
                    {
                        if (elementSP.GetType() == typeof(TextBox))
                        {
                            TextBox textBoxesInSP = (TextBox)elementSP;
                            if (textBoxesInSP != null)
                                textBoxesInSP.Text = String.Empty;
                        }
                    }
                }
            }
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (UIElement element in newItemTextBoxesPanel.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    TextBox textBoxes = (TextBox)element;
                    if (textBoxes != null)
                        textBoxes.Text = String.Empty;
                }
                if (element.GetType() == typeof(StackPanel))
                {
                    StackPanel stackPanel = element as StackPanel;
                    foreach (UIElement elementSP in stackPanel.Children)
                    {
                        if (elementSP.GetType() == typeof(TextBox))
                        {
                            TextBox textBoxesInSP = (TextBox)elementSP;
                            if (textBoxesInSP != null)
                                textBoxesInSP.Text = String.Empty;
                        }
                    }
                }
            }
        }
        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (selectedViewSource == anime_ilosc_ver2ViewSource)
            {
                var current = anime_ilosc_ver2ViewSource.View.CurrentItem as anime_ilosc_ver2;
                var anime = (from c in context.anime_ilosc_ver2 where c.ID == current.ID select c).FirstOrDefault();
                if (anime != null)
                    context.anime_ilosc_ver2.Remove(anime);
                context.SaveChanges();
                anime_ilosc_ver2ViewSource.View.Refresh();
            }
            if (selectedViewSource == manga_iloscViewSource)
            {
                var current = manga_iloscViewSource.View.CurrentItem as manga_ilosc;
                var manga = (from c in context.manga_ilosc where c.ID == current.ID select c).FirstOrDefault();
                if (manga != null)
                    context.manga_ilosc.Remove(manga);
                context.SaveChanges();
                manga_iloscViewSource.View.Refresh();
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (AnimeList.IsSelected)
                    selectedViewSource = anime_ilosc_ver2ViewSource;
                if (MangaList.IsSelected)
                    selectedViewSource = manga_iloscViewSource;
            }
        }
    }
}