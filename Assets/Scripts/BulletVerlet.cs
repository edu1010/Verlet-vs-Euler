using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVerlet : MonoBehaviour
{
    public Vector3 dir;
    public Vector3 movement = Vector3.zero;
    public float speed;
    public float currentVerticalSpeed = 0;
    public float previusVerticalSpeed = 0;
    public float newVerticalSpeed = 0;

    public float currentHorizontalSpeed = 0;
    public float previusHorizontalSpeed = 0;
    public float newHorizontalSpeed = 0;
    public float verticalSpeed =0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //previus frame velocity + previus Frame velocity+gravity / sum vel *0.5f
        verticalSpeed += Physics2D.gravity.y * (Time.deltaTime * Time.deltaTime);
        previusVerticalSpeed = currentVerticalSpeed;
        currentVerticalSpeed = dir.y * speed * Time.deltaTime + 0.5f * verticalSpeed;
        newVerticalSpeed = (currentVerticalSpeed + previusVerticalSpeed) * 0.5f;



        previusHorizontalSpeed = currentHorizontalSpeed;
        currentHorizontalSpeed = dir.x * speed * Time.deltaTime;
        newHorizontalSpeed = (currentHorizontalSpeed + previusHorizontalSpeed) * 0.5f;
       
        movement = new Vector3(newHorizontalSpeed, newVerticalSpeed, 0);
     

        transform.position += movement;


    }
}
