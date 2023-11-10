using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.isBoost)
        {
            transform.position += Vector3.down * 6 * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * 3 * Time.deltaTime;
        }

        if (transform.position.y < -18.5)
        {
            transform.position = Vector3.zero + new Vector3(-0.23f,0,0);
        }
    }
}
