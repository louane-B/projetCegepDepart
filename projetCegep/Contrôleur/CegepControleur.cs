using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.linq;
using ProjetCegep.DTO;
using ProjetCegep.model;

namespace ProjetCegep.Contrôleur
{
    public class CegepControleur
    {
        // Singleton
        private static CegepControleur _instance;
        public static CegepControleur Instance => _instance ??= new CegepControleur();


        // Données internes
        private CegepDTO _cegep;
        private List<DepartementDTO> _departement;
        private Dictionary<string, List<EnseignantDTO>> _enseignantsParDepartement;


        // Constructeur privé
        private CegepControleur()
        {
            _departement = new List<DepartementDTO>();
            _enseignantsParDepartement = new Dictionary<string, List<EnseignantDTO>>();
        }

        // Méthodes de gestion du Cegep
        public bool CreerCegep(CegepDTO cegep)
        {
            if (cegep == null) return false;
            _cegep = cegep;
            return true;
        }

        public CegepDTO ObtenirCegep() => _cegep;

        public bool ModifierCegep(CegepDTO cegep)
        {
            if (_cegep == null || cegep == null) return false;
            _cegep = cegep;
            return true;
        }

        public bool SupprimerCegep()
        {
            if (_cegep == null) return false;
            _cegep = null;
            _departements.Clear();
            _enseignantsParDepartement.Clear();
            return true;
        }

        // Méthodes de gestion des départements
        public List<DepartementDTO> ObtenirListeDepartement() => _departement;

        public DepartementDTO ObtenirDepartement(DepartementDTO departement)
        {
            return _departement.FirstOrDefault(d => d.No == departement.No);
        }

        public bool AjouterDepartement(DepartementDTO departement)
        {
            if (departement == null || _departement.Any(d => d.No == departement.No)) return false;
            _departement.Add(departement);
            _enseignantsParDepartement[departement.No] = new List<EnseignantDTO>();
            return true;
        }

        public bool SuprimerDepartement(DepartementDTO departement)
        {
            var toRemove = _departement.FirstOrDefault(d => d.No == departement.No);
            if (toRemove == null) return false;
            _departement.Remove(toRemove);
            _enseignantsParDepartement.Remove(departement.No);
            return true;
        }

        // Méthodes de gestion des enseignants

        public List<EnseignantDTO> ObtenirListEnseignant(DepartementDTO departement)
        {
            return _enseignantsParDepartement.TryGetValue(departement.No, out var liste) ? liste : new List<EnseignantDTO>();
        }

        public EnseignantDTO ObtenirEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            return ObtenirListEnseignant(departement).FirstOrDefault(e => e.NoEmploye == enseignant.NoEmploye);
        }

        public bool AjouterEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            var liste = ObtenirListEnseignant(departement);
            if (liste.Any(e => e.NoEmploye == enseignant.NoEmploye)) return false;
            liste.Add(enseignant);
            return true;
        }

        public bool ModifierEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            var liste = ObtenirListEnseignant(departement);
            var index = liste.FindIndex(e => e.NoEmploye == enseignant.NoEmploye);
            if (index == -1) return false;
            liste[index] = enseignant;
            return true;
        }

        public bool SupprimerEnseignant(DepartementDTO departement, EnseignantDTO enseignant)
        {
            var liste = ObtenirListEnseignant(departement);
            var toRemove = liste.FirstOrDefault(e => e.NoEmploye == enseignant.NoEmploye);
            if (toRemove == null) return false;
            liste.Remove(toRemove);
            return true;
        }

        // Méthodes de persistance
       public void ChargerDonneesFichier()
        {
            if (!File.Exists(FichierDonnees)) return;

            string json = File.ReadAllText(FichierDonnees);

            var donnees = JsonSerializer.Deserialize<DonneesCegep>(json);
            if (donnees != null)
            {
                _cegep = donnees.Cegep;
                _departements = donnees.Departements ?? new List<DepartementDTO>();
                _enseignantsParDepartement = donnees.EnseignantsParDepartement ?? new Dictionary<string, List<EnseignantDTO>>();
            }
        }


        public void SauvegarderDonneesFichier()
        {
            var donnees = new DonneesCegep
            {
                Cegep = _cegep,
                Departements = _departements,
                EnseignantsParDepartement = _enseignantsParDepartement
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(donnees, options);
            File.WriteAllText(FichierDonnees, json);
        }

    }
}
