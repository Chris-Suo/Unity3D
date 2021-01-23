using UnityEngine;
using UnityEngine.UI;

public class Castle : Tower
{
    public GameObject victory;
    public GameObject defeat;
    public AudioClip victoryAud;
    public AudioClip defeatAud;
    public bool isEnemey = true;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    protected override void Dead()
    {
        base.Dead();
        if (isEnemey)
        {
            victory.SetActive(true);
            aud.PlayOneShot(victoryAud, 1.5f);
        }
        else
        {
            defeat.SetActive(true);
            aud.PlayOneShot(defeatAud, 1.5f);
        }
    }
}
