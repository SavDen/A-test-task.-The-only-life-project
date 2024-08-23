using UnityEngine;
using UnityEngine.AI;

public class AnimEvents : MonoBehaviour
{
    public Player Player;
    public Enemy Enemy;

    public void PlayerAttack()
    {
        Player.TakeHit();
    }

    public void PlayAttackSound()
    {
        Player.PlayAttackSound();
    }

    public void EnemyAttack()
    {
        Enemy.TakeHit();
    }

    public void AddCountDead()
    {
        Enemy.AddCountKill();
    }

    public void StopAgent(int state)
    {
        Enemy.StopAgent(state);
    }

}
