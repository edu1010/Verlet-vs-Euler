using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 oldVelocity;
    public Vector2 newVelocity;
    public Vector2 currebtVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CalculateMovement()
    {
        Vector3 screen = Input.mousePosition;
        screen.z = 0;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(screen);
        oldVelocity = currebtVelocity;


    }
    
}
