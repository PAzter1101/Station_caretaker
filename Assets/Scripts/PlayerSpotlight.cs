using UnityEngine;

public class PlayerSpotlight : MonoBehaviour
{
    [SerializeField] private float offset;   //Сдвиг (при необходимости)


    void Update()
    {
        //Вращение фонарика за курсором
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset-90); 
        //-----------------------------------
    }
}
