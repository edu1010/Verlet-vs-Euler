using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionControl : MonoBehaviour
{
    public static List<ICollisonableObjects> collisonableObjects;
    // Start is called before the first frame update
    void Awake()
    {
        collisonableObjects = new List<ICollisonableObjects>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in collisonableObjects)
        {
            foreach (var secondItem in collisonableObjects)
            {
                if(item != secondItem)
                {
                    item.Collide(secondItem);
                }
            }

        }
    }
}
