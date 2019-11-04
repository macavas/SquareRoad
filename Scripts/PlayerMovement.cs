using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Vector3 newPosition;

    public float moveSpeed;

    int oldDirection;

    private void Start()
    {
        instance = this;
        FindRandomPosition();
    }

    private void FindRandomPosition()
    {
        int direction = 0;
        do
        {
            direction = Random.Range(0, 4);
        } while (direction == oldDirection);

        switch (direction)
        {
            case 0:
                newPosition = transform.position + new Vector3(0,1,0);
                oldDirection = 2;
                break;
            case 1:
                newPosition = transform.position + new Vector3(1, 0, 0);
                oldDirection = 3;
                break;
            case 2:
                newPosition = transform.position + new Vector3(0, -1, 0);
                oldDirection = 0;
                break;
            case 3:
                newPosition = transform.position + new Vector3(-1, 0, 0);
                oldDirection = 1;
                break;
        }
        StartCoroutine(MoveOverSpeed(gameObject, newPosition, moveSpeed));
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.position = newPosition;
        GameManager.instance.IncreaseScore();
        GroundSpawner.instance.SpawnShowCases();
        FindRandomPosition();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if(!checkIfPosEmpty(newPosition))
            {
                GameManager.instance.EndGame(transform.position);
                gameObject.SetActive(false);
            }
        }
    }

    public bool checkIfPosEmpty(Vector3 targetPos)
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position == targetPos)
                return true;
        }
        return false;
    }

    public void IncreaseSpeed()
    {
        moveSpeed += 0.1f;
    }


}
