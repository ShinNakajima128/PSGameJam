using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SoundManager.Instance.PlaySeByName("Enter1");
            LoadSceneManager.Instance.LoadEasyScene();
        }
    }
}
