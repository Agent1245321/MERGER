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
    public static bool[] ocuupied;
    public static float[] income;
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


    public static bool rebirth;
    private int rebirthCost;
    
    // Start is called before the first frame update
    void Start()
    {
        spawns = new Vector3[] 
          { new Vector3(-25, 1, 5), 
            new Vector3(-20, 1, 5), 
            new Vector3(-15, 1, 5), 
            new Vector3(-10, 1, 5), 
            new Vector3(-5, 1, 5), 
            new Vector3(0, 1, 5), 
            new Vector3(5, 1, 5),
            new Vector3(10,1,5),
            new Vector3(15, 1, 5), 
            new Vector3(20,1,5),
            new Vector3(25, 1, 5),
            new Vector3(-25, 1, 0),
            new Vector3(-20, 1, 0),
            new Vector3(-15, 1, 0),
            new Vector3(-10, 1, 0),
            new Vector3(-5, 1, 0),
            new Vector3(0, 1, 0),
            new Vector3(5, 1, 0),
            new Vector3(10,1,0),
            new Vector3(15, 1, 0),
            new Vector3(20,1,0),
            new Vector3(25, 1, 0),
            new Vector3(-25, 1, -5),
            new Vector3(-20, 1, -5),
            new Vector3(-15, 1, -5),
            new Vector3(-10, 1, -5),
            new Vector3(-5, 1, -5),
            new Vector3(0, 1, -5),
            new Vector3(5, 1, -5),
            new Vector3(10,1,-5),
            new Vector3(15, 1, -5),
            new Vector3(20,1,-5),
            new Vector3(25, 1, -5),
            };


        ocuupied = new bool[]
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false

        };


        income = new float[]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
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
    public void Resbirth()
    {
        if (gains >= rebirthCost)
        {
            gains = 0;
            rebirthCost += 10;
            StartCoroutine(Redbirth());
        }
    }
    public IEnumerator Redbirth()
    {
        rebirth = true;
        yield return new WaitUntil(() => !rebirth);
        Debug.Log("Destroyed");
        Rebirth();
        yield return null;
    }
    public void Rebirth()
    {
        Debug.Log("Reset");
        
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
}
