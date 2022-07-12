using System;


namespace cycle.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points1 = 0;
        private int points2 = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {
            AddPointsOne(0);
            AddPointsTwo(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsOne(int points1)
        {
            this.points1 += points1;
            SetText($"Player 1 Score: {this.points1}");
        }

        public void AddPointsTwo(int points2)
        {
            this.points2 += points2;
            SetText($"Player 2 Score: {this.points2}");
        }
    }
}