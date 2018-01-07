using Animate.Core;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Animations.ScaleAnimations {

    /// <summary>
    /// </summary>
    public static class ScaleExtensions {

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData AddScaleFromAnimation(this ITweenData tweenData, Transform transform, Vector3 from) {
            IAnimation animation = new ScaleFromAnimation(transform, from);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddScaleToAnimation(this ITweenData tweenData, Transform transform, Vector3 to) {
            IAnimation animation = new ScaleToAnimation(transform, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData AddScaleFromToAnimation(this ITweenData tweenData, Transform transform, Vector3 from, Vector3 to) {
            IAnimation animation = new ScaleFromToAnimation(transform, from, to);
            return tweenData.AddAnimation(animation);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ITweenData ScaleFrom(this Transform transform, Vector3 from) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddScaleFromAnimation(transform, from);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData ScaleTo(this Transform transform, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddScaleToAnimation(transform, to);
        }

        /// <summary>
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static ITweenData ScaleFromTo(this Transform transform, Vector3 from, Vector3 to) {
            ITweenData tweenData = TweenFactory.New();
            return tweenData.AddScaleFromToAnimation(transform, from, to);
        }

    }

}