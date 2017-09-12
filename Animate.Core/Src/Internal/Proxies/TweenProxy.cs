using Animate.Core.Interfaces;

namespace Animate.Core.Internal.Proxies {

    internal sealed class TweenProxy : ITween {

        private readonly ITween tween;

        public TweenProxy(ITween tween) {
            this.tween = tween;
        }

        public float Time => this.tween.Time;

        public float Progress => this.tween.Progress;

        public float Evaluation => this.tween.Evaluation;

    }

}