using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [field: SerializeField]
    public Transform Player { get; private set; }
    [field: SerializeField]
    public Vector3 LocalOffset { get; private set; }
    void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.position, Player.position - LocalOffset, 9f);
        transform.LookAt(Player);
    }
}
