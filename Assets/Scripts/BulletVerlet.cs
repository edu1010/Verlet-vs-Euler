using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVerlet : MonoBehaviour,ICollisonableObjects
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
    public float radius = 0;
    public GameObject rControl;
    [Tooltip("Contante de restitución")]
    public float k = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        radius = Vector2.Distance(transform.position, rControl.transform.position);
        AddCollionableObject();
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
    public void AddCollionableObject()
    {
        ColisionControl.collisonableObjects.Add(this);
    }

    public void Collide(ICollisonableObjects collision)
    {
        if (collision.GetType() == TypeColision.Circle)
        {
            float distancia = Mathf.Sqrt(
                (transform.position.x - collision.GetGameobject().transform.position.x) *
                 (transform.position.x - collision.GetGameobject().transform.position.x) +
                 (transform.position.y - collision.GetGameobject().transform.position.y) *
                 (transform.position.y - collision.GetGameobject().transform.position.y)
                );
            if (distancia < radius + collision.GetRadius()) 
            {
                Vector3 l_dir = transform.position - collision.GetGameobject().transform.position;
                verticalSpeed = 0;
                dir = k * l_dir;
            }
        }

    }

    TypeColision ICollisonableObjects.GetType()
    {
        return TypeColision.Circle;
    }

    public GameObject GetGameobject()
    {
        return gameObject;
    }

    public float GetRadius()
    {
        return radius;
    }
}
