using UnityEngine;

namespace PlayerSystem.StateAnimation.StateBehavior
{
    public sealed class CharacterBehaviorDancesWinGame : CharacterBehavior
    {
        public CharacterBehaviorDancesWinGame(Animator anim) : base(anim) { }

        public override void Enter()
        {
            _anim.SetBool(DictionaryAnimState.STR_WIN_GAME, true);
        }

        public override void Exit()
        {
            _anim.SetBool(DictionaryAnimState.STR_WIN_GAME, false);
        }
    }
}