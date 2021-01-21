using UnityEngine;

public class Clearing : MonoBehaviour
{
    [SerializeField]
    public GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            gm.score++;
            if (gm.life < 100)
            {
                gm.life += 7;
            }
            gm.RefreshUi();
            Debug.Log("Clearing!");
            Destroy(gameObject);
        }
    }
}
