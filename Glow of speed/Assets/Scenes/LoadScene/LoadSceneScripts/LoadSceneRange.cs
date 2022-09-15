using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneRange : MonoBehaviour
{
    public InternetConection internetConection;
    public void Rangeforload()
    {
        int _range = Random.Range(50, 99);
        Debug.Log("RandomeRange = " + _range);
        internetConection.LoadRange(_range);
    }

    public void RangeforCoroutine()
    {
        int _range = Random.Range(0, 3);
    }
}
