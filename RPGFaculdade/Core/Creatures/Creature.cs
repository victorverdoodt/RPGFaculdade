using RPGFaculdade.Core.Items;
using RPGFaculdade.Core.Things;

namespace RPGFaculdade.Core.Creatures
{
#nullable disable
    public abstract class Creature : Thing
    {
        private int _MaxHealth { get; set; }
        private int _ActualHealth { get; set; }
        private int _BaseAttack { get; set; }
        private int _BaseDefense { get; set; }
        private string _Sprite { get; set; }
        private string _DeadSprite { get; set; }
        private int _Level { get; set; } = 1;

        public int ActualHealth
        {
            get
            {
                return _ActualHealth;
            }
            set
            {
                _ActualHealth = value;
                OnPropertyChanged(nameof(ActualHealth));
            }
        }

        public int MaxHealth
        {
            get
            {
                return _MaxHealth;
            }
            set
            {
                _MaxHealth = value;
                OnPropertyChanged(nameof(MaxHealth));
            }
        }

        public int BaseAttack
        {
            get
            {
                return _BaseAttack;
            }
            set
            {
                _BaseAttack = value;
                OnPropertyChanged(nameof(BaseAttack));
            }
        }

        public int BaseDefense
        {
            get
            {
                return _BaseDefense;
            }
            set
            {
                _BaseDefense = value;
                OnPropertyChanged(nameof(BaseDefense));
            }
        }

        public string Sprite
        {
            get
            {
                return _Sprite;
            }
            set
            {
                _Sprite = value;
                OnPropertyChanged(nameof(Sprite));
            }
        }

        public string DeadSprite
        {
            get
            {
                return _DeadSprite;
            }
            set
            {
                _DeadSprite = value;
                OnPropertyChanged(nameof(DeadSprite));
            }
        }

        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public bool IsAlive()
        {
            if (ActualHealth <= 0)
                return false;

            return true;
        }

        public override bool IsCreature()
        {
            return true;
        }

        public abstract int GetMaxTotalHealth();
        public abstract int GetTotalAttack(Item item);
        public abstract int GetTotalDefense();
    }
}
