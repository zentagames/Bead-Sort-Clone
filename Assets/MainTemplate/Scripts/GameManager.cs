using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void NextStage()
    {
        //PlayerPrefHelper.CurrentStage += 1;
        RestartStage();
    }

    public void RestartStage()
    {
        SceneManager.LoadScene(PlayerPrefHelper.CurrentStage + 1);
    }
}

public static class PlayerPrefHelper
{
    public static int CurrentStage
    {
        get
        {
            if (PlayerPrefs.HasKey("CurrentStage") == false)
            {
                PlayerPrefs.SetInt("CurrentStage", 0);
            }

            return PlayerPrefs.GetInt("CurrentStage");
        }
        set
        {
            PlayerPrefs.SetInt("CurrentStage", value);
        }
    }
}

