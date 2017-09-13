using Animate.Core.Events;
using Animate.Core.Interfaces;
using Animate.Core.Internal.Collections;
using Animate.Core.Internal.Interfaces;
using Animate.Core.Internal.Proxies;

namespace Animate.Core.Internal.Concretes {

    internal sealed class TweenRuntime : ITweenData, ITweenRuntime {

        private readonly IEventList onTweenBegins;

        private readonly IEventList onTweenEnds;

        private readonly IEventList onTweenUpdates;

        private readonly ITween proxy;

        private float time;

        private float delay;

        private float elapsedTime;

        private float evaluation;

        private float progress;

        private bool isCompleted;

        private bool isStarted;

        public TweenRuntime() {
            this.onTweenBegins = new EventList();
            this.onTweenUpdates = new EventList();
            this.onTweenEnds = new EventList();
            this.proxy = new TweenProxy(this);
        }

        public float Time => this.time;

        public float Progress => this.progress;

        public float Evaluation => this.evaluation;

        public ITweenData SetTime(float time) {
            this.time = time;
            return this;
        }

        public ITweenData SetDelay(float delay) {
            this.delay = delay;
            return this;
        }

        public ITweenData AddOnTweenBegin(AnimateEvent onTweenBegin) {
            this.onTweenBegins.Add(onTweenBegin);
            return this;
        }

        public ITweenData AddOnTweenUpdate(AnimateEvent onTweenUpdate) {
            this.onTweenUpdates.Add(onTweenUpdate);
            return this;
        }

        public ITweenData AddOnTweenEnd(AnimateEvent onTweenEnd) {
            this.onTweenEnds.Add(onTweenEnd);
            return this;
        }

        public bool IsCompleted => this.isCompleted;

        public void Update(float deltaTime) {
            if (!this.isStarted) {
                this.isStarted = true;
                this.onTweenBegins.Invoke(this.proxy);
            }

            this.elapsedTime += deltaTime;

            if (this.elapsedTime <= this.delay) {
                return;
            }

            this.progress = (this.elapsedTime - this.delay) / this.time;
            this.evaluation = this.progress;
            this.onTweenUpdates.Invoke(this.proxy);

            if (this.progress < 1) {
                return;
            }

            this.isCompleted = true;
            this.onTweenEnds.Invoke(this.proxy);
        }

    }

}