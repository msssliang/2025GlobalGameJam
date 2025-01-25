using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public bool player2 { get; private set; }
    [field: SerializeField]
    public float moveAmount { get; private set; }
    [field: SerializeField]
    public Vector3 forward { get; private set; }
    [field: SerializeField]
    public Vector3 right { get; private set; }
    [field: SerializeField]
    public Vector3 left { get; private set; }
    [field: SerializeField]
    public Vector3 back { get; private set; }
    void Update()
    {
        if (player2)
        {
            player2Control();
        }
        else
        {
            player1Control();
        }
    }
    void player1Control()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += forward * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += back * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += left * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += right * moveAmount;
        }
    }
    void player2Control()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            transform.position += forward * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            transform.position += back * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            transform.position += left * moveAmount;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.position += right * moveAmount;
        }
    }
}
