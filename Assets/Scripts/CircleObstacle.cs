using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObstacle : MonoBehaviour, ICollisonableObjects
{
    public float radius = 0;
    public GameObject rControl;
    // Start is called before the first frame update
    void Start()
    {
        radius = Vector2.Distance(transform.position, rControl.transform.position);
        AddCollionableObject();
    }

    public void AddCollionableObject()
    {
        ColisionControl.collisonableObjects.Add(this);
    }

    public void Collide(ICollisonableObjects collision)
    {
       //es estatico
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
