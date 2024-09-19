using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    private double currentTime = 0d;

    public bool noteActive = true;
    [SerializeField] private Transform tfNoteAppear = null;
    //[SerializeField] private GameObject goNote = null
    public NoteData[] noteData;
    private TimingManager theTimingManager;
    private EffectManager theEffectManager;
    private int cnt = 0;
    void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
        noteData = new NoteData[100];

        for (int i = 0; i < 100; i++)
        {
            noteData[i] = new NoteData(1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (noteActive)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 60d / bpm * noteData[cnt].beatUnit)
            {
                GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                t_note.transform.position = tfNoteAppear.position;
                t_note.SetActive(true);
                //GameObject t_note = Instantiate(goNote, tfNoteAppear.position, Quaternion.identity);
                //t_note.transform.SetParent(this.transform);
                theTimingManager.boxNoteList.Add(t_note);
                currentTime -= 60d / bpm * noteData[cnt].beatUnit;
                cnt++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if(collision.GetComponent<Note>().GetNoteFlag())
                theEffectManager.JudgementEffect(4);
            theTimingManager.boxNoteList.Remove(collision.gameObject);
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }

    public void RemoveNote()
    {
        noteActive = false;
        for (int i = 0; i < theTimingManager.boxNoteList.Count; i++)
        {
            theTimingManager.boxNoteList[i].SetActive(false);
            ObjectPool.instance.noteQueue.Enqueue(theTimingManager.boxNoteList[i]);
        }
    }
}
