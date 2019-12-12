using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //attack speed time
    public float timeBtwAttack;
    public float startTimeBtwAttack = 0.3f;

    //where the attack hits
    public Transform attackPos;
    //identify what is an enemy and how many there are
    public LayerMask whatIsEnemies;
    //range on the attack
    public float attackRange;
    //How much damage each attack does
    public int damage;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0 && Input.GetButtonDown("Attack"))
        {
            //circle hit box for attack
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            //for loop to hit each enemy
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                //Gets each enemy recorded in enemiesToDamage and removes health from that enemy
                enemiesToDamage[i].GetComponent<EnemyHealth>().Health-= damage;
            }
            timeBtwAttack = startTimeBtwAttack;
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            anim.SetBool("IsAttacking", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Color the attack circle red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}
