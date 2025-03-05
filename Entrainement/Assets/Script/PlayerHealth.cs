using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData dataPlayer;
    public bool isInvulnerable = false;
    public float invulnerableTime = 2.20f;
    public float invulnerableFlash = 0.2f;
    public SpriteRenderer sr;
    public VoidEventchannel onPlayerDeath;
    void Start()
    {
        dataPlayer.currentLifePoints = dataPlayer.maxLifePoints;
    }
    public void Hurt(int damage = 1){
        if(isInvulnerable){
            return;
        }
        dataPlayer.currentLifePoints = dataPlayer.currentLifePoints - damage;
        if (dataPlayer.currentLifePoints <= 0){
            onPlayerDeath.Raise();
        }else{
            StartCoroutine(Invulnerable());
        }
    }
    IEnumerator Invulnerable(){
        isInvulnerable = true;
        Color startColor = sr.color;
        WaitForSeconds invulnerableFlashWait = new WaitForSeconds(invulnerableFlash);
        for (float i = 0;i <= invulnerableTime; i += invulnerableFlash){
            if(sr.color.a == 1){
                sr.color = Color.clear; 
            }else{
                sr.color = startColor;
            }
            yield return invulnerableFlashWait;
        }
        sr.color = startColor;
        isInvulnerable = false;
        yield return null;
    }
}
