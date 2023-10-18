using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D pol;
    private AudioSource audioSource;
    public AudioClip forceField;
    void Start()
    {
        anim = GetComponent<Animator>();
        pol = GetComponent<PolygonCollider2D>();
        audioSource = GameObject.FindGameObjectWithTag("Barrier").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robot") || other.gameObject.CompareTag("Player"))
        {
            anim.SetInteger("State", 1);
            audioSource.PlayOneShot(forceField);
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetInteger("State", 1);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Robot") || other.gameObject.CompareTag("Player"))
        {
            anim.SetInteger("State", 0);
            audioSource.PlayOneShot(forceField);
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<Animator>().SetInteger("State", 0);
            
        }
    }
}
