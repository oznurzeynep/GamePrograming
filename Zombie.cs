using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    [SerializeField]
    public float zombieHP = 100;
    Animator zombieAnim;
    bool zombieDead;
    public float sensingDistance;
    public float attackDistance;
    NavMeshAgent zombieNavMesh;

    GameObject targetPlayer;

    AudioSource audioSource;
    public AudioClip attackAudio;

    void Start()
    {
        zombieAnim = this.GetComponent<Animator>();
        targetPlayer = GameObject.Find("SWAT");
        zombieNavMesh = transform.GetComponent<NavMeshAgent>();
        audioSource = transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (zombieHP <= 0)
        {
            zombieDead = true;
        }

        if (zombieDead == true)
        {
            zombieAnim.SetBool("Died", true);
            StartCoroutine(Disappear());
        }

        else
        {
            float distance = Vector3.Distance(this.transform.position, targetPlayer.transform.position);
            if (distance < sensingDistance)
            {
                zombieNavMesh.isStopped = false;
                zombieNavMesh.SetDestination(targetPlayer.transform.position);
                zombieAnim.SetBool("Walking", true);
                this.transform.LookAt(targetPlayer.transform.position);
            }
            else
            {
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("Walking", false);
                zombieAnim.SetBool("Attack", false);
            }
            if (distance < attackDistance)
            {
                this.transform.LookAt(targetPlayer.transform.position);
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("Walking", false);
                zombieAnim.SetBool("Attack", true);
            }
        }
    }

    public void DamageAudio()
    {
        audioSource.PlayOneShot(attackAudio);
    }

    public void Damage()
    {
        targetPlayer.GetComponent<CharacterControl>().TakeDamageC();
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    public void TakeDamage()
    {
        zombieHP -= Random.Range(35, 45);
    }
}
