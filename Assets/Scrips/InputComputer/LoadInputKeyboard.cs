using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoadInputKeyboard : MonoBehaviour
{
    static public LoadInputKeyboard instance;
    public Vector3 keyboardPos;
    public float speed=2f;
    // Start is called before the first frame update
    private void Awake()
    {
        LoadInputKeyboard.instance = this;
    }
    private void Update()
    {
        this.GetNewPos();
    }
    protected virtual void GetNewPos()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        this.keyboardPos=movement;
    }
}
