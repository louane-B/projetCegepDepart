namespace ProjetCegep.DTO
{
    public class EnseignantDTO
    {
        public int NoEmploye { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string CodePostal { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public string DateEmbauche { get; set; }
        public string DateArret { get; set; }

        //constructeur par défaut
        public EnseignantDTO(int noEmploye = "", string nom = "", string prenom = "", string adresse = "", string ville = "", string province = "", string codePostal = "", string telephone = "", string courriel = "", string dateEmbauche = "", string dateArret = "")
        {
            NoEmploye = noEmploye;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            CodePostal = codePostal;
            Telephone = telephone;
            Courriel = courriel;
            DateEmbauche = dateEmbauche;
            DateArret = dateArret;
        }

        //Constructeur a partir d'un objet Enseignant
        public EnseignantDTO(Enseignant Lenseignant)
        {
            NoEmploye = Lenseignant.NoEmploye;
            Nom = Lenseignant.Nom;
            Prenom = Lenseignant.Prenom;
            Adresse = Lenseignant.Adresse;
            Ville = Lenseignant.Ville;
            Province = Lenseignant.Province;
            CodePostal = Lenseignant.CodePostal;
            Telephone = Lenseignant.Telephone;
            Courriel = Lenseignant.Courriel;
            DateEmbauche = Lenseignant.DateEmbauche;
            DateArret = Lenseignant.DateArret;
        }

        public override string ToString()
        {
            return $"{NoEmploye}\n{Nom}\n{Prenom}\n{Adresse}\n{Ville}\n{Province}\n{CodePostal}\n{Telephone}\n{Courriel}\n{DateEmbauche}\n{DateArret}";
        }

    }
}