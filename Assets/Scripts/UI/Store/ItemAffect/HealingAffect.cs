public class HealingAffect : ItemAffect
{
    public override void Affect()
    {
        Player player = FindAnyObjectByType<Player>();
        player.ChangeLive(player.currentLive + 1);
    }
}
