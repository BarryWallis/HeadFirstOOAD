using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystemFramework
{
    public class Board
    {
        private int width;
        private int height;
        private Tile[][] tiles;

        /// <summary>
        /// Create a new instance of a game board.
        /// </summary>
        /// <param name="width">The number of tiles in the width of the board.</param>
        /// <param name="height">the number of tiles in the height of the board.</param>
        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            Initialize();
        }

        /// <summary>
        /// Initialize the jagged array of tiles.
        /// </summary>
        private void Initialize()
        {
            tiles = new Tile[width][];
            for (int x = 0; x < width; x++)
            {
                tiles[x] = new Tile[height];
                for (int y = 0; y < height; y++)
                {
                    tiles[x][y] = new Tile();
                }
            }
        }

        /// <summary>
        /// Return the tile at the given location on the game board.
        /// </summary>
        /// <param name="column">1-based x-coordinate of the tile's location.</param>
        /// <param name="row">1-based y-coordinate of the tile's location.</param>
        /// <returns></returns>
        public Tile GetTile(int column, int row)
        {
            if (column < 1 || column > width)
                throw new ArgumentOutOfRangeException(nameof(column), "x not witin game board width");
            if (row < 1 || row > height)
                throw new ArgumentOutOfRangeException(nameof(row), "y not within game board height");

            return tiles[column - 1][row - 1];
        }

        /// <summary>
        /// Add the unit to the tile at the given location on the game board.
        /// </summary>
        /// <param name="unit">The unit to add.</param>
        /// <param name="column">1-based x-coordinate of the tile's location.</param>
        /// <param name="row">1-based y-coordinate of the tile's location.</param>
        /// <returns></returns>
        public void AddUnit(Unit unit, int column, int row)
        {
            if (column < 1 || column > width)
                throw new ArgumentOutOfRangeException(nameof(column), "x not witin game board width");
            if (row < 1 || row > height)
                throw new ArgumentOutOfRangeException(nameof(row), "y not within game board height");

            GetTile(column, row).Add(unit);
        }

        /// <summary>
        /// Remove the unit from the tile at the given location on the game board.
        /// </summary>
        /// <param name="unit">The unit to remove.</param>
        /// <param name="column">1-based x-coordinate of the tile's location.</param>
        /// <param name="row">1-based y-coordinate of the tile's location.</param>
        /// <returns></returns>
        public void RemoveUnit(Unit unit, int column, int row)
        {
            if (column < 1 || column > width)
                throw new ArgumentOutOfRangeException(nameof(column), "x not witin game board width");
            if (row < 1 || row > height)
                throw new ArgumentOutOfRangeException(nameof(row), "y not within game board height");

            GetTile(column, row).Remove(unit);
        }

        /// <summary>
        /// Remove all the units from the tile at the given location on the game board.
        /// </summary>
        /// <param name="column">1-based x-coordinate of the tile's location.</param>
        /// <param name="row">1-based y-coordinate of the tile's location.</param>
        /// <returns></returns>
        public void RemoveUnits(int column, int row)
        {
            if (column < 1 || column > width)
                throw new ArgumentOutOfRangeException(nameof(column), "x not witin game board width");
            if (row < 1 || row > height)
                throw new ArgumentOutOfRangeException(nameof(row), "y not within game board height");

            GetTile(column, row).RemoveUnits();
        }

        public ICollection<Unit> GetUnits(int column, int row)
        {
            if (column < 1 || column > width)
                throw new ArgumentOutOfRangeException(nameof(column), "x not witin game board width");
            if (row < 1 || row > height)
                throw new ArgumentOutOfRangeException(nameof(row), "y not within game board height");

            return GetTile(column, row).Units;
        }
    }
}
