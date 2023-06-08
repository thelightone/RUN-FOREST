using UnityEngine;

public class Right : MonoBehaviour
{
    private float _speed = 30f;
    private float _border = -25f;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        if (transform.position.x > -_border)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Lives>())
        {
            collision.gameObject.GetComponent<Lives>().FeedAnimal(1);
            Destroy(gameObject);
        }
    }
}
