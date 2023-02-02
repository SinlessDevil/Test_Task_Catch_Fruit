using UnityEngine;
using UnityEngine.SceneManagement;
using SoundSystem;

namespace UISystem.UIMeinMenu
{
    public class MeinMenuSceneControl : MonoBehaviour
    {
        [SerializeField] private GameObject _audioManager;
        private void Awake()
        {
            if(GameObject.Find("[AUDIO MANAGER](Clone)") == null)
            {
                Instantiate(_audioManager,transform.position, Quaternion.identity);
            }
        }

        public void OnEnable()
        {
            MeinMenuButtons.ButtonClickPlayGameEvent += PlayGame;
            MeinMenuButtons.ButtonClickExitEvent += ExitThisGame;
        }

        public void OnDisable()
        {
            MeinMenuButtons.ButtonClickPlayGameEvent -= PlayGame;
            MeinMenuButtons.ButtonClickExitEvent -= ExitThisGame;
        }

        private void PlayGame()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void ExitThisGame()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            Application.Quit();
            Debug.Log("Exit");
        }
    }
}