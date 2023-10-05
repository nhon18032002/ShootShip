using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    private void Awake()
    {
        this.LoadComponent();

    }
    private void Start()
    {
        this.AddOnClickEvent();
    }
    protected virtual void LoadComponent()
    {
        this.slider = GetComponent<Slider>();
    }
    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float hp);
}
