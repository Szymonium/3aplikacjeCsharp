namespace SportsTeamManagementSystem;

public class Team
{
    public List<Player> Members;

    public Team(List<Player> members)
    {
        Members = members;
    }
}