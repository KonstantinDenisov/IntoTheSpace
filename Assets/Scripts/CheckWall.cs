using System;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
      Destroy(col.gameObject);
   }
}