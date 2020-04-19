using UnityEngine;

//Скрипт поворота игрока в сторону мыши
public class PlayerRotation : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 250.0f))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;

            targetPosition -= transform.position;
            transform.rotation = Quaternion.LookRotation(targetPosition, Vector3.up);
        }
    }

}
