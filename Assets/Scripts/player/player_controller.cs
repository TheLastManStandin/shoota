using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // общие переменные
    public bool is_grounded = false;

    // переменные реализации передвижения
    public float player_speed = 5;
    public float mouse_speed = 1;
    public float jump_forse = 3;
    private Rigidbody rb;

    // переменные реализации поворота головы
    public float sensitivity = 100;
    float xRotation = 0;
    public Transform cam;

    //
    public float mouseX;
    public float mouseY;
    //

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void JumpLogic(){
        if (Input.GetAxis("Jump") > 0)
        {
            if (is_grounded)
            {
                rb.AddForce(Vector3.up * jump_forse);
            }
        }
    }

    private void MovementLogic()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement_vector = new Vector3(move_horizontal, 0, move_vertical);

        transform.Translate(movement_vector * player_speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);// ограничения на осмотр вверх и вниз

        Quaternion quaternion = Quaternion.Euler(xRotation, 0, 0);
        cam.localRotation = quaternion;
        transform.Rotate(Vector3.up * mouseX);
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            is_grounded = value;
        }
    }
}