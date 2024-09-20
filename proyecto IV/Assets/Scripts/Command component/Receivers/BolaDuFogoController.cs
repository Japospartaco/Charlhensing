using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDuFogoController : MonoBehaviour, IMoveableReceiver
{
    public float speed;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0f);
        transform.position += movement;
    }

    private void Update()
    {
        if (transform.position.x > player.transform.position.x + 14)
        {
            transform.position = new Vector3(player.transform.position.x + 14, transform.position.y, transform.position.z);
        }
        if (transform.position.x < player.transform.position.x - 14)
        {
            transform.position = new Vector3(player.transform.position.x - 14, transform.position.y, transform.position.z);
        }
        if (transform.position.y > player.transform.position.y + 8)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y +8, transform.position.z);
        }
        if (transform.position.y < player.transform.position.y - 8)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y -8, transform.position.z);
        }

    }
}
