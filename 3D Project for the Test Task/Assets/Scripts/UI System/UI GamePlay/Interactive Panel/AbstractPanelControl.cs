using UnityEngine;
using UnityEngine.SceneManagement;
using SoundSystem;

namespace UISystem.UIGamePlay.InteractivePanel
{
    public abstract class AbstractPanelControl : MonoBehaviour
    {
        protected void RestartThisScene()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        protected void ExitToMeinMenu()
        {
            AudioClips.Instance.PlayClip(DictionaruSounds.STR_AUDIO_CLIP_BUTTON_CLIKC);
            SceneManager.LoadScene(0);
        }
    }
}