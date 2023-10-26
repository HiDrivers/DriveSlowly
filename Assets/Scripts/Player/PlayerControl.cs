using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private int moveX;
    private int moveY;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveX = 0; moveY = 0;
        if (isLeft) moveX -= 1;
        if (isRight) moveX += 1;
        if (isUp) moveY += 1;
        if (isDown) moveY -= 1;
        transform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
    }

    public void Up_PointerDown()
    {
        isUp = true;
    }

    public void Up_PointerUp()
    {
        isUp = false;
    }

    public void Down_PointerDown()
    {
        isDown = true;
    }

    public void Down_PointerUp()
    {
        isDown = false;
    }

    public void Left_PointerDown()
    {
        isLeft = true;
    }

    public void Left_PointerUp()
    {
        isLeft = false;
    }

    public void Right_PointerDown()
    {
        isRight = true;
    }

    public void Right_PointerUp()
    {
        isRight = false;
    }


}
