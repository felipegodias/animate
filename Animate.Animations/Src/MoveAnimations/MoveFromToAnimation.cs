using Animate.Animations.TransformAnimations;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Animations.MoveAnimations {

    /// <summary>
    /// </summary>
    public class MoveFromToAnimation : TransformAnimation {

        private readonly Vector3 from;

        private readonly Vector3 to;

        private readonly Vector3 dif;

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public MoveFromToAnimation(Transform transform, Vector3 from, Vector3 to) : base(transform) {
            this.from = from;
            this.to = to;
            this.dif = to - from;
        }

        /// <summary>
        /// </summary>
        public Vector3 From => this.from;

        /// <summary>
        /// </summary>
        public Vector3 To => this.to;

        public override void OnTweenBegin(ITweenRuntime tweenRuntime) {
            this.SetPosition(tweenRuntime.Evaluation);
        }

        public override void OnTweenLoopBegin(ITweenRuntime tweenRuntime) {
            this.SetPosition(tweenRuntime.Evaluation);
        }

        public override void OnTweenUpdate(ITweenRuntime tweenRuntime) {
            this.SetPosition(tweenRuntime.Evaluation);
        }

        public override void OnTweenLoopEnd(ITweenRuntime tweenRuntime) {
            this.SetPosition(tweenRuntime.Evaluation);
        }

        public override void OnTweenEnd(ITweenRuntime tweenRuntime) {
            this.SetPosition(tweenRuntime.Evaluation);
        }

        private void SetPosition(float evaluation) {
            this.Transform.position = this.from + this.dif * evaluation;
        }

    }

}