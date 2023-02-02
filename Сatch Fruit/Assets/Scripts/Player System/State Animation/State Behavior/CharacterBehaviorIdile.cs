using UnityEngine;

namespace PlayerSystem.StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorIdile : CharacterBehavior
    {
        public CharacterBehaviorIdile(Animator anim) : base(anim) {}

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.STR_PUT_DOWN, false);
            _anim.SetBool(DictionaryAnimState.STR_PUT_UP, false);
            _anim.SetBool(DictionaryAnimState.STR_WIN_GAME, false);
            _anim.SetBool(DictionaryAnimState.STR_GAME_OVER, false);
        }

        public override void Exit()
        {
           
        }
    }
}