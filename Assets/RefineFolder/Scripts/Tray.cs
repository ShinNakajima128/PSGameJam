using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum TrayState
{
    None,
    Ramen,
    Curry,
    Fishset,
    Gyudon,
    Sushi
}

public class Tray : MonoBehaviour
{
    [SerializeField] GameObject m_ramen = default;
    [SerializeField] GameObject m_curry = default;
    [SerializeField] GameObject m_Fishset = default;
    [SerializeField] GameObject m_gyudon = default;
    [SerializeField] GameObject m_sushi = default;
    [SerializeField] Transform m_foodPosision1 = default;
    [SerializeField] Transform m_foodPosision2 = default;
    [SerializeField] Transform m_foodPosision3 = default;
    [SerializeField] int m_totalCost = 0;
    public TrayState m_trayState = TrayState.None;
    public List<GameObject> m_trayObjectList = new List<GameObject>();
    public List<int> m_trayIndexList = new List<int>();
    int m_trayCount = 0;
    List<int> ramenStuffIndex;
    List<int> curryStuffIndex;
    List<int> fishsetStuffIndex;
    List<int> gyudonStuffIndex;
    List<int> sushiStuffIndex;
    public GameObject CookedFood;

    private void Start()
    {
        ramenStuffIndex = m_ramen.GetComponent<Ramen>().m_foodstuffIndexs;
        curryStuffIndex = m_curry.GetComponent<Curry>().m_foodstuffIndexs;
        fishsetStuffIndex = m_Fishset.GetComponent<Fishset>().m_foodstuffIndexs;
        gyudonStuffIndex = m_gyudon.GetComponent<Gyuudon>().m_foodstuffIndexs;
        sushiStuffIndex = m_sushi.GetComponent<Sushi>().m_foodstuffIndexs;
    }

    public void AddFoodstuffs(GameObject foodstuff)
    {
        if (m_trayCount >= 3 || m_trayState != TrayState.None) return;

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

    public void Cooking()
    {
        m_trayIndexList.Sort();

        if (m_trayIndexList.SequenceEqual(ramenStuffIndex))
        {
            m_trayState = TrayState.Ramen;
            var ramen = Instantiate(m_ramen);
            CookedFood = ramen;
            ramen.transform.position = m_foodPosision2.position;
            ResetStuff();
        }
        else if (m_trayIndexList.SequenceEqual(curryStuffIndex))
        {
            m_trayState = TrayState.Curry;
            var curry = Instantiate(m_curry);
            CookedFood = curry;
            curry.transform.position = m_foodPosision2.position;
            ResetStuff();
        }
        else if (m_trayIndexList.SequenceEqual(fishsetStuffIndex))
        {
            m_trayState = TrayState.Fishset;
            var fishset = Instantiate(m_Fishset);
            CookedFood = fishset;
            fishset.transform.position = m_foodPosision2.position;
            ResetStuff();
        }
        else if (m_trayIndexList.SequenceEqual(gyudonStuffIndex))
        {
            m_trayState = TrayState.Gyudon;
            var gyudon = Instantiate(m_gyudon);
            CookedFood = gyudon;
            gyudon.transform.position = m_foodPosision2.position;
            ResetStuff();
        }
        else if (m_trayIndexList.SequenceEqual(sushiStuffIndex))
        {
            m_trayState = TrayState.Sushi;
            var sushi = Instantiate(m_sushi);
            CookedFood = sushi;
            sushi.transform.position = m_foodPosision2.position;
            ResetStuff();
        }
        else
        {

            SoundManager.Instance.PlaySeByName("Failure");
            ScoreManager.Instance.TotalLoss += m_totalCost;
            ResetStuff();
            
        }
    }

    public void SuccessReset()
    {
        m_trayState = TrayState.None;
        Destroy(CookedFood);
        CookedFood = null;
    }

    public void ResetTray()
    {
        SoundManager.Instance.PlaySeByName("Steal");

        m_trayState = TrayState.None;

        if (CookedFood) 
        {
            if (CookedFood.CompareTag("Ramen")) ScoreManager.Instance.TotalLoss += CookedFood.GetComponent<Ramen>().FoodPrice;
            if (CookedFood.CompareTag("Curry")) ScoreManager.Instance.TotalLoss += CookedFood.GetComponent<Curry>().FoodPrice;
            if (CookedFood.CompareTag("Fishset")) ScoreManager.Instance.TotalLoss += CookedFood.GetComponent<Fishset>().FoodPrice;
            if (CookedFood.CompareTag("Gyudon")) ScoreManager.Instance.TotalLoss += CookedFood.GetComponent<Gyuudon>().FoodPrice;
            if (CookedFood.CompareTag("Sushi")) ScoreManager.Instance.TotalLoss += CookedFood.GetComponent<Sushi>().FoodPrice;

            Debug.Log(ScoreManager.Instance.TotalLoss);
            Destroy(CookedFood);
            CookedFood = null; 
            return; 
        }

        m_trayCount = 0;
        ScoreManager.Instance.TotalLoss += m_totalCost;
        Debug.Log(ScoreManager.Instance.TotalLoss);

        ResetStuff();
    }

    void ResetStuff()
    {
        for (int i = 0; i < m_trayObjectList.Count; i++)
        {
            Destroy(m_trayObjectList[i]);
        }

        m_trayObjectList.Clear();
        m_trayIndexList.Clear();
        m_totalCost = 0;
        m_trayCount = 0;
    }
}
