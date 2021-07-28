using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    [SerializeField] GameObject m_optionPanel = default;

    void Start()
    {
        m_optionPanel.SetActive(false);
    }

    public void OnPanel()
    {
        m_optionPanel.SetActive(true);
    }
    public void OffPanel()
    {
        m_optionPanel.SetActive(false);
    }
}
