/**
* Point – Point constructor plus getters and override tostring method
*
* <pre>
*
* Assignment: #3
* Course: ADEV-3001
* Date Created: November 2, 2017
* 
* Revision Log
* Who        When       Reason
* --------- ---------- ----------------------------------
*
* </pre>
*
* @author Matt Scott
* @version 1.0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    class Point : IComparable<Point>
    {
        const string STUDENT = "Matt Scott 0286401";

        private int row;
        private int column;
        private int parentRow;
        private int parentColumn;

        /// <summary>
        /// Row and column Point constructor
        /// </summary>
        /// <param name="row">An int value of the row</param>
        /// <param name="column">An int value of the column</param>
        public Point(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        /// <summary>
        /// All arg Point constructor
        /// </summary>
        /// <param name="row">An int value of the row</param>
        /// <param name="column">An int value of the column</param>
        /// <param name="parentRow">An int value of the parentRow</param>
        /// <param name="parentColumn">An int value of the parentColumn</param>
        public Point(int row, int column, int parentRow, int parentColumn)
        {
            this.row = row;
            this.column = column;
            this.parentRow = parentRow;
            this.parentColumn = parentColumn;
        }

        /// <summary>
        /// Returns the row of the point
        /// </summary>
        /// <returns>The int value of the row</returns>
        public int GetRow()
        {
            return row;
        }

        /// <summary>
        /// Returns the column of the point
        /// </summary>
        /// <returns>The int value of the column</returns>
        public int GetColumn()
        {
            return column;
        }

        /// <summary>
        /// Returns the parentRow of the point
        /// </summary>
        /// <returns>The int value of the parentRow</returns>
        public int GetParentRow()
        {
            return parentRow;
        }

        /// <summary>
        /// Sets the value of the parentRow of the point
        /// </summary>
        /// <param name="parentRow">Int value of the parent row</param>
        public void SetParentRow(int parentRow)
        {
            this.parentRow = parentRow;
        }

        /// <summary>
        /// Returns the parentColumn of the point
        /// </summary>
        /// <returns>Int value of the parentColumn</returns>
        public int GetParentColumn()
        {
            return parentColumn;
        }

        /// <summary>
        /// Sets the value of the parentColumn of the point
        /// </summary>
        /// <param name="parentColumn">Int value of the parentColumn</param>
        public void SetParentColumn(int parentColumn)
        {
            this.parentColumn = parentColumn;
        }

        /// <summary>
        /// Overrides the ToString method for a point
        /// </summary>
        /// <returns>The row and column string</returns>
        public override string ToString()
        {
            return string.Format("[{0},{1}]", row, column);
        }

        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }
    }
}
