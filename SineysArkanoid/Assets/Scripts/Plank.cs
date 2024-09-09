using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Plank : MonoBehaviour
{
    public static event Action<Plank> OnPlankDestroyed;
    
    public void DestroyPlank()
    {
        gameObject.SetActive(false);
        
        OnPlankDestroyed?.Invoke(this);
    }
}
