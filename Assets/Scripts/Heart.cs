using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite BrokenSprite;
    public AudioClip dieAudio;

    public GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Die()
    {
        
        sr.sprite = BrokenSprite;

        Instantiate(explosionPrefab, transform.position, transform.rotation);

        PlayerManager.Instance.isDefead = true;
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);

        //Invoke("ReturnToTheMainMenu", 3);

    }

    //public void ReturnToTheMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}

}
