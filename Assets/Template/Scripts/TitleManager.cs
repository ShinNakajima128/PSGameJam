using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    bool isStarted;

    private void Start()
    {
        isStarted = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStarted)
        {
            SoundManager.Instance.PlaySeByName("Enter1");
            LoadSceneManager.Instance.LoadEasyScene();
            isStarted = true;
        }
    }
}
