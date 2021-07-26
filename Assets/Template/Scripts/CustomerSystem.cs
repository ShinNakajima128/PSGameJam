using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSystem : MonoBehaviour
{
    [SerializeField] Customer m_customer;

    [SerializeField] GameObject m_prefab = default;
    /// <summary>true の場合、開始時にまず生成する</summary>
    [SerializeField] bool m_generateOnStart = true;
    [SerializeField] float m_interval = 1;
    float m_timer = 0;

    void Start()
    {
        Instantiate(m_prefab, this.transform.position, Quaternion.identity);
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer > m_interval)
        {
            m_timer = 0;
            if (m_customer.m_timer != 0)
            {
                Instantiate(m_prefab, this.transform.position, Quaternion.identity);
            }
            m_interval = Random.Range(5, 10);
        }
    }
}
