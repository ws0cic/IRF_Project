﻿namespace Labirintius
{
    public class Maze
    {
        public char[][] Value { get; set; }
        public int Dimension { get; set; }
        public int?[][] Solution { get; set; }
        public bool IsResoluble { get; set; }
        public int? Shortest { get; set; }
    }
}