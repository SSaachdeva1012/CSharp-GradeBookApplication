﻿using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var percent = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();

            if (grades[percent - 1] <= averageGrade)
            {
                return 'A';
            }

            if ((grades[(percent * 2 )- 1]) <= averageGrade)
            {
                return 'B';
            }

            if ((grades[(percent * 3) - 1]) <= averageGrade)
            {
                return 'C';
            }

            if ((grades[(percent * 4) - 1]) <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }


        }


    }
}
