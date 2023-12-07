using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSOManager : MonoBehaviour
{
    [SerializeField] private CutScneneSO BadDrive;
    [SerializeField] private CutScneneSO GoodDrive;
    public int currentChapter;
    // Start is called before the first frame update
    private GameManager gameManager;
    private PlayerData playerData;
    private void Awake()
    {
        playerData = PlayerData.Instance;

        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
            if (currentChapter == 1)
            {
                if (gameManager.currentBoosterCount > 2)
                {
                    gameObject.GetComponent<TalkManager>().cutScneneSO = BadDrive;
                }
                else
                {
                    gameObject.GetComponent<TalkManager>().cutScneneSO = GoodDrive;
                    playerData.gold -= (3 - gameManager.currentBoosterCount) * 2;
                    playerData.gold = Mathf.Max(0, playerData.gold);
                    gameManager.currentGoldCount -= (3 - gameManager.currentBoosterCount) * 2;
                    gameManager.currentGoldCount = Mathf.Max(0, gameManager.currentGoldCount);
                }
            }
            else if (currentChapter == 2)
            {
                if (gameManager.sleepMode || gameManager.currentPillowCount > 1)
                {
                    gameObject.GetComponent<TalkManager>().cutScneneSO = BadDrive;
                }
                else
                {
                    gameObject.GetComponent<TalkManager>().cutScneneSO = GoodDrive;
                    playerData.gold += 5;
                    gameManager.currentGoldCount += 5;
                }
            }

        }
    }
}
