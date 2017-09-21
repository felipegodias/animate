using Animate.Animations.TransformAnimations;
using UnityEngine;

namespace Animate.Animations.RotateAnimations {

    /// <summary>
    /// </summary>
    public class RotateFromToAnimation : TransformAnimation {

        private readonly Vector3 from;

        private readonly Vector3 to;

        private readonly Vector3 dif;

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public RotateFromToAnimation(Transform transform, Vector3 from, Vector3 to) : base(transform) {
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

        protected override void Animate(float evaluation) {
            this.Transform.eulerAngles = this.from + this.dif * evaluation;
        }

    }

}