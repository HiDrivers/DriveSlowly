using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Update is called once per frame
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

        if (transform.position.y < -23.5)
        {
            transform.position = Vector3.zero;
        }
    }
}
