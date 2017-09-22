using UnityEngine;

namespace Animate.Animations.ScaleAnimations {

    /// <summary>
    /// </summary>
    public class ScaleToAnimation : ScaleFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        public ScaleToAnimation(Transform transform, Vector3 to) : base(transform, transform.localScale, to) {
        }

    }

}