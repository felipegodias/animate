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

        private float elapsedTime;

        private float evaluation;

        private bool isCompleted;

        private bool isStarted;

        private float progress;

        private float time;

        public TweenRuntime() {
            this.onTweenBegins = new EventList();
            this.onTweenUpdates = new EventList();
            this.onTweenEnds = new EventList();
            this.proxy = new TweenProxy(this);
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

        public float Time => this.time;

        public float Progress => this.progress;

        public float Evaluation => this.evaluation;

        public ITweenData SetTime(float time) {
            this.time = time;
            return this;
        }

        public bool IsCompleted => this.isCompleted;

        public void Update(float deltaTime) {
            if (!this.isStarted) {
                this.isStarted = true;
                this.onTweenBegins.Invoke(this.proxy);
            }

            this.elapsedTime += deltaTime;
            this.progress = this.elapsedTime / this.time;
            this.evaluation = this.progress;
            this.onTweenUpdates.Invoke(this.proxy);

            if (!(this.elapsedTime >= this.time)) {
                return;
            }

            this.isCompleted = true;
            this.onTweenEnds.Invoke(this.proxy);
        }

    }

}