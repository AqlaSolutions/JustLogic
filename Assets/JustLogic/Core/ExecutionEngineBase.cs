using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace JustLogic.Core
{
    /// <tocexclude />
    [Serializable]
    public abstract class ExecutionEngineBase
    {
        /// <summary>
        /// Units tree
        /// </summary>
        public JLAction Tree;

        /// <summary>
        /// Holds variables and temporary data
        /// </summary>
        public ExecutionContext Context = new ExecutionContext();

        /// <summary>
        /// Should be called after the parameterless constructor
        /// </summary>
        public void Initialize(ReentranceMode reentrance)
        {
            if (Context == null)
                Context = new ExecutionContext();
            Reentrance = reentrance;
        }

        /// <summary>
        /// Specifies what to do when an execution is being invoking when another execution is already in its execution process
        /// </summary>
        [Serializable]
        public enum ReentranceMode
        {
            /// <summary>
            /// Current execution will be cancelled.
            /// </summary>
            Interrupt = 0,
            /// <summary>
            /// Will be enqueued to be executed later. Check it with <see cref="ExecutionEngineBase.HasStartedCoroutines"/>
            /// </summary>
            Queue,
            /// <summary>
            /// The invokation will be dropped and not executed at all.
            /// </summary>
            Drop,
            /// <summary>
            /// The invokation will be queued but in a seperate coroutine.
            /// </summary>
            /// <remarks>
            /// You can do multiple runs of one script in "parallel" coroutines. In fact they will run in the same thread but in seperate coroutine instances. Note that it doesn't affect anything if you don't use "Wait for..." in a script. 
            /// </remarks>
            Parallel
        }

        /// <summary>
        /// Specifies what to do when an execution is being invoking when the engine already is in its execution process
        /// </summary>
        /// <remarks>See <see cref="ReentranceMode"/> for details</remarks>
        public ReentranceMode Reentrance;

        /// <summary>
        /// An execution start arguments
        /// </summary>
        /// <tocexclude />
        public struct StartArguments
        {
            public EventData CurrentEvent { get; private set; }

            public StartArguments(EventData currentEvent)
                : this()
            {
                CurrentEvent = currentEvent;
            }
        }

        [NonSerialized]
        readonly Queue<StartArguments> _queuedStarts = new Queue<StartArguments>();

        /// <summary>
        /// Starts or enqueues an execution
        /// </summary>
        public void Start(StartArguments arguments)
        {
            if (!Tree || (((_coroutines.Count != 0) || (_queuedStarts.Count != 0)) && (Reentrance != ReentranceMode.Parallel)))
            {
                if (Reentrance == ReentranceMode.Queue)
                    _queuedStarts.Enqueue(arguments);
                else if (Reentrance == ReentranceMode.Interrupt)
                {
                    _queuedStarts.Clear();
                    _coroutines.Clear();
                    StartNow(arguments);
                }
            }
            else StartNow(arguments);

        }

        /// <summary>
        /// Stops all parallel executions which are stored as coroutines
        /// </summary>
        public void StopAllCoroutines()
        {
            _coroutines.Clear();
        }

        /// <summary>
        /// Cancels all queued with <see cref="ReentranceMode.Queue"/> execution starts
        /// </summary>
        public void ClearQueuedStarts()
        {
            _queuedStarts.Clear();
        }

        /// <summary>
        /// Returns true if there are started parallel executions which are stored as coroutines
        /// </summary>
        /// <returns></returns>
        public bool HasStartedCoroutines()
        {
            return _coroutines.Count != 0;
        }

        /// <summary>
        /// Returns true if there are queued with <see cref="ReentranceMode.Queue"/> execution starts
        /// </summary>
        public bool HasQueuedStarts()
        {
            return _queuedStarts.Count != 0;
        }

        private void StartNow(StartArguments arguments)
        {
            Context.Variables = null;
            Context.CurrentEvent = arguments.CurrentEvent;
            IEnumerator<YieldMode> e = Tree.ExecuteSafe(Context);
            if (e.SafeMoveNext())
                switch (e.Current)
                {
#if !JUSTLOGIC_FREE

                    case YieldMode.YieldForNextFixedUpdate:
                    case YieldMode.YieldForNextUpdate:
                        _coroutines.AddLast(new CoroutineData(e, Context.Variables != null ? new Dictionary<string, Variable>(Context.Variables) : null, Context.CurrentEvent));
                        break;
#endif

                    case YieldMode.None:
#if !JUSTLOGIC_FREE

                    case YieldMode.Return:
#endif

                        break;
                    default:
                        throw new InvalidOperationException();
                }
        }

        struct CoroutineData
        {
            public readonly Dictionary<string, Variable> Variables;
            public readonly EventData CurrentEvent;
            public readonly IEnumerator<YieldMode> Enumerator;

            public CoroutineData(IEnumerator<YieldMode> enumerator, Dictionary<string, Variable> variables, EventData currentEvent)
            {
                Variables = variables;
                CurrentEvent = currentEvent;
                Enumerator = enumerator;
            }
        }
        [NonSerialized]
        readonly LinkedList<CoroutineData> _coroutines = new LinkedList<CoroutineData>();

        /// <summary>
        /// The owner of the <see cref="ExecutionEngine"/> instance should call this method every frame
        /// </summary>
        public void Continue(bool fixedUpdate)
        {
            if (_coroutines.Count != 0)
            {
                var el = _coroutines.First;
                while (el != null)
                {
                    var next = el.Next;
                    var coroutine = el.Value;
#if !JUSTLOGIC_FREE
                    if ((coroutine.Enumerator.Current == YieldMode.YieldForNextFixedUpdate) == fixedUpdate)
#else
                    if (!fixedUpdate)
#endif

                    {
                        Context.Variables = coroutine.Variables;
                        Context.CurrentEvent = coroutine.CurrentEvent;
                        if (coroutine.Enumerator.SafeMoveNext())
                        {
                            switch (el.Value.Enumerator.Current)
                            {
#if !JUSTLOGIC_FREE

                                case YieldMode.YieldForNextFixedUpdate:
                                case YieldMode.YieldForNextUpdate:
                                    break;
#endif

                                case YieldMode.None:
#if !JUSTLOGIC_FREE
                                case YieldMode.Return:
#endif

                                    el.Value.Enumerator.Dispose();
                                    _coroutines.Remove(el);
                                    break;
                                default:
                                    _coroutines.Remove(el);
                                    throw new InvalidOperationException();
                            }
                        }
                        else _coroutines.Remove(el);
                    }

                    el = next;
                }
            }
            else
            {
                if (_queuedStarts.Count != 0)
                    StartNow(_queuedStarts.Dequeue());
            }
        }
    }
}