using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Plank : MonoBehaviour
{
    [HideInInspector] public int points = 100;
    
    public static event Action<Plank> OnPlankDestroyed;

    public void DestroyPlank()
    {
        gameObject.SetActive(false);
        
        OnPlankDestroyed?.Invoke(this);
    }
}
