using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPos : MonoBehaviour
{
    
    void Update()
    {
        Vector3 pos = new Vector3(0,1,0);
        transform.position = transform.parent.parent.position + pos;
        transform.rotation= Quaternion.Euler(0,0,0);
    }
}
