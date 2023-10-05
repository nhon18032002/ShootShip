using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewInventory : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);    
    }
    public void OpenInventory()
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        
    }
    public void CloseInventory()
    {
        if(gameObject.activeSelf) gameObject.SetActive(false);
    }
}
