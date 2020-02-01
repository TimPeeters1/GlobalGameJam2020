using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    Animator anim;
    AudioSource source;
    [SerializeField]AudioClip[] slapSounds;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 3f, Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.Play("Hit");
            source.PlayOneShot(slapSounds[Random.Range(0, slapSounds.Length)]);
            StartCoroutine(HitObject());
        }
    }

    IEnumerator HitObject()
    {
        yield return new WaitForSeconds(0.25f);

        RaycastHit hit;
        Ray camRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(camRay, out hit, 3f))
        {
            try
            {
                hit.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1000f);
            }
            catch 
            {

            }
        }
    }
}
