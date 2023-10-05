using UnityEngine;

public class AudioGame : MonoBehaviour
{
    public static AudioGame instance;
    private void Awake()
    {
        if (AudioGame.instance == null)
        {
            AudioGame.instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        Destroy(gameObject);
    }
}
