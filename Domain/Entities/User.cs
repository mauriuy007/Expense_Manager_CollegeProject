using LibreriaLogicaNegocio.Interfaces;
using LibreriaLogicaNegocio.Vo;

namespace LibreriaLogicaNegocio.Entities
{
    public class User : IEntity, IValidation
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }

        public User(Name name, LastName lastName, Email email, Password password, Team team) 
        { 
        
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Team = team;
        }

        public User()
        {

        }
        public void Validate()
        {

        }
    }
}
