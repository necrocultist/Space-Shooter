using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonobehaviour<GameManager>
{
    private PlayerDetailsSO playerDetails;
    private Player player;

    [HideInInspector] public GameState gameState;
    [HideInInspector] public GameState previousGameState;

    private long gameScore;
    private int scoreMultiplier;

    [SerializeField] private GameObject pauseMenu;

    protected override void Awake()
    {
        base.Awake();

        playerDetails = GameResources.Instance.currentPlayer.playerDetails;

        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        GameObject playerGameObject = Instantiate(playerDetails.playerPrefab);

        player = playerGameObject.GetComponent<Player>();

        player.Initialize(playerDetails);
    }
    
    private void Start()
    {
        previousGameState = GameState.gameStarted;
        gameState = GameState.gameStarted;

        // Set score to zero
        gameScore = 0;

        // Set multiplier to 1;
        scoreMultiplier = 1;

        // Set screen to black
        //StartCoroutine(Fade(0f, 1f, 0f, Color.black));
    }

    // Update is called once per frame
    private void Update()
    {
        //HandleGameState();

        // For testing
        if (Input.GetKeyDown(KeyCode.P))
        { 
            gameState = GameState.gameStarted;
        }

    }

    public void PauseGameMenu()
    {
        if (gameState != GameState.gamePaused)
        {
            pauseMenu.SetActive(true);
            GetPlayer().playerControl.DisablePlayer();

            // Set game state
            previousGameState = gameState;
            gameState = GameState.gamePaused;
        }
        else if (gameState == GameState.gamePaused)
        {
            pauseMenu.SetActive(false);
            GetPlayer().playerControl.EnablePlayer();

            // Set game state
            gameState = previousGameState;
            previousGameState = GameState.gamePaused;

        }
    }
    
    public Player GetPlayer()
    {
        return player;
    }
    
    public Sprite GetPlayerMiniMapIcon()
    {
        return playerDetails.playerMiniMapIcon;
    }
}