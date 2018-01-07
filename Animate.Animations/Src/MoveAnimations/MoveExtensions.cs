using Animate.Core;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Animations.MoveAnimations {

    /// <summary>
    /// </summary>
    public static class MoveExtensions {

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData AddMoveFromAnimation(this ITweenData tweenData, Transform transform, Vector3 from) {
            IAnimation animation = new MoveFromAnimation(transform, from);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddMoveToAnimation(this ITweenData tweenData, Transform transform, Vector3 to) {
            IAnimation animation = new MoveToAnimation(transform, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddMoveFromToAnimation(this ITweenData tweenData, Transform transform, Vector3 from, Vector3 to) {
            IAnimation animation = new MoveFromToAnimation(transform, from, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData MoveFrom(this Transform transform, Vector3 from) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddMoveFromAnimation(transform, from);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData MoveTo(this Transform transform, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddMoveToAnimation(transform, to);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData MoveFromTo(this Transform transform, Vector3 from, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddMoveFromToAnimation(transform, from, to);
        }

    }

}