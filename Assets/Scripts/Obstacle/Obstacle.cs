using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D obstacleRigidbody;

    public float speed;
    [SerializeField] private Vector3 direction;
    public bool isFromBottom;
    public int pos;
    public GameObject ObstacleManager;

    public float initialSpeed;

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

        if (transform.position.y < -8f || transform.position.y > 8f) // 장애물이 일정 y범위를 벗어나면 비활성화
        {
            ObstacleManager.GetComponent<ObstacleGenerateManager>().spawnPosCount[pos] -= 1;
            gameObject.SetActive(false);
        }
    }

    //private void OnEnable()
    //{
    //    if (transform.position.y < -6f) direction = Vector2.up;
    //    else direction = Vector2.down;

    //    obstacleRigidbody.velocity = direction * speed;
    //}


    //private void OnTriggerEnter2D(Collider2D collision) // 리팩토링 피드백에 따라, 장애물의 현재 좌표에 따른 비활성화 로직으로 변경합니다.
    //{

    //    if (collision.tag == "End")
    //    {
    //        ObstacleManager.GetComponent<ObstacleGenerateManager>().spawnPosCount[pos] -= 1;
    //        gameObject.SetActive(false);
    //    }

    //    else if (collision.tag == "Obstacle")
    //    {
    //        Debug.Log("GameOver : Car crash");
    //    }
    //}
}
