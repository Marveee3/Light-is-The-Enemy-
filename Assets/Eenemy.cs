using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eenemy : MonoBehaviour
{
    [SerializeField]private healthSistem helthSis;
    [SerializeField]private Animator anim;
    [SerializeField]private int animcc = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            Attack();
        }
        // else
        // {
        //
        // }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        anim.SetInteger("Attach", 0);
    }
    void Attack()
    {
        anim.SetInteger("Attach", 1);
        Invoke("Damage", 2f);

    }
    void Damage()
    {
        if(helthSis.health == 3)
        {
            helthSis.health = 2;
            Invoke("Attack", 2f);
        }
        if(helthSis.health == 2)
        {
            helthSis.health = 1;
            Invoke("Attack", 2f);
        }
        if(helthSis.health == 1)
        {
            helthSis.health = 0;
            Invoke("Attack", 2f);
        }
    }
    void StopAttack()
    {
        
    }
}
