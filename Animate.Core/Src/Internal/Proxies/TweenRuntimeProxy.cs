using Animate.Core.Interfaces;

namespace Animate.Core.Internal.Proxies {

    internal sealed class TweenRuntimeProxy : ITweenRuntime {

        private readonly ITweenRuntime tweenRuntime;

        public TweenRuntimeProxy(ITweenRuntime tweenRuntime) {
            this.tweenRuntime = tweenRuntime;
        }

        #region ITweenRuntime Members

        public float Progress => this.tweenRuntime.Progress;

        public float Evaluation => this.tweenRuntime.Evaluation;

        #endregion

    }

}