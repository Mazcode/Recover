using System;
using System.Collections.Generic;

namespace CFIOThread
{

    /// <summary>
    /// 为 <see cref="Queue{T}"/> 提供扩展方法，以模拟 .NET Core 2.0+ 中的 TryDequeue/TryPeek 行为。
    /// 主要用于在 .NET Framework 4.8 及更早版本中避免使用异常控制流程或竞态条件检查。
    /// </summary>
    public static class QueueExtensions
    {
        /// <summary>
        /// 尝试从队列的开头移除并返回对象。
        /// <para>
        /// 与直接调用 <see cref="Queue{T}.Dequeue"/> 不同，此方法在队列为空时不会抛出异常，
        /// 而是返回 <see langword="false"/>。这使得它在单线程检查或多线程配合锁使用时更加安全和高效。
        /// </para>
        /// </summary>
        /// <typeparam name="T">队列中元素的类型。</typeparam>
        /// <param name="queue">目标队列实例。</param>
        /// <param name="result">
        /// 当此方法返回 <see langword="true"/> 时，包含从队列中移除的元素；
        /// 如果队列为空（返回 <see langword="false"/>），则包含 <typeparamref name="T"/> 的默认值 (default)。
        /// </param>
        /// <returns>
        /// 如果成功从队列中移除并获取了元素，则为 <see langword="true"/>；
        /// 如果队列为空，无法获取元素，则为 <see langword="false"/>。
        /// </returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="queue"/> 为 <see langword="null"/> 时抛出。</exception>
        /// <remarks>
        /// <para><strong>线程安全性：</strong> 此方法本身不是线程安全的。</para>
        /// <para>
        /// 虽然它原子地检查了 Count 并执行了 Dequeue，但在多线程环境下，
        /// 如果多个线程同时操作同一个 <see cref="Queue{T}"/> 实例，仍需外部同步机制（如 <see langword="lock"/>）。
        /// 对于高并发场景，建议直接使用 <see cref="System.Collections.Concurrent.ConcurrentQueue{T}"/>。
        /// </para>
        /// </remarks>
        public static bool TryDequeue<T>(this Queue<T> queue, out T result)
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));

            if (queue.Count > 0)
            {
                result = queue.Dequeue();
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// 尝试返回队列开头的对象但不将其移除。
        /// <para>
        /// 与直接调用 <see cref="Queue{T}.Peek"/> 不同，此方法在队列为空时不会抛出异常，
        /// 而是返回 <see langword="false"/>。
        /// </para>
        /// </summary>
        /// <typeparam name="T">队列中元素的类型。</typeparam>
        /// <param name="queue">目标队列实例。</param>
        /// <param name="result">
        /// 当此方法返回 <see langword="true"/> 时，包含队列开头的元素（未移除）；
        /// 如果队列为空，则包含 <typeparamref name="T"/> 的默认值。
        /// </param>
        /// <returns>
        /// 如果成功获取了元素（队列非空），则为 <see langword="true"/>；
        /// 如果队列为空，则为 <see langword="false"/>。
        /// </returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="queue"/> 为 <see langword="null"/> 时抛出。</exception>
        /// <remarks>
        /// <para><strong>线程安全性：</strong> 此方法本身不是线程安全的。</para>
        /// <para>
        /// 在多线程环境中，即使 <see cref="TryPeek"/> 返回了元素，该元素也可能在随后被其他线程移除。
        /// 请务必配合锁 (<see langword="lock"/>) 使用，或使用 <see cref="System.Collections.Concurrent.ConcurrentQueue{T}"/>。
        /// </para>
        /// </remarks>
        public static bool TryPeek<T>(this Queue<T> queue, out T result)
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));

            if (queue.Count > 0)
            {
                result = queue.Peek();
                return true;
            }

            result = default(T);
            return false;
        }
    }
}
