using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int obrpls = 1;
    int obrnas = 1;
    int obrvvp = 1;
    public GameObject[] Gmob;
    public GameObject[] GDost,DostMap;
    public GameObject Info,SpisokButton,Kolvo_stran,Kolvo_stran_kol,Spis_List,Listok;
    public Text Tinfo1, Tinfo2, Tinfo3;
    public Text Sps1, Sps2, Sps3, Sps4;
    public Text StrokaGlav1, StrokaGlav2, StrokaGlav3, StrokaGlav4;
    
    private Vector3 dsa1,dsa2,dsa3,dsa4;
    [HideInInspector]public AllCity d;
    [System.Serializable]
    public struct city
    {
        public string name;
        public float pls;
        public float nas;
        public float vvp;

        public city(string namec, float plsc, float nasc, float vvpc)
        {
            name = namec;
            pls = plsc;
            nas = nasc;
            vvp = vvpc;
        }
    }

    public city[] citys;
    public city[] citys2;
    
    void Start()
    {
        Spis_List.SetActive(false);
        d = GameObject.Find("GameMan").GetComponent<AllCity>();
        Gmob = GameObject.FindGameObjectsWithTag("Marker");
    }

    void Update()
    {
        Gmob = null;
        Gmob = GameObject.FindGameObjectsWithTag("Marker");
        
        for(int i = 0; i < Gmob.Length; i++)
        {
            if (!Gmob[i].GetComponent<PointScript>())
            {
                Gmob[i].AddComponent<PointScript>();
            }
        }

        Kolvo_stran_kol.GetComponent<Text>().text = "Количество выбранных стран: " + d.kol + " ";
            
        GDost = null;
        GDost = GameObject.FindGameObjectsWithTag("Dost");
        
        for(int i = 0; i < GDost.Length; i++)
        {
            if (!GDost[i].GetComponent<DostScript>())
            {
                GDost[i].AddComponent<DostScript>();
            }
        }

        if (d.kol == 1)
        {
            Info.SetActive(true);

            for (int j = 0; j < citys.Length; j++)
            {
                if (d.names2[0] == citys[j].name)
                {
                    Tinfo1.text = " Площадь: " + citys[j].pls + " ";
                    Tinfo2.text = " ВВП: " + citys[j].vvp + " ";
                    Tinfo3.text = " Население: " + citys[j].nas + " ";
                }
                else
                {
                    Debug.Log("NetTakoga");
                }
            }
        }
        if (d.kol <= 1)
        {
            SpisokButton.SetActive(false);
            Kolvo_stran.SetActive(false);
        }
        if (d.kol > 1)
        {
            
            Info.SetActive(false);
            SpisokButton.SetActive(true);
            Kolvo_stran.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SortPls();
        }
    }

    public void SpisokPokaz()
    {
        citys2 = new city[d.names2.Count];
        
        Spis_List.SetActive(true);
        
        for (int g = 0; g < d.names2.Count; g++)
        {
            for (int k = 0; k < citys.Length; k++)
            {
                if (d.names2[g] == citys[k].name)
                {
                    citys2[g] = citys[k];
                }
            }
        }
        
        SpisokForm();
    }

    public void SortPls()
    {
        city temp;
        for (int i = 0; i < citys2.Length-1; i++)
        {
            for (int j = i + 1; j < citys2.Length; j++)
            {
                if (obrpls == 1)
                {
                    if (citys2[i].pls > citys2[j].pls)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
                if (obrpls == -1)
                {
                    if (citys2[i].pls < citys2[j].pls)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
            }
        }
        obrpls *= -1;
        SpisokClear();
        SpisokForm();
    }
    public void SortNas()
    {
        city temp;
        for (int i = 0; i < citys2.Length-1; i++)
        {
            for (int j = i + 1; j < citys2.Length; j++)
            {
                if (obrnas == 1)
                {
                    if (citys2[i].nas > citys2[j].nas)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
                if (obrnas == -1)
                {
                    if (citys2[i].nas < citys2[j].nas)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
            }
        }
        obrnas *= -1;
        SpisokClear();
        SpisokForm();
    }
    public void SortVvp()
    {
        city temp;
        for (int i = 0; i < citys2.Length-1; i++)
        {
            for (int j = i + 1; j < citys2.Length; j++)
            {
                if (obrvvp == 1)
                {
                    if (citys2[i].vvp > citys2[j].vvp)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
                if (obrvvp == -1)
                {
                    if (citys2[i].vvp < citys2[j].vvp)
                    {
                        temp = citys2[i];
                        citys2[i] = citys2[j];
                        citys2[j] = temp;
                    }
                }
            }
        }
        obrvvp *= -1;
        SpisokClear();
        SpisokForm();
    }

    private void SpisokForm()
    {
        dsa1 = StrokaGlav1.transform.position;
        dsa2 = StrokaGlav2.transform.position;
        dsa3 = StrokaGlav3.transform.position;
        dsa4 = StrokaGlav4.transform.position;
        for (int u = 0; u < d.names2.Count; u++)
        {
            Text sady1 = Instantiate(Sps1, dsa1 + new Vector3(0, -100, 0), Quaternion.identity,
                        Listok.transform);
                    sady1.text = citys2[u].name;
                    sady1.tag = "spis";
                    Text sady2 = Instantiate(Sps2, dsa2 + new Vector3(0, -100, 0), Quaternion.identity,
                        Listok.transform);
                    sady2.text = citys2[u].pls.ToString();
                    sady2.tag = "spis";
                    Text sady3 = Instantiate(Sps3, dsa3 + new Vector3(0, -100, 0), Quaternion.identity,
                        Listok.transform);
                    sady3.text = citys2[u].nas.ToString();
                    sady3.tag = "spis";
                    Text sady4 = Instantiate(Sps4, dsa4 + new Vector3(0, -100, 0), Quaternion.identity,
                        Listok.transform);
                    sady4.text = citys2[u].vvp.ToString();
                    sady4.tag = "spis";

                    dsa1 = sady1.transform.position;
                    dsa2 = sady2.transform.position;
                    dsa3 = sady3.transform.position;
                    dsa4 = sady4.transform.position;
        }
    }

    public void SpisokClear()
    {
        GameObject[] asgd = GameObject.FindGameObjectsWithTag("spis");
        for (int r = 0; r < asgd.Length; r++)
        {
            Destroy(asgd[r]);
        }
    }

    public void BackBut()
    {
        SpisokClear();
        Spis_List.SetActive(false);
    }

    public void ButSpisClr()
    {
        SpisokClear();
        DostMap = GameObject.FindGameObjectsWithTag("Dost");
        for (int b = 0; b < DostMap.Length; b++)
        {
            DostMap[b].GetComponent<DostScript>().BackPoint();
        }
        d.kol = 0;
        d.names2.Clear();
    }
    
}
