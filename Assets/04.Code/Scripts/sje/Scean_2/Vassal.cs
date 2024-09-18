    using UnityEngine;

    public class Vassal : MonoBehaviour
    {
        public GameObject interaction;
        public AudioClip voiceClip;  
        private AudioSource audioSource;  

        public GameObject otherObject; 
        private Animator otherAnimator; 
        
        public GameObject ChatText;
        bool enterOk = false;
        bool hasPlayed = false;  

 
        enum EnemyState
        {
            Idle,
            FormalBow   
        }

         
        private EnemyState m_State;

       
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
                
                if (anim != null && m_State != EnemyState.FormalBow)  
                {
                    anim.SetTrigger("Idle2ToFormalBow");
                    m_State = EnemyState.FormalBow;
                    
                   
                    if (audioSource != null && voiceClip != null)
                    {
                        audioSource.Play();
                        hasPlayed = true;  
                        
                    }
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
                
                if (anim != null && m_State == EnemyState.FormalBow)
                {
                    anim.SetTrigger("FormalBowToIdle2");   
                    m_State = EnemyState.Idle;
                  
                }
            }
        }
    }


