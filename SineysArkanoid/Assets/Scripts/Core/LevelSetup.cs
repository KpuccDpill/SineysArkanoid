using System.Collections.Generic;
using Reflex.Attributes;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private Plank plankPrefab;

    [Inject] private Level _level;

    private const float PlankSizeX = 5;
    private const float PlankSizeY = 2;
    private const int MaxGridSize = 7;

    private void Start()
    {
        List<List<int>> cells = new List<List<int>>(MaxGridSize);

        for (var i = 0; i < cells.Capacity; i++)
        {
            int cellsAmount = Random.Range(1, MaxGridSize + 1);
            cells.Add(new List<int>(cellsAmount));

            for (int j = 0; j < cellsAmount; j++)
            {
                float random = Random.value;
                int result = random > 0.25f ? 1 : 0;
                
                cells[i].Add(result);
            }
        }

        var plankXSize = plankPrefab.transform.localScale.x * PlankSizeX;
        var plankYSize = -plankPrefab.transform.localScale.y * PlankSizeY;

        List<Plank> planks = new List<Plank>();

        for (int i = 0; i < cells.Count; i++)
        {
            var firstPlankPosX = -plankXSize * (cells[i].Count - 1) / 2;
            var plankPosY = plankYSize * i;
            
            for (int j = 0; j < cells[i].Count; j++)
            {
                if (cells[i][j] == 1)
                {
                    Plank plank = Instantiate(plankPrefab, new Vector3(firstPlankPosX + plankXSize * j, 
                            plankPosY + transform.position.y), Quaternion.identity, transform);

                    planks.Add(plank);
                }
            }
        }

        _level.InitLevel(planks);
    }
}
