using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    public GameManager GameManager { get; private set; }
    [field: SerializeField]
    public GameObject BulletPrefab { get; private set; }
    public void GenerateBubble(Vector2 GridPosition)
    {
        Vector3 yOffset = new Vector3(0, 0.0001f, 0);
        GameObject instance = Instantiate(BulletPrefab, transform.position + yOffset, Quaternion.identity);
        GameManager.AddBubble(instance, GridPosition);
    }
}
