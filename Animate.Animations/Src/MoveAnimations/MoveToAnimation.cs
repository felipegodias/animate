using UnityEngine;

namespace Animate.Animations.MoveAnimations {

    /// <summary>
    /// </summary>
    public class MoveToAnimation : MoveFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        public MoveToAnimation(Transform transform, Vector3 to) : base(transform, transform.position, to) {
        }

    }

}