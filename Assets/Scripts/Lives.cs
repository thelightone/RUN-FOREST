using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    private AudioSource _source;
    private int _currentFedAmount = 0;

    [SerializeField]
    private Slider _hungerSlider;
    [SerializeField]
    private int _amountToBeFed;
    [SerializeField]
    private ParticleSystem _explosion;
    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        _hungerSlider.maxValue = _amountToBeFed;
        _hungerSlider.value = 0;
        _hungerSlider.fillRect.gameObject.SetActive(false);
        _source = GetComponent<AudioSource>();
    }

    public void FeedAnimal(int amount)
    {
        _currentFedAmount += amount;
        _hungerSlider.fillRect.gameObject.SetActive(true);
        _hungerSlider.value = _currentFedAmount;
        if (_currentFedAmount >= _amountToBeFed)
        {
            var expl = Instantiate(_explosion, transform.position, transform.rotation);
            _source.PlayOneShot(_clip, 1f);
            Destroy(gameObject,0.1f);
            Destroy(expl, 0.5f);
        }
    }
}
