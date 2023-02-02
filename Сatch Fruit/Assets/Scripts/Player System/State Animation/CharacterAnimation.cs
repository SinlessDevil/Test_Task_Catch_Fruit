using System;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystem.StateAnimation.StateBehavior;

namespace PlayerSystem.StateAnimation
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private Dictionary<Type, ICharacterBehavior> _behaviorsMap;
        private ICharacterBehavior _behaviorCurrent;

        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            this.InitBehaviors();
            SetBehaviorByDefault();
        }

        private void InitBehaviors()
        {
            this._behaviorsMap = new Dictionary<Type, ICharacterBehavior>();

            this._behaviorsMap[typeof(CharacterBehaviorIdile)] = new CharacterBehaviorIdile(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorPutDown)] = new CharacterBehaviorPutDown(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorPutUp)] = new CharacterBehaviorPutUp(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorDancesWinGame)] = new CharacterBehaviorDancesWinGame(_anim);
            this._behaviorsMap[typeof(CharacterBehaviorDancesGameOver)] = new CharacterBehaviorDancesGameOver(_anim);
        }
        private void SetBehavior(ICharacterBehavior newBehavior){
            if(this._behaviorCurrent != null){
                this._behaviorCurrent.Exit();
            }

            this._behaviorCurrent = newBehavior;
            this._behaviorCurrent.Enter();
        }
        private void SetBehaviorByDefault(){
            SetBehaviorIdile();
        }

        private ICharacterBehavior GetBehavior<T>() where T : ICharacterBehavior{
            var type = typeof(T);
            return this._behaviorsMap[type];
        }

        //----------------------------------------------------------------------------------------------------------

        public void SetBehaviorIdile(){
            var _behaviorByDefault = this.GetBehavior<CharacterBehaviorIdile>();
            this.SetBehavior(_behaviorByDefault);
        }

        public void SetBehaviorPutDown(){
            var _behaviorByMove = this.GetBehavior<CharacterBehaviorPutDown>();
            this.SetBehavior(_behaviorByMove);
        }

        public void SetBehaviorPutUp(){
            var _behaviorByJump = this.GetBehavior<CharacterBehaviorPutUp>();
            this.SetBehavior(_behaviorByJump);
        }

        public void SetBehaviorDancesWinGame()
        {
            var _behaviorByAttack = this.GetBehavior<CharacterBehaviorDancesWinGame>();
            this.SetBehavior(_behaviorByAttack);
        }

        public void SetBehaviorDancesGameOver()
        {
            var _behaviorByAttack = this.GetBehavior<CharacterBehaviorDancesGameOver>();
            this.SetBehavior(_behaviorByAttack);
        }
    }
}