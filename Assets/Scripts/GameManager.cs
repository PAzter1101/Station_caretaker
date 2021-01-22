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

    void Start()
    {
        Cursor.visible = false;

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
            SceneManager.LoadScene("Menu");
        }

        if (pollute > 100)
        {
            gameOver = true;           
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void CreateTrain()
    {
        Instantiate(train, tsp.position, tsp.rotation);
    }


    private void Pollution()
    {
        Instantiate(dirt, new Vector3(Random.Range(0, 2), Random.Range(-7, 4), -1), Quaternion.Euler(1, 1, 1));
        pollute += dirtyDamage;
        RefreshUi();
    }

    public void RefreshUi()
    {
        textScore.GetComponent<Text>().text = "Score: " + score.ToString();
        textLife.GetComponent<Text>().text = "Pollute: " + pollute.ToString();
    }
}
