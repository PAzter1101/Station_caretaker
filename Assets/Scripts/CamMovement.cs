using UnityEngine;

public class CamMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    private Transform tp;

    void Start()
    {
        tp = GetComponent<Transform>();
    }

    void Update()
    {
        Transform player_tp = player.GetComponent<Transform>();
        Vector3 move = player_tp.position - new Vector3(0, 0, 10);

        tp.position = move;
    }
}
