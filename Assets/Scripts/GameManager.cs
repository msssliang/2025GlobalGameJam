using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        None,
        CountDown,
        Playing,
        Pause,
        GameOver
    }
    [field: SerializeField]
    public float GameTime { get; private set; }
    [field: SerializeField]
    public Vector2 FieldSize { get; private set; } = new Vector2(20, 20);
    [Header("遊戲資訊")]
    [field: SerializeField]
    public float CurrentTimer { get; private set; }
    [field: SerializeField]
    public GameState CurrentGameState { get; private set; }
    private Dictionary<string, GameObject> bubbleGrid = new();
    private Dictionary<string, GameObject> obstacleGrid = new();
    private Boundary boundary;
    void Start()
    {
        boundary = new Boundary(this, FieldSize);
        ChanageState(GameState.CountDown);
    }
    public void ChanageState(GameState state)
    {
        switch (state)
        {
            case GameState.CountDown:
                CurrentTimer = 4;
                break;
            case GameState.Playing:
                CurrentTimer = GameTime;
                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                break;
        }
        CurrentGameState = state;
    }
    public bool CheckMovable(Vector2 position)
    {
        string key = position.ToString();
        if (obstacleGrid.ContainsKey(key))
        {
            return false;
        }
        return true;
    }
    public void AddObstacle(GameObject obstacle, Vector2 position)
    {
        string key = position.ToString();
        obstacleGrid.Add(key, obstacle);
    }
    public void AddBubble(GameObject bubble, Vector2 position)
    {
        string key = position.ToString();
        if (bubbleGrid.ContainsKey(key))
        {
            if (bubbleGrid[key] != null)
            {
                Destroy(bubbleGrid[key]);
            }
            Debug.Log($"Remove Bubble {key}");
            bubbleGrid.Remove(key);
        }
        bubbleGrid.Add(key, bubble);
    }
    public void RemoveBubble(Vector2 position)
    {
        string key = position.ToString();
        if (bubbleGrid.ContainsKey(key))
        {
            if (bubbleGrid[key] != null)
            {
                Destroy(bubbleGrid[key]);
            }
            bubbleGrid.Remove(key);
        }
    }
    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.CountDown:
                CountDownState();
                break;
            case GameState.Playing:
                PlayingState();
                break;
            case GameState.Pause:
                break;
            case GameState.GameOver:
                break;
        }
    }
    void CountDownState()
    {
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer <= 0)
        {
            ChanageState(GameState.Playing);
        }
    }
    void PlayingState()
    {
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer <= 0)
        {
            ChanageState(GameState.GameOver);
        }
    }
}
