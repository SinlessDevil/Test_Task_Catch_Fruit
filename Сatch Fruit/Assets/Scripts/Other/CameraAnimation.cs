using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimation : MonoBehaviour
{
    private const string STR_START_GAME_ANIAMTION = "StartGame";
    private const string STR_END_GAME_ANIAMTION = "EndGame";

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        StartAnim();
    }

    private void OnEnable()
    {
        Level.OnWinGameEvent += EndAnim;
        Level.OnGameOverEvent += EndAnim;
    }

    private void OnDisable()
    {
        Level.OnWinGameEvent -= EndAnim;
        Level.OnGameOverEvent -= EndAnim;
    }

    private void StartAnim()
    {
        _anim.SetBool(STR_START_GAME_ANIAMTION, true);
    }

    private void EndAnim()
    {
        _anim.SetBool(STR_END_GAME_ANIAMTION, true);
    }
}