using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Slider m_Slider;
    public GameObject m_ObjectSlider;
    [SerializeField] float m_Timer = 1;
    int m_Time = 0;

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

        if (m_Timer < m_Time)
        {
            m_Timer = 0;
        }
    }
}
