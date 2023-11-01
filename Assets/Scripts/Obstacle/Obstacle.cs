using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D obstacleRigidbody;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 direction;

    private void Awake()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        obstacleRigidbody.velocity = direction * speed;
    }
}
