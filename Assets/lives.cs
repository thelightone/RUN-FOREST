using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;
//using static UnityEditor.PlayerSettings;


public class lives : MonoBehaviour
{
    public Slider hungerSlider;
    public int amountToBeFed;
    private int currentFedAmount = 0;
    public ParticleSystem explosion;
    private AudioSource source;
    public AudioClip clip;
    

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
        source = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;
        if (currentFedAmount >= amountToBeFed)
        {
            Instantiate(explosion, new Vector3 (transform.position.x, transform.position.y+1, transform.position.z), new Quaternion (0,180,0, transform.rotation.w));
            source.PlayOneShot(clip, 1f);

            Destroy(gameObject, 0.1f);
        }
    }

}
