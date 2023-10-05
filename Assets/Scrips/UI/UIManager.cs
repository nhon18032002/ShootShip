using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button button;
    private void Update()
    {
        if (this.button.gameObject.activeSelf &&!GameManager.instance.gameRun) this.button.gameObject.SetActive(false);
    }
}
