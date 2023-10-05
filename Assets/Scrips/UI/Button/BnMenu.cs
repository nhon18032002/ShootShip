using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BnMenu : BaseBn
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gameObject.SetActive(false);
    } 
    public void Active()
    {
        if (gameObject.activeSelf) gameObject.SetActive(false);

        else
            gameObject.SetActive(true);
    }
    public void ContinueGame()
    {
        if(Time.timeScale==0)
        {
            Time.timeScale = 1f;
        }    
    }    
}
