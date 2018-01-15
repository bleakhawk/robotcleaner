using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCleaner.Library
{
    public class RobotProcessor
    {
        public static int Clean(int startX, int startY, List<KeyValuePair<char, int>> directions)
        {
            List<KeyValuePair<int, int>> uniquePositions = new List<KeyValuePair<int, int>>();

            uniquePositions.Add(new KeyValuePair<int, int>(startX, startY));
            var currentXPosition = startX;
            var currentYPosition = startY;

            foreach (KeyValuePair<char, int> direction in directions)
            {
                if (direction.Value != 0)
                {
                    if (direction.Key == 'E' || direction.Key == 'W')
                    {
                        for (int i = 0; i < direction.Value; i++)
                        {
                            if (direction.Key == 'E')
                            {
                                currentXPosition++;
                            }
                            else
                            {
                                currentXPosition--;
                            }

                            CheckUniqueAndAddPosition(currentXPosition, currentYPosition, uniquePositions);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < direction.Value; i++)
                        {
                            if (direction.Key == 'N')
                            {
                                currentYPosition++;
                            }
                            else
                            {
                                currentYPosition--;
                            }

                            CheckUniqueAndAddPosition(currentXPosition, currentYPosition, uniquePositions);
                        }
                    }
                }


            }

            return uniquePositions.Count;
        }

        public static List<KeyValuePair<int, int>> CheckUniqueAndAddPosition(int positionX, int positionY, List<KeyValuePair<int, int>> uniquePositions)
        {
            var alreadyExists = uniquePositions
                .Where(x => x.Key == positionX)
                .Any(y => y.Value == positionY);

            if(!alreadyExists)
            {
                uniquePositions.Add(new KeyValuePair<int, int>(positionX, positionY));
            }

            return uniquePositions;
        }
    }
}
