namespace Raccord.Application.Core.Services.Cast
{
  public class CastMemberDto
  {
    public long ID { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Telephone { get; set; }

    public string Email { get; set; }

    public long ProjectID { get; set; }
  }
}