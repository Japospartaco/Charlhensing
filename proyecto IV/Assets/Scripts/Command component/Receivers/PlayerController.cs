using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IMoveableReceiver
{
    public float speed;

    public void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0f);
        transform.position += movement;
    }
}
