using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    public float speed = 5.0f;



    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(-50, 0, 5);
    }
}
