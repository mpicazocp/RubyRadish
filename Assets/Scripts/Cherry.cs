using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        
        if(playerInventory != null){
            playerInventory.CherryCollected();
            gameObject.SetActive(false);
        }
    }
}
