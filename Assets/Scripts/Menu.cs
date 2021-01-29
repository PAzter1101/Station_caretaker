using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string key = "Score";
    [SerializeField] private GameObject alertTable;

    private void Start()
    {
        alertTable.SetActive(false);
        Cursor.visible = true;
    }
    public void Continue()
    {
        if (PlayerPrefs.HasKey(key))
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            StartNewGame();
        }
    }

    public void OpenAlertTableNewGame()
    {
        alertTable.SetActive(true);
    }
    public void ClouseAlertTableNewGame()
    {
        alertTable.SetActive(false);
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt(key, 0);
        PlayerPrefs.Save();
        Debug.Log("NewGame starting!");
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
