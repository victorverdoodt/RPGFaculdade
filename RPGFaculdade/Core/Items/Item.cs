using RPGFaculdade.Core.Things;

namespace RPGFaculdade.Core.Items
{
    public class Item : Thing
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Durability { get; set; }


        public void SetAttack(int attack)
        {
            Attack = attack;
        }

        public void SetDefense(int attack)
        {
            Attack = attack;
        }

        public void SetDurability()
        {
            Durability = Durability;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public int GetDefense()
        {
            return Defense;
        }

        public int GetDurability()
        {
            return Durability;
        }

        public override bool IsCreature()
        {
            return false;
        }

        public override bool IsItem()
        {
            return true;
        }

        public override bool IsMonter()
        {
            return false;
        }

        public override bool IsPlayer()
        {
            return false;
        }
    }
}
