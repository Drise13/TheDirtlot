using System.Collections.Generic;
using System.Linq;

using Assets.Utils;

using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject ContentPanel;

    public int GridSize;
    public List<List<Tile>> TileGrid;
    public GameObject TilePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        PrepareGrid();
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
                TileGrid[x].Add(tile);

                prefab.transform.localPosition = new Vector3(x * tile.TileSize, -y * tile.TileSize, 0);
            }
        }
    }

    // Update is called once per frame
    private void Update() { }

    public void OnDrawGizmos()
    {
        //PrepareGrid();
    }
}