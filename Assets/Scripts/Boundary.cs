using UnityEngine;

public class Boundary
{
    private GameManager GameManager;
    public Boundary(GameManager manager, Vector2 fieldSize)
    {
        GameManager = manager;
        Vector2 XRange = new Vector2(-fieldSize.x / 2, fieldSize.x / 2);
        Vector2 ZRange = new Vector2(-fieldSize.y / 2, fieldSize.y / 2);
        Vector3[] positions = new Vector3[]
        {
            new Vector3(XRange.x, 0, ZRange.x),
            new Vector3(XRange.x, 0, ZRange.y),
            new Vector3(XRange.y, 0, ZRange.y),
            new Vector3(XRange.y, 0, ZRange.x),
        };
        for (float i = positions[0].z; i < positions[1].z; i += 1)
        {
            CreateObstacle(new Vector3(positions[0].x, 0, i));
        }
        for (float i = positions[1].x; i < positions[2].x; i += 1)
        {
            CreateObstacle(new Vector3(i, 0, positions[1].z));
        }
        for (float i = positions[2].z; i > positions[3].z; i -= 1)
        {
            CreateObstacle(new Vector3(positions[2].x, 0, i));
        }
        for (float i = positions[3].x; i > positions[0].x; i -= 1)
        {
            CreateObstacle(new Vector3(i, 0, positions[3].z));
        }
    }
    void CreateObstacle(Vector3 position)
    {
        GameManager.AddObstacle(new Vector2(position.x, position.z));
    }
}