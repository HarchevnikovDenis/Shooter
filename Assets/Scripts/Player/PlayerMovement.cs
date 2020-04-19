using UnityEngine;
using UnityEngine.AI;

//Скрипт перемещения персонажа
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private new Transform transform;
    private NavMeshAgent agent;

    private void Start()
    {
        transform = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if(movement.x != 0 || movement.z != 0)
        {
            movement = Vector3.ClampMagnitude(movement, speed);
            movement *= speed * Time.deltaTime;
            agent.Move(movement);
        }
    }
}
