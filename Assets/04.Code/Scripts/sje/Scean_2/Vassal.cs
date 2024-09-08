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

        // 에너미 상태 상수
        enum EnemyState
        {
            Idle,
            FormalBow   
        }

        // 에너미 상태 변수
        private EnemyState m_State;

        // 애니메이터 변수
        private Animator anim;

        void Start()
        {
           
            anim = transform.GetComponentInChildren<Animator>();
            
            //음성파일 
            audioSource = gameObject.AddComponent<AudioSource>();  
            audioSource.clip = voiceClip; // 음성 파일 연결
            audioSource.playOnAwake = false; // Start()에서 자동으로 재생되지 않도록 설정

            // 최초의 에너미 상태는 대기 (Idle) 로 한다.
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
                    
                    // 음성 파일 재생
                    if (audioSource != null && voiceClip != null)
                    {
                        audioSource.Play();
                        hasPlayed = true; // 음성이 재생되었음을 기록
                        
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
                    anim.SetTrigger("FormalBowToIdle2");   //FormalBowToIdle  // TalkingToIdle
                    m_State = EnemyState.Idle;
                  
                }
            }
        }
    }


