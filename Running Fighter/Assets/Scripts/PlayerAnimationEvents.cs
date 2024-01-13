using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void AnimationTrigger(){
        player.StopAttacking();
    }
}
