using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody playerShip;
    public float Speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;

    // Joystick Screen Touch
    private bool touchStart = false;
 

    public GameObject laserShot; //чем стрелять
    public Transform laserGun; // от куда стрелять
    public float shotDelay;
    float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.Instance.getIsStarted())
        {
            return;
        }

        // Move on PC
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal * Speed, 0, moveVertical * Speed);

        float restrictedX = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float restrictedZ = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(restrictedX, 0, restrictedZ);
        playerShip.rotation = Quaternion.Euler(playerShip.velocity.z * tilt, 0, -playerShip.velocity.x * tilt);

        //shooting
        if (Time.time > nextShotTime && (Input.GetButton("Fire1")|| (Input.touchCount >0)))
        {
            Instantiate(laserShot, laserGun.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        //Touch screen
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            playerShip.position = new Vector3(touchPosition.x, 0, -4f);
        }

    }

}
