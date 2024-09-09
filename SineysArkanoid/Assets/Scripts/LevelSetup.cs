using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private Plank plankPrefab;
    [SerializeField] private Caret caret;

    private const float PlankSizeX = 5;
    private const float PlankSizeY = 2;

    private void Start()
    {
        int[][] cells = new int[][]
        {
            new[] { 0 },
            new[] { 0 },
            new[] { 0 },
            new[] { 0 },
            new[] { 0 },
            new[] { 1 },
        };

        var plankXSize = plankPrefab.transform.localScale.x * PlankSizeX;
        var plankYSize = -plankPrefab.transform.localScale.y * PlankSizeY;

        List<Plank> planks = new List<Plank>();

        for (int i = 0; i < cells.Length; i++)
        {
            var firstPlankPosX = -plankXSize * (cells[i].Length - 1) / 2;
            var plankPosY = plankYSize * i;
            
            for (int j = 0; j < cells[i].Length; j++)
            {
                if (cells[i][j] == 1)
                {
                    Plank plank = Instantiate(plankPrefab, new Vector3(firstPlankPosX + plankXSize * j, 
                            plankPosY + transform.position.y), Quaternion.identity, transform);

                    planks.Add(plank);
                }
            }
        }

        Level newLevel = new Level();
        newLevel.InitLevel(planks, caret);
    }
}
