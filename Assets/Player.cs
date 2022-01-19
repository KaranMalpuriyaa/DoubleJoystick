using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick aimJoystick;

    Vector3 moveVelocity;
    Vector3 aimVelocity;
    public Rigidbody rb;

    public float moveSpeed;

    public GameObject bullet;
    public Transform firePoint;
    public float fireSpeed;

    private void Start () {
        rb = GetComponent<Rigidbody> ();
    }

    private void Update () {

        // movement 
        moveVelocity = new Vector3 (moveJoystick.Horizontal, 0f, moveJoystick.Vertical);
        Vector3 moveInput = new Vector3 (moveVelocity.x, 0f, moveVelocity.z);
        Vector3 moveDir = moveInput.normalized * moveSpeed;
        rb.MovePosition (rb.position + moveDir * Time.deltaTime);

        // Aim
        aimVelocity = new Vector3 (aimJoystick.Horizontal, 0f, aimJoystick.Vertical);
        Vector3 AimInput = new Vector3 (aimVelocity.x, 0f, aimVelocity.z);
        Vector3 lookAtPoint = transform.position + AimInput;
        transform.LookAt (lookAtPoint);


        //if(Input.GetMouseButtonDown(0)) {
        //    Shoot ();
        //}
        if(aimJoystick.Horizontal >= 0.6f || aimJoystick.Vertical >= 0.6) {
            Shoot ();
        }
        else if(aimJoystick.Horizontal <= -0.6f || aimJoystick.Vertical <= -0.6) {
            Shoot ();
        }

    }

    void Shoot() {

        GameObject newBullet = Instantiate (bullet, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody> ();
        bulletRb.AddForce (transform.forward * fireSpeed);

        if(newBullet != null) {
            Destroy (newBullet, 30f);
        }
    }



}
