using UnityEngine;

public class JumpMushroom : MonoBehaviour, IGroundPoundEffect
{
    [SerializeField] private Animator animator;
    [SerializeField] private float strength = 2.0f;

    public void ApplyEffect(GameObject other)
    {
        var player = other.GetComponent<CharacterController2D>();
        if (player)
        {
            player.Jump(true, strength);
        }
    }

    public void GetPounded()
    {
        animator.SetTrigger("Pounded");
    }
}

public interface IGroundPoundEffect
{
    public void GetPounded();
    public void ApplyEffect(GameObject other);
}
