using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveTime;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float elapsedTime = 0.0f;
    private bool isMoving = false;
    public float speed;
    public float speedY;

    public LogicScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            StartMove(Vector3.forward + new Vector3(0, 0, speed));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            StartMove(-Vector3.forward + new Vector3(0, 0, -speed));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            StartMove(Vector3.forward + new Vector3(0, speedY, -1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            StartMove(-Vector3.forward + new Vector3(0, -speedY, 1));
        }

        if (isMoving)
        {
            PerformMove();
        }

}


    void StartMove(Vector3 targetVector)
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, targetVector, out hit, targetVector.magnitude))
        {
            startPosition = transform.position;
            endPosition = startPosition + targetVector;
            elapsedTime = 0.0f;
            isMoving = true;
        }
    }

    void PerformMove()
    {
        elapsedTime += Time.deltaTime;
        float fraction = elapsedTime / moveTime;

        transform.position = Vector3.Lerp(startPosition, endPosition, fraction);

        if (fraction >= 1.0f)
        {
            isMoving = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
        {
            Debug.Log("is touching");
        }
    }


    //TODO zrobic ontriggerenter na sciane zeby sie platformy respily zamiast tego ze kamera nie widzi
    // zrobic takie same triggery na granice ruchu kostki

    //do zrobienia jeszcze zeby nie wychodzilo poza siatke
    /*metoda na  znikajaca platformy
     onbecomevisible
     onbecomeinvisible*/

    private void OnCollisionEnter(Collision collision)
    {
        logic.gameOver();
        Debug.Log("Obstacle collision");
    }

}

