using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float speed = 1f;
    protected Vector3 newPos;
    protected float rotation;
    protected Vector3 directery= Vector3.right;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        this.Move();
    }
    protected virtual void Move()
    {
        
    }
}
