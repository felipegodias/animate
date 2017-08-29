using System.Collections.Generic;
using Animate.Core.Events;
using Animate.Core.Interfaces;
using Animate.Core.Proxies;

namespace Animate.Core.Concretes {

    internal sealed class TweenRuntime : ITweenData, ITweenRuntime {

        private readonly IList<OnTweenBegin> onTweenBegins;

        private readonly IList<OnTweenEnd> onTweenEnds;

        private readonly IList<OnTweenUpdate> onTweenUpdates;

        private readonly ITween proxy;

        private bool isCompleted;

        private float time;

        public TweenRuntime() {
            this.onTweenBegins = new List<OnTweenBegin>();
            this.onTweenUpdates = new List<OnTweenUpdate>();
            this.onTweenEnds = new List<OnTweenEnd>();
            this.proxy = new TweenProxy(this);
        }

        public ITweenData AddOnTweenBegin(OnTweenBegin onTweenBegin) {
            this.onTweenBegins.Add(onTweenBegin);
            return this;
        }

        public ITweenData AddOnTweenUpdate(OnTweenUpdate onTweenUpdate) {
            this.onTweenUpdates.Add(onTweenUpdate);
            return this;
        }

        public ITweenData AddOnTweenEnd(OnTweenEnd onTweenEnd) {
            this.onTweenEnds.Add(onTweenEnd);
            return this;
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