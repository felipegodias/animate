using Animate.Core.Events;
using Animate.Core.Interfaces;
using Animate.Core.Internal.Collections;
using Animate.Core.Internal.Interfaces;
using Animate.Core.Internal.Proxies;
using UnityEngine;

namespace Animate.Core.Internal.Concretes {

    internal sealed class TweenRuntime : ITween, ITweenData, ITweenRuntime {

        private readonly IEventList onTweenBegins;

        private readonly IEventList onTweenEnds;

        private readonly IEventList onTweenUpdates;

        private readonly ITween proxy;

        private float time;

        private float startDelay;

        private float loopDelay;

        private uint loopCount;

        private float elapsedTime;

        private uint elapsedLoops;

        private float evaluation;

        private float progress;

        private bool isStarted;

        private bool isCompleted;

        public TweenRuntime() {
            this.onTweenBegins = new EventList();
            this.onTweenUpdates = new EventList();
            this.onTweenEnds = new EventList();
            this.proxy = new TweenProxy(this);
        }

        public float Progress => this.progress;

        public float Evaluation => this.evaluation;

        public float Time => this.time;

        public float StartDelay => this.startDelay;

        public float LoopDelay => this.loopDelay;

        public uint LoopCount => this.loopCount;

        public ITweenData SetTime(float time) {
            this.time = time;
            return this;
        }

        public ITweenData SetStartDelay(float startDelay) {
            this.startDelay = startDelay;
            return this;
        }

        public ITweenData SetLoopDelay(float loopDelay) {
            this.loopDelay = loopDelay;
            return this;
        }

        public ITweenData SetLoopCount(uint loopCount) {
            this.loopCount = loopCount;
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

            if (this.elapsedTime <= this.startDelay + this.time * this.elapsedLoops + this.loopDelay * this.elapsedLoops) {
                return;
            }

            float normalizedTime = this.elapsedTime - (this.startDelay + this.elapsedLoops * this.loopDelay);

            uint currentLoopIndex = (uint) Mathf.FloorToInt(normalizedTime / this.time);

            if (this.elapsedLoops != currentLoopIndex) {
                this.progress = 1;
            } else {
                this.progress = normalizedTime % this.time / this.time;
            }

            this.evaluation = this.progress;
            this.onTweenUpdates.Invoke(this.proxy);

            this.elapsedLoops = currentLoopIndex;

            if (this.elapsedLoops <= this.loopCount - 1) {
                return;
            }

            this.isCompleted = true;
            this.onTweenEnds.Invoke(this.proxy);
        }

    }

}