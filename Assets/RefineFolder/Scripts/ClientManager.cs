using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] GameObject m_client1 = default;
    [SerializeField] GameObject m_client2 = default;
    [SerializeField] GameObject m_client3 = default;
    [SerializeField] GameObject m_villain = default;
    [SerializeField] float m_VillainVisitTime1 = 15.0f;
    [SerializeField] float m_VillainVisitTime2 = 20.0f;
    [SerializeField] float m_VillainVisitTime3 = 20.0f;
    public static bool isClientReserve1 = false;
    public static bool isClientReserve2 = false;
    public static bool isClientReserve3 = false;

    private void Start()
    {
        isClientReserve1 = false;
        isClientReserve2 = false;
        isClientReserve3 = false;

        StartCoroutine(OnVillain());
    }

    void Update()
    {
        if (!m_client1.activeSelf && !isClientReserve1)
        {
            isClientReserve1 = true;
            var timer = Random.Range(3, 6);
            StartCoroutine(OnClient(1, timer, m_client1));
        }

        if (!m_client2.activeSelf && !isClientReserve2)
        {
            isClientReserve2 = true;
            var timer = Random.Range(3, 6);
            StartCoroutine(OnClient(2, timer, m_client2));
        }

        if (!m_client3.activeSelf && !isClientReserve3)
        {
            isClientReserve3 = true;
            var timer = Random.Range(3, 6);
            StartCoroutine(OnClient(3, timer, m_client3));
        }
    }

    IEnumerator OnClient(int clientType, int time, GameObject client)
    {
        yield return new WaitForSeconds(time);

        client.SetActive(true);

        if (clientType == 1) isClientReserve1 = false;
        if (clientType == 2) isClientReserve2 = false;
        if (clientType == 3) isClientReserve3 = false;
    }
    IEnumerator OnVillain()
    {
        yield return new WaitForSeconds(m_VillainVisitTime1);

        Instantiate(m_villain);

        yield return new WaitForSeconds(m_VillainVisitTime2);

        Instantiate(m_villain);

        yield return new WaitForSeconds(m_VillainVisitTime3);

        Instantiate(m_villain);
    }
}
