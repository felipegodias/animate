using System.Collections.Generic;
using System.Reflection;
using Animate.Core.Internal.Interfaces;
using UnityEngine;

namespace Animate.Core.Internal.Controllers {

    [Obfuscation(Feature = "Apply to member Update when method: renaming", Exclude = true)]
    [Obfuscation(Feature = "Apply to member LateUpdate when method: renaming", Exclude = true)]
    internal sealed class TweenManager : MonoBehaviour, ITweenManager {

        private readonly LinkedList<ITweenBehaviour> runningList = new LinkedList<ITweenBehaviour>();

        private readonly Queue<ITweenBehaviour> waitingQueue = new Queue<ITweenBehaviour>();

        public void Add(ITweenBehaviour tweenBehaviour) {
            this.waitingQueue.Enqueue(tweenBehaviour);
        }

        private void Update() {
            float deltaTime = Time.deltaTime;
            LinkedListNode<ITweenBehaviour> iterator = this.runningList.First;
            while (iterator != null) {
                ITweenBehaviour tweenBehaviour = iterator.Value;
                tweenBehaviour.StartUpdate();
                tweenBehaviour.Update(deltaTime);
                tweenBehaviour.FinishUpdate();
                if (tweenBehaviour.DestroyFlag) {
                    LinkedListNode<ITweenBehaviour> nodeToRemove = iterator;
                    this.runningList.Remove(nodeToRemove);
                    iterator = iterator.Next;
                    continue;
                }

                iterator = iterator.Next;
            }
        }

        private void LateUpdate() {
            while (this.waitingQueue.Count > 0) {
                ITweenBehaviour tweenBehaviour = this.waitingQueue.Dequeue();
                this.runningList.AddLast(tweenBehaviour);
            }
        }

    }

}