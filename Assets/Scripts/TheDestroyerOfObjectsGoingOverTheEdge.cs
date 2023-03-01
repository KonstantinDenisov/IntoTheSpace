using UnityEngine;

public class TheDestroyerOfObjectsGoingOverTheEdge : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D col)
   {
      Destroy(col.gameObject);
   }
}