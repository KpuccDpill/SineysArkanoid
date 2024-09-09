using Reflex.Attributes;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [Inject] private PlayerStats _playerStats;
    
    private void Start()
    {
        _playerStats.Reset();
    }
}
