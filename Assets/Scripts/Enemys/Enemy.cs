using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region static params
    public Animator e_anim;
    public float e_speed;
    public Rigidbody2D e_body2d;
    private Vector2 direction;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private Transform target;
    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    #endregion


    #region dynamic params
    public int maxHealth;
    int currentHealth;

    public int Damage = 20;
    public float attackrange;
    public LayerMask PlayerLayers;
    public Collider2D AttackCollider;
    
    #endregion

    #region referens params
    public GameObject AttackPoint;
    public GameObject groudcollider;


    #endregion


    void Start()
    {
        e_body2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
 
    }

    void Update()
    {
        //Debug.Log(GetComponentInChildren<AggroRangeScript>().pathdirection.normalized);
        FollowTarget();
        //OnTriggerEnter2D(AttackCollider);       
        if (Time.time >= nextAttackTime)
        {           
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;            
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        e_anim.SetTrigger("Hurt");
        e_anim.SetBool("IsHurt", true);
        gameObject.GetComponent<Rigidbody2D>().AddForce(GetComponentInChildren<AggroRangeScript>().pathdirection.normalized *8f, ForceMode2D.Impulse);
        //transform.up*
        StartCoroutine(Wait());
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {

        e_anim.SetBool("IsDead",true);
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        e_body2d.velocity = new Vector2(0, e_body2d.velocity.y);
        AttackCollider.GetComponent<CircleCollider2D>().enabled = false;
        groudcollider.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(DeathWait());     
        
    }

   
    private void FollowTarget()
    {
        if (target != null && (e_anim.GetBool("IsHurt") == false || e_anim.GetBool("IsAttacking") == false))
        {
            
            e_anim.SetBool("IsRunning", true);

            if (target.transform.position.x > gameObject.transform.position.x)
            {
                e_body2d.velocity = new Vector2(e_speed, e_body2d.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }                
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                e_body2d.velocity = new Vector2(-e_speed, e_body2d.velocity.y);
            }                        
        }
        else
        {
            e_body2d.velocity = new Vector2(0, e_body2d.velocity.y);
            e_anim.SetBool("IsRunning", false);
        }
    }

    
    public void Attack()
    {
        e_anim.SetTrigger("Attack");    
        e_anim.SetBool("IsAttacking",true);
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(AttackPoint.transform.position, attackrange, PlayerLayers); ;
        foreach (Collider2D Player in hitplayer)
        {
            Player.GetComponent<PlayerCombat>().TakeDamage(Damage);
        }
        StartCoroutine(WaitOneSec());              

    }

   


    //private void OnDrawGizmosSelected()
    //{
    //    if (AttackPoint == null)
    //        return;

    //    Gizmos.DrawWireSphere(AttackPoint.transform.position, attackrange);
    //}

    IEnumerator WaitOneSec()
    {
        
        yield return new WaitForSeconds(1);
        e_anim.SetBool("IsAttacking", false);

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        e_anim.SetBool("IsHurt", false);

    }
    
    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(4);
        Debug.Log("done");
        Destroy(gameObject);
    }

}
