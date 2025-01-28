using UnityEngine;

public class MeleeEnemy : Enemycontroller
{
    public Animator animator;

    private float m_Horizontal;
    private float m_Vertical;
    public new GameObject m_player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_player = GameObject.Find("Character");
        m_Damage = 10;

    }

    protected override void Update()
    {
        base.Update();
        Vector3 dir = (m_player.transform.position - this.transform.position).normalized;
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", 1);
       


    }




    public override void Attack()
    {
        
        animator.SetTrigger("Attacking");
        
        M_speed = 0;

    }

    public override void AddDificulty(int D, int H)
    {
        m_Damage += D;
        gameObject.GetComponent<EnemyHealthScript>().AddHealth(H);
        
    }
}
