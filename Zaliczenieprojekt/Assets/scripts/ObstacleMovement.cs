using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = 85;

    private void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        if (transform.position.x > deadZone)
        {
            Debug.Log("ObstacleDestroyed");
            Destroy(gameObject);
        }
    }
}
