using LibreriaLogicaNegocio.Interfaces;
using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaNegocio.Entities
{
    public class Expense: IEntity, IValidation
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Description Description { get; set; }

        public Expense(Name name, Description description)
        {
            Name = name;
            Description = description;
        }

        public Expense() { }
        public void Validate()
        {
           
        }
    }
    
    
}
