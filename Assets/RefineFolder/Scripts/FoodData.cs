using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create FoodData")]
public class FoodData : ScriptableObject
{
    [SerializeField] string m_foodName = default;
    [SerializeField] int m_price = default;
    [SerializeField] List<GameObject> m_foodstuffList = new List<GameObject>();

    public string FoodName
    {
        get { return m_foodName; }
    }

    public int Price
    {
        get { return m_price; }
    }

    public List<GameObject> FoodstuffList
    {
        get { return m_foodstuffList; }
    }
}
