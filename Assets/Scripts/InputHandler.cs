using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputHandler : MonoBehaviour
{
    Vector3 dir;
    public Transform firepoint;
    public Slider sliderEuler;
    public Slider sliderVerlet;
    public float sliderSpeed = 1f;
    public float sliderSpeedDecrementMultiplayer = 5f;
    public float velocity = 0;
    public float incrementVelocity = 1f;
    public GameObject bulletEuler;
    public GameObject bulletVerlet;
    bool canShootEuler = false;
    bool canShootVerlet = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        SliderControler();
        ShootEuler();
        ShootVerlet();


    }
    public void ShootEuler()
    {
        if (Input.GetMouseButton(0) && sliderEuler.value < 1)
        {
            velocity += incrementVelocity * Time.deltaTime;
            canShootEuler = true;
        }
        else
        {
            if (canShootEuler)
            {
                canShootEuler = false;
                GameObject bullet = Instantiate(bulletEuler);
                bullet.transform.position = firepoint.position;
                bullet.GetComponent<BulletEuler>().speed = velocity;
                velocity = 0;
                bullet.GetComponent<BulletEuler>().dir = transform.up.normalized;

            }
        }

    }
    public void ShootVerlet()
    {
        if (Input.GetMouseButton(1) && sliderVerlet.value < 1)
        {
            velocity += incrementVelocity * Time.deltaTime;
            canShootVerlet = true;
        }
        else
        {
            if (canShootVerlet)
            {
                canShootVerlet = false;
                GameObject bullet = Instantiate(bulletVerlet);
                bullet.transform.position = firepoint.position;
                bullet.GetComponent<BulletVerlet>().speed = velocity;
                velocity = 0;
                bullet.GetComponent<BulletVerlet>().dir = transform.up.normalized;

            }
        }

    }
    public void SliderControler()
    {
        
        if (Input.GetMouseButton(0))
        {
            sliderEuler.value += sliderSpeed * Time.deltaTime;
        }
        else
        {
            if (sliderEuler.value - sliderSpeed * Time.deltaTime > 0)
            {

                sliderEuler.value -= sliderSpeed* sliderSpeedDecrementMultiplayer * Time.deltaTime;
            }
            else
            {
                sliderEuler.value = 0;
            }
        }

        if (Input.GetMouseButton(1))
        {
            sliderVerlet.value += sliderSpeed * Time.deltaTime;
        }
        else
        {
            if (sliderVerlet.value - sliderSpeed * Time.deltaTime > 0)
            {

                sliderVerlet.value -= sliderSpeed * sliderSpeedDecrementMultiplayer * Time.deltaTime;
            }
            else
            {
                sliderVerlet.value = 0;
            }
        }

    }
    public void LookAtMouse()
    {
        dir = MousePos() - transform.position;
        dir.z = 0;
        dir.Normalize();
        transform.up = dir;
    }
    public Vector3 MousePos()
    {
        Vector3 screen = Input.mousePosition;
        screen.z = 0;

        return  Camera.main.ScreenToWorldPoint(screen);
    }
}
