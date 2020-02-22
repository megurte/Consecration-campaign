using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackpoint;
    public float attackrange = 0.4f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public int attackDamage;
    public int MaxHealth;
    [SerializeField]
    int currentHealth;

    private float direction = 1f;
    private float powerForce = 8f;

    public bool immortal = false;

    public int CurrentHealth
    {
		get
		{
			return currentHealth;
		}
		set {
			currentHealth = value;
		} 
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Heal(20);
        }
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (CurrentHealth <= 0 && !immortal)
        {
            Destroy(this.gameObject);
            //Death();
            //StartCoroutine(DeathWait());           
            //Debug.Log("player is dead");
        }
        
    }

    //void Death()
    //{
    //    animator.SetTrigger("Death");
    //    GetComponent<BoxCollider2D>().enabled = false;
    //    this.enabled = false;
    //    StartCoroutine(DeathWait());

    //}

    void Attack()
    {
        
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //*******************************
            // ЕСЛИ ВЫЗОВЕТ ПРОБЛЕМЫ - УБРАТЬ
            //*******************************

            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            else
            {
                enemy.GetComponent<NPC>().TakeDamage(attackDamage);
            }
            
        }
        
    }

    public int Heal(int healpoints)
    {
         return CurrentHealth += healpoints;
       
    }

    public void TakeDamage(int Damagetaken)
    {
        animator.SetTrigger("Hurt");
        CurrentHealth -= Damagetaken;
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * direction * powerForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }

        if (collision.gameObject.tag == "Spikes")
        {
            TakeDamage(10);
        }
    }


    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }


}

