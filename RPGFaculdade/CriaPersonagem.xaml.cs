using RPGFaculdade.ViewModels;
using System.Windows;

namespace RPGFaculdade
{
    /// <summary>
    /// Lógica interna para CriaPersonagem.xaml
    /// </summary>
    public partial class CriaPersonagem : Window
    {
        private CharacterCreation Char { get; set; }
        public CriaPersonagem()
        {
            InitializeComponent();
            Char = new CharacterCreation();
            DataContext = Char;
        }

        private void UseThisPlayer_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Char.GetPlayer());
            mainWindow.Show();
            Close();
        }
    }
}
