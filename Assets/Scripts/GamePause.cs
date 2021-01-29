using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPause;
    private GameManager gm;

    [SerializeField] public GameObject pausePanel;

    private void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
    }
    public void Active()
    {
        if (!isPause)
        {
            PauseGame();
        }
        else
        {
            ContinueGame();
        }
    }
    void ContinueGame()
    {        
        isPause = false;       
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPause = true;        
        pausePanel.SetActive(true);
        Cursor.visible = true;
    }
    public void Save()
    {
        PlayerPrefs.SetInt(gm.key, gm.score);
        PlayerPrefs.Save();
        Debug.Log("Saving score to register. Score: " + gm.score);
    }
}
