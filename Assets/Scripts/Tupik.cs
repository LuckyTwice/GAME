using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tupik : MonoBehaviour
{
    public GameObject block;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("�����"))
        {
            Instantiate(block, transform.GetChild(0).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(1).position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}