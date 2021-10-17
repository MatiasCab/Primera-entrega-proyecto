using System;

namespace Hello
{
    public class Entity
    {
        private string name;

        private string ubication;

        private string rubro;

        Entity(string name, string ubication, string rubro)
        {
            this.Name = name;
            this.Ubication = ubication;
            this.Rubro = rubro;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Ubication
        {
            get
            {
                return this.ubication;
            }
            set
            {
                this.ubication = value;
            }
        }

        public string Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value;
            }
        }

    }
}