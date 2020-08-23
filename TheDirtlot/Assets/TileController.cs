using System.Collections.Generic;
using System.Linq;

using Assets.Managers;
using Assets.Utils;

using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject ContentPanel;

    public List<GameObject> GridLines;

    public int GridSize;
    public GameObject LinePanel;
    public List<List<Tile>> TileGrid;
    public GameObject TilePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        TileGrid = new List<List<Tile>>();
        GridLines = new List<GameObject>();
        PrepareGrid();
        DrawGrid();
    }

    public void PrepareGrid()
    {
        TileGrid = new List<List<Tile>>();

        foreach (var x in Enumerable.Range(0, GridSize))
        {
            TileGrid.Add(new List<Tile>());

            foreach (var y in Enumerable.Range(0, GridSize))
            {
                var prefab = Instantiate(TilePrefab, ContentPanel.transform);
                var tile = prefab.GetComponent<Tile>();
                tile.CurrentTool = ToolManager.Instance.Tools.First(t => t.ToolType == ToolType.Dirt);

                var tileSize = tile.TileSize;

                TileGrid[x].Add(tile);

                prefab.transform.localPosition = new Vector3(x * tileSize, -y * tileSize, 0);
            }
        }
    }

    public void DrawGrid()
    {
        var tileSize = TileGrid.First().First().TileSize;

        foreach (var gridLine in GridLines)
        {
            Destroy(gridLine);
        }

        foreach (var y in Enumerable.Range(1, GridSize - 1))
        {
            var verticalLine = Instantiate(LinePanel, ContentPanel.transform);
            verticalLine.transform.localPosition = new Vector3(y * tileSize, 0, 5);
            verticalLine.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(5, GridSize * tileSize);

            GridLines.Add(verticalLine);
        }

        foreach (var x in Enumerable.Range(1, GridSize - 1))
        {
            var horizontalLine = Instantiate(LinePanel, ContentPanel.transform);
            horizontalLine.transform.localPosition = new Vector3(0, -x * tileSize, 5);
            horizontalLine.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(GridSize * tileSize, 5);

            GridLines.Add(horizontalLine);
        }
    }

    // Update is called once per frame
    private void Update() { }
}