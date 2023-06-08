using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Vector3 _pos = new Vector3(50f, 1f, 0.3f);
    private Jump _controller;

    [SerializeField]
    private GameObject[] _prefabs;

    void Start()
    {
        InvokeRepeating("SpawnMan", 2, 2.1f);
        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Jump>();
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
