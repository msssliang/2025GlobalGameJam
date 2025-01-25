using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public PlayerEnum player { get; private set; }
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
    [field: SerializeField]
    public UnityEvent<Vector2> OnMove { get; private set; }
    void Update()
    {
        switch (player)
        {
            case PlayerEnum.Player1:
                player1Control();
                break;
            case PlayerEnum.Player2:
                player2Control();
                break;
        }
    }
    void player1Control()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(forward);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(back);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(right);
        }
    }
    void player2Control()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Move(forward);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Move(back);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Move(left);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Move(right);
        }
    }
    void Move(Vector3 direction){
        Debug.Log($"{player} call Move");
        transform.position += direction * moveAmount;
        OnMove?.Invoke(new Vector2(transform.position.x, transform.position.z));
    }
}
