using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sozaimaneger : MonoBehaviour
{
    GameObject clickedGameObject;
    Sprite clickedGameObjectsprite;
    Sprite kyaku;
    List<Sprite> kyakuclasssozai;
    int kyakuclassmoney;
    List<Sprite> sozai = new List<Sprite>();

    GameObject food;
    RandomFood foodscript;
    GameObject FoodManagement;
    FoodManeger managementscript;

    [SerializeField]GameObject toree;
    

    void Start()
    {
        

        food = GameObject.Find("Food");
        foodscript = food.GetComponent<RandomFood>();
        FoodManagement = GameObject.Find("FoodManager");
        managementscript = FoodManagement.GetComponent<FoodManeger>();
        

        
    }

    void Update()
    {
        kyaku = foodscript.image.sprite;
        if(kyaku.name == "ra-men")
        {
            kyakuclasssozai = managementscript.rarmen1.GetSozai();
            kyakuclassmoney = managementscript.rarmen1.GetNoney();
            //kyakuclasssozai.Sort();
        }
        else if (kyaku.name == "kare-")
        {
            kyakuclasssozai = managementscript.carry1.GetSozai();
            kyakuclassmoney = managementscript.carry1.GetNoney();
            //kyakuclasssozai.Sort();
        }
        else if (kyaku.name == "susi")
        {
            kyakuclasssozai = managementscript.susi1.GetSozai();
            kyakuclassmoney = managementscript.susi1.GetNoney();
            //kyakuclasssozai.Sort();
        }
        else if (kyaku.name == "gyudon")
        {
            kyakuclasssozai = managementscript.gyudon1.GetSozai();
            kyakuclassmoney = managementscript.gyudon1.GetNoney();
            //kyakuclasssozai.Sort();
        }
        else if (kyaku.name == "yakizakanateisyoku")
        {
            kyakuclasssozai = managementscript.Yakizakana1.GetSozai();
            kyakuclassmoney = managementscript.Yakizakana1.GetNoney();
           // kyakuclasssozai.Sort();
        }

        if (Input.GetMouseButtonDown(0))
        {

            //clickedGameObject = null;

            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit2d.collider)
            {
                clickedGameObject = hit2d.collider.gameObject;

                //if (clickedGameObject.gameObject.tag != "Villain" && clickedGameObject.transform.parent.name != "toree")
                if (clickedGameObject.gameObject.tag != "Villain")
                    clickedGameObjectsprite = clickedGameObject.GetComponent<Sprite>();

                sozai.Add(clickedGameObjectsprite);
                for (int i = 0; i < kyakuclasssozai.Count; i++)
                {
                    if (clickedGameObjectsprite != kyakuclasssozai[i])
                    {
                        continue;
                    }
                    else if (sozai.Count == 1)
                    {
                        clickedGameObject = hit2d.transform.gameObject;


                        Instantiate(clickedGameObject, new Vector2(4.19f, -3.87f),this.transform.rotation);


                        clickedGameObject.transform.parent = toree.transform;
                    }
                    else if(sozai.Count == 2)
                    {
                        clickedGameObject = hit2d.transform.gameObject;

                        Instantiate(clickedGameObject, new Vector2(7.43f, -4.19f), this.transform.rotation);


                        clickedGameObject.transform.parent = toree.transform;
                    }
                    else if(sozai.Count == 3)
                    {
                        clickedGameObject = hit2d.transform.gameObject;

                        Instantiate(clickedGameObject, new Vector2(5.62f, -3.7f), this.transform.rotation);

                        

                        clickedGameObject.transform.parent = toree.transform;
                    }
                }
                //sozai.Sort();
                if (sozai == kyakuclasssozai)
                {
                    ScoreManager.Instance.TotalScore += kyakuclassmoney;
                    foreach (Transform n in toree.transform)
                    {
                        GameObject.Destroy(n.gameObject);
                    }





                }
                
            }
        }
    }
}

