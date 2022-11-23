using RPGFaculdade.Components;
using RPGFaculdade.Core.Creatures;

namespace RPGFaculdade.ViewModels
{
    public class CharacterCreation : BaseNotifyProperty
    {
        public string Name { get; set; }
        public string Class { get; set; }


        public Player GetPlayer()
        {
            Player player = null;
            if (Class == "Guerreiro")
            {
                player = new Player(Name, 20, 8, 7, Class);
                player.Equipments.Add(new Core.Items.Item { Name = "Espada Simples", Attack = 5 });
            }
            else if (Class == "Arqueiro")
            {
                player = new Player(Name, 15, 10, 5, Class);
                player.Equipments.Add(new Core.Items.Item { Name = "Arco simples", Attack = 5 });
            }
            else if (Class == "Mago")
            {
                player = new Player(Name, 10, 13, 4, Class);
                player.Equipments.Add(new Core.Items.Item { Name = "Bastão Simples", Attack = 5 });
            }
            else
            {
                player = new Player(Name, 10, 10, 3, "Trabalhador");
                player.Equipments.Add(new Core.Items.Item { Name = "Taco Simples", Attack = 5 });
            }

            player.Equipments.Add(new Core.Items.Item { Name = "Roupão Simples", Defense = 5 });
            return player;
        }
    }
}
