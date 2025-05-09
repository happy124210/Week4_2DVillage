using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        [Header("Audio Sources")]
        [SerializeField] private AudioSource bgmSource;
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource stepSource;

        // BGM Clips
        private AudioClip mainSceneBGM;
        private AudioClip dungeonSceneBGM;
        
        // SFX Clips
        private AudioClip hitSound;
        private AudioClip dialogueSound;
        private AudioClip stepSound;
        private AudioClip coinSound;
        
        private float stepTimer;
        private readonly float StepInterval = 0.3f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
            
            mainSceneBGM = Resources.Load<AudioClip>("BGM/mainSceneBGM");
            dungeonSceneBGM = Resources.Load<AudioClip>("BGM/dungeonSceneBGM");
            hitSound = Resources.Load<AudioClip>("Audio/Hit");
            dialogueSound = Resources.Load<AudioClip>("Audio/Dialogue");
            stepSound = Resources.Load<AudioClip>("Audio/Step");
            coinSound =  Resources.Load<AudioClip>("Audio/Coin");
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    
        
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            switch (scene.name)
            {
                case "MainScene":
                    PlayBGM(mainSceneBGM);
                    break;
                case "DungeonScene":
                    PlayBGM(dungeonSceneBGM);
                    break;
            }
        }

        
        private void PlayBGM(AudioClip clip)
        {
            if (bgmSource.clip == clip) return;

            bgmSource.Stop();
            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
        
        
        public void HandleStepSound(bool isWalking)
        {
            if (!isWalking)
            {
                stepTimer = 0f;
                return;
            }

            stepTimer += Time.deltaTime;

            if (stepTimer >= StepInterval)
            {
                stepTimer = 0f;
                sfxSource.PlayOneShot(stepSound);
            }
        }

        public void PlayHit() => sfxSource.PlayOneShot(hitSound);
        public void PlayDialogue() => sfxSource.PlayOneShot(dialogueSound);
        public void PlayCoin() => sfxSource.PlayOneShot(coinSound);
    }
}
