using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class ClickingScript : MonoBehaviour
{
    private Managing managing;
    public static bool itemIsSelected;
    public static int sIN = -1; //selected item number
    public static GameObject selectedObject;
    private int pIN = 0; // personal item number
    private bool thisIsSelected;
    private int arrayLocation;


    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        managing = GameObject.FindWithTag("Manager").GetComponent<Managing>();
        mesh = this.GetComponent<MeshRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (managing.rebirth) { DestroySelf(); }
        if (thisIsSelected)
        {
            mesh.material.color = Color.red;
        }
        else if (this.pIN == sIN) { mesh.material.color = Color.blue; }
        else
        {
            mesh.material.color = Color.green;
        }

        this.gameObject.transform.localScale = new Vector3(pIN + 1, pIN +1, pIN + 1);

        arrayLocation = Array.IndexOf(Managing.spawns, this.transform.position);

        if(!managing.rebirth) managing.income[arrayLocation] = (Mathf.Pow(2, 1.5f * pIN));


    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!itemIsSelected) 
            {itemIsSelected = true; sIN = pIN; thisIsSelected = true; selectedObject = this.gameObject; }

            else if (sIN == pIN && !thisIsSelected) 
            {
                selectedObject.GetComponent<ClickingScript>().DestroySelf();
                pIN++;
                sIN= -1;
                itemIsSelected = false;
            }
            else if(thisIsSelected)
            {
                thisIsSelected = false;
                selectedObject = null;
                itemIsSelected = false;
                sIN = 0;
            }
            
        }

       
    }

    

    public void DestroySelf()
    {
        managing.income[arrayLocation] = 0;
        managing.ocuupied[arrayLocation] = false;
        if (thisIsSelected && !managing.rebirth) { Destroy(this.transform.root.gameObject); }

        if (managing.rebirth)
        {
           if(Managing.incomeRate == (int)Mathf.Pow(2, 1.5f * pIN))
            {
                Debug.Log("This is the last one");
                managing.rebirth = false;
                
                Destroy(this.transform.root.gameObject);
                managing.Rebirth2();
            }
           else
            {
                Debug.Log("This is not last one");
                Destroy(this.transform.root.gameObject);
            }
        }
    }

}
