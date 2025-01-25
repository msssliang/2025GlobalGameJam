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
