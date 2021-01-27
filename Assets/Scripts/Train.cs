using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private int speed;
    public string direction;

    private void Start()
    {
        if (direction == "Down")
        {
            speed *= -1;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    void Update()
    {
        transform.position += (new Vector3(0, speed, 0)) * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FinishTrain")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Dirt")
        {
            if (direction == "Up")
            {
                if (speed > 4)
                {
                    speed--;
                }
            }
            if (direction == "Down")
            {
                if (speed < -4)
                {
                    speed++;
                }
            }
        }

        if (collision.tag == "Player")
        {
            GameManager.gameOver = true;
        }
    }
}
