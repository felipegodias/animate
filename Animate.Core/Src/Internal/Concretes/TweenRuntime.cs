using System;
using Animate.Core.Events;
using Animate.Core.Interfaces;
using Animate.Core.Internal.Collections;
using Animate.Core.Internal.Interfaces;
using Animate.Core.Internal.Proxies;
using UnityEngine;

namespace Animate.Core.Internal.Concretes {

    internal sealed class TweenRuntime : ITween, ITweenData, ITweenRuntime {

        private const string kTimeArgOutOfRangeExceptionMessage = "Time argument is out of range. The value should be higher than zero.";

        private const string kHasBeganExceptionMessage = "The tween can not be modified after it has started.";

        private const string kIsUpdatingExceptionMessage = "Play, Pause, Stop and Restart methods can not be called inside a event callback.";

        private readonly ITweenController tweenController;

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

        private bool isPlaying;

        private bool hasBegan;

        private bool hasLoopBegan;

        private bool hasEnded;

        private bool isUpdating;

        public TweenRuntime(ITweenController tweenController) {
            this.tweenController = tweenController;
            this.isPlaying = true;
            this.onTweenBegin = new EventList();
            this.onTweenLoopBegin = new EventList();
            this.onTweenUpdate = new EventList();
            this.onTweenLoopEnd = new EventList();
            this.onTweenEnd = new EventList();
            this.proxy = new TweenProxy(this);
        }

        public float Progress => this.progress;

        public float Evaluation => this.evaluation;

        public bool IsPlaying => this.isPlaying;

        public bool IsPaused => !this.IsPlaying;

        public void Play() {
            this.AssertThatIsNotUpdating();
            this.isPlaying = true;
        }

        public void Pause() {
            this.AssertThatIsNotUpdating();
            this.isPlaying = false;
        }

        public void Stop() {
            this.AssertThatIsNotUpdating();
            this.Pause();
            this.hasBegan = false;
            this.hasLoopBegan = false;
            this.elapsedTime = 0;
            this.elapsedLoops = 0;
            this.progress = 0;
            this.evaluation = 0;
        }

        public void Restart() {
            this.AssertThatIsNotUpdating();
            this.Stop();
            this.Play();

            if (!this.hasEnded) {
                return;
            }

            this.hasEnded = false;
            this.tweenController.Add(this);
        }

        public float Time => this.time;

        public float StartDelay => this.startDelay;

        public float LoopDelay => this.loopDelay;

        public uint LoopCount => this.loopCount;

        public LoopType LoopType => this.loopType;

        public ITweenData SetTime(float time) {
            if (time < 0) {
                throw new ArgumentOutOfRangeException(nameof(time), time, kTimeArgOutOfRangeExceptionMessage);
            }
            this.AssertThatHasNotBegan();
            this.time = time;
            return this;
        }

        public ITweenData SetStartDelay(float startDelay) {
            this.AssertThatHasNotBegan();
            this.startDelay = startDelay;
            return this;
        }

        public ITweenData SetLoopDelay(float loopDelay) {
            this.AssertThatHasNotBegan();
            this.loopDelay = loopDelay;
            return this;
        }

        public ITweenData SetLoopCount(uint loopCount) {
            this.AssertThatHasNotBegan();
            this.loopCount = loopCount;
            return this;
        }

        public ITweenData SetLoopType(LoopType loopType) {
            this.AssertThatHasNotBegan();
            this.loopType = loopType;
            return this;
        }

        public ITweenData SetEaseCurve(IEaseCurve easeCurve) {
            if (easeCurve == null) {
                throw new ArgumentNullException(nameof(easeCurve));
            }
            this.AssertThatHasNotBegan();
            this.easeCurve = easeCurve;
            return this;
        }

        public ITweenData AddOnTweenBegin(AnimateEvent onTweenBegin) {
            if (onTweenBegin == null) {
                throw new ArgumentNullException(nameof(onTweenBegin));
            }
            this.AssertThatHasNotBegan();
            this.onTweenBegin.Add(onTweenBegin);
            return this;
        }

        public ITweenData AddOnTweenLoopBegin(AnimateEvent onTweenLoopBegin) {
            if (onTweenLoopBegin == null) {
                throw new ArgumentNullException(nameof(onTweenLoopBegin));
            }
            this.AssertThatHasNotBegan();
            this.onTweenLoopBegin.Add(onTweenLoopBegin);
            return this;
        }

        public ITweenData AddOnTweenUpdate(AnimateEvent onTweenUpdate) {
            if (onTweenUpdate == null) {
                throw new ArgumentNullException(nameof(onTweenUpdate));
            }
            this.AssertThatHasNotBegan();
            this.onTweenUpdate.Add(onTweenUpdate);
            return this;
        }

        public ITweenData AddOnTweenLoopEnd(AnimateEvent onTweenLoopEnd) {
            if (onTweenLoopEnd == null) {
                throw new ArgumentNullException(nameof(onTweenLoopEnd));
            }
            this.AssertThatHasNotBegan();
            this.onTweenLoopEnd.Add(onTweenLoopEnd);
            return this;
        }

        public ITweenData AddOnTweenEnd(AnimateEvent onTweenEnd) {
            if (onTweenEnd == null) {
                throw new ArgumentNullException(nameof(onTweenEnd));
            }
            this.AssertThatHasNotBegan();
            this.onTweenEnd.Add(onTweenEnd);
            return this;
        }

        public ITweenData AddAnimation(IAnimation animation) {
            if (animation == null) {
                throw new ArgumentNullException(nameof(animation));
            }
            this.AssertThatHasNotBegan();
            this.onTweenBegin.Add(animation.OnTweenBegin);
            this.onTweenLoopBegin.Add(animation.OnTweenLoopBegin);
            this.onTweenUpdate.Add(animation.OnTweenUpdate);
            this.onTweenLoopEnd.Add(animation.OnTweenLoopEnd);
            this.onTweenEnd.Add(animation.OnTweenEnd);
            return this;
        }

        public bool IsCompleted => this.hasEnded;

        public void StartUpdate() {
            this.isUpdating = true;
        }

        public void FinishUpdate() {
            this.isUpdating = false;
        }

        public void Update(float deltaTime) {
            if (!this.isPlaying) {
                return;
            }

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

        private void AssertThatHasNotBegan() {
            if (this.hasBegan) {
                throw new InvalidOperationException(kHasBeganExceptionMessage);
            }
        }

        private void AssertThatIsNotUpdating() {
            if (this.isUpdating) {
                throw new InvalidOperationException(kIsUpdatingExceptionMessage);
            }
        }

    }

}