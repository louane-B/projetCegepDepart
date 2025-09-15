namespace ProjetCegep.DTO
{
    public class DepartementDTO
    {
        //propriété publique
        public string No { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        //constructeur par défaut
        public DepartementDTO(string no = "", string nom = "", string description = "")
        {
            No = no;
            Nom = nom;
            Description = description;
        }

        //constructeur a partir d'un objet Departement
        public DepartementDTO(Departement leDepartement)
        {
            No = leDepartement.No;
            Nom = leDepartement.Nom;
            Description = leDepartement.Description;
        }

        public override string ToString()
        {
            return $"{No}\n{Nom}\n{Description}";
        }
    }
}