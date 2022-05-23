using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    [SerializeField] bool enemyBullet;

    public GameObject destroyEffect;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Invoke("DestroyBullet", lifetime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
             if (hitInfo.collider.CompareTag("Enemy"))
                 {
                     hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                 }
             if (hitInfo.collider.CompareTag("Player") && enemyBullet)
             {
                 hitInfo.collider.GetComponent<Hero_Controle>().ChangeHealth(-damage);
             }
             DestroyBullet();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    public void DestroyBullet()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
