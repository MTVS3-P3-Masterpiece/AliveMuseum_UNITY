using System.Collections;
using UnityEngine;

public class CenterFlame : MonoBehaviour
{
   private AudioSource myAudio;
   private bool musicStart = false;
   private NoteManager noteManager;
   public GameObject FinishUI;

   public GameObject GameUI1;
   public GameObject GameUI2;
   public GameObject GameUI3;
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
      GameUI1.SetActive(false);
      GameUI2.SetActive(false);
      GameUI3.SetActive(false);
      FinishUI.SetActive(true);

   }
}
