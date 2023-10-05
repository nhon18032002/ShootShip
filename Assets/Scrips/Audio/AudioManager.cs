using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance; 
    public AudioSource aus;
    public AudioClip clip;
    public List<AudioClip> listClip;
    // Start is called before the first frame update
    private void Awake()
    {
        AudioManager.instance = this;
        this.aus = GetComponent<AudioSource>();
        
        this.LoadListClip();
    }
    protected void LoadListClip()
    {
        Transform listAudio = GameObject.Find("ListAudio").transform;
        foreach (Transform trf in listAudio)
        {
            this.listClip.Add(trf.GetComponent<AudioSource>().clip);
        }
    }
    // Update is called once per frame
   
    public void PlayAudio(int indexAudio)
    {
        this.aus.PlayOneShot(this.listClip[indexAudio]);
    }
}
