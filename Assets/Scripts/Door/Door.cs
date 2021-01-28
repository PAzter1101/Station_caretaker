using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _open;
    void Start()
    {
        _open = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_open)
        {
            if (collision.tag == "Player")
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                _open = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_open)
        {
            if (collision.tag == "Player")
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                _open = false;
            }
        }
    }
}
