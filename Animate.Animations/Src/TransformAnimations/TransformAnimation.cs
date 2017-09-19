using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Animations.TransformAnimations {

    /// <summary>
    /// </summary>
    public abstract class TransformAnimation : IAnimation {

        private readonly Transform transform;

        protected TransformAnimation(Transform transform) {
            this.transform = transform;
        }

        /// <summary>
        /// </summary>
        public Transform Transform => this.transform;

        #region IAnimation Members

        public virtual void OnTweenBegin(ITweenRuntime tweenRuntime) {
        }

        public virtual void OnTweenLoopBegin(ITweenRuntime tweenRuntime) {
        }

        public virtual void OnTweenUpdate(ITweenRuntime tweenRuntime) {
        }

        public virtual void OnTweenLoopEnd(ITweenRuntime tweenRuntime) {
        }

        public virtual void OnTweenEnd(ITweenRuntime tweenRuntime) {
        }

        #endregion

    }

}