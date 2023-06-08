using UnityEngine;

public class BackRepeat : MonoBehaviour
{
    private Vector3 _startPos;
    private float _colWidth;

    void Start()
    {
        _startPos = transform.position;
        _colWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        if (transform.position.x < _startPos.x - _colWidth)
        {
            transform.position = _startPos;
        }
    }
}
