using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInputMouse : MonoBehaviour
{
    static public LoadInputMouse instance;
    protected Vector3 mousePos;
    public Vector3 MousePosition { get => mousePos; }
    private void Awake()
    {
        LoadInputMouse.instance = this;
    }
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        this.GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.mousePos.z = 0f;
    }
}
