using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DostScript : MonoBehaviour
{
    public GameObject Pointsa,Info;
    public AllCity d;

    public string[] names;
    public void Start()
    {
        d = GameObject.Find("GameMan").GetComponent<AllCity>();
    }

    private void OnMouseDown()
    {
        BackPoint();
    }

    public void BackPoint()
    {
        GameObject asd = Instantiate(Pointsa,gameObject.transform.position, Quaternion.identity);
        asd.transform.position += new Vector3(0,+0.1700f,0);
        asd.name = gameObject.name;
        Destroy(gameObject);
        d.kol -= 1;
        d.names2.Remove(gameObject.name);
    }
}
