using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    [SerializeField]private float speed;

    [SerializeField]private int positionOfPatrol;
    [SerializeField]private Transform point;
    [SerializeField]private bool isFacingRight = true;

    [SerializeField]private healthSistem helthSis;
    [SerializeField]private Animator anim;
    [SerializeField]private int animcc = 0;
    [SerializeField]private GameObject part;
    public bool spawnTrue = false;

    bool moveingRight;

    Transform player;
    [SerializeField]private float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    void Start()
    {   
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnTrue = false;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false )
        {
            chill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;

        }


        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            Goback();
        }
    }

    void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;

        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;

        }

        if (moveingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {   
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }


    void Angry()
    {
        if(transform.position.x < player.position.x - positionOfPatrol)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
        if(transform.position.x > player.position.x + positionOfPatrol)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Goback()
    {
      transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.collider.CompareTag("Player"))
        {
            Attack();
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        anim.SetInteger("Attach", 0);
        StopAttack();
    }
    void Attack()
    {
        anim.SetInteger("Attach", 1);
        spawnTrue = true;
        Invoke("Damage", 0.5f);

    }
    void Damage()
    {
        helthSis.TakeDamage();
        Instantiate(part, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void StopAttack()
    {
        Angry();
    }

}
