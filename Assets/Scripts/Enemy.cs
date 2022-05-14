using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public float speed;

    private Animator anim;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;

    public float startStopTime;
    private float stopTime;
    public float normalSpeed;

    private Hero_Controle player;

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        Health -= damage;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Hero_Controle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public void OnEnemyAttack()
    {
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("run");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
}
