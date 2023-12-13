using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Items : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    public virtual void ItemEffect(GameObject other)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            this.gameObject.SetActive(false);
        }
    }

    protected void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
