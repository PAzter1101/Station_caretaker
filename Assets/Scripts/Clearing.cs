using UnityEngine;

public class Clearing : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gm.score++;

            if (gm.pollute > 6)
            {
                gm.pollute -= 7;
            }

            gm.RefreshUi();

            Destroy(gameObject);
        }
    }
}
