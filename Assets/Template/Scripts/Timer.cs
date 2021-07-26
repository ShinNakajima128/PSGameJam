using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Slider m_Slider;
    public GameObject m_ObjectSlider;
    [SerializeField] float m_Timer = 1;
    int m_Time = 0;
    bool a = false;

    [SerializeField] GameObject m_GameEnd;

    void Start()
    {
        m_Slider = m_ObjectSlider.GetComponent<Slider>();
    }
    void Update()
    {
        GameTimer();
    }

    public void GameTimer()
    {
        m_Slider.value = m_Timer;
        m_Timer -= Time.deltaTime;

        if (m_Timer < m_Time && !a)
        {
            m_Timer = 0;
            m_GameEnd.SetActive(true);
            StartCoroutine(LoadScene());
            a = true;
        }
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        LoadSceneManager.Instance.Result();
    }
}
