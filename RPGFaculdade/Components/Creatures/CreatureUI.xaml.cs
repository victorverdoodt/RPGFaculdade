using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RPGFaculdade.Components.Creatures
{
    /// <summary>
    /// Interação lógica para CreatureUI.xam
    /// </summary>
#nullable disable
    public partial class CreatureUI : UserControl
    {
        public CreatureUI()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AttackTextProperty = DependencyProperty.Register("AttackText", typeof(String), typeof(CreatureUI), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty HealthTextProperty = DependencyProperty.Register("HealthText", typeof(String), typeof(CreatureUI), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty DefenseTextProperty = DependencyProperty.Register("DefenseText", typeof(String), typeof(CreatureUI), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty NameTextProperty = DependencyProperty.Register("NameText", typeof(String), typeof(CreatureUI), new FrameworkPropertyMetadata(string.Empty));
        public static readonly DependencyProperty SpriteProperty = DependencyProperty.Register("Sprite", typeof(ImageSource), typeof(CreatureUI), null);
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("ColorBorder", typeof(Brush), typeof(CreatureUI), null);

        public event PropertyChangedEventHandler PropertyChanged;

        public ImageSource Sprite
        {
            get { return (ImageSource)GetValue(SpriteProperty); }
            set
            {
                SetValue(SpriteProperty, value);
            }
        }
        public String AttackText
        {
            get { return GetValue(AttackTextProperty).ToString(); }
            set
            {
                SetValue(AttackTextProperty, value);
            }
        }

        public String DefenseText
        {
            get { return GetValue(DefenseTextProperty).ToString(); }
            set
            {
                SetValue(DefenseTextProperty, value);
            }
        }

        public String HealthText
        {
            get { return GetValue(HealthTextProperty).ToString(); }
            set
            {
                SetValue(HealthTextProperty, value);
            }
        }

        public Brush ColorBorder
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public String NameText
        {
            get { return GetValue(NameTextProperty).ToString(); }
            set
            {
                SetValue(NameTextProperty, value);
            }
        }
    }
}
