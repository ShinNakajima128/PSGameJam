using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFood : MonoBehaviour
{
    public Sprite[] sprite;
    public float m_timer = 5;
    float time = 0;

    private void Update()
    {
        time += Time.deltaTime;
        RandomImage();
    }
    void RandomImage()
    {
        var image = GetComponent<Image>();//このオブジェクトにくっ付いてるImageの取得
        while(m_timer < time)
        {
            time = 0;
            image.sprite = sprite[Random.Range(0, sprite.Length)];//配列からランダムに画像指定
        }
    }
}
