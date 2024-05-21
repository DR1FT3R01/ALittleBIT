using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    public float speed = 50.0f;

    

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            transform.position = new Vector3(-70, 0, 5);
        }
        
    }
    
}

//TODO zoptymalizowac predosc platform do ich miejsca respienia w grze

