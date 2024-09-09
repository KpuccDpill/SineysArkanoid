using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private Caret caret;
    [SerializeField] private Ball firstBall;
    
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(caret);
        containerBuilder.AddSingleton(firstBall);
        containerBuilder.AddScoped(_ => new PlayerStats());
        containerBuilder.AddScoped(_ => new Level());
    }
}
