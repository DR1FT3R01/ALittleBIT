using System.Collections;
using System.Collections.Generic;
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
    //public Vector2 BounceVector;
    public float gridSize = 3f;
    private Vector3 gridOrigin = Vector3.zero;

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

    void TryMove(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction;
        if (Mathf.Abs(newPosition.x - gridOrigin.x) <= gridSize && Mathf.Abs(newPosition.y - gridOrigin.y) <= gridSize)
        {
            StartMove(direction);
        }
    }

    void StartMove(Vector3 targetVector)
    {
        startPosition = transform.position;
        endPosition = startPosition + targetVector; 
        elapsedTime = 0.0f;
        isMoving = true;
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

    


    //TODO zrobic ontriggerenter na sciane zeby sie platformy respily zamiast tego ze kamera nie widzi
    // zrobic takie same triggery na granice ruchu kostki

    //do zrobienia jeszcze zeby nie wychodzilo poza siatke
    /*metoda na  znikajaca platformy
     onbecomevisible
     onbecomeinvisible*/





}

