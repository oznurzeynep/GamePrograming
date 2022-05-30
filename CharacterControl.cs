using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float characterSpeed;
    [SerializeField]
    private float characterHp = 100;
    bool live;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        live = true;
    }

    void Update()
    {
        if (characterHp <= 0)
        {
            live = false;
            anim.SetBool("Live", live);
        }

        if (live == true)
        {
            Move();
        }
    }

    public float GetCharacterHP()
    {
        return characterHp;
    }

    public bool Live()
    {
        return live;
    }

    public void TakeDamageC()
    {
        characterHp -= Random.Range(5, 10);
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", hor);
        anim.SetFloat("Vertical", ver);

        this.gameObject.transform.Translate(hor * characterSpeed * Time.deltaTime, 0, ver * characterSpeed * Time.deltaTime);
    }
}
