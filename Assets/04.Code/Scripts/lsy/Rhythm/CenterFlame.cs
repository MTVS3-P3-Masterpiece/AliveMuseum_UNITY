using System.Collections;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
   private AudioSource myAudio;
   private bool musicStart = false;
   private NoteManager noteManager;
   private void Start()
   {
      myAudio = GetComponent<AudioSource>();
      noteManager = FindObjectOfType<NoteManager>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Note") && musicStart == false)
      {
         myAudio.Play();
         musicStart = true;
         StartCoroutine(FinishGame());
      }
   }

   private IEnumerator FinishGame()
   {
      yield return new WaitForSeconds(myAudio.clip.length);
      noteManager.RemoveNote();

   }
}
