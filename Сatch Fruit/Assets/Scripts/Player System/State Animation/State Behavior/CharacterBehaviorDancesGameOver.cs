using UnityEngine;

namespace PlayerSystem.StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorDancesGameOver : CharacterBehavior
    {
        public CharacterBehaviorDancesGameOver(Animator anim) : base(anim) { }

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.STR_GAME_OVER, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.STR_GAME_OVER, false);
        }
    }
}