using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelEnemy : MonoBehaviour
{
    public int Currenthp;
    Animator anim;
    private float attackRate = 2f;
    float nextAttackTime = 0f;
    public bool IsTriggered = true;
    GameObject player;
    public GameObject FirePref;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
    
        if (IsTriggered && Time.time>= nextAttackTime)
        {
            StartCoroutine(AttackCD());
            nextAttackTime = Time.time + 10f / attackRate;
        } 
    }

    public void TakeDamage(int damage)
    {
        Currenthp -= damage;
        if (Currenthp <= 0)
            Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void Attackinitiate()
    {
        Vector2 vec = new Vector2(player.transform.position.x, player.transform.position.y + 2f);
        Debug.Log("Angels attack");
        Instantiate(FirePref, vec, player.transform.rotation);
    }
    
    

    private IEnumerator AttackCD()
    {
       Attackinitiate();
       anim.SetBool("IsAttacking", true);
       yield return new WaitForSeconds(2);
       anim.SetBool("IsAttacking", false);
    }
    
}
