using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HiddenTitleController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int clickCnt;
    private void Start()
    {
        clickCnt = 0;
    }
    public void CheckClickCount()
    {
        clickCnt++;
        if (clickCnt >= 5)
        {
            SceneManager.LoadScene("CreditScene");
        }
    }
}
