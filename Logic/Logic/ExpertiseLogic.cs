using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using DAOInterface.Interface;
using DAOInterface.DTOs;

namespace Logic.Logic
{
    public class ExpertiseLogic
    {
        public IExpertiseDOA _expertiseDOA { get; set; }

        public ExpertiseLogic(IExpertiseDOA expertiseDOA)
        {
            _expertiseDOA = expertiseDOA;
        }

        public List<Expertise> GetAllExpertises()
        {
            List<Expertise> returnExpertises = new();
            List<ExpertiseDTO> expertiseDTOs = _expertiseDOA.GetAllExpertises();

            foreach (var expertise in expertiseDTOs)
            {
                returnExpertises.Add(new Expertise()
                {
                    ID = expertise.ID,
                    Beschrijving = expertise.Beschrijving,
                    Name = expertise.Name
                });
            }

            return returnExpertises;
        }

        public Expertise GetExpertise(int id)
        {
            ExpertiseDTO expertise = _expertiseDOA.GetExpertise(id);

            return new Expertise()
            {
                ID = expertise.ID,
                Beschrijving = expertise.Beschrijving,
                Name = expertise.Name
            };
        }

        public List<Expertise> GetExpertisesFromUser(int userid)
        {
            List<ExpertiseDTO> expertiseDTOs = _expertiseDOA.GetExpertiseFromUser();

        }

        public Expertise AddExpertise(Expertise expertise)
        {
            int id = _expertiseDOA.AddExpertise(new ExpertiseDTO()
            {
                Name = expertise.Name,
                Beschrijving = expertise.Beschrijving
            });

            expertise.ID = id;

            return expertise;
        }

        
    }
}
