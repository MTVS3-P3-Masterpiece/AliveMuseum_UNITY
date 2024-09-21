    using UnityEngine;

    public class SejongFSM : MonoBehaviour
    {
        public GameObject interaction;
        public AudioClip voiceClip;  
        private AudioSource audioSource;  
        
        public GameObject ChatText;
        bool enterOk = false;
        bool hasPlayed = false; 
        
        // 에너미 상태 상수
        enum EnemyState
        {
            Idle,
            Talking
        }

        // 에너미 상태 변수
        private EnemyState m_State;

        // 애니메이터 변수
        private Animator anim;

        void Start()
        {

            anim = transform.GetComponentInChildren<Animator>();
 
            audioSource = gameObject.AddComponent<AudioSource>(); 
            audioSource.clip = voiceClip;  
            audioSource.playOnAwake = false;  

           
            m_State = EnemyState.Idle;
        }

        void Update()
        {
            if (enterOk && Input.GetKeyDown(KeyCode.E))
            {
                if (anim != null && m_State == EnemyState.Idle)  
                {
                    anim.SetTrigger("IdleToTalking");
                    m_State = EnemyState.Talking;
                 
                    if (audioSource != null && voiceClip != null)
                    {
                        audioSource.Play();
                        hasPlayed = true;  
                    }
                }
            }
            
      
            if (m_State == EnemyState.Talking && !audioSource.isPlaying && hasPlayed)
            {
                if (anim != null)
                {
                    anim.SetTrigger("TalkingToIdle");
                    m_State = EnemyState.Idle;
                    hasPlayed = false;  
                }
            }
        }
        

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enterOk = true;
                interaction.SetActive(true);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                enterOk = false;
                interaction.SetActive(false);
                
                if (anim != null && m_State == EnemyState.Talking)
                {
                    anim.SetTrigger("TalkingToIdle");
                    m_State = EnemyState.Idle;
                    audioSource.Stop();
                }
            }
        }
    }



