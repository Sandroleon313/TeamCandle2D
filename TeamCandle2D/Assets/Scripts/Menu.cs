using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{ 
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject objectivePanel;
    [SerializeField] TimeKeeper timeKeeper;
    [SerializeField] Transform menuButton;
    TextMeshProUGUI playButtonText;
    GameObject _currentPanel;
    Image _image;
 
    void Start()
    {
        _image = GetComponent<Image>();
        gameOverPanel.SetActive(false);
        creditsPanel.SetActive(false);
        objectivePanel.SetActive(false);
        Button button = menuPanel.GetComponentInChildren<Button>();
        playButtonText = button.GetComponentInChildren<TextMeshProUGUI>();

        _currentPanel = menuPanel;
      }

    void Update()
    {
        bool menuToggled = Input.GetKeyDown(KeyCode.Escape);
        if (menuToggled)
        {
            ToggleMenu();
        }   
    }

    public void ToggleMenu()
    { 
        if (!_currentPanel.activeSelf)
        {
            timeKeeper.Pause();
            ShowStartingMenu();
            menuButton.gameObject.SetActive(false);
            return;
        }
        
        HidePanel();
        menuButton.gameObject.SetActive(true);

        if (!timeKeeper.isAlive)
        {
            timeKeeper.NewGame();
            return;
        }
        
        timeKeeper.Resume();

    }

    void ShowPanel()
    {
         _currentPanel.SetActive(true);
        if (timeKeeper.isPlaying)
        {
            playButtonText.text = "resume";
            return;
        }
        playButtonText.text = "play";
    }

    void HidePanel()
    {
        _currentPanel.SetActive(false);
        _image.enabled = false;
    }

    public void ShowStartingMenu()
    {
        _currentPanel.SetActive(false);
        _currentPanel = menuPanel;
        ShowPanel();
    }

    public void ShowCreditsMenu()
    {
        _currentPanel.SetActive(false);
        _currentPanel = creditsPanel;
        _currentPanel.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        _currentPanel.SetActive(false);
        _currentPanel = gameOverPanel;
        _currentPanel.SetActive(true);
    }

    public void ShowGameWinMenu()
    {
        _currentPanel.SetActive(false);
        _currentPanel = gameWinPanel;
        _currentPanel.SetActive(true);
    }

    public void ShowObjectiveMenu()
    {
        _currentPanel.SetActive(false);
        _currentPanel = objectivePanel;
        _currentPanel.SetActive(true);
    }

}


 