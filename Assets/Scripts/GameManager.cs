using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int minTime;
    [SerializeField]
    private int maxTime;

    [SerializeField]
    private GameObject dirt;
    [SerializeField]
    private int dirtyDamage;

    [SerializeField]
    public GameObject textScore;
    [SerializeField]
    public GameObject textLife;

    public int score;
    public int life;

    void Start()
    {
        InvokeRepeating("pollution", 1, 3);
        score = 0;
    }
    private void Update()
    {
        if (life < 0)
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }


    void pollution()
    {
        Instantiate(dirt, new Vector3(Random.Range(0, 2), Random.Range(-7, 4), -1), Quaternion.Euler(1, 1, 1));
        life -= dirtyDamage;
        RefreshUi();
    }

    public void RefreshUi()
    {
        textScore.GetComponent<Text>().text = "Score: " + score.ToString();
        textLife.GetComponent<Text>().text = "Life: " + life.ToString();
    }
}
