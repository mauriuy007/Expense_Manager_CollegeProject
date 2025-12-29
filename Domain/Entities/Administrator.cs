using LibreriaLogicaNegocio.Vo; 

namespace LibreriaLogicaNegocio.Entities
{
    public class Administrator : User
    {
        public Administrator(Name name, LastName lastName, Email email, Password password, Team team) : base(name, lastName, email, password, team)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Team = team;
        }
        public Administrator() { }
    }
}
