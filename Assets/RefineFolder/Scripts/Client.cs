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
    [SerializeField] float m_offTimer = 2.0f;
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
                SoundManager.Instance.PlaySeByName("Success");
                var score = m_tray.CookedFood.GetComponent<Ramen>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                SoundManager.Instance.PlaySeByName("Failure");
                m_tray.ResetTray();
            }

            StartCoroutine(OffClient());

        }
        else if (m_clientState == ClientState.Curry)
        {
            if (m_tray.m_trayState == TrayState.Curry)
            {
                SoundManager.Instance.PlaySeByName("Success");
                var score = m_tray.CookedFood.GetComponent<Curry>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                SoundManager.Instance.PlaySeByName("Failure");
                m_tray.ResetTray();
            }

            StartCoroutine(OffClient());

        }
        else if (m_clientState == ClientState.Fishset)
        {
            if (m_tray.m_trayState == TrayState.Fishset)
            {
                SoundManager.Instance.PlaySeByName("Success");
                var score = m_tray.CookedFood.GetComponent<Fishset>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                SoundManager.Instance.PlaySeByName("Failure");
                m_tray.ResetTray();
            }

            StartCoroutine(OffClient());

        }
        else if (m_clientState == ClientState.Gyudon)
        {
            if (m_tray.m_trayState == TrayState.Gyudon)
            {
                SoundManager.Instance.PlaySeByName("Success");
                var score = m_tray.CookedFood.GetComponent<Gyuudon>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                SoundManager.Instance.PlaySeByName("Failure");
                m_tray.ResetTray();
            }

            StartCoroutine(OffClient());

        }
        else if (m_clientState == ClientState.Sushi)
        {
            if (m_tray.m_trayState == TrayState.Sushi)
            {
                SoundManager.Instance.PlaySeByName("Success");
                var score = m_tray.CookedFood.GetComponent<Sushi>().FoodPrice;
                ScoreManager.Instance.TotalScore += score;
                m_tray.SuccessReset();
            }
            else
            {
                SoundManager.Instance.PlaySeByName("Failure");
                m_tray.ResetTray();
            }

            StartCoroutine(OffClient());

        }
    }
    public void SelectFoods(int foodType)
    {
        if (foodType == 0)
        {
            m_clientState = ClientState.Ramen;
            SetImage(foodType);
        }
        if (foodType == 1)
        {
            m_clientState = ClientState.Curry;
            SetImage(foodType);
        }
        if (foodType == 2)
        {
            m_clientState = ClientState.Gyudon;
            SetImage(foodType);
        }
        if (foodType == 3)
        {
            m_clientState = ClientState.Fishset;
            SetImage(foodType);
        }
        if (foodType == 4)
        {
            m_clientState = ClientState.Sushi;
            SetImage(foodType);
        }
    }

    void SetImage(int Type)
    {
        for (int i = 0; i < m_foodImages.Length; i++)
        {
            if (i == Type)
            {
                m_foodImages[i].enabled = true;
            }
            else
            {
                m_foodImages[i].enabled = false;
            }
        }
    }

    IEnumerator OffClient()
    {
        yield return new WaitForSeconds(m_offTimer);

        gameObject.SetActive(false);
    }
}
