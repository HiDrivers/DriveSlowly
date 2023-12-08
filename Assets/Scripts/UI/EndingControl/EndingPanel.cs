using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPanel : MonoBehaviour
{
    [SerializeField] public GameObject blindObject;
    public int endingNum;
    private void Start()
    {
        if (PlayerPrefs.HasKey($"Ending{endingNum}"))
        {
            if (PlayerPrefs.GetInt($"Ending{endingNum}") == 1)
            {
                blindObject.SetActive(false);
            }
            else
            {
                blindObject.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt($"Ending{endingNum}", 0);
            blindObject.SetActive(true);
        }
    }
}
