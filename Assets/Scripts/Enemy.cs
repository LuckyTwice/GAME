using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    public float speed;
    public GameObject floatingDamage;

    private Animator anim;
    private float timeBtwAttack;
    private AddRoom room;

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
        Vector2 damagePos = new Vector2(transform.position.x, transform.position.y + 0.01f);
        Instantiate(floatingDamage, damagePos, Quaternion.identity);
        floatingDamage.GetComponentInChildren<FloatingDamage>().damage = damage;
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Hero_Controle>();
        room = GetComponentInParent<AddRoom>();
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
            room.enemies.Remove(gameObject);
        }
        if (player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    public void OnEnemyAttack()
    {
        player.ChangeHealth(-damage);
        timeBtwAttack = startTimeBtwAttack;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                anim.SetTrigger("attack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
}
