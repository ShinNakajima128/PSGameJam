using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField] Transform m_foodPosision1 = default;
    [SerializeField] Transform m_foodPosision2 = default;
    [SerializeField] Transform m_foodPosision3 = default;
    int m_trayCount = 0;
    public List<GameObject> m_trayList = new List<GameObject>();

    public void AddFoodstuffs(GameObject foodstuff)
    {
        var stuff = Instantiate(foodstuff);
        if (m_trayCount == 0) stuff.transform.position = m_foodPosision1.position;
        if (m_trayCount == 1) stuff.transform.position = m_foodPosision2.position;
        if (m_trayCount == 2) stuff.transform.position = m_foodPosision3.position;

        m_trayCount++;
        m_trayList.Add(stuff);
    }
}
