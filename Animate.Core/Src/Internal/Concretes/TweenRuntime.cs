using Animate.Core.Events;
using Animate.Core.Interfaces;
using Animate.Core.Internal.Collections;
using Animate.Core.Internal.Interfaces;
using Animate.Core.Internal.Proxies;
using UnityEngine;

namespace Animate.Core.Internal.Concretes {

    internal sealed class TweenRuntime : ITween, ITweenData, ITweenRuntime {

        private readonly IEventList onTweenBegin;

        private readonly IEventList onTweenLoopBegin;

        private readonly IEventList onTweenUpdate;

        private readonly IEventList onTweenLoopEnd;

        private readonly IEventList onTweenEnd;

        private readonly ITween proxy;

        private float time;

        private float startDelay;

        private float loopDelay;

        private uint loopCount;

        private float elapsedTime;

        private uint elapsedLoops;

        private LoopType loopType;

        private IEaseCurve easeCurve;

        private float evaluation;

        private float progress;

        private bool hasBegan;

        private bool hasLoopBegan;

        private bool hasEnded;

        public TweenRuntime() {
            this.onTweenBegin = new EventList();
            this.onTweenLoopBegin = new EventList();
            this.onTweenUpdate = new EventList();
            this.onTweenLoopEnd = new EventList();
            this.onTweenEnd = new EventList();
            this.proxy = new TweenProxy(this);
        }

        public float Progress => this.progress;

        public float Evaluation => this.evaluation;

        public float Time => this.time;

        public float StartDelay => this.startDelay;

        public float LoopDelay => this.loopDelay;

        public uint LoopCount => this.loopCount;

        public LoopType LoopType => this.loopType;

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

        public ITweenData SetLoopType(LoopType loopType) {
            this.loopType = loopType;
            return this;
        }

        public ITweenData SetEaseCurve(IEaseCurve easeCurve) {
            this.easeCurve = easeCurve;
            return this;
        }

        public ITweenData AddOnTweenBegin(AnimateEvent onTweenBegin) {
            this.onTweenBegin.Add(onTweenBegin);
            return this;
        }

        public ITweenData AddOnTweenLoopBegin(AnimateEvent onTweenLoopBegin) {
            this.onTweenLoopBegin.Add(onTweenLoopBegin);
            return this;
        }

        public ITweenData AddOnTweenUpdate(AnimateEvent onTweenUpdate) {
            this.onTweenUpdate.Add(onTweenUpdate);
            return this;
        }

        public ITweenData AddOnTweenLoopEnd(AnimateEvent onTweenLoopEnd) {
            this.onTweenLoopEnd.Add(onTweenLoopEnd);
            return this;
        }

        public ITweenData AddOnTweenEnd(AnimateEvent onTweenEnd) {
            this.onTweenEnd.Add(onTweenEnd);
            return this;
        }

        public ITweenData AddAnimation(IAnimation animation) {
            this.onTweenBegin.Add(animation.OnTweenBegin);
            this.onTweenLoopBegin.Add(animation.OnTweenLoopBegin);
            this.onTweenUpdate.Add(animation.OnTweenUpdate);
            this.onTweenLoopEnd.Add(animation.OnTweenLoopEnd);
            this.onTweenEnd.Add(animation.OnTweenEnd);
            return this;
        }

        public bool IsCompleted => this.hasEnded;

        public void Update(float deltaTime) {
            if (!this.hasBegan) {
                this.hasBegan = true;
                this.onTweenBegin.Invoke(this.proxy);
            }

            this.elapsedTime += deltaTime;

            float timeForLoops = this.time * this.elapsedLoops;
            float loopDelayForLoops = this.loopDelay * this.elapsedLoops;
            if (this.elapsedTime <= this.startDelay + timeForLoops + loopDelayForLoops) {
                return;
            }

            if (!this.hasLoopBegan) {
                this.hasLoopBegan = true;
                this.progress = 0;
                bool isLoopPairAndPingPong = this.elapsedLoops % 2 == 0 && this.loopType == LoopType.PingPong;
                this.evaluation = isLoopPairAndPingPong ? 0 : 1;
                this.onTweenLoopBegin.Invoke(this.proxy);
            }

            float normalizedTime = this.elapsedTime - (this.startDelay + this.elapsedLoops * this.loopDelay);

            uint currentLoopIndex = (uint) Mathf.FloorToInt(normalizedTime / this.time);

            if (this.elapsedLoops != currentLoopIndex) {
                this.progress = 1;
            } else {
                this.progress = normalizedTime % this.time / this.time;
            }

            this.evaluation = this.easeCurve?.Evaluate(this.progress) ?? this.progress;

            if (this.loopType == LoopType.PingPong) {
                this.evaluation = this.elapsedLoops % 2 == 0 ? this.evaluation : 1 - this.evaluation;
            }

            this.onTweenUpdate.Invoke(this.proxy);

            if (this.elapsedLoops != currentLoopIndex) {
                this.onTweenLoopEnd.Invoke(this.proxy);
                this.hasLoopBegan = false;
            }

            this.elapsedLoops = currentLoopIndex;

            if (this.elapsedLoops <= this.loopCount - 1) {
                return;
            }

            this.hasEnded = true;
            this.onTweenEnd.Invoke(this.proxy);
        }

    }

}