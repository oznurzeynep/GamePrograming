using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text magazineText;
    public Text HpText;
    public GameObject Menu;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("SWAT");
    }

    void Update()
    {
        magazineText.text = player.GetComponent<ShootSystem>().GetMagazine().ToString() + "/" + player.GetComponent<ShootSystem>().GetAmmo().ToString();
        HpText.text = "HP: " + player.GetComponent<CharacterControl>().GetCharacterHP();

        if (Input.GetKey(KeyCode.Escape))
        {
            StopGame();
        }
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }
}
