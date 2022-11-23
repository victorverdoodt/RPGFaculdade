using RPGFaculdade.Core.Items;
using System;
using System.Collections.ObjectModel;

namespace RPGFaculdade.Core.Creatures
{
#nullable disable
    public class Player : Creature
    {
        private double _ActualExperience { get; set; }
        public ObservableCollection<Item> Equipments { get; set; }
        private int _Gold { get; set; }
        public Player(string nome, int health, int attack, int defense, string sprite)
        {
            Equipments = new ObservableCollection<Item>();
            BaseAttack = attack;
            BaseDefense = defense;
            Name = nome;
            MaxHealth = health;
            ActualHealth = health;
            var Base = AppDomain.CurrentDomain.BaseDirectory;
            Sprite = $"{Base}/Imagem/Player/{sprite}.png";

        }

        public double ActualExperience
        {
            get
            {
                return _ActualExperience;
            }
            set
            {
                _ActualExperience = value;
                OnPropertyChanged(nameof(ActualExperience));
            }
        }
        public int Gold
        {
            get
            {
                return _Gold;
            }
            set
            {
                _Gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public void AddExperience(double quantity)
        {
            if ((ActualExperience + quantity) >= (100 * Level))
            {
                Level += 1;
                ActualExperience = 0;
                ActualHealth = MaxHealth;
            }
            else
            {
                ActualExperience += quantity;
            }
        }

        public void AddGold(int quantity)
        {
            Gold += quantity;
        }

        public int DoAttack(ref Monster monster, Item item)
        {
            var attackFormula = GetTotalAttack(item) - monster.GetTotalDefense();
            monster.ActualHealth -= attackFormula;
            return attackFormula;
        }

        public override int GetTotalAttack(Item item)
        {
            int extraAttack = 0;
            if (item != null)
                extraAttack = item.GetAttack();

            return BaseAttack + extraAttack + (Level * 5);
        }

        public override int GetTotalDefense()
        {
            int extraDefense = 0;
            foreach (Item item in Equipments)
            {
                if (item != null)
                    extraDefense += item.GetDefense();
            }

            return BaseDefense + extraDefense + (Level * 5);
        }

        public override int GetMaxTotalHealth()
        {

            return MaxHealth + (5 * Level);
        }

        public override bool IsItem()
        {
            return false;
        }

        public override bool IsMonter()
        {
            return false;
        }

        public override bool IsPlayer()
        {
            return true;
        }
    }
}
