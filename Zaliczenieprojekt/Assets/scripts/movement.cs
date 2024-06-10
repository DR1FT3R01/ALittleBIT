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
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving && !logic.isPaused)
        {
            StartMove(Vector3.forward + new Vector3(0, 0, speed));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving && !logic.isPaused)
        {
            StartMove(-Vector3.forward + new Vector3(0, 0, -speed));
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving && !logic.isPaused)
        {
            StartMove(Vector3.forward + new Vector3(0, speedY, -1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving && !logic.isPaused)
        {
            StartMove(-Vector3.forward + new Vector3(0, -speedY, 1));
        }

        if (isMoving)
        {
            PerformMove();
        }

        //PauseGame - GameMenu

        if (Input.GetKeyDown(KeyCode.Escape) && !logic.isGameOver)
        {
            logic.gameMenu();
        }

        //RestartGame - GameOver

        if (Input.GetKeyDown(KeyCode.Return) && logic.isGameOver)
        { 
            logic.restartGame();
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

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Obstacle")
        {
            logic.gameOver();
            Debug.Log("Obstacle collision");
        }
    }


    //TODO zrobic ontriggerenter na sciane zeby sie platformy respily zamiast tego ze kamera nie widzi
    // zrobic takie same triggery na granice ruchu kostki

    //do zrobienia jeszcze zeby nie wychodzilo poza siatke
    /*metoda na  znikajaca platformy
     onbecomevisible
     onbecomeinvisible*/

}

