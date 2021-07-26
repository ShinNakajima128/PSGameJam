using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    /// <summary> 合計スコア </summary>
    public int TotalScore { get; set; }
    public int TotalLoss { get; set; }

    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (SceneManager.GetActiveScene().name == "Title")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
        TotalScore = 2000;
        TotalLoss = 500;
    }

    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
        else if (SceneManager.GetActiveScene().name == "GameScene")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
    }
}
