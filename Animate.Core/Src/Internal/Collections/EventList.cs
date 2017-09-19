using System;
using System.Collections;
using System.Collections.Generic;
using Animate.Core.Events;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Core.Internal.Collections {

    internal sealed class EventList : IEventList {

        private readonly ICollection<AnimateEvent> collection;

        public EventList() {
            this.collection = new LinkedList<AnimateEvent>();
        }

        #region IEventList Members

        IEnumerator IEnumerable.GetEnumerator() {
            return this.collection.GetEnumerator();
        }

        public IEnumerator<AnimateEvent> GetEnumerator() {
            return this.collection.GetEnumerator();
        }

        public void Add(AnimateEvent item) {
            this.collection.Add(item);
        }

        public void Invoke(ITweenRuntime tweenRuntime) {
            foreach (AnimateEvent animateEvent in this.collection) {
                try {
                    animateEvent.Invoke(tweenRuntime);
                } catch (Exception e) {
                    Debug.LogException(e);
                }
            }
        }

        #endregion

    }

}