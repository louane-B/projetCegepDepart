namespace ProjetCegep
{
    public class CegepDTO
    {
        //propriété publiques
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string CodePostal { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }

        //Constructeur par défaut
        public CegepDTO(string nom = "", string adresse = "", string ville = "", string province = "", string codePostal = "", string telephone = "", string courriel = "")
        {
            Nom = nom;
            Adresse = adresse;
            Ville = ville;
            Province = province;
            CodePostal = codePostal;
            Telephone = telephone;
            Courriel = courriel;

        }

        //Constructeur a partir d'un objet cegep
        public CegepDTO(Cegep leCegep)
        {
            Nom = leCegep.Nom;
            Adresse = leCegep.Adresse;
            Ville = leCegep.Ville;
            Province = leCegep.Province;
            CodePostal = leCegep.CodePostal;
            Telephone = leCegep.Telephone;
            Courriel = leCegep.Courriel;
        }

        public override string ToString()
        {
            return $"{Nom}\n{Adresse}\n{Ville}\n{Province}\n{CodePostal}\n{Telephone}\n{Courriel}";
        }
    }
}