using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkShop : MonoBehaviour
{
    public GameObject[] Prefabs;
    public float betweenx;
    public float betweeny;
    private float posx = 0f;
    private float posy = 0f;
    public int x;
    private int y;
        void Start()
    {
        for(int i = 0; i < Prefabs.Length; i++)
        {
            if (posx == betweenx*x && i != 0)
            {
              posx = 0;
              posy = posy - betweeny;
            }
         Prefabs[i].transform.localPosition += new Vector3(posx, posy, 0f);
         posx = posx + betweenx;
        }
    }
}
