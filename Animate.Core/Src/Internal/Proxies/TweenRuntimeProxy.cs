using Animate.Core.Interfaces;

namespace Animate.Core.Internal.Proxies {

    internal sealed class TweenRuntimeProxy : ITweenRuntime {

        private readonly ITweenRuntime tweenRuntime;

        public TweenRuntimeProxy(ITweenRuntime tweenRuntime) {
            this.tweenRuntime = tweenRuntime;
        }

        public float Progress => this.tweenRuntime.Progress;

        public float Evaluation => this.tweenRuntime.Evaluation;

    }

}