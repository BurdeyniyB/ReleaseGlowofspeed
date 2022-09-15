using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lock_player : MonoBehaviour
{
    public GameObject[] Obj;
    public GameObject[] ObjLock;
    public SkinManager skinManager;
    public int a;
    void Start()
    {
            if (skinManager.IsUnlocked(a))
            {
               for (int i = 0; i < Obj.Length; i++)
               {
                 Obj[i].SetActive(true);
               }

               for (int i = 0; i < ObjLock.Length; i++)
               {
                 ObjLock[i].SetActive(false);
               }
            }
            else
            {
                for (int i = 0; i < Obj.Length; i++)
               {
                 Obj[i].SetActive(false);
               }

               for (int i = 0; i < ObjLock.Length; i++)
               {
                 Obj[i].SetActive(true);
               }
            }
    }
}
