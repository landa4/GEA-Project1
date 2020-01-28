using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(string.Compare(other.tag, "Player") == 0){
            Debug.Log("Win");
       }
    }
}
