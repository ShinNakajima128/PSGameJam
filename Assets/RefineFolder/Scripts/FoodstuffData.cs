using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create FoodstuffData")]
public class FoodstuffData : ScriptableObject
{
    [SerializeField] string m_stuffName = default;
    [SerializeField] int m_cost = default;
    [SerializeField] int m_index = default; 

    public int Cost { get => m_cost; }
    public int Index { get => m_index; }
}
