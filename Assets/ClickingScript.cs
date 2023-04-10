using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class ClickingScript : MonoBehaviour
{

    public static bool itemIsSelected;
    public static int sIN; //selected item number
    public static GameObject selectedObject;
    private int pIN = 0; // personal item number
    private bool thisIsSelected;
    private int arrayLocation;


    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
         mesh = this.GetComponent<MeshRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
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

        Managing.income[arrayLocation] = (Mathf.Pow(2, 2 *pIN));
        
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!itemIsSelected) 
            {itemIsSelected = true; sIN = pIN; thisIsSelected = true; selectedObject = this.gameObject; }

            else if (sIN == pIN && !thisIsSelected) 
            {
                selectedObject.GetComponent<ClickingScript>().destroySelf();
                pIN++;
                sIN= 0;
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

    

    public void destroySelf()
    {
        Managing.income[arrayLocation] = 0;
        Managing.ocuupied[arrayLocation] = false;
        if (thisIsSelected) { Destroy(this.gameObject); }
    }

}
