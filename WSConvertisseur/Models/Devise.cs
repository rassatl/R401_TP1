using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }

        public Devise()
        {
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string? nomDevise;
        [Required]
        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }

        private double taux;

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }
    }
}
