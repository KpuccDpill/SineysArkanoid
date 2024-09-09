using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    [SerializeField] private Plank plankPrefab;

    private const float PlankSizeX = 5;
    private const float PlankSizeY = 2;

    private void Start()
    {
        int[][] cells = new int[][]
        {
            new[] { 1, 0, 1, 1, 1, 1, 1 },
            new[] { 1, 1, 0, 1, 1, 1, 1 },
            new[] { 1, 1, 0, 1, 1, 1 },
            new[] { 1, 1, 0, 0, 1, 1 },
            new[] { 1, 0, 1, 1, 0, 1, 1 },
            new[] { 1, 1, 0, 0, 1, 1, 1 },
        };

        var plankXSize = plankPrefab.transform.localScale.x * PlankSizeX;
        var plankYSize = -plankPrefab.transform.localScale.y * PlankSizeY;

        for (int i = 0; i < cells.Length; i++)
        {
            var firstPlankPosX = -plankXSize * (cells[i].Length - 1) / 2;
            var plankPosY = plankYSize * i;
            
            for (int j = 0; j < cells[i].Length; j++)
            {
                if (cells[i][j] == 1)
                {
                    Instantiate(plankPrefab, new Vector3(firstPlankPosX + plankXSize * j, plankPosY + transform.position.y),
                        Quaternion.identity, transform);
                }
            }
        }
    }
}
