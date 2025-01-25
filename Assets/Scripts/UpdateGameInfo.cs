using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameInfo : MonoBehaviour
{
    [field: SerializeField]
    public GameManager GameManager { get; private set; }
    [field: SerializeField]
    public Image Player1Bar { get; private set; }
    [field: SerializeField]
    public Image Player2Bar { get; private set; }
    [field: SerializeField]
    public TextMeshProUGUI Timer { get; private set; }
    void Update()
    {
        GameManager.GetCurrentScore(out int player1Score, out int player2Score);
        int totalScore = (int)(GameManager.FieldSize.x * GameManager.FieldSize.y);
        Debug.Log($"Player1: {player1Score}, Player2: {player2Score} / {totalScore}");
        Player1Bar.fillAmount = (float)player1Score / totalScore;
        Player2Bar.fillAmount = (float)player2Score / totalScore;
        if (GameManager.CurrentGameState == GameManager.GameState.Playing)
        {
            Timer.text = GameManager.CurrentTimer.ToString("0");
        }
        else
        {
            Timer.text = "";
        }
    }
}
