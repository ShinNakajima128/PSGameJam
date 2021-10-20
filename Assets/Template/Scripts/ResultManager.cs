using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField] GameObject m_moneyText = default;
    [SerializeField] GameObject m_lossesText = default;
    [SerializeField] GameObject m_totalText = default;
    [SerializeField] GameObject m_selectPanel = default;
    [SerializeField] float m_ViewTimer = 2.0f;
    Text money;
    Text losses;
    Text total;

    [SerializeField] int m_totalMoney = 0;
    [SerializeField] int m_totalLosses = 0;
    [SerializeField] int m_totalResult = 0;

    [Header("デバッグ用")]
    [SerializeField] bool isDebug = false;
    [SerializeField] int m_testTotal = 100;

    public int TotalResult => m_totalResult;
    public static ResultManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        m_selectPanel.SetActive(false);
        money = m_moneyText.GetComponent<Text>();
        losses = m_lossesText.GetComponent<Text>();
        total = m_totalText.GetComponent<Text>();
        StartCoroutine(ResultView());
    }

    private void Update()
    {
        if (m_moneyText.activeSelf) money.text = m_totalMoney.ToString() + "円";
        if (m_lossesText.activeSelf) losses.text = m_totalLosses.ToString() + "円";
        if (m_totalText.activeSelf) total.text = m_totalResult.ToString() + "円";
    }

    IEnumerator ResultView()
    {
        Debug.Log("表示");
        m_moneyText.SetActive(true);

        DOTween.To(() =>
                m_totalMoney,
                x => m_totalMoney = x,
                ScoreManager.Instance.TotalScore,
                2.0f
                );

        yield return new WaitForSeconds(m_ViewTimer);

        m_lossesText.SetActive(true);

        DOTween.To(() =>
                m_totalLosses,
                x => m_totalLosses = x,
                ScoreManager.Instance.TotalLoss,
                2.0f
                );

        yield return new WaitForSeconds(m_ViewTimer);

        m_totalText.SetActive(true);

        DOTween.To(() =>
                m_totalResult,
                x => m_totalResult = x,
                m_totalMoney - m_totalLosses,
                2.0f
                );

        yield return new WaitForSeconds(m_ViewTimer);

        SoundManager.Instance.PlaySeByName("Result");

        yield return new WaitForSeconds(m_ViewTimer);

        if (isDebug)
        {
            m_totalResult = m_testTotal;
        }

        RankingManager.Instance.SetScoreOfCurrentPlay(m_totalResult);

        yield return StartCoroutine(RankingSubmit());

        m_selectPanel.SetActive(true);
    }

    IEnumerator RankingSubmit()
    {
        yield return new WaitForSeconds(1.0f);

        while (true)
        {
            if (RankingManager.Instance.FInishedProcess)
            {
                Debug.Log(RankingManager.Instance.FInishedProcess);
                yield break;
            }
            yield return null;
        }
    }
}
