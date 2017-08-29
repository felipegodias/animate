using Animate.Core.Interfaces;

namespace Animate.Core.Proxies {

    public class TweenProxy : ITween {

        private readonly ITween tween;

        public TweenProxy(ITween tween) {
            this.tween = tween;
        }

        public float Time => this.tween.Time;

    }

}