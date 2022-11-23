using RPGFaculdade.Components;
using System;

namespace RPGFaculdade.Core.Things
{
#nullable disable
    public abstract class Thing : BaseNotifyProperty, IDisposable
    {
        private string _Name { get; set; }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public abstract bool IsCreature();
        public abstract bool IsPlayer();
        public abstract bool IsMonter();
        public abstract bool IsItem();



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
