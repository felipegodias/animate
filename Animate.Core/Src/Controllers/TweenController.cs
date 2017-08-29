using System.Collections.Generic;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.Core.Controllers {

    internal sealed class TweenController : MonoBehaviour, ITweenController {

        private readonly LinkedList<ITweenRuntime> runningList = new LinkedList<ITweenRuntime>();

        private readonly Queue<ITweenRuntime> waitingQueue = new Queue<ITweenRuntime>();

        public void Add(ITweenRuntime tweenRuntime) {
            this.waitingQueue.Enqueue(tweenRuntime);
        }

        private void Update() {
            float deltaTime = Time.deltaTime;
            LinkedListNode<ITweenRuntime> iterator = this.runningList.First;
            while (iterator != null) {
                ITweenRuntime tweenRuntime = iterator.Value;
                tweenRuntime.Update(deltaTime);
                if (tweenRuntime.IsCompleted) {
                    LinkedListNode<ITweenRuntime> nodeToRemove = iterator;
                    this.runningList.Remove(nodeToRemove);
                    iterator = iterator.Next;
                    continue;
                }

                iterator = iterator.Next;
            }
        }

        private void LateUpdate() {
            while (this.waitingQueue.Count > 0) {
                ITweenRuntime tweenRuntime = this.waitingQueue.Dequeue();
                this.runningList.AddLast(tweenRuntime);
            }
        }

    }

}