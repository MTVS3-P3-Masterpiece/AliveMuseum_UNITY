using System.Text;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
   private AudioSource myAudio;
   private bool musicStart = false;
   private void Start()
   {
      myAudio = GetComponent<AudioSource>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Note") && musicStart == false)
      {
         myAudio.Play();
         musicStart = true;
      }
   }
}
