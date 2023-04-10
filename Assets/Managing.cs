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

    private int cost = 10;

    public TextMeshProUGUI gainText;
    public TextMeshProUGUI incomeText;
    public TextMeshProUGUI costText;

    

    public static int incomeRate;
    
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

    public void Update()
    {
        incomeRate = (int)income.Sum();
        
    }

    public void LateUpdate()
    {
        incomeText.text = $"Income: {incomeRate}ps";
        gainText.text = $"${gains}";
        costText.text = $" Buy Item: {cost}";
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
