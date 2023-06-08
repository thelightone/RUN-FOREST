using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Jump : MonoBehaviour
{
    private Rigidbody _rb;
    private float _gravMod = 4;
    private float _force = 1200;
    private float _score;
    private AudioSource _source;

    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private ParticleSystem _dirt;
    [SerializeField]
    private AudioClip _jumpS;
    [SerializeField]
    private AudioClip _deathS;
    [SerializeField]
    private AudioClip _shotS;
    [SerializeField]
    private AudioClip _moneyS;
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private TMP_Text _text2;
    [SerializeField]
    private UnityEvent _loseEvents;

    public bool loos = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= _gravMod;
        _animator = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
        _score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.1 && loos != true)
        {
            _animator.SetTrigger("pressJump");
            _rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
            _source.PlayOneShot(_jumpS, 3);
        }
        else { _animator.ResetTrigger("pressJump"); }

        if (Input.GetKeyDown(KeyCode.W))
        {
            var weapPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            _source.PlayOneShot(_shotS, 1);
            Instantiate(_weapon, weapPos, _weapon.transform.rotation);
        }

        if (loos == false) 
            _score += 1 * Time.deltaTime;
        _text.text = System.Math.Round(_score).ToString();
        _text2.text = _text.text;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Bomb"))
        {
            _explosion.Play();
            _dirt.Stop();
            loos = true;
            _animator.SetBool("Death", true);
            _source.PlayOneShot(_deathS, 1f);
            Destroy(collision.gameObject);
            Physics.gravity /= _gravMod;
            _loseEvents.Invoke();
        }
        else if (collision.gameObject.CompareTag("Money"))
        {
            _score += 100;
            _source.PlayOneShot(_moneyS, 1f);
            Destroy(collision.gameObject);
        }
    }
}
