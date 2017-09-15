using Animate.Core.Interfaces;

namespace Animate.Core.Internal.Proxies {

    internal sealed class TweenProxy : ITween {

        private readonly ITween tween;

        public TweenProxy(ITween tween) {
            this.tween = tween;
        }

        public float Progress => this.tween.Progress;

        public float Evaluation => this.tween.Evaluation;

        public bool IsPlaying => this.tween.IsPlaying;

        public bool IsPaused => this.tween.IsPaused;

        public void Play() {
            this.tween.Play();
        }

        public void Pause() {
            this.tween.Pause();
        }

        public void Stop() {
            this.tween.Stop();
        }

        public void Restart() {
            this.tween.Restart();
        }

    }

}