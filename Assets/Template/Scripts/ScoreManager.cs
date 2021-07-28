using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    [SerializeField] Text m_totalScoreText = default;
    [SerializeField] Text m_totalLossText = default;

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
        else if (SceneManager.GetActiveScene().name == "RefineScene")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
    }

    void OnSceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
        else if (SceneManager.GetActiveScene().name == "RefineScene")
        {
            TotalScore = 0;
            TotalLoss = 0;
        }
    }

    private void Update()
    {
        m_totalScoreText.text = "売上額：　" + TotalScore.ToString() + "円";
        m_totalLossText.text = "損失額：　" + TotalLoss.ToString() + "円";
    }
}
