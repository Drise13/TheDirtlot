namespace Assets
{
    using System.Linq;

    using UnityEngine;

    using Utils;

    public class GridManager : MonoBehaviour
    {
        public int GridSize = 10;
        public int TileSize = 1;
        public GameObject Surface;

        // Start is called before the first frame update
        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            var referenceTile = Instantiate(Resources.Load("Dirt256"), Surface.transform).As<GameObject>();

            foreach (var x in Enumerable.Range(0, GridSize))
            {
                foreach (var y in Enumerable.Range(0, GridSize))
                {
                    var tile = Instantiate(referenceTile, transform);

                    tile.transform.position = new Vector3(x * TileSize, -y * TileSize, 0) + Surface.transform.position;
                }
            }

            Destroy(referenceTile);
        }

        // Update is called once per frame
        private void Update() { }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            foreach (var x in Enumerable.Range(0, GridSize))
            {
                foreach (var y in Enumerable.Range(0, GridSize))
                {
                    var point = new Vector2(x * TileSize, -y * TileSize);
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}