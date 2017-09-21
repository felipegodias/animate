using Animate.Core;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Animations.RotateAnimations {

    /// <summary>
    /// </summary>
    public static class RotateExtensions {

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData AddRotateFromAnimation(this ITweenData tweenData, Transform transform, Vector3 from) {
            IAnimation animation = new RotateFromAnimation(transform, from);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddRotateToAnimation(this ITweenData tweenData, Transform transform, Vector3 to) {
            IAnimation animation = new RotateToAnimation(transform, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddRotateFromToAnimation(this ITweenData tweenData, Transform transform, Vector3 from, Vector3 to) {
            IAnimation animation = new RotateFromToAnimation(transform, from, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData RotateFrom(this Transform transform, Vector3 from) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddRotateFromAnimation(transform, from);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData RotateTo(this Transform transform, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddRotateToAnimation(transform, to);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData RotateFromTo(this Transform transform, Vector3 from, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddRotateFromToAnimation(transform, from, to);
        }

    }

}