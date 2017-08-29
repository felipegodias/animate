using Animate.Core.Interfaces;
using Animate.Core.Proxies;

namespace Animate.Core.Concretes {

    internal sealed class TweenRuntime : ITweenData, ITweenRuntime {

        private bool isCompleted;

        private ITween proxy;

        private float time;

        public TweenRuntime() {
            this.proxy = new TweenProxy(this);
        }

        public float Time => this.time;

        public ITweenData SetTime(float time) {
            this.time = time;
            return this;
        }

        public bool IsCompleted => this.isCompleted;

        public void Update(float deltaTime) {
            this.isCompleted = true;
        }

    }

}