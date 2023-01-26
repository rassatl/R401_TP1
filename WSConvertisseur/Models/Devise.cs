using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    /// <summary>
    /// The Class of this project
    /// </summary>
    public class Devise
    {
        /// <summary>
        /// The constructor of the class
        /// </summary>
        /// <param name="id">the id of the currency</param>
        /// <param name="nomDevise">the name the currency</param>
        /// <param name="taux">the taux of the currency</param>
        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }
        /// <summary>
        /// The empty constructor of the class
        /// </summary>
        public Devise()
        {
        }

        private int id;
        /// <summary>
        /// The id property
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string? nomDevise;
        /// <summary>
        /// The name property
        /// </summary>
        [Required]
        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }

        private double taux;
        /// <summary>
        /// The taux property
        /// </summary>
        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }
    }
}
