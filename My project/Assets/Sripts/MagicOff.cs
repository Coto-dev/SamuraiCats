using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicOff : MonoBehaviour
{
    public Transform attackPos;
    public Transform magic;
    public LayerMask enemy;
    public float attackRange;
    Animator magAnim;
 
    
    void Start()
    {
        magAnim = magic.GetComponent<Animator>();
    }
   public void Wd()
    {
        magAnim.SetTrigger("NoFire");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        Debug.Log("enemies  " + enemies.Length);
        for (int i = 0; i < enemies.Length; i++)
        {
            Debug.Log("enemies  " + enemies[i]);
            try
            {
                enemies[i].GetComponent<EnemyControl>().TakeDamage(30);
            }
            catch
            {
                enemies[i].GetComponent<BossControl>().TakeDamage(30);

            }
        }
        magAnim.SetTrigger("NoFire");
    }
    
    /*void FixedUpdate()
    {
        magAnim.SetTrigger("NoFire");
    }*/
}
