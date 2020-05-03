using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrachHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] GameObject trackPrefab;
    [SerializeField] Text scoreTxt;

    private float distanceOfDeletion=-200f;
    internal int score =0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      scoreTxt.text=score.ToString();
        gameObject.transform.Translate(-Vector3.forward*Time.deltaTime*moveSpeed);
        if(gameObject.transform.position.z<=distanceOfDeletion)
        {
          Destroy(gameObject.transform.GetChild(0).gameObject);
          score+=5;
          distanceOfDeletion=distanceOfDeletion-200;
          GameObject temp =Instantiate(trackPrefab,Vector3.zero,Quaternion.identity);
          gameObject.transform.GetChild(gameObject.transform.childCount-1);
          temp.transform.position=new Vector3(0,0,gameObject.transform.GetChild(gameObject.transform.childCount-1).transform.position.z+200f);
          temp.transform.parent=gameObject.transform;
        }
    }
}
