using System.Collections.Generic;
using Raccord.Domain.Model.Characters;
using Raccord.Domain.Model.Projects;
using Raccord.Domain.Model.Users;

namespace Raccord.Domain.Model.Cast
{
  public class CastMember : Entity
  {
    private ICollection<Character> _characters;
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Telephone { get; set; }

    public string Email { get; set; }

    public long ProjectID { get; set; }

    public virtual Project Project { get; set; }

    public long? ProjectUserID { get; set; }
    public virtual ProjectUser ProjectUser { get; set; }

    public virtual ICollection<Character> Characters
    {
      get
      {
        return _characters ?? (_characters = new List<Character>());
      }
      set
      {
        _characters = value;
      }
    }
  }
}