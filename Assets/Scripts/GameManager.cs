using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dirt;
    [SerializeField]
    private int dirtyDamage;

    [SerializeField]
    private GameObject train;
    [SerializeField]
    private GameObject trainStartPosition;
    private Transform tsp;

    [SerializeField]
    private GameObject textScore;
    [SerializeField]
    private GameObject textLife;

    public int score;
    public int pollute;

    public static bool gameOver;

    [SerializeField]
    private GameObject gameOverPanel;

    void Start()
    {
        Time.timeScale = 1;

        //Отключение курсора
        Cursor.visible = false;

        //Отклчение панелей
        gameObject.GetComponent<GamePause>().pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        gameOver = false;
        score = 0;
        pollute = 0;

        tsp = trainStartPosition.GetComponent<Transform>();

        InvokeRepeating("CreateTrain", 3, 7);
        InvokeRepeating("Pollution", 1, 3);
    }
    private void Update()
    {
        if (gameOver)
        {
            GameOver();
        }

        if (pollute > 100)
        {
            gameOver = true;           
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<GamePause>().Active();
        }
    }

    private void CreateTrain()
    {
        Instantiate(train, tsp.position, tsp.rotation);
    }


    private void Pollution()
    {
        Instantiate(dirt, new Vector3(Random.Range(-0.5f, 2.5f), Random.Range(-7f, 4f), -1), Quaternion.Euler(1, 1, 1));
        pollute += dirtyDamage;
        RefreshUi();
    }

    public void RefreshUi()
    {
        textScore.GetComponent<Text>().text = "Score: " + score.ToString();
        textLife.GetComponent<Text>().text = "Pollute: " + pollute.ToString();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    void GameOver()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        gameOverPanel.SetActive(true);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
