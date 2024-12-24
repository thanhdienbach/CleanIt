using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public GameState CurentState { get; private set; }

    [SerializeField] TextMeshProUGUI playerInfoText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {

        ExitState(CurentState);

        CurentState = newState;

        EnterState(newState);
    }
    private void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                //Time.timeScale = 1.0f;
                break;
            case GameState.Playing:
                //Time.timeScale = 1.0f;
                break;
            case GameState.Paused:
                //Time.timeScale = 1.0f;
                break;
            case GameState.GameOver:
                //Time.timeScale = 1.0f;
                break;
        }
    }
    private void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Time.timeScale = 0.0f;
                break;
            case GameState.Playing:
                Time.timeScale = 1.0f;
                PlayerEvent.Instance.LoadScore();
                break;
            case GameState.Paused:
                PlayerEvent.Instance.SavePlayerData();
                Time.timeScale = 0.0f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0.0f;
                break;
        }
    }

}
