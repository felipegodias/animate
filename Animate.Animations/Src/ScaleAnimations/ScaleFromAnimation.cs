using UnityEngine;

namespace Animate.Animations.ScaleAnimations {

    /// <summary>
    /// </summary>
    public class ScaleFromAnimation : ScaleFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        public ScaleFromAnimation(Transform transform, Vector3 from) : base(transform, from, transform.localScale) {
        }

    }

}