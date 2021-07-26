using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillainController : MonoBehaviour
{
    [SerializeField] int m_stealMoney = 1000;
    [SerializeField] GameObject m_alert = default;
    [SerializeField] GameObject m_Arrested = default;
    [SerializeField] Slider m_limitSlider = default;
    [SerializeField] GameObject m_stealMessage = default;
    [SerializeField] GameObject m_downMessage = default;
    [SerializeField] int m_villainHp = 10;
    SpriteRenderer m_villain;

    float m_timer;
    bool isDowned = false;
    bool m_isTimeOut = false;

    void Start()
    {
        m_villain = GetComponent<SpriteRenderer>();
        m_Arrested.SetActive(false);
        m_stealMessage.SetActive(false);
        m_downMessage.SetActive(false);
    }

    void Update()
    {
        if (m_villainHp <= 0) { isDowned = true; }

        if (!m_isTimeOut)
        {
            m_timer = Time.deltaTime;

            m_limitSlider.value -= m_timer;

            if (isDowned)
            {
                m_isTimeOut = true;
                m_downMessage.SetActive(true);
                m_Arrested.SetActive(true);
                m_villain.enabled = false;
                m_alert.SetActive(false);
                StartCoroutine(DelayDestroy());
            }

            if (m_limitSlider.value <= 0 && !isDowned)
            {
                ScoreManager.Instance.TotalScore -= m_stealMoney;
                m_stealMessage.SetActive(true);
                m_alert.SetActive(false);
                m_isTimeOut = true;
                StartCoroutine(DelayDestroy());
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit.collider)
            {
                if (hit.collider.gameObject.name == "Villain")
                {
                    Debug.Log(m_villainHp);
                    m_villainHp--;
                }
            }
            
        }
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(3.0f);

        Destroy(gameObject);
    }
}
