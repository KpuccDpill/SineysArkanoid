using Reflex.Core;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private Caret caret;
    [SerializeField] private Ball firstBall;
    [SerializeField] private NextLevelDialog nextLevelDialog;
    [SerializeField] private GameResultDialog gameResultDialog;
    [SerializeField] private GameHUD gameHud;
    
    public void InstallBindings(ContainerBuilder containerBuilder)
    {
        containerBuilder.AddSingleton(caret);
        containerBuilder.AddSingleton(firstBall);
        containerBuilder.AddSingleton(nextLevelDialog);
        containerBuilder.AddSingleton(gameResultDialog);
        containerBuilder.AddSingleton(gameHud);
        
        var playerStats = containerBuilder.Parent.Single<PlayerStats>();
        containerBuilder.AddScoped(_ => new Level(caret, playerStats, nextLevelDialog, gameResultDialog));
    }
}
