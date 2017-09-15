using Animate.Core.Interfaces;
using Animate.Core.Internal.Concretes;
using Animate.Core.Internal.Controllers;
using Animate.Core.Internal.Interfaces;
using UnityEngine;

namespace Animate.Core {

    /// <summary>
    /// </summary>
    public static class Tween {

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
        public static ITweenData New() {
            ITweenController tweenController = TweenController;
            TweenRuntime tweenRuntime = new TweenRuntime(tweenController);
            tweenController.Add(tweenRuntime);
            return tweenRuntime;
        }

    }

}