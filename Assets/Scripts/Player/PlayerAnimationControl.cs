using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    private GameManager gameManager;

    public int currentStage;

    private bool isSleep = false;
    private bool isDrunk = false;

    [SerializeField] private GameObject EffectObject;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStage == 2)
        {
            if (gameManager.isSleep != isSleep)
            {
                isSleep = gameManager.isSleep;
                EffectObject.SetActive(isSleep);
            }
        }

        else if (currentStage == 3)
        {
            if(gameManager.isDrunk != isDrunk)
            {
                isDrunk = gameManager.isDrunk;
                EffectObject.SetActive(isDrunk);
            }
        }
    }
}
