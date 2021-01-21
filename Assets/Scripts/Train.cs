using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private int speed;

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
            if (speed > 4)
            {
                speed -= 1;
            }
        }

        if (collision.tag == "Player")
        {
            GameManager.gameOver = true;
        }
    }
}
