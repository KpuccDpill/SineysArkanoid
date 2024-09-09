using Reflex.Core;
using UnityEngine;

public class MainMenuInstaller : MonoBehaviour, IInstaller
{
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(containerBuilder.Parent.Single<PlayerStats>());
    }
}
