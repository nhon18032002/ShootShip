using UnityEngine;
using UnityEngine.SceneManagement;

public class BnStart:BaseBn
{
    protected override void OnClick()
    {
        base.OnClick();
        SceneManager.LoadScene(0);
    }
}
