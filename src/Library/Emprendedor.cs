using System;
using System.Collections.Generic;

namespace Proyect
{
    public class Emprendedor : Entity
    {
        private string qualifications;

        private string specializations;

        private List<Offer> purchasedOffer;

        Emprendedor(string name, string ubication, string rubro, string qualifications, string specializations):base(name,ubication,rubro)
        {
            this.Qualifications = qualifications;
            this.Specializations = specializations;
        }

        public string Qualifications
        {
            get
            {
                return this.qualifications;
            }
            set
            {
                this.qualifications = value;
            }
        }

        public string Specializations
        {
            get
            {
                return this.specializations;
            }
            set
            {
                this.specializations = value;
            }
        }

        public void SearchByKeywords(string keywords)
        {
            string[] keywords = keywords.Split(" ");

        }

        public void SearchByUbications(string ubication)
        {

        }

        public void SearchByType(string tipo)
        {
            
        }

        private void AceptOffer(Offer oferta)
        {
            this.purchasedOffer.Add(oferta);
            oferta.Buyer = this;
        }
    }
}