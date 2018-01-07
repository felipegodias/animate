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
            this.Animate(tweenRuntime.Evaluation);
        }

        public virtual void OnTweenLoopBegin(ITweenRuntime tweenRuntime) {
            this.Animate(tweenRuntime.Evaluation);
        }

        public virtual void OnTweenUpdate(ITweenRuntime tweenRuntime) {
            this.Animate(tweenRuntime.Evaluation);
        }

        public virtual void OnTweenLoopEnd(ITweenRuntime tweenRuntime) {
            this.Animate(tweenRuntime.Evaluation);
        }

        public virtual void OnTweenEnd(ITweenRuntime tweenRuntime) {
            this.Animate(tweenRuntime.Evaluation);
        }

        #endregion

        /// <summary>
        /// </summary>
        /// <param name="evaluation"></param>
        protected abstract void Animate(float evaluation);

    }

}