using UnityEngine;

namespace PlayerSystem.StateAnimation.StateBehavior
{
    public abstract class CharacterBehavior : MonoBehaviour, ICharacterBehavior
    {
        protected Animator _anim;
        public CharacterBehavior(Animator anim)
        {
            this._anim = anim;
        }

        public abstract void Enter();

        public abstract void Exit();

    }
}