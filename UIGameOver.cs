using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    public GameObject GameOver;
    Animator anim;
    bool live;
    private float characterHp = 100;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("SWAT");
    }

    void Update()
    {
        characterHp = player.GetComponent<CharacterControl>().GetCharacterHP();

        if (characterHp <= 0)
        {
            StopGame();
        }
    }

    public void StopGame()
    {
        GameOver.SetActive(true);
        //Time.timeScale = 0;
    }
}
