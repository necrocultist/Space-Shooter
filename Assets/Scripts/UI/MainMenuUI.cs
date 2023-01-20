using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    #region Header CANVAS REFERENCES

    [Space(10)]
    [Header("Canvas References")]

    #endregion Header CANVAS REFERENCES

    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField] private GameObject highScoresCanvas;
    [SerializeField] private GameObject instructionsCanvas;

    private void Awake()
    {
        highScoresCanvas.SetActive(false);
        instructionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    private void Start()
    {
        MusicManager.Instance.PlayMusic(GameResources.Instance.mainMenuMusic, 0f, 2f);
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadHighScores()
    {
        mainMenuCanvas.SetActive(false);
        instructionsCanvas.SetActive(false);
        highScoresCanvas.SetActive(true);
    }

    public void LoadInstructions()
    {
        mainMenuCanvas.SetActive(false);
        highScoresCanvas.SetActive(false);
        instructionsCanvas.SetActive(true);
    }

    public void LoadMainMenu()
    {
        highScoresCanvas.SetActive(false);
        instructionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    #region Validation
#if UNITY_EDITOR
    // Validate the scriptable object details entered
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(mainMenuCanvas), mainMenuCanvas);
        HelperUtilities.ValidateCheckNullValue(this, nameof(instructionsCanvas), instructionsCanvas);
        HelperUtilities.ValidateCheckNullValue(this, nameof(highScoresCanvas), highScoresCanvas);

    }
#endif
    #endregion
}