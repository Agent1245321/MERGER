using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Managing : MonoBehaviour
{
    
    public static Vector3[] spawns;
    [SerializeField]
    public  bool[] ocuupied;
    [SerializeField]
    public  float[] income;


    public GameObject prefab;
    int fOS; // first open slot
    public int gains = 10;
    public int gems = 0;

    private int cost = 10;

    public TextMeshProUGUI gainText;
    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI gemcostText;
    public TextMeshProUGUI gemText;



    public static int incomeRate;


    public bool rebirth;
    private int rebirthCost;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] item = new GameObject[]
        {
            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null
        };

        StartCoroutine(Income());
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (gains >= cost)
        {
            gains -= cost;
            cost = (int)Math.Floor( cost * 1.2);
            fOS = Array.IndexOf(ocuupied, false);
            Instantiate(prefab, spawns[fOS], Quaternion.identity);
            ocuupied[fOS] = true;
        }
       
    }
   /* public void Resbirth()
    {
        Debug.Log("Res");
        if (gains >= rebirthCost)
        {
            gains = 0;
            rebirthCost += 10;
            StartCoroutine(Redbirth());
        }
    }
    public IEnumerator Redbirth()
    {
        Debug.Log("Red");
        rebirth = true;
        bool emptyList = ocuupied.All(element => element = false);
        yield return new WaitUntil(() => emptyList == true);
        Debug.Log("Destroyed");
        Rebirth();
        yield return null;
    }
    public void Rebirth()
    {
        Debug.Log("Reb");

        int tick = 0;


       foreach (bool item in ocuupied)
        {
            ocuupied[tick] = false;
            income[tick] = 0;
            tick++;
        }

        gains = 10;
        cost = 10;
        gems += 50;
        rebirth = false;
        Debug.Log("I Reset It");

        
    }

    */


    public void Rebirth1()
    {
        rebirth = true;
    }

    public void Rebirth2()
    {
        gems += 50;
    }

    public void Update()
    {
        incomeRate = (int)income.Sum();
        
    }

    public void LateUpdate()
    {
        incomeText.text = $"Income: {incomeRate}ps";
        gainText.text = $"${gains}";
        costText.text = $" Buy Item: {cost}";
        gemcostText.text = $"Rebirth: {rebirthCost}";
        gemText.text = $"{gems} gems";
    }

    public IEnumerator Income()
    {
        while(1==1)
        {
            yield return new WaitForSeconds(1);
            gains += incomeRate;
        }

    }


    // MAKE A DANG GAME OBJCT ARRAY
}
