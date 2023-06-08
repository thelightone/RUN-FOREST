using UnityEngine;

public class SpawnFly : MonoBehaviour
{
    private Vector3 _pos;
    private Jump _controller;

    [SerializeField]
    private GameObject[] _prefabs;
    [SerializeField]
    private float _bord1 = -1.8f;
    [SerializeField]
    private float _bord2 = -3.5f;

    void Start()
    {
        InvokeRepeating("SpawnMan", 3, 2.9f);
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
    }

    void Update()
    {
        _pos = new Vector3(20f, Random.Range(3f, 6f), 0.3f);
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
