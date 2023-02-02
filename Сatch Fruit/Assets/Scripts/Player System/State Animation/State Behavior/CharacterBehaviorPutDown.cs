using UnityEngine;

namespace PlayerSystem.StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorPutDown : CharacterBehavior
    {
        public CharacterBehaviorPutDown(Animator anim) : base(anim) { }

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.STR_PUT_DOWN, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.STR_PUT_DOWN, false);
        }
    }
}