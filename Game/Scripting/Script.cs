using System.Collections.Generic;


namespace cycle.Game.Scripting
{
    /// <summary>
    /// <para>A collection of actions.</para>
    /// <para>
    /// The responsibility of a cast is to keep track of a collection of actions. It has methods for 
    /// adding, removing and getting them by a group name.
    /// </para>
    /// </summary>
    public class Script
    {
        private Dictionary<string, List<TheAction>> actions = new Dictionary<string, List<TheAction>>();

        /// <summary>
        /// Constructs a new instance of Script.
        /// </summary>
        public Script()
        {
        }

        /// <summary>
        /// Adds the given action to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to add.</param>
        public void AddAction(string group, TheAction action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<TheAction>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        /// <summary>
        /// Gets the actions in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actions.</returns>
        public List<TheAction> GetActions(string group)
        {
            List<TheAction> results = new List<TheAction>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }

        /// <summary>
        /// Removes the given action from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to remove.</param>
        public void RemoveActor(string group, TheAction action)
        {
            if (actions.ContainsKey(group))
            {
                actions[group].Remove(action);
            }
        }

    }
}