using UnityEngine;

public class SpawnFlow : MonoBehaviour
{
    private Vector3 _pos;
    private Quaternion _rot;
    private Jump _controller;

    [SerializeField]
    private float _bord1 = -1.8f;
    [SerializeField]
    private float _bord2 = -3.5f;
    [SerializeField]
    private float _time;
    [SerializeField]
    private GameObject[] _prefabs;

    void Start()
    {
        InvokeRepeating("SpawnMan", 0.1f, _time);
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    void Update()
    {
        _pos = new Vector3(30f, 0.2f, Random.Range(_bord1, _bord2));
    }
    private void SpawnMan()
    {
        int rand = Random.Range(0, _prefabs.Length);
        if (_controller.loos != true)
        {
            var obj = Instantiate(_prefabs[rand], _pos, _prefabs[rand].transform.rotation);
            Destroy(obj, 10f);
        }
    }
}
