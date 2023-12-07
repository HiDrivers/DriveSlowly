using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneSOManager : MonoBehaviour
{
    public bool isMadeByYJ;

    [SerializeField] private CutScneneSO EndingScene1;
    [SerializeField] private CutScneneSO EndingScene2;
    [SerializeField] private CutScneneSO EndingScene3;
    [SerializeField] private CutScneneSO EndingScene4;
    [SerializeField] private CutScneneSO EndingScene5;
    [SerializeField] private CutScneneSO EndingScene6;
    [SerializeField] private CutScneneSO EndingScene7;
    [SerializeField] private CutScneneSO EndingScene8;
    [SerializeField] private CutScneneSO EndingScene9;

    private GameManager gameManager;

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
            if (isMadeByYJ)
            {
                switch (gameManager.endingSceneNum)
                {
                    case 1:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene1;
                        break;
                    case 2:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene2;
                        break;
                    case 3:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene3;
                        break;
                    case 4:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene4;
                        break;
                }
            }
            else
            {
                switch (gameManager.endingSceneNum)
                {
                    case 5:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene5;
                        break;
                    case 6:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene6;
                        break;
                    case 7:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene7;
                        break;
                    case 8:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene8;
                        break;
                    case 9:
                        gameObject.GetComponent<TalkManager>().cutScneneSO = EndingScene9;
                        break;
                }
            }

        }
    }
}
