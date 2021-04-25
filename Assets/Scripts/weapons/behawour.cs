using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behawour : MonoBehaviour
{
    public Animator animator;
    public Animator cam_animator;

    public Rigidbody player_rb;
    public float impact_forse;
    public Transform cam;

    public bool canshoot = true;
    public float waittime;

    public void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (canshoot == true))
        {
            animator.Play("shoot");
            cam_animator.Play("cam_shoot");
            player_rb.AddForce(cam.transform.forward * -impact_forse);
            StartCoroutine(waiter());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.Play("reload");
        }
    }

    IEnumerator waiter()
    {
        canshoot = false;
        yield return new WaitForSeconds(waittime);
        canshoot = true;
    }
}