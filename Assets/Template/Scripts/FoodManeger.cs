using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FoodManeger : MonoBehaviour
{
    [SerializeField] GameObject[] food;

    [SerializeField] int cary_money;
    [SerializeField] int rarmen_money;
    [SerializeField] int susi_money;
    [SerializeField] int yakizalanateisyoku_money;
    [SerializeField] int gyudon_money;
    public Cary carry1;
    public Rarmen rarmen1;
    public Susi susi1;
    public Yakizakanateisyoku Yakizakana1;
    public Gyudon gyudon1;

    void Start()
    {

        for (int i = 0; i < food.Length; i++)
        {
            if (food[i].gameObject.tag == "kare-")
            {
                carry1 = new Cary();
                carry1.money = cary_money;
                var ruu = GameObject.FindGameObjectWithTag("ru-").GetComponent<Sprite>();
                var rice = GameObject.FindGameObjectWithTag("raisu").GetComponent<Sprite>();
                var niku = GameObject.FindGameObjectWithTag("niku").GetComponent<Sprite>();
                carry1.sozai.Add(ruu);
                carry1.sozai.Add(rice);
                carry1.sozai.Add(niku);
            }
            else if (food[i].gameObject.tag == "ra-men")
            {
                rarmen1 = new Rarmen();
                rarmen1.money = rarmen_money;
                var men = GameObject.FindGameObjectWithTag("men").GetComponent<Sprite>();
                var nori = GameObject.FindGameObjectWithTag("nori").GetComponent<Sprite>();
                var niku = GameObject.FindGameObjectWithTag("niku").GetComponent<Sprite>();
                rarmen1.sozai.Add(men);
                rarmen1.sozai.Add(nori);
                rarmen1.sozai.Add(niku);
            }
            else if (food[i].gameObject.tag == "susi")
            {
                susi1 = new Susi();
                susi1.money = susi_money;
                var sakana = GameObject.FindGameObjectWithTag("sakana").GetComponent<Sprite>();
                var raisu = GameObject.FindGameObjectWithTag("raisu").GetComponent<Sprite>();
                var nori = GameObject.FindGameObjectWithTag("nori").GetComponent<Sprite>();
                susi1.sozai.Add(sakana);
                susi1.sozai.Add(raisu);
                susi1.sozai.Add(nori);
            }
            else if (food[i].gameObject.tag == "yakizakana")
            {
                Yakizakana1 = new Yakizakanateisyoku();
                Yakizakana1.money = yakizalanateisyoku_money;
                var sakana = GameObject.FindGameObjectWithTag("sakana").GetComponent<Sprite>();
                var raisu = GameObject.FindGameObjectWithTag("raisu").GetComponent<Sprite>();
                Yakizakana1.sozai.Add(sakana);
                Yakizakana1.sozai.Add(raisu);
            }
            else if (food[i].gameObject.tag == "gyudon")
            {
                gyudon1 = new Gyudon();
                gyudon1.money = gyudon_money;
                var niku = GameObject.FindGameObjectWithTag("niku").GetComponent<Sprite>();
                var raisu = GameObject.FindGameObjectWithTag("raisu").GetComponent<Sprite>();
                gyudon1.sozai.Add(niku);
                gyudon1.sozai.Add(raisu);
            }
        }
    }
}

public class Rarmen
{
    public List<Sprite> sozai = new List<Sprite>();
    public int money;

    public List<Sprite> GetSozai()
    {
        return sozai;
    }

    public int GetNoney()
    {
        return money;
    }
}

public class Cary
{
    public List<Sprite> sozai = new List<Sprite>();
    public int money;

    public List<Sprite> GetSozai()
    {
        return sozai;
    }

    public int GetNoney()
    {
        return money;
    }
}

public class Susi
{
    public List<Sprite> sozai = new List<Sprite>();
    public int money;

    public List<Sprite> GetSozai()
    {
        return sozai;
    }

    public int GetNoney()
    {
        return money;
    }
}

public class Yakizakanateisyoku
{
    public List<Sprite> sozai = new List<Sprite>();
    public int money;

    public List<Sprite> GetSozai()
    {
        return sozai;
    }

    public int GetNoney()
    {
        return money;
    }
}

public class Gyudon
{
    public List<Sprite> sozai = new List<Sprite>();
    public int money;

    public List<Sprite> GetSozai()
    {
        return sozai;
    }

    public int GetNoney()
    {
        return money;
    }
}
