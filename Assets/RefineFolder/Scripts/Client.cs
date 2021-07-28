using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ClientState
{
    None,
    Ramen,
    Curry,
    Fishset,
    Sushi,
    Gyudon
}

public class Client : MonoBehaviour
{
    [SerializeField] Image[] m_foodImages = default;
    [SerializeField] ClientState m_clientState = ClientState.None;
    [SerializeField] Tray m_tray = default;
    int Want2EatType = 0;

    private void OnEnable()
    {
        Want2EatType = Random.Range(0, 5);

        SelectFoods(Want2EatType);
    }

    private void OnDisable()
    {
        m_clientState = ClientState.None;
    }

    public void CompareFoods()
    {
        if (m_clientState == ClientState.Ramen)
        {
            if (m_tray.m_trayState == TrayState.Ramen)
            {
                var score = m_tray.CookedFood.GetComponent<Ramen>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                m_tray.ResetTray();
            }
        }
        else if (m_clientState == ClientState.Curry)
        {
            if (m_tray.m_trayState == TrayState.Curry)
            {
                var score = m_tray.CookedFood.GetComponent<Curry>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                m_tray.ResetTray();
            }
        }
        else if (m_clientState == ClientState.Fishset)
        {
            if (m_tray.m_trayState == TrayState.Fishset)
            {
                var score = m_tray.CookedFood.GetComponent<Fishset>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                m_tray.ResetTray();
            }
        }
        else if (m_clientState == ClientState.Gyudon)
        {
            if (m_tray.m_trayState == TrayState.Gyudon)
            {
                var score = m_tray.CookedFood.GetComponent<Gyuudon>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                m_tray.ResetTray();
            }
        }
        else if (m_clientState == ClientState.Sushi)
        {
            if (m_tray.m_trayState == TrayState.Sushi)
            {
                var score = m_tray.CookedFood.GetComponent<Sushi>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                m_tray.ResetTray();
            }
        }
    }
    public void SelectFoods(int foodType)
    {
        if (foodType == 0)
        {
            m_clientState = ClientState.Ramen;

        }
        if (foodType == 1)
        {
            m_clientState = ClientState.Curry;
        }
        if (foodType == 2)
        {
            m_clientState = ClientState.Gyudon;
        }
        if (foodType == 3)
        {
            m_clientState = ClientState.Fishset;
        }
        if (foodType == 4)
        {
            m_clientState = ClientState.Sushi;
        }
    }
}
