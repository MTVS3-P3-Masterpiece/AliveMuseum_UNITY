    using UnityEngine;

    public class SejongFSM : MonoBehaviour
    {
        public GameObject interaction;
        public AudioClip voiceClip; // 재생할 음성 파일을 할당할 변수
        private AudioSource audioSource; // 음성 파일을 재생할 AudioSource 컴포넌트
        
        public GameObject ChatText;
        bool enterOk = false;
        bool hasPlayed = false; // 음성이 재생되었는지 여부를 기록하는 변수
        
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
            
            //음성파일 
            audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource 컴포넌트 추가
            audioSource.clip = voiceClip; // 음성 파일 연결
            audioSource.playOnAwake = false; // Start()에서 자동으로 재생되지 않도록 설정

            // 최초의 에너미 상태는 대기 (Idle) 로 한다.
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
                    // 음성 파일 재생
                    if (audioSource != null && voiceClip != null)
                    {
                        audioSource.Play();
                        hasPlayed = true; // 음성이 재생되었음을 기록
                    }
                }
            }
            
            // 음성이 끝나면 애니메이션을 Idle로 전환
            if (m_State == EnemyState.Talking && !audioSource.isPlaying && hasPlayed)
            {
                if (anim != null)
                {
                    anim.SetTrigger("TalkingToIdle");
                    m_State = EnemyState.Idle;
                    hasPlayed = false; // 음성 재생 상태 리셋
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
                
                // Idle 애니메이션으로 전환
                if (anim != null && m_State == EnemyState.Talking)
                {
                    //anim.SetTrigger("FormalBowToIdle2");
                    anim.SetTrigger("TalkingToIdle");
                    m_State = EnemyState.Idle;
                    audioSource.Stop();
                }
            }
        }
    }



