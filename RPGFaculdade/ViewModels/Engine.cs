using RPGFaculdade.Components;
using RPGFaculdade.Core.Creatures;
using RPGFaculdade.Core.Items;
using RPGFaculdade.Core.Things;
using RPGFaculdade.Events;
using System;
using System.Collections.ObjectModel;

namespace RPGFaculdade.ViewModels
{
    public class Engine : BaseNotifyProperty
    {
        private int? _Target = null;
        private Player _ActPlayer { get; set; }
        private Position _ActPos { get; set; }
        public ObservableCollection<Monster> Creatures { get; set; }
        public Item ActWeapon { get; set; }
        private void Log(string message)
        {
            OnMessageRaised?.Invoke(this, new MessageEvent(message));
        }
        public Engine(Player initalPlayer)
        {
            ActPlayer = initalPlayer;
            Creatures = new ObservableCollection<Monster>();
            ActPos = new Position(0, 0);
        }

        public Position ActPos
        {
            get { return _ActPos; }
            set
            {
                _ActPos = value;

                OnPropertyChanged(nameof(ActPos));
                ActPos.GeraLugar();
                GetCreatures();
            }
        }

        private void GetCreatures()
        {
            Creatures.Clear();
            var gen = ActPos.GetCreatures();
            foreach (var item in gen)
            {
                Creatures.Add(item);
            }
        }

        public Player ActPlayer
        {
            get
            {
                return _ActPlayer;
            }
            set
            {
                _ActPlayer = value;
                OnPropertyChanged(nameof(ActPlayer));
            }
        }


        public event EventHandler<MessageEvent> OnMessageRaised;

        public void SetTarget(int? target)
        {
            if (ActPlayer != null)
            {
                if (target.HasValue)
                {
                    _Target = target.Value;
                    var targetObj = Creatures[(int)target];
                    Log($"Player: {ActPlayer?.Name} colocou como alvo {targetObj.Name}\n");
                }
            }

            _Target = target;
        }

        public int? GetTarget()
        {
            return _Target;
        }

        public void PlayerAttack(int? pos)
        {
            if (pos != null)
            {
                var monster = Creatures[(int)pos];
                var player = ActPlayer;
                if (monster != null && player != null)
                {
                    if (monster.IsAlive())
                    {
                        var dmg = player.DoAttack(ref monster, ActWeapon);
                        if (dmg > 0)
                        {
                            Log($"Jogador: {player.Name} atacou {monster.Name} com {dmg} de dano.\n");
                        }
                        else
                        {
                            Log($"Jogador: {player.Name} atacou {monster.Name} mas não teve nenhum efeito.\n");
                        }
                        if (!monster.IsAlive())
                        {
                            var expBase = 50;
                            player.AddExperience(expBase);
                            player.AddGold(10);
                            SetTarget(null);
                            Log($"Jogador: {player.Name} matou o {monster.Name} e recebeu Exp: {expBase} e {10} gold.\n");
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            MonsterAttack(i);
                        }
                    }
                    else
                    {
                        Log($"Error: monstro morto\n");
                    }

                }
            }
            else
            {
                Log($"Selecione um alvo antes de atacar\n");
            }
        }

        public void MonsterAttack(int pos)
        {
            var monster = Creatures[pos];
            var player = ActPlayer;
            if (monster != null && player != null)
            {
                if (monster.IsAlive())
                {
                    if (ActPlayer.IsAlive())
                    {
                        var dmg = monster.DoAttack(ref player);
                        if (dmg > 0)
                        {
                            Log($"Monstro: {monster.Name} atacou {player.Name} com {dmg} de dano.\n");
                        }
                        else
                        {
                            Log($"Monstro: {monster.Name} atacou {player.Name} mas não deu nenhum dano.\n");
                        }

                    }
                    else
                    {
                        Log($"Error: player morto\n");
                    }
                }
            }
        }

        public void Move(int dir)
        {
            Position VirtualLocation = null;

            switch (dir)
            {
                case 0: //Norte
                    VirtualLocation = ActPos.GeraLugar();
                    break;
                case 1: //Leste
                    VirtualLocation = ActPos.GeraLugar();
                    break;
                case 2: //Sul
                    VirtualLocation = ActPos.GeraLugar();
                    break;
                case 3: //Oeste
                    VirtualLocation = ActPos.GeraLugar();
                    break;
            }

            ActPos = VirtualLocation;
        }
    }
}
