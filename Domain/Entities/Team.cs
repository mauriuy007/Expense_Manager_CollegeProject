using LibreriaLogicaNegocio.Interfaces;
using LibreriaLogicaNegocio.Vo;


namespace LibreriaLogicaNegocio.Entities
{
    public class Team : IEntity, IValidation
    {
        public int Id { get; set; }
        public Name Name { get; set; } 
        public Team(Name name)
        {
            Name = name;
        }
        public Team()
        {

        }
        public void Validate()
        {

        }
    }
    
  
}
