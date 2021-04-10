using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 10;

    public GameObject moveTarget;

    public float maximumDistFromCenter = 6;

    public Rigidbody2D missilePrefab;

    public Vector2 missileLaunchVector = new Vector2(0, 20);
    public Transform missileSpawnLocation;
    public float missileDestroyTime = 10;

    public float fireCooldown = .1f;
    public float cooldownCounter = 0;

    public AudioSource audSource;
    public AudioClip laserFire;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldownCounter > 0) cooldownCounter -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cooldownCounter <= 0)
        {
            Rigidbody2D newMissile = Instantiate(missilePrefab);
            newMissile.transform.position = missileSpawnLocation.position;
            newMissile.AddForce(missileLaunchVector);
            Destroy(newMissile.gameObject, missileDestroyTime);
            cooldownCounter = fireCooldown;
            //play fire sound effect
            audSource.PlayOneShot(laserFire);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveTarget.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveTarget.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        //keep the X (left and right) position between the values of maximumDistFromCenter
        float clampedvalue = Mathf.Clamp(transform.position.x, -maximumDistFromCenter, maximumDistFromCenter);
        moveTarget.transform.position = new Vector3(clampedvalue, moveTarget.transform.position.y, moveTarget.transform.position.z);
    }
}
