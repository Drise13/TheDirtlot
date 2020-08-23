namespace Assets
{
    using System.Linq;

    using UnityEngine;

    using Utils;

    public class GridManager : MonoBehaviour
    {
        public int GridSize = 10;
        public int TileSize = 1;

        // Start is called before the first frame update
        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            var referenceTile = Instantiate(Resources.Load("Dirt256")).As<GameObject>();

            foreach (var x in Enumerable.Range(0, GridSize))
            {
                foreach (var y in Enumerable.Range(0, GridSize))
                {
                    var tile = Instantiate(referenceTile, transform);

                    tile.transform.position = new Vector2(x * TileSize, -y * TileSize);
                }
            }

            Destroy(referenceTile);
        }

        // Update is called once per frame
        private void Update() { }

        //public void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.yellow;

        //    for (float x = 0; x < 40; x += size)
        //    {
        //        for (float y = 0; y < 40; y += size)
        //        {
        //            var point = GetNearestPointOnGrid(new Vector3(x, y, 0));
        //            Gizmos.DrawSphere(point, 0.1f);
        //        }
        //    }
        //}
    }
}