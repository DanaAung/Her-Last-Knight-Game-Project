using UnityEngine;


public class Enemy : Entity
{
    private bool playerDetected;

    [Header("Movement details")]
    [SerializeField] protected float moveSpeed = 3.5f;

    protected override void Update()
    {
        base.Update(); 
        HandleAttack();
    }

    protected override void HandleAttack()
    {
        if (playerDetected)
            anim.SetTrigger("attack");
    }

    protected override void HandleMovement()
    {
        if (canMove == true)
            rb.linearVelocity = new Vector2(facingDir * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    protected override void HandleCollision()
    {
        base.HandleCollision();
        playerDetected = Physics2D.OverlapCircle(attackPoint.position,attackRadius,whatIsTarget);
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.AddKillCount();
        if (UI.instance.killCount == 30)
        {
            Time.timeScale = .4f;
            EnableVictory();
        }
    }

    protected void EnableVictory()
    {
        UI.instance.EnableVictoryUI();
    }

    protected override void HandleAnimations()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "DestroyObj")
            Destroy(gameObject);
    }
}
