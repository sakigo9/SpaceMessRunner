using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
        [SerializeField] GameObject cam;

        [SerializeField] TrachHandler stopTrack;
       private AudioSource audioSource;
         [SerializeField] AudioClip[] musicPackage;
    // Start is called before the first frame update
    void Start()
    {

          audioSource= gameObject.GetComponent<AudioSource>();
          if (audioSource.isPlaying)
          {
            audioSource.clip=musicPackage[Random.Range(0,musicPackage.Length)];
            audioSource.Play();
          }
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetButton("MoveRight"))
     {
       gameObject.transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
     }else if(Input.GetButton("MoveLeft"))
     {
       gameObject.transform.Translate(-Vector3.right*moveSpeed*Time.deltaTime);
     }
     if (audioSource.isPlaying)
     {
       audioSource.clip=musicPackage[Random.Range(0,musicPackage.Length)];
       audioSource.Play();
     }
    }


    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="obstacle"  || other.gameObject.tag=="Border" )
      {
        cam.transform.parent=null;
        stopTrack.enabled=false;
        gameObject.SetActive(false);
        Invoke("Gameover",2.5f);
      }


    }
    private void Gameover(){
      PlayerPrefs.SetInt("CurrentScore",stopTrack.score);
      SceneManager.LoadScene(2);
    }
}
