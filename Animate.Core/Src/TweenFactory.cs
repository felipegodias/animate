using Animate.Core.Interfaces;
using Animate.Core.Internal.Concretes;
using Animate.Core.Internal.Managers;
using Animate.Core.Internal.Interfaces;
using UnityEngine;

namespace Animate.Core {

    /// <summary>
    /// </summary>
    public static class TweenFactory {

        private static ITweenManager tweenManager;

        private static ITweenManager TweenManager {
            get {
                if (tweenManager != null) {
                    return tweenManager;
                }

                GameObject gameObject = new GameObject(nameof(TweenManager));
                Object.DontDestroyOnLoad(gameObject);
                tweenManager = gameObject.AddComponent<TweenManager>();
                return tweenManager;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static ITweenData New() {
            ITweenManager tweenManager = TweenManager;
            Tween tweenBehaviour = new Tween(tweenManager);
            tweenManager.Add(tweenBehaviour);
            return tweenBehaviour;
        }

    }

}