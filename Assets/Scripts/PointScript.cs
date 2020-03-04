using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
    private GameObject myObject,galka, Info;
    private AllCity AllCity;
    private string azxcv;
    private GameObject[] Dosts;

    public AllCity d;
    
    private int[,] inf;

    void Awake()
    {
        Info = GameObject.Find("GameMan").GetComponent<GameManager>().Info;
        azxcv = this.gameObject.name;
        myObject = this.gameObject;
        Info.SetActive(false);
        d = GameObject.Find("GameMan").GetComponent<AllCity>();
    }
    
    void Start()
    {
        AllCity = GameObject.Find("GameMan").GetComponent<AllCity>();
    }
    
    void Update()
    {
        Dosts = null;
        Dosts = AllCity.Dosts;
        galka = AllCity.galka;
    }

    private void OnMouseDown()
    {

        for (int i = 0; i < Dosts.Length; i++)
        {
            if (Dosts[i].name == azxcv)
            {
                GameObject asd = Instantiate(Dosts[i],gameObject.transform.position, Quaternion.identity);
                asd.transform.position += new Vector3(0,-0.1700f,0);
                asd.name = azxcv;
                GameObject dsa = Instantiate(galka,gameObject.transform.position + new Vector3(0.1f,-0.1f,-0.03f),Quaternion.identity,asd.transform);
                d.kol += 1;
                //d.names[d.names.Length] = gameObject.name;
                d.names2.Add(gameObject.name);
                Debug.Log(d.names2[0] + " sdf");
            }
        }
        Destroy(myObject);
    }

}
