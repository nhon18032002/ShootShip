using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance; 
    PlayerReceiveDamage player;
    SpawnShape spawnShape;
    public bool gameRun = true;
    public float gameSpeed=1f;
    public float gameTime = 1f;
    private void Awake()
    {
        GameManager.instance = this;
        this.player=Transform.FindObjectOfType<PlayerReceiveDamage>();
        this.spawnShape = Transform.FindObjectOfType<SpawnShape>();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void FixedUpdate()
    {
        if (this.player.isDeath()&&this.gameRun) this.StopGame();
    }
    protected void StopGame()
    {
        this.spawnShape.isSpawn = false;
        Transform holder = this.spawnShape.transform.Find("Holder");
        //holder.gameObject.SetActive(false);
        foreach (Transform gameObj in holder)
        {
            DamageReceiver damageReceiver = gameObj.GetComponentInChildren<DamageReceiver>();
            damageReceiver.ShipHp = 0;
        }
        AudioManager.instance.PlayAudio(2);
        //AudioManager.instance.aus.Stop();
        this.gameRun = false;
    }
    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0f;
    }    
      
}
