using System.Collections.Generic;
using System.Reflection;
using Animate.Core.Internal.Interfaces;
using UnityEngine;

namespace Animate.Core.Internal.Controllers {

    [Obfuscation(Feature = "Apply to member Update when method: renaming", Exclude = true)]
    [Obfuscation(Feature = "Apply to member LateUpdate when method: renaming", Exclude = true)]
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