using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Plank : MonoBehaviour
{
    [HideInInspector] public int points = 100;

    [SerializeField] private TextMeshPro hpText;
    
    private int _hp;
    
    public static event Action<Plank> OnPlankDestroyed;

    public void SetupPlank(int hp)
    {
        _hp = hp;
        UpdateHpText();
    }

    public void TakeHit()
    {
        _hp--;
        UpdateHpText();
        
        if (_hp == 0)
            DestroyPlank();
    }

    private void DestroyPlank()
    {
        gameObject.SetActive(false);
        
        OnPlankDestroyed?.Invoke(this);
    }

    private void UpdateHpText()
    {
        hpText.text = _hp.ToString();
    }
}
