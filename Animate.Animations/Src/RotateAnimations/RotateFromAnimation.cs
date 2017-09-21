using UnityEngine;

namespace Animate.Animations.RotateAnimations {

    /// <summary>
    /// </summary>
    public class RotateFromAnimation : RotateFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        public RotateFromAnimation(Transform transform, Vector3 from) : base(transform, from, transform.eulerAngles) {
        }

    }

}