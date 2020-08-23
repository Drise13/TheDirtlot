namespace Assets
{
    using UnityEngine;

    public class Grid : MonoBehaviour
    {
        public float size = 1f;

        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            position -= transform.position;

            var xCount = Mathf.RoundToInt(position.x / size);
            var yCount = Mathf.RoundToInt(position.y / size);
            var zCount = Mathf.RoundToInt(position.z / size);

            var result = new Vector3(xCount * size, yCount * size, zCount * size);

            result += transform.position;

            return result;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            for (float x = 0; x < 40; x += size)
            {
                for (float y = 0; y < 40; y += size)
                {
                    var point = GetNearestPointOnGrid(new Vector3(x, y, 0));
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}