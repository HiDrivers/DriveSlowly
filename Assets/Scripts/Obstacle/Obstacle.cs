using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D obstacleRigidbody;

    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    public bool isFromBottom;
    public int pos;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.isBoost)
        {
            if (isFromBottom)
            {
                transform.position += direction * (speed - 2.5f) * Time.deltaTime;
            }
            else
            {
                transform.position += direction * (speed + 2.5f) * Time.deltaTime;
            }
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
        }

    }

    //private void OnEnable()
    //{
    //    if (transform.position.y < -6f) direction = Vector2.up;
    //    else direction = Vector2.down;

    //    obstacleRigidbody.velocity = direction * speed;
    //}


    //private void Update()
    //{
    //    if (transform.position.y < -10f || transform.position.y > 10f)
    //    {
    //        gameObject.SetActive(false);
    //        //ObstacleGenerateManager_Jin.Instance.occupiedList.Dequeue();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "End")
        {
            ObstacleGenerateManager_Jin.Instance.spawnPosCount[pos] -= 1;
            gameObject.SetActive(false);
        }

        else if (collision.tag == "Obstacle")
        {
            Debug.Log("GameOver : Car crash");
        }
    }
}
