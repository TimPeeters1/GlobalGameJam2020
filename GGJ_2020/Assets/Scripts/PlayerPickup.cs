using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    Animator anim;
    AudioSource source;

    [SerializeField] GameObject handAttachPos;

    [SerializeField] AudioClip[] slapSounds;

    public GameObject currentItem;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.Play("Hit");
            source.PlayOneShot(slapSounds[Random.Range(0, slapSounds.Length)]);
            StartCoroutine(HitObject());
        }

        if(currentItem != null && Input.GetKey(KeyCode.Mouse0)){
            StartCoroutine(ReleaseObject());
        }

        if (currentItem)
        {
            currentItem.transform.position = handAttachPos.transform.position;
        }
    }
    IEnumerator ReleaseObject()
    {
        currentItem.layer = 0;

        yield return new WaitForSeconds(0.25f);

        currentItem.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 300f);
        currentItem = null;
    
    }

    IEnumerator HitObject()
    {
        yield return new WaitForSeconds(0.25f);

        RaycastHit hit;
        Ray camRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(camRay, out hit, 5f))
        {
            try
            {
                if (hit.collider.GetComponent<FixPickup>())
                {
                    currentItem = hit.collider.gameObject;
                    currentItem.layer = 10;
                    hit.collider.gameObject.transform.position = handAttachPos.transform.position;
                    hit.collider.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    hit.collider.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                else
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 50f);
                }
                
            }
            catch 
            {

            }
        }
    }
}
