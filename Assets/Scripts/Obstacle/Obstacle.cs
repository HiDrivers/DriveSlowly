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

        if (transform.position.y < -8f || transform.position.y > 8f) // ��ֹ��� ���� y������ ����� ��Ȱ��ȭ
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


    //private void OnTriggerEnter2D(Collider2D collision) // �����丵 �ǵ�鿡 ����, ��ֹ��� ���� ��ǥ�� ���� ��Ȱ��ȭ �������� �����մϴ�.
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
