using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneSOManager : MonoBehaviour
{
    [SerializeField] private CutScneneSO Speeding;
    [SerializeField] private CutScneneSO SlowDown;
    // Start is called before the first frame update
    private GameManager gameManager;
    private void Awake()
    {
        if(GameManager.Instance != null)
        {
            gameManager = GameManager.Instance;
            if (gameManager.currentBoosterCount > 2)
            {
                gameObject.GetComponent<TalkManager>().cutScneneSO = Speeding;
            }
            else
            {
                gameObject.GetComponent<TalkManager>().cutScneneSO = SlowDown;
                gameManager.gold -= (3 - gameManager.currentBoosterCount) * 2;
                gameManager.gold = Mathf.Max(0, gameManager.gold);
                gameManager.currentGoldCount -= (3 - gameManager.currentBoosterCount) * 2;
                gameManager.currentGoldCount = Mathf.Max(0, gameManager.currentGoldCount);
            }
        }
    }
}
