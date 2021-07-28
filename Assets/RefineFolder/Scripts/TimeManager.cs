using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Slider m_timeSlider = default;
    [SerializeField] float m_gameTime = 60;
    [SerializeField] float m_loadTime = 2.0f;
    [SerializeField] bool m_inGame = false;
    [SerializeField] GameObject m_finishPanel = default;
    [SerializeField] Text m_countDownText = default;
    float m_timer;

    private void Start()
    {
        m_finishPanel.SetActive(false);
        m_timeSlider.maxValue = m_gameTime;
        m_timeSlider.value = m_gameTime;

        StartCoroutine(CountDown());
    }

    void Update()
    {
        if (m_inGame)
        {

            m_timeSlider.value -= Time.deltaTime;

            if (m_timeSlider.value <= 0)
            {
                SoundManager.Instance.PlaySeByName("GameFinish");
                m_inGame = false;
                m_finishPanel.SetActive(true);
                StartCoroutine(FinishGame());
            }
        }
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(m_loadTime);

        LoadSceneManager.Instance.Result();
    }
    IEnumerator CountDown()
    {
        m_countDownText.text = "3";

        yield return new WaitForSeconds(1f);

        m_countDownText.text = "2";

        yield return new WaitForSeconds(1f);

        m_countDownText.text = "1";

        yield return new WaitForSeconds(1f);

        m_countDownText.fontSize = 200;
        m_countDownText.text = "<color=#F0FF92>営業開始！</color>";

        yield return new WaitForSeconds(1f);

        SoundManager.Instance.PlayBgmByName("Main");
        m_countDownText.enabled = false;
        m_inGame = true;
    }
}
