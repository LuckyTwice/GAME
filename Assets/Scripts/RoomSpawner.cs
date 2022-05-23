using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None
    }

    private RoomsVariant variant;
    private int rand;
    private bool spawned = false;
    private readonly float waitTime = 3f;

    private void Start()
    {
        variant = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariant>();
        Destroy(gameObject, waitTime);
        Invoke(nameof(Spawn), 0.2f);
    }
    public void Spawn()
    {
        if(!spawned)
        {
            if(direction==Direction.Up)
            {
                rand = Random.Range(0, variant.UpRooms.Length);
                Instantiate(variant.UpRooms[rand], transform.position, variant.UpRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Down)
            {
                rand = Random.Range(0, variant.DownRooms.Length);
                Instantiate(variant.DownRooms[rand], transform.position, variant.DownRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Right)
            {
                rand = Random.Range(0, variant.RightRooms.Length);
                Instantiate(variant.RightRooms[rand], transform.position, variant.RightRooms[rand].transform.rotation);
            }
            else if (direction == Direction.Left)
            {
                rand = Random.Range(0, variant.LeftRooms.Length);
                Instantiate(variant.LeftRooms[rand], transform.position, variant.LeftRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("SpawnRoom") && other.GetComponent<RoomSpawner>().spawned)
        {
            Destroy(gameObject);
        }
    }
}
