using System;
using System.Collections.Generic;
using System.Data;
using cycle.Game.Casting;
using cycle.Game.Services;


namespace cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : TheAction
    {
        private bool isGameOver = false;
        private int counter = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        // private void HandleFoodCollisions(Cast cast)
        // {
        //     Cycle1 snake = (Cycle1)cast.GetFirstActor("snake");
        //     Score score = (Score)cast.GetFirstActor("score");
        //     Food food = (Food)cast.GetFirstActor("food");
            
        //     if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake.GrowTail(points);
        //         score.AddPoints(points);
        //         food.Reset();
        //     }
        // }

        private void HandleGrowth(Cast cast)
        {
            Cycle1 cycle1 = (Cycle1)cast.GetFirstActor("cycle1");
            Cycle2 cycle2 = (Cycle2)cast.GetFirstActor("cycle2");
            // Score score1 = (Score)cast.GetFirstActor("score1");
            // Score score2 = (Score)cast.GetFirstActor("score2");
            counter = counter +1;
            if (counter % 15 == 0){
                cycle1.GrowTail(1);
                cycle2.GrowTail(1);
                // score1.AddPointsOne(1);
                // score2.AddPointsTwo(1);
            }

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle1 cycle1 = (Cycle1)cast.GetFirstActor("cycle1");
            Actor head1 = cycle1.GetHead();
            List<Actor> body1 = cycle1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            Cycle2 cycle2 = (Cycle2)cast.GetFirstActor("cycle2");
            Actor head2 = cycle2.GetHead();
            List<Actor> body2 = cycle2.GetBody();
            Score score2 = (Score)cast.GetFirstActor("score2");


            foreach (Actor segment1 in body1)
            {
                foreach (Actor segment2 in body2)
                {
                    if (segment1.GetPosition().Equals(head1.GetPosition()) || head1.GetPosition().Equals(segment2.GetPosition()))
                    {
                        isGameOver = true;
                        score2.AddPointsTwo(1);
                    }
                    if (segment2.GetPosition().Equals(head2.GetPosition()) || segment1.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        score1.AddPointsOne(1);
                    }
                }
            }

            // foreach (Actor segment2 in body2)
            // {
            //     if (segment2.GetPosition().Equals(head2.GetPosition()) || segment2.GetPosition().Equals(head1.GetPosition()))
            //     {
            //         isGameOver = true;
            //     }
            // }

        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Cycle1 cycle1 = (Cycle1)cast.GetFirstActor("cycle1");
                List<Actor> segments1 = cycle1.GetSegments();

                Cycle2 cycle2 = (Cycle2)cast.GetFirstActor("cycle2");
                List<Actor> segments2 = cycle2.GetSegments();
               
                // Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }

    }
}