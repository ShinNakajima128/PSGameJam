using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomFood : MonoBehaviour
{
    public Sprite[] sprite;

    void Start()
    {
        RandomImage();
    }
    void RandomImage()
    {
        var image = GetComponent<Image>();//このオブジェクトにくっ付いてるImageの取得
        image.sprite = sprite[Random.Range(0, sprite.Length)];//配列からランダムに画像指定
    }
}
