using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : MonoBehaviour
{
    protected TextMeshProUGUI text;
    private void Awake()
    {
        this.LoadComponent();

    }
    protected virtual void LoadComponent()
    {
        this.text = GetComponent<TextMeshProUGUI>();
    }
}
