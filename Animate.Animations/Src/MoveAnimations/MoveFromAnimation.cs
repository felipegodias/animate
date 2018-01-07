using UnityEngine;

namespace Animate.Animations.MoveAnimations {

    /// <summary>
    /// </summary>
    public class MoveFromAnimation : MoveFromToAnimation {

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        public MoveFromAnimation(Transform transform, Vector3 from) : base(transform, from, transform.position) {
        }

    }

}