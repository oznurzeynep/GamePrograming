using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    Camera cam;
    public LayerMask zombieLayer;
    CharacterControl characterHp;
    public ParticleSystem muzzleFlash;
    Animator anim;

    private float magazine = 5;
    private float ammo = 10;
    private float magazineCapacity = 5;

    AudioSource audioSource;
    public AudioClip shootAudio;
    public AudioClip reloadAudio;

    void Start()
    {
        cam = Camera.main;
        characterHp = this.gameObject.GetComponent<CharacterControl>();
        anim = this.gameObject.GetComponent<Animator>();
        audioSource = this.gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (characterHp.Live() == true)
        {
            if (Input.GetMouseButton(0))
            {
                if (magazine > 0)
                {
                    anim.SetBool("Shoot", true);
                }
                if (magazine <= 0)
                {
                    anim.SetBool("Shoot", false);
                }
                if (magazine <= 0 && ammo > 0)
                {
                    anim.SetBool("magazineChange", true);
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("Shoot", false);
            }
        }
    }

    public void MagazineChangeAudio()
    {
        audioSource.PlayOneShot(reloadAudio);
        audioSource.volume = 1f;
    }

    public void MagazineChange()
    {
        audioSource.volume = 1f;
        ammo -= magazineCapacity - magazine;
        magazine = magazineCapacity;
        anim.SetBool("magazineChange", false);
    }

    public void Shoot()
    {
        magazine--;
        if (magazine > 0)
        {
            muzzleFlash.Play();
            audioSource.PlayOneShot(shootAudio);
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombieLayer))
            {
                hit.collider.gameObject.GetComponent<Zombie>().TakeDamage(); 
            }
        } 
    }

    public float GetMagazine()
    {
        return magazine;
    }

    public float GetAmmo()
    {
        return ammo;
    }
}
