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
    [Header("遊戲資訊")]
    [field: SerializeField]
    public float CurrentTimer { get; private set; }
    [field: SerializeField]
    public GameState CurrentGameState { get; private set; }
    public Dictionary<string, GameObject> BubbleGrid { get; private set; } = new();
    void Start()
    {
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
    public void AddBubble(GameObject bubble, Vector2 position)
    {
        string key = position.ToString();
        if (BubbleGrid.ContainsKey(key))
        {
            if (BubbleGrid[key] != null)
            {
                Destroy(BubbleGrid[key]);
            }
            Debug.Log($"Remove Bubble {key}");
            BubbleGrid.Remove(key);
        }
        BubbleGrid.Add(key, bubble);
    }
    public void RemoveBubble(Vector2 position)
    {
        string key = position.ToString();
        if (BubbleGrid.ContainsKey(key))
        {
            if (BubbleGrid[key] != null)
            {
                Destroy(BubbleGrid[key]);
            }
            BubbleGrid.Remove(key);
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
