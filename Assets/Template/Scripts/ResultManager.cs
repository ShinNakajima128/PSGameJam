using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instance.PlaySeByName("Result");
    }
}
