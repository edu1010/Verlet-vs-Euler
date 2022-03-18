using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisonableObjects 
{
    public void AddCollionableObject();
    public void Collide(ICollisonableObjects collision);
    public TypeColision GetType();
    public GameObject GetGameobject();
    public float GetRadius();
}
public enum TypeColision
{
    Circle,
    Rectangle
}
