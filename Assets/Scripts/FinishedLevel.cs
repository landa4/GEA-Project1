using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour
{
    public GameObject winningtext;
    private void OnTriggerEnter(Collider other)
    {
       if(string.Compare(other.tag, "Player") == 0){
            other.gameObject.GetComponent<MoveBehaviour>().SetCanMove(false);
            winningtext.SetActive(true);
       }

    }
}
