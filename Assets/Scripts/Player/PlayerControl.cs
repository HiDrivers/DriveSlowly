using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private GameObject carPrefab;
    [SerializeField]
    private float rotSpeed = 10.0f;

    [SerializeField]
    public float speed = 2.5f;

    private Rigidbody2D rgbody2D;

    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isBoost = false;

    //private bool isUpBtnUp = true;
    //private bool isDownBtnUp = true;
    //private bool isLeftBtnUp = true;
    //private bool isRightBtnUp = true;

    private float moveX;
    private float moveY;

    private bool drunkCheck = false;
    private bool phoneCheck = false;

    private Vector3 rotOrigin;
    private Vector3 rotLeft = new Vector3(0, 0, 30f);
    private Vector3 rotRight = new Vector3(0, 0, -30f);

    private GameManager gameManager;

    private void Start()
    {
        rgbody2D = GetComponent<Rigidbody2D>();
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");

        //if (Input.GetKeyDown(KeyCode.W)) isUpBtnUp = false;
        //if (Input.GetKeyDown(KeyCode.S)) isDownBtnUp = false;
        //if (Input.GetKeyDown(KeyCode.A)) isLeftBtnUp = false;
        //if (Input.GetKeyDown(KeyCode.D)) isRightBtnUp = false;

        //if (Input.GetKeyUp(KeyCode.W)) isUpBtnUp = true;
        //if (Input.GetKeyUp(KeyCode.S)) isDownBtnUp = true;
        //if (Input.GetKeyUp(KeyCode.A)) isLeftBtnUp = true;
        //if (Input.GetKeyUp(KeyCode.D)) isRightBtnUp = true;


        //if (!isUpBtnUp || !isDownBtnUp || !isLeftBtnUp || !isRightBtnUp)
        //{
        //    transform.Translate(new Vector3(x, y, 0).normalized * speed * Time.deltaTime);
        //}
        //else
        //{
        CheckUIChange();
        moveX = 0; moveY = 0;
        if (isLeft)
        {
            moveX -= 1;
            carPrefab.transform.rotation = Quaternion.Lerp(carPrefab.transform.rotation, Quaternion.Euler(rotLeft), Time.deltaTime * rotSpeed);
        }
        if (isRight)
        {
            moveX += 1;
            carPrefab.transform.rotation = Quaternion.Lerp(carPrefab.transform.rotation, Quaternion.Euler(rotRight), Time.deltaTime * rotSpeed);
        }
        if (isUp) moveY += 1;
        if (isDown) moveY -= 1;
        if (!isLeft || !isRight) // 좌우 이동 복귀 시 회전값 복구
        {
            carPrefab.transform.rotation = Quaternion.Lerp(carPrefab.transform.rotation, Quaternion.Euler(rotOrigin), Time.deltaTime * rotSpeed);
        }

        if (gameManager.isBoost)
        {
            speed = 4.5f;
            if (!isBoost)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                isBoost = true;
            }
        }
        else
        {
            speed = 2.5f;
            if (isBoost)
            {
                transform.GetChild(1).gameObject.SetActive(false);
                isBoost = false;
            }
        }
        if (transform.position.y < -5.2 && moveY < 0) moveY = 0;
        else if (transform.position.y > 5.2 && moveY > 0) moveY = 0;

        if (transform.position.y < -5.2 || transform.position.y > 5.2) rgbody2D.mass = 100;
        else rgbody2D.mass = 1;

        transform.Translate(new Vector3(moveX, moveY, 0).normalized * speed * Time.deltaTime);
        //}
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
        // 왼쪽 버튼 홀드 시 작동 => 여기다 자동차 회전 로직 작성
    }

    public void Left_PointerUp()
    {
        isLeft = false;
        // 자동차 회전값 원상 복귀
    }

    public void Right_PointerDown()
    {
        isRight = true;
        // 왼쪽 버튼 홀드 시 작동
    }

    public void Right_PointerUp()
    {
        isRight = false;
    }

    public void CheckUIChange()
    {
        if (drunkCheck != gameManager.isDrunk)
        {
            Up_PointerUp();
            Down_PointerUp();
            Left_PointerUp();
            Right_PointerUp();
            drunkCheck = gameManager.isDrunk;
        }
        else if (phoneCheck != gameManager.isPhone)
        {
            if (gameManager.currentArrow == 0) Up_PointerUp();
            else if (gameManager.currentArrow == 1) Down_PointerUp();
            else if (gameManager.currentArrow == 2) Left_PointerUp();
            else if (gameManager.currentArrow == 3) Right_PointerUp();
        }
    }

}
