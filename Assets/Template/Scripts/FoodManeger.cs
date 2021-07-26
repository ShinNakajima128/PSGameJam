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


    void Start()
    {

        for (int i = 0; i < food.Length; i++)
        {
            if(gameObject.tag == "kare-")
            {
                Cary carry1 = new Cary();
                carry1.money = cary_money ;
                var ruu = GameObject.FindGameObjectWithTag("ru-");
                var rice = GameObject.FindGameObjectWithTag("raisu");
                var niku = GameObject.FindGameObjectWithTag("niku");
                carry1.sozai.Add(ruu) ;
                carry1.sozai.Add(rice);
                carry1.sozai.Add(niku);
            }
            else if(gameObject.tag == "ra-men")
            {
                Rarmen rarmen1 = new Rarmen();
                rarmen1.money = rarmen_money;
                var men = GameObject.FindGameObjectWithTag("men");
                var nori = GameObject.FindGameObjectWithTag("nori");
                var niku = GameObject.FindGameObjectWithTag("niku");
                rarmen1.sozai.Add(men);
                rarmen1.sozai.Add(nori);
                rarmen1.sozai.Add(niku);
            }
            else if (gameObject.tag == "susi")
            {
                Susi susi1 = new Susi();
                susi1.money = susi_money;
                var sakana = GameObject.FindGameObjectWithTag("sakana");
                var raisu = GameObject.FindGameObjectWithTag("raisu");
                var nori = GameObject.FindGameObjectWithTag("nori");
                susi1.sozai.Add(sakana);
                susi1.sozai.Add(raisu);
                susi1.sozai.Add(nori);
            }
            else if (gameObject.tag == "yakizakana")
            {
                Yakizakanateisyoku Yakizakana1 = new Yakizakanateisyoku();
                Yakizakana1.money = yakizalanateisyoku_money;
                var sakana = GameObject.FindGameObjectWithTag("sakana");
                var raisu = GameObject.FindGameObjectWithTag("raisu");
                Yakizakana1.sozai.Add(sakana);
                Yakizakana1.sozai.Add(raisu);
            }
            else if (gameObject.tag == "gyudon")
            {
                Gyudon gyudon1 = new Gyudon();
                gyudon1.money = gyudon_money;
                var niku = GameObject.FindGameObjectWithTag("niku");
                var raisu = GameObject.FindGameObjectWithTag("raisu");
                gyudon1.sozai.Add(niku);
                gyudon1.sozai.Add(raisu);
            }
        }
    }

    public class Rarmen
    {
        public List<GameObject> sozai = new List<GameObject>();
        public int money;

        public List<GameObject> GetSozai()
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
        public List<GameObject> sozai = new List<GameObject>();
        public int money;

        public List<GameObject> GetSozai()
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
        public List<GameObject> sozai = new List<GameObject>();
        public int money;

        public List<GameObject> GetSozai()
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
        public List<GameObject> sozai = new List<GameObject>();
        public int money;

        public List<GameObject> GetSozai()
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
        public List<GameObject> sozai = new List<GameObject>();
        public int money;

        public List<GameObject> GetSozai()
        {
            return sozai;
        }

        public int GetNoney()
        {
            return money;
        }
    }


}
