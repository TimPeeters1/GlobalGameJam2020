using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator anim;

    AudioSource audioSource;
    [SerializeField] AudioClip soundOpen;
    [SerializeField] AudioClip soundClose;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            anim.SetBool("OpenDoor", true);
            audioSource.clip = soundOpen;
            audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            anim.SetBool("OpenDoor", false);
            audioSource.clip = soundClose;
            audioSource.Play();
        }
    }
}