using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingLobbyLoader : MonoBehaviour
{
    [SerializeField] private GameObject NoteUI;

    public void EndingLobbyLoad()
    {
        if (PlayerPrefs.GetInt("IsFirst") == 0)
        {
            PlayerPrefs.SetInt("IsFirst", 1);
            NoteUI.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("LobbyScene");
            Time.timeScale = 1f;
            Screen.SetResolution(1080, 1920, false);
        }
    }
}
