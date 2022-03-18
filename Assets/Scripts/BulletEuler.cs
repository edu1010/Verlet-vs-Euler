using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEuler : MonoBehaviour
{
    public Vector3 dir;
    public Vector3 movement = Vector3.zero;
    public float speed;
    public float verticalSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed += Physics2D.gravity.y * (Time.deltaTime * Time.deltaTime);
        movement = new Vector3(
            dir.x * speed * Time.deltaTime,
            dir.y * speed *Time.deltaTime + 0.5f * verticalSpeed,
            0);

  
        transform.position += movement;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hello");
    }
}
