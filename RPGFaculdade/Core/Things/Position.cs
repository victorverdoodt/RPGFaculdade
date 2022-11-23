using RPGFaculdade.Core.Creatures;
using System;
using System.Collections.Generic;

namespace RPGFaculdade.Core.Things
{
    public class Position
    {
        public Position(int x, int y, string nome = "", string desc = "", string image = "Home")
        {
            X = x;
            Y = y;
            Nome = nome;
            Desc = desc;
            var Base = AppDomain.CurrentDomain.BaseDirectory;
            Image = $"{Base}/Imagem/Location/{image}.png";
        }

        public int X { get; set; }
        public int Y { get; set; }

        public string Nome { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }

        public Monster GenerateMonster()
        {
            string[] names = { "GiantSpider", "Snake", "Rat" };
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, names.Length);


            return new Monster(names[randomNumber], 10 + rnd.Next(1, 5), 10 + rnd.Next(1, 5), 10 + rnd.Next(1, 5), names[randomNumber], names[randomNumber]);
        }
        public ICollection<Monster> GetCreatures()
        {

            List<Monster> monsters = new List<Monster>();
            for (int i = 0; i < 3; i++)
            {

                monsters.Add(GenerateMonster());
            }

            return monsters;
        }

        public Position GeraLugar()
        {
            string[] names = { "SpiderForest", "FarmFields", "HerbalistsGarden" };
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, names.Length);


            return new Position(0, 0, names[randomNumber], names[randomNumber], names[randomNumber]);
        }
    }
}
