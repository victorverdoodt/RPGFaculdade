using RPGFaculdade.Core.Creatures;
using RPGFaculdade.Events;
using RPGFaculdade.ViewModels;
using System.Windows;
using System.Windows.Documents;


namespace RPGFaculdade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Engine engine { get; set; }
        public MainWindow(Player player)
        {
            InitializeComponent();
            engine = new(player);
            engine.OnMessageRaised += OnGameMessageRaised;
            DataContext = engine;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            engine.PlayerAttack(engine.GetTarget());
        }

        private void Target0_Click(object sender, RoutedEventArgs e)
        {
            engine.SetTarget(0);
        }

        private void Target1_Click(object sender, RoutedEventArgs e)
        {
            engine.SetTarget(1);
        }

        private void Target2_Click(object sender, RoutedEventArgs e)
        {
            engine.SetTarget(2);
        }

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e)
        {
            engine.Move(0);
        }
        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            engine.Move(3);
        }
        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            engine.Move(1);
        }
        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            engine.Move(2);
        }

        private void OnGameMessageRaised(object sender, MessageEvent e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
    }
}
