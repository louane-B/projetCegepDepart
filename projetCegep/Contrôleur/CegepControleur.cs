using System;

namespace ProjetCegep
{
    public class CegepControleur
    {
        // Singleton
        private static CegepControleur instance = null;
        public static CegepControleur Instance
        {
            get
            {
                if (instance == null)
                    instance = new CegepControleur();
                return instance;
            }
        }

         // Attribut privé pour stocker le cégep
        private Cegep cegepActuel;

        // Constructeur privé
        private CegepControleur()
        {
            cegepActuel = null;
        }

        // Créer un cégep à partir d’un DTO
        public bool CreerCegep(CegepDTO dto)
        {
            if (dto == null || cegepActuel != null)
                return false;
            
            cegepActuel = new Cegep(
                dto.Nom,
                dto.Adresse,
                dto.Ville,
                "", // Province non incluse dans DTO
                dto.CodePostal,
                dto.Telephone,
                dto.Courriel
            );

            return cegepActuel != null;
        }

        // Obtenir le cégep actuel sous forme de DTO
        public CegepDTO ObtenirCegep()
        {
            if (cegepActuel == null)
                return null;

            return new CegepDTO(cegepActuel);
        }

        // Modifier le cégep actuel avec un nouveau DTO
        public bool ModifierCegep(CegepDTO dto)
        {
            if (dto == null || cegepActuel == null)
                return false;

            cegepActuel.Nom = dto.Nom;
            cegepActuel.Adresse = dto.Adresse;
            cegepActuel.Ville = dto.Ville;
            cegepActuel.CodePostal = dto.CodePostal;
            cegepActuel.Telephone = dto.Telephone;
            cegepActuel.Courriel = dto.Courriel;

            return true;
        }

        // Supprimer le cégep actuel
        public bool SupprimerCegep()
        {
            if (cegepActuel == null)
                return false;

            cegepActuel = null;
            return true;
        }
    }
}






