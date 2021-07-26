using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] float m_timer = 1;
    int m_time = 0;

    void Update()
    {
        m_timer -= Time.deltaTime;

        if (m_timer < m_time)
        {
            Destroy(this.gameObject);
        }
    }
}
