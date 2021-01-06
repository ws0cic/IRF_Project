namespace Labirintius
{
    public static class Finder
    {
        public static int PathFinder(Maze maze)
        {
            char wall = 'W';
            int dimension = maze.Dimension;
            char[][] m = maze.Value;
            int?[][] w = new int?[dimension][];
            for (int i = 0; i < dimension; i++)
            {
                w[i] = new int?[dimension];
            }
            w[0][0] = 0;
            for (int i = 0; i < (dimension * dimension); i++)
            {
                bool was = false;
                for (int x = 0; x < dimension; x++)
                    for (int y = 0; y < dimension; y++)
                    {
                        if (w[x][y] == i)
                        {
                            was = true;
                            if (x - 1 >= 0 && !w[x - 1][y].HasValue)
                            {
                                if (m[x - 1][y] == wall)
                                    w[x - 1][y] = -1;
                                else
                                    w[x - 1][y] = i + 1;
                            }
                            if (y - 1 >= 0 && !w[x][y - 1].HasValue)
                            {
                                if (m[x][y - 1] == wall)
                                    w[x][y - 1] = -1;
                                else
                                    w[x][y - 1] = i + 1;
                            }
                            if (x + 1 < dimension && !w[x + 1][y].HasValue)
                            {
                                if (m[x + 1][y] == wall)
                                    w[x + 1][y] = -1;
                                else
                                    w[x + 1][y] = i + 1;
                            }
                            if (y + 1 < dimension && !w[x][y + 1].HasValue)
                            {
                                if (m[x][y + 1] == wall)
                                    w[x][y + 1] = -1;
                                else
                                    w[x][y + 1] = i + 1;
                            }
                        }
                    }
                if (!was)
                {
                    break;
                }
            }
            var end = w[dimension - 1][dimension - 1];

            if (end.HasValue && end.Value >= 0)
                return end.Value;
            else
                return -1;
        }
    }
}
