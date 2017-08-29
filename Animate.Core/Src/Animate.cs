using Animate.Core.Concretes;
using Animate.Core.Controllers;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Core {

    /// <summary>
    /// </summary>
    public static class Animate {

        private static ITweenController tweenController;

        private static ITweenController TweenController {
            get {
                if (tweenController != null) {
                    return tweenController;
                }

                GameObject gameObject = new GameObject(nameof(TweenController));
                Object.DontDestroyOnLoad(gameObject);
                tweenController = gameObject.AddComponent<TweenController>();
                return tweenController;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static ITweenData Play() {
            TweenRuntime tweenRuntime = new TweenRuntime();
            TweenController.Add(tweenRuntime);
            return tweenRuntime;
        }

    }

}