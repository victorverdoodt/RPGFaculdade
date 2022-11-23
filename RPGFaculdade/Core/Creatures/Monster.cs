using RPGFaculdade.Core.Items;
using System;

namespace RPGFaculdade.Core.Creatures
{
#nullable disable
    public class Monster : Creature
    {
        public Monster(string nome, int health, int attack, int defense, string sprite, string dead, int level = 1)
        {
            BaseAttack = attack;
            BaseDefense = defense;
            Name = nome;
            MaxHealth = health;
            ActualHealth = MaxHealth;
            var Base = AppDomain.CurrentDomain.BaseDirectory;
            Sprite = $"{Base}/Imagem/Monsters/{sprite}.png";

            DeadSprite = dead;
            Level = level;
        }
        public int DoAttack(ref Player player)
        {
            var attackFormula = GetTotalAttack(null) - player.GetTotalDefense();

            if (attackFormula > 0)
            {
                player.ActualHealth -= attackFormula;
                return attackFormula;
            }

            return 0;
        }

        public override int GetMaxTotalHealth()
        {
            return MaxHealth + (Level * 5);
        }

        public override int GetTotalAttack(Item item)
        {
            return BaseAttack + (Level * 5);
        }

        public override int GetTotalDefense()
        {
            return BaseDefense + (Level * 5);
        }

        public override bool IsItem()
        {
            return false;
        }

        public override bool IsMonter()
        {
            return true;
        }

        public override bool IsPlayer()
        {
            return false;
        }
    }
}
