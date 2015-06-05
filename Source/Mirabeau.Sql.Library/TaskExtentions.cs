using System.Threading.Tasks;

namespace Mirabeau.Sql.Library
{
    /// <summary>
    /// Extention methods for <see cref="Task"/>
    /// </summary>
    public static class TaskExtentions
    {
        /// <summary>
        /// Gets the result from a task.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static T TaskResult<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}