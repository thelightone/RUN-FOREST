using UnityEngine;

public class Left : MonoBehaviour
{
    private float _speedy = 0.15f;
    private Jump _controller;
    private float _border = -15f;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _controller = _player.GetComponent<Jump>();
    }

    void FixedUpdate()
    {
        float xx = transform.position.x - _speedy;
        if (_player.transform.position.y > 0.2)
            xx = transform.position.x - (_speedy * 1.5f);
        if (_controller.loos != true)
            transform.position = new Vector3(xx, transform.position.y, transform.position.z);
        if (transform.position.x < _border && (gameObject.CompareTag("Ground") || gameObject.CompareTag("Bomb") || gameObject.CompareTag("Respawn")))
            Destroy(gameObject);
    }
}
