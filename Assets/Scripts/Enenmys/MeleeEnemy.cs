using UnityEngine;

public class MeleeEnemy : Enemycontroller
{
    public Animator animator;

    private float m_Horizontal;
    private float m_Vertical;
    public GameObject m_player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_player = GameObject.Find("Character");

    }

    protected override void Update()
    {
        base.Update();
        Vector3 dir = (m_player.transform.position - this.transform.position).normalized;
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
        animator.SetFloat("Speed", 1);
        Debug.Log("Float");


    }




    public override void Attack()
    {
        Debug.Log("hello");

    }

    

}
