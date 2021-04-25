using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behawour : MonoBehaviour
{
    public Animator animator;
    public Animator cam_animator;

    public Rigidbody player_rb;
    public float impact_forse;

    public Transform pistol;
    public bool is_pos1;
    private Quaternion pos1;
    private Quaternion pos2;

    public void Start()
    {
        pos1 = new Quaternion(0, 0, 0, 0);
        pos2 = new Quaternion(0, 0, 60, 0);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("shoot");
            cam_animator.Play("cam_shoot");
            player_rb.AddForce(transform.up * -impact_forse);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (is_pos1 == true)
            {
                pistol.rotation = pos2;
                is_pos1 = !is_pos1;
            }
            else
            {
                pistol.rotation = pos1;
                is_pos1 = !is_pos1;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.Play("reload");
        }
    }
}