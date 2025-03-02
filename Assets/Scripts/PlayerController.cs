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
    public float PressTime { get; private set; } = 0.1f;
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
    [field: SerializeField]
    public Animator Animator { get; private set; }
    [field: SerializeField]
    public GameObject Particle { get; set; }
    public bool Controllable { get; set; } = false;

    public AudioSource audioSource;
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
        if (Input.GetKey(KeyCode.W))
        {
            Move(forward);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveFast(forward);
        }
        // 
        if (Input.GetKey(KeyCode.S))
        {
            Move(back);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveFast(back);
        }
        // 
        if (Input.GetKey(KeyCode.A))
        {
            Move(left);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveFast(left);
        }
        // 
        if (Input.GetKey(KeyCode.D))
        {
            Move(right);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveFast(right);
        }
        // 
        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D))
        {
            pressTime = 0;
            Animator.SetBool("idle", true);
            Animator.SetBool("walk", false);
            audioSource.Play();
        }
    }
    void player2Control()
    {
        if (Input.GetKey(KeyCode.I))
        {
            Move(forward);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MoveFast(forward);
        }
        // 
        if (Input.GetKey(KeyCode.K))
        {
            Move(back);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            MoveFast(back);
        }
        // 
        if (Input.GetKey(KeyCode.J))
        {
            Move(left);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            MoveFast(left);
        }
        // 
        if (Input.GetKey(KeyCode.L))
        {
            Move(right);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            MoveFast(right);
        }
        if (Input.GetKeyUp(KeyCode.I) ||
            Input.GetKeyUp(KeyCode.K) ||
            Input.GetKeyUp(KeyCode.J) ||
            Input.GetKeyUp(KeyCode.L))
        {
            pressTime = 0;
            Animator.SetBool("idle", true);
            Animator.SetBool("walk", false);
            audioSource.Play();
        }
    }
    float pressTime = 0;
    void Move(Vector3 direction)
    {
        Animator.SetBool("idle", false);
        Animator.SetBool("walk", true);
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        Vector3 moveTarget = direction * moveAmount + transform.position;
        Vector2 checkPosition = new Vector2(moveTarget.x, moveTarget.z);
        if (gameManager.CheckMovable(checkPosition) == false) return;
        pressTime += Time.deltaTime;
        if (pressTime < PressTime) return;
        transform.position += direction * moveAmount;
        if (Controllable)
        {
            Instantiate(Particle, transform.position, Quaternion.Euler(-90, 0, 0));
            OnMove?.Invoke(new Vector2(transform.position.x, transform.position.z));
        }
        pressTime = 0;
    }

    void MoveFast(Vector3 direction)
    {
        GameManager gameManager = FindFirstObjectByType<GameManager>();
        Vector3 moveTarget = direction * moveAmount + transform.position;
        Vector2 checkPosition = new Vector2(moveTarget.x, moveTarget.z);
        if (gameManager.CheckMovable(checkPosition) == false) return;
        transform.position += direction * moveAmount;
        if (Controllable)
        {
            Instantiate(Particle, transform.position, Quaternion.Euler(-90, 0, 0));
            OnMove?.Invoke(new Vector2(transform.position.x, transform.position.z));
        }
    }
}
