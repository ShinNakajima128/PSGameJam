using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBase : MonoBehaviour
{
    public FoodData foodData = default;
    public List<int> m_foodstuffIndexs = new List<int>();

    private void Start()
    {
        for (int i = 0; i < foodData.FoodstuffList.Count; i++)
        {
            var index = foodData.FoodstuffList[i].GetComponent<FoodstuffBase>().foodstuffData.Index;

            m_foodstuffIndexs.Add(index);
            m_foodstuffIndexs.Sort();
        }
    }
}
