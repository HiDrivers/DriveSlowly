using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Items : MonoBehaviour
{
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * 2; // 2 = speed
    }

    public virtual void ItemEffect(GameObject other)
    {

    }
}
