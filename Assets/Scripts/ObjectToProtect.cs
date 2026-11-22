using UnityEngine;

public class ObjectToProtect : Entity
{
    [Space]
    [SerializeField] private Transform player;

    protected override void Update()
    {
        HandleFlip();
    }

    protected override void HandleFlip()
    {
        if (player == null)
            return;

        if (player.transform.position.x > transform.position.x && facingRight == false)
            Flip();
        else if (player.transform.position.x < transform.position.x && facingRight == true)
            Flip();
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.EnableGameOverUI();
    }

    protected override void HandleAnimations()
    {
        anim.SetBool("isGrounded", isGrounded);
    }
}
