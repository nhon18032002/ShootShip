using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBn : MonoBehaviour
{
    protected Button bn;
    protected virtual void Start()
    {
        this.bn.onClick.AddListener(OnClick);
    }
    protected void Awake()
    {
        this.LoadComponent();
    }
    protected void LoadComponent()
    {
        this.bn = GetComponent<Button>();
    }

    protected virtual void OnClick()
    {

    }
}
