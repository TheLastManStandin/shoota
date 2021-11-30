using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behawour : MonoBehaviour
{
    public Animator animator;
    public Animator cam_animator;

    public Rigidbody player_rb;

    public Transform cam;
    public Transform sp; //shooting point

    public bool canshoot = true;

    public float impact_forse;
    public float waittime;
    public float weapon_damage;

    public void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && (canshoot == true))
        {
            // непосредсвенно срельба
            RaycastHit hit;
            if (Physics.Raycast(sp.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(sp.position, transform.TransformDirection(Vector3.back) * 1000000, Color.yellow, 10);
                if (hit.collider.tag == "enemy")
                {
                    hit.collider.GetComponent<enemymain>().take_damage(weapon_damage);
                }
            }
            //

            // анимация
            animator.Play("shoot");
            cam_animator.Play("cam_shoot");
            player_rb.AddForce(cam.transform.forward * -impact_forse);
            StartCoroutine(waiter());
            //
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