using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool activeLight;

    void Update()
    {
        //Включение/выключение фонарика
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (activeLight)
            {
                activeLight = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                activeLight = true;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        //-----------------------------
    }
}
