using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    public float moveSpeed = 100;
    public float deadZone = 50;

    private void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        if (transform.position.x > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
