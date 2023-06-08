using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class jump : MonoBehaviour
{
    private Rigidbody rb;
    public float gravMod=4;
    public float force;
    public bool loos = false;
    private Animator animator;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpS;
    public AudioClip deathS;
    public AudioClip shotS;
    public AudioClip moneyS;
    private AudioSource source;
    public GameObject weapon;
    public float score;
    public TMP_Text text;
    public TMP_Text text2;
    public UnityEvent loseEvents;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
        Physics.gravity *= gravMod;
        animator= GetComponent<Animator>();
       source = GetComponent<AudioSource>();
        score = 0;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& transform.position.y < 0.1 && loos != true)
        {
            animator.SetTrigger("pressJump");
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            source.PlayOneShot(jumpS, 3);
        }
       else { animator.ResetTrigger("pressJump"); }

        if (Input.GetKeyDown(KeyCode.W))
        {
            var weapPos = new Vector3(transform.position.x, transform.position.y+1f, transform.position.z);
            source.PlayOneShot(shotS, 1);
            Instantiate(weapon, weapPos, weapon.transform.rotation);
        }
       if (loos == false) score += 1 * Time.deltaTime;
        text.text = System.Math.Round(score).ToString();
        text2.text = text.text;
}

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Bomb"))
        {
            explosion.Play();
            dirt.Stop();
           loos = true;
            Debug.Log("R.I.P.");
            animator.SetBool("Death",true);
            source.PlayOneShot(deathS, 1f);
            Destroy(collision.gameObject);
            Physics.gravity /= gravMod;
            loseEvents.Invoke();
        }
        else if (collision.gameObject.CompareTag("Money"))
        {
            score += 100;


            Debug.Log(score);

            source.PlayOneShot(moneyS, 1f);
            Destroy(collision.gameObject);
        }
    }

}
