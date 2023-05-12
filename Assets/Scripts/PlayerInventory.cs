using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public int NumCherry {get; private set;}

   public void CherryCollected(){
       NumCherry++;
   }
}
