using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    [field: SerializeField]
    public Camera Camera { get; private set; }
    [field: SerializeField]
    public Vector3 RotationOffset { get; private set; }
    void LateUpdate()
    {
        // 計算物體到攝影機的方向
        Vector3 targetPosition = transform.position + Camera.transform.rotation * Vector3.forward;
        Vector3 targetUp = Camera.transform.rotation * Vector3.up;

        // 設置物體的朝向，使其朝向攝影機的位置，同時保持物體的上方向與攝影機的上方向一致
        transform.LookAt(targetPosition, targetUp);
    }
}
