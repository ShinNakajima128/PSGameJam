using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour
{
    [SerializeField] Transform m_foodPosision1 = default;
    [SerializeField] Transform m_foodPosision2 = default;
    [SerializeField] Transform m_foodPosision3 = default;
    int m_trayCount = 0;
    [SerializeField] int m_totalCost = 0;
    public List<GameObject> m_trayObjectList = new List<GameObject>();
    public List<int> m_trayIndexList = new List<int>();

    public void AddFoodstuffs(GameObject foodstuff)
    {
        var stuff = Instantiate(foodstuff);
        m_trayObjectList.Add(stuff);
        var stuffIndex = stuff.GetComponent<FoodstuffBase>().foodstuffData.Index;
        var stuffCost = stuff.GetComponent<FoodstuffBase>().foodstuffData.Cost;

        if (m_trayCount == 0) stuff.transform.position = m_foodPosision1.position;
        if (m_trayCount == 1) stuff.transform.position = m_foodPosision2.position;
        if (m_trayCount == 2) stuff.transform.position = m_foodPosision3.position;

        m_trayCount++;
        m_totalCost += stuffCost;
        m_trayIndexList.Add(stuffIndex);
    }

    public void ResetTray()
    {
        m_trayCount = 0;
        ScoreManager.Instance.TotalLoss += m_totalCost;
        Debug.Log(ScoreManager.Instance.TotalLoss);

        for (int i = 0; i < m_trayObjectList.Count; i++)
        {
            Destroy(m_trayObjectList[i]);
        }
        m_trayObjectList.Clear();
        m_trayIndexList.Clear();
        m_totalCost = 0;
    }
}
