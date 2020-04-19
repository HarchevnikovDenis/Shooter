using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
