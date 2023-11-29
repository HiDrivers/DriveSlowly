using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimationControl : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private int currentStage;

    private bool isBoost = false;
    private bool isSleep = false;
    private bool isDrunk = false;

    [SerializeField] private GameObject frontLight;

    [Header("Effect List: <effectObject> will be Current Effect of each scene")]
    [SerializeField] private GameObject effectObject;
    [SerializeField] private GameObject boostEffect;
    [SerializeField] private GameObject drunkEffect;
    [SerializeField] private GameObject sleepEffect;

    private PlayerControl playerControl;

    private string currentScene;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;
        gameManager = GameManager.Instance;
        playerControl = GetComponent<PlayerControl>();
    }
    private void Start()
    {
        //gameManager = GameManager.Instance;
        switch (currentScene)
        {
            case "Stage2Scene":
            case "Stage2Scene 1":
                currentStage = 2;
                effectObject = sleepEffect;
                break;
            case "Stage3Scene":
            case "Stage3Scene 1":
                currentStage = 3;
                effectObject = drunkEffect;
                break;
            default:
                currentStage = 0;
                effectObject = null;
                break;
        }
        //if (currentScene == "Stage2Scene" || currentScene == "Stage2Scene 1")
        //{
        //    currentStage = 2;
        //    effectObject = sleepEffect;
        //}
        //else if (currentScene == "Stage3Scene" || currentScene == "Stage3Scene 1")
        //{
        //    currentStage = 3;
        //    effectObject = drunkEffect;
        //}
        //else
        //{
        //    currentStage = 0;
        //    effectObject = null;
        //}

        if (currentScene != "Stage3Scene" || currentScene != "Stage3Scene 1")
        {
            frontLight.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameManager.isBoost)
        {
            playerControl.speed = 4.5f;
            if (!isBoost)
            {
                boostEffect.SetActive(true);
                isBoost = true;
            }
        }
        else
        {
            playerControl.speed = 2.5f;
            if (isBoost)
            {
                boostEffect.SetActive(false);
                isBoost = false;
            }
        }

        if (currentStage == 2)
        {
            if (gameManager.isSleep != isSleep)
            {
                isSleep = gameManager.isSleep;
                effectObject.SetActive(isSleep);
            }
        }

        else if (currentStage == 3)
        {
            if(gameManager.isDrunk != isDrunk)
            {
                isDrunk = gameManager.isDrunk;
                effectObject.SetActive(isDrunk);
            }
        }
    }
}
