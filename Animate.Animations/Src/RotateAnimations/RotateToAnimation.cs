using UnityEngine;

namespace Animate.Animations.RotateAnimations {

    /// <summary>
    /// </summary>
    public class RotateToAnimation : RotateFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        public RotateToAnimation(Transform transform, Vector3 to) : base(transform, transform.eulerAngles, to) {
        }

    }

}