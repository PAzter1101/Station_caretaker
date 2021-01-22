using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPause;

    [SerializeField]
    public GameObject pausePanel;
   
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
}
