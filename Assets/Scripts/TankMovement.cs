using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Bullet bb;
    [SerializeField] float reloadTime = 2f;
    bool isReadyToShoot = true;
    Animator anim;
    public Transform bulletSpawn;
    public GameObject[] bulletPrefabs;
    [SerializeField] float speed = 20.0f;
    Rigidbody rb;
    bool isOnGround;
    float groundCheckRadius = 0.9f;
    public Transform legs;
    public LayerMask groundMask;
    public float speedRotation = 90f;
    public GameObject shootingSpot;
    int bulletIndex = 0;
    public GameObject framepanel1;
    public GameObject framePanel2;
    public GameObject framePanel3;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        anim = FindObjectOfType<Animator>();
        bb = FindObjectOfType<Bullet>();
    }
    private void FixedUpdate()
    {

        Collider[] colliders = Physics.OverlapSphere(legs.position, groundCheckRadius, groundMask);
        if (colliders.Length == 1)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
   
    void Reload()
    {
        isReadyToShoot = true;
    }
   
    void Update()
    {
        if (isOnGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(transform.forward * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(transform.forward * -1 * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {

                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, speedRotation * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, speedRotation * -1 * Time.deltaTime, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isReadyToShoot)
        {
           
            // GameObject bullet = Instantiate(bulletPrefabs[Random.Range(1, 3)]);
            GameObject bullet = Instantiate(bulletPrefabs[bulletIndex]);
            bullet.transform.rotation =shootingSpot.transform.rotation;
            bullet.transform.Rotate(90, 0, 0);
            bullet.transform.position = bulletSpawn.position;
            //anim.SetBool("Ishot", true);
            isReadyToShoot = false;
            Invoke("Reload", reloadTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            framepanel1.SetActive(true);
            framePanel2.SetActive(false);
            framePanel3.SetActive(false);
           bulletIndex = 0;
            print(bulletIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            framepanel1.SetActive(false);
            framePanel2.SetActive(true);
            framePanel3.SetActive(false);
            bulletIndex = 1;
            print(bulletIndex);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            framepanel1.SetActive(false);
            framePanel2.SetActive(false);
            framePanel3.SetActive(true);
            bulletIndex = 2;
            print(bulletIndex);
        }
    }
}
