using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlaySeByName("Enter1");
            LoadSceneManager.Instance.LoadEasyScene();
        }
    }
}
