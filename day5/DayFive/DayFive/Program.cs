﻿using System;
using System.Collections.Generic;

namespace DayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            Q13();
            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        static void Q13()
        {
            var icc = new IntCodeCompiler("Q13", new List<long> { 1, 380, 379, 385, 1008, 2719, 351522, 381, 1005, 381, 12, 99, 109, 2720, 1102, 1, 0, 383, 1101, 0, 0, 382, 20102, 1, 382, 1, 21002, 383, 1, 2, 21101, 37, 0, 0, 1105, 1, 578, 4, 382, 4, 383, 204, 1, 1001, 382, 1, 382, 1007, 382, 40, 381, 1005, 381, 22, 1001, 383, 1, 383, 1007, 383, 26, 381, 1005, 381, 18, 1006, 385, 69, 99, 104, -1, 104, 0, 4, 386, 3, 384, 1007, 384, 0, 381, 1005, 381, 94, 107, 0, 384, 381, 1005, 381, 108, 1106, 0, 161, 107, 1, 392, 381, 1006, 381, 161, 1102, 1, -1, 384, 1105, 1, 119, 1007, 392, 38, 381, 1006, 381, 161, 1102, 1, 1, 384, 21002, 392, 1, 1, 21101, 24, 0, 2, 21101, 0, 0, 3, 21102, 1, 138, 0, 1105, 1, 549, 1, 392, 384, 392, 20102, 1, 392, 1, 21101, 0, 24, 2, 21102, 1, 3, 3, 21101, 0, 161, 0, 1105, 1, 549, 1101, 0, 0, 384, 20001, 388, 390, 1, 21001, 389, 0, 2, 21102, 1, 180, 0, 1106, 0, 578, 1206, 1, 213, 1208, 1, 2, 381, 1006, 381, 205, 20001, 388, 390, 1, 21001, 389, 0, 2, 21101, 205, 0, 0, 1106, 0, 393, 1002, 390, -1, 390, 1101, 1, 0, 384, 20102, 1, 388, 1, 20001, 389, 391, 2, 21101, 0, 228, 0, 1105, 1, 578, 1206, 1, 261, 1208, 1, 2, 381, 1006, 381, 253, 21002, 388, 1, 1, 20001, 389, 391, 2, 21102, 253, 1, 0, 1106, 0, 393, 1002, 391, -1, 391, 1101, 0, 1, 384, 1005, 384, 161, 20001, 388, 390, 1, 20001, 389, 391, 2, 21102, 1, 279, 0, 1106, 0, 578, 1206, 1, 316, 1208, 1, 2, 381, 1006, 381, 304, 20001, 388, 390, 1, 20001, 389, 391, 2, 21101, 304, 0, 0, 1106, 0, 393, 1002, 390, -1, 390, 1002, 391, -1, 391, 1101, 1, 0, 384, 1005, 384, 161, 21001, 388, 0, 1, 21002, 389, 1, 2, 21102, 0, 1, 3, 21102, 338, 1, 0, 1106, 0, 549, 1, 388, 390, 388, 1, 389, 391, 389, 21001, 388, 0, 1, 20101, 0, 389, 2, 21101, 4, 0, 3, 21101, 365, 0, 0, 1106, 0, 549, 1007, 389, 25, 381, 1005, 381, 75, 104, -1, 104, 0, 104, 0, 99, 0, 1, 0, 0, 0, 0, 0, 0, 298, 18, 21, 1, 1, 20, 109, 3, 22101, 0, -2, 1, 22101, 0, -1, 2, 21102, 1, 0, 3, 21102, 414, 1, 0, 1106, 0, 549, 21202, -2, 1, 1, 22101, 0, -1, 2, 21101, 429, 0, 0, 1106, 0, 601, 2101, 0, 1, 435, 1, 386, 0, 386, 104, -1, 104, 0, 4, 386, 1001, 387, -1, 387, 1005, 387, 451, 99, 109, -3, 2105, 1, 0, 109, 8, 22202, -7, -6, -3, 22201, -3, -5, -3, 21202, -4, 64, -2, 2207, -3, -2, 381, 1005, 381, 492, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 481, 21202, -4, 8, -2, 2207, -3, -2, 381, 1005, 381, 518, 21202, -2, -1, -1, 22201, -3, -1, -3, 2207, -3, -2, 381, 1006, 381, 507, 2207, -3, -4, 381, 1005, 381, 540, 21202, -4, -1, -1, 22201, -3, -1, -3, 2207, -3, -4, 381, 1006, 381, 529, 21201, -3, 0, -7, 109, -8, 2106, 0, 0, 109, 4, 1202, -2, 40, 566, 201, -3, 566, 566, 101, 639, 566, 566, 1201, -1, 0, 0, 204, -3, 204, -2, 204, -1, 109, -4, 2105, 1, 0, 109, 3, 1202, -1, 40, 593, 201, -2, 593, 593, 101, 639, 593, 593, 21001, 0, 0, -2, 109, -3, 2106, 0, 0, 109, 3, 22102, 26, -2, 1, 22201, 1, -1, 1, 21102, 1, 523, 2, 21102, 583, 1, 3, 21102, 1040, 1, 4, 21101, 0, 630, 0, 1106, 0, 456, 21201, 1, 1679, -2, 109, -3, 2105, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 2, 0, 2, 2, 2, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 1, 1, 0, 2, 2, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 1, 1, 0, 2, 0, 2, 0, 2, 0, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2, 0, 2, 2, 0, 2, 2, 2, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 1, 1, 0, 2, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 0, 2, 2, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 2, 0, 0, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 2, 2, 2, 0, 0, 1, 1, 0, 2, 2, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 2, 2, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 0, 2, 2, 0, 0, 2, 0, 0, 2, 2, 0, 2, 2, 2, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 2, 2, 2, 2, 0, 0, 0, 2, 0, 2, 0, 2, 2, 2, 0, 0, 2, 2, 2, 0, 0, 0, 2, 0, 0, 0, 1, 1, 0, 0, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 2, 0, 2, 2, 2, 2, 2, 0, 0, 0, 1, 1, 0, 0, 2, 2, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 2, 0, 2, 2, 0, 2, 0, 2, 0, 0, 2, 0, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 1, 1, 0, 2, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 2, 2, 2, 0, 2, 0, 0, 1, 1, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 2, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 2, 2, 2, 0, 0, 2, 2, 0, 2, 2, 2, 0, 2, 0, 0, 0, 1, 1, 0, 0, 2, 2, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 2, 2, 0, 2, 2, 2, 0, 0, 2, 2, 2, 2, 2, 2, 0, 2, 0, 2, 2, 0, 0, 2, 0, 1, 1, 0, 2, 2, 2, 0, 2, 0, 0, 0, 2, 2, 2, 2, 0, 0, 2, 2, 2, 0, 0, 0, 2, 2, 2, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 2, 0, 1, 1, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 2, 0, 2, 2, 0, 0, 0, 2, 0, 0, 2, 2, 2, 2, 0, 0, 2, 0, 0, 0, 2, 0, 2, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 2, 0, 2, 2, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 0, 2, 0, 0, 2, 0, 2, 2, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 0, 1, 1, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 0, 2, 0, 2, 0, 2, 2, 0, 0, 0, 0, 0, 2, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 94, 63, 98, 14, 55, 98, 64, 9, 39, 55, 40, 3, 77, 79, 41, 40, 52, 25, 26, 46, 83, 8, 72, 65, 35, 58, 50, 6, 78, 78, 40, 77, 45, 49, 98, 98, 47, 68, 93, 85, 87, 19, 71, 89, 59, 81, 2, 62, 12, 53, 10, 21, 45, 23, 11, 95, 37, 33, 57, 32, 82, 63, 2, 97, 43, 93, 91, 66, 32, 55, 20, 53, 14, 7, 50, 62, 41, 32, 12, 63, 85, 86, 2, 83, 63, 7, 1, 91, 7, 67, 6, 57, 74, 63, 21, 14, 50, 92, 96, 13, 73, 52, 27, 39, 1, 17, 82, 87, 58, 45, 30, 31, 29, 85, 70, 59, 95, 71, 75, 74, 12, 51, 62, 83, 38, 53, 15, 13, 45, 6, 71, 35, 98, 36, 88, 9, 77, 37, 4, 5, 52, 59, 53, 83, 77, 7, 8, 97, 56, 97, 14, 40, 82, 93, 1, 81, 37, 38, 49, 89, 70, 9, 60, 1, 12, 79, 5, 22, 7, 86, 41, 42, 79, 24, 51, 9, 1, 8, 72, 3, 53, 71, 76, 49, 55, 57, 95, 87, 68, 33, 6, 28, 7, 50, 81, 75, 57, 72, 95, 67, 12, 29, 19, 77, 52, 69, 72, 38, 16, 21, 4, 91, 15, 1, 11, 3, 70, 46, 54, 95, 24, 93, 13, 40, 23, 14, 93, 58, 59, 87, 54, 79, 84, 38, 7, 97, 66, 40, 66, 42, 1, 66, 45, 82, 64, 65, 95, 19, 43, 16, 20, 36, 94, 39, 95, 25, 2, 75, 96, 55, 7, 63, 30, 8, 86, 92, 68, 54, 75, 81, 49, 75, 29, 77, 3, 85, 23, 72, 19, 44, 8, 5, 40, 48, 65, 23, 67, 76, 43, 87, 72, 52, 46, 61, 22, 42, 86, 86, 23, 46, 17, 58, 67, 86, 83, 36, 93, 95, 53, 69, 14, 58, 54, 69, 25, 2, 51, 2, 51, 35, 24, 57, 92, 75, 82, 23, 61, 19, 94, 15, 34, 4, 29, 10, 24, 81, 2, 88, 48, 5, 84, 72, 64, 28, 11, 57, 3, 30, 71, 58, 88, 7, 63, 54, 15, 66, 48, 4, 5, 78, 35, 37, 24, 89, 89, 68, 90, 38, 85, 81, 9, 73, 36, 28, 5, 89, 42, 14, 5, 76, 72, 2, 38, 97, 49, 46, 80, 86, 17, 71, 3, 27, 2, 4, 28, 91, 31, 9, 83, 89, 63, 47, 53, 38, 30, 35, 21, 66, 27, 51, 3, 68, 70, 17, 30, 57, 83, 80, 66, 32, 92, 52, 84, 80, 29, 4, 79, 20, 86, 41, 17, 31, 39, 67, 25, 39, 97, 41, 53, 63, 78, 26, 85, 57, 76, 82, 25, 48, 81, 92, 66, 49, 29, 95, 89, 56, 65, 87, 62, 71, 63, 17, 46, 98, 4, 86, 39, 26, 12, 14, 51, 73, 38, 46, 27, 98, 66, 1, 19, 65, 56, 98, 25, 27, 98, 78, 31, 49, 47, 42, 32, 13, 3, 60, 1, 11, 14, 42, 69, 11, 76, 86, 95, 17, 19, 92, 77, 8, 19, 85, 81, 69, 22, 18, 48, 68, 27, 2, 24, 3, 10, 25, 6, 27, 3, 28, 64, 23, 3, 7, 94, 96, 84, 27, 18, 9, 60, 90, 60, 37, 72, 58, 93, 72, 36, 21, 85, 62, 11, 64, 34, 5, 3, 6, 9, 31, 85, 25, 81, 34, 87, 86, 88, 35, 69, 8, 7, 18, 31, 24, 8, 79, 71, 45, 51, 41, 83, 13, 81, 39, 34, 3, 44, 17, 27, 71, 7, 13, 36, 89, 70, 77, 79, 61, 31, 62, 51, 15, 78, 72, 37, 32, 82, 62, 10, 32, 84, 79, 64, 19, 89, 56, 51, 52, 87, 44, 31, 18, 75, 96, 26, 79, 58, 51, 2, 54, 84, 42, 17, 60, 37, 34, 66, 33, 4, 20, 93, 43, 8, 90, 43, 92, 10, 90, 43, 9, 34, 18, 39, 79, 32, 1, 36, 69, 90, 29, 49, 56, 63, 60, 36, 46, 38, 79, 6, 57, 1, 97, 65, 78, 47, 82, 78, 25, 33, 3, 14, 22, 89, 37, 29, 81, 68, 82, 41, 31, 16, 91, 13, 73, 68, 4, 79, 6, 86, 91, 87, 69, 85, 46, 41, 85, 6, 36, 87, 93, 18, 74, 55, 84, 3, 9, 88, 19, 30, 46, 47, 33, 79, 94, 67, 75, 36, 8, 66, 14, 52, 10, 92, 91, 93, 5, 63, 52, 42, 11, 11, 48, 45, 66, 51, 30, 5, 39, 39, 49, 66, 38, 57, 19, 54, 90, 44, 60, 31, 11, 21, 31, 56, 35, 76, 35, 67, 79, 70, 18, 11, 50, 6, 97, 59, 5, 72, 50, 54, 75, 41, 19, 54, 12, 47, 56, 42, 80, 70, 69, 69, 34, 97, 57, 43, 6, 60, 52, 39, 43, 52, 34, 4, 41, 86, 47, 2, 80, 41, 15, 60, 50, 24, 31, 24, 83, 34, 19, 40, 55, 42, 25, 93, 39, 85, 29, 98, 95, 67, 55, 62, 4, 26, 19, 61, 93, 14, 11, 45, 50, 40, 81, 61, 57, 17, 44, 3, 75, 7, 74, 20, 70, 2, 63, 29, 52, 48, 47, 29, 90, 8, 36, 39, 77, 62, 97, 11, 43, 31, 13, 25, 5, 66, 2, 6, 20, 49, 89, 48, 67, 79, 66, 74, 48, 79, 45, 5, 35, 31, 33, 50, 95, 23, 56, 33, 40, 75, 24, 81, 84, 56, 35, 96, 11, 95, 29, 7, 55, 17, 37, 18, 20, 32, 41, 4, 71, 74, 67, 7, 46, 1, 86, 70, 9, 13, 40, 17, 12, 64, 31, 65, 60, 40, 4, 6, 42, 57, 89, 15, 40, 53, 88, 14, 2, 35, 5, 16, 44, 62, 6, 53, 83, 76, 87, 26, 82, 1, 7, 25, 66, 65, 53, 60, 52, 57, 64, 9, 16, 88, 2, 93, 33, 62, 82, 27, 17, 29, 17, 40, 68, 83, 4, 28, 83, 62, 6, 91, 45, 69, 30, 8, 39, 55, 78, 97, 46, 13, 2, 7, 80, 74, 19, 68, 20, 2, 5, 35, 55, 62, 25, 32, 55, 3, 76, 92, 70, 62, 36, 73, 14, 55, 12, 4, 25, 46, 25, 17, 41, 63, 19, 74, 70, 86, 4, 80, 50, 97, 44, 65, 51, 44, 7, 78, 59, 351522 }, false);
            var cp = new CarePackage();
            cp.SetUp(icc);
            Console.WriteLine(cp.CountBlockTiles);
        }

        static void Q11b()
        {

            var icc = new IntCodeCompiler("Q11b", new List<long> { 3, 8, 1005, 8, 326, 1106, 0, 11, 0, 0, 0, 104, 1, 104, 0, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 1001, 8, 0, 29, 2, 1003, 17, 10, 1006, 0, 22, 2, 106, 5, 10, 1006, 0, 87, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 1001, 8, 0, 65, 2, 7, 20, 10, 2, 9, 17, 10, 2, 6, 16, 10, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 0, 10, 4, 10, 101, 0, 8, 99, 1006, 0, 69, 1006, 0, 40, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 101, 0, 8, 127, 1006, 0, 51, 2, 102, 17, 10, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4, 10, 1002, 8, 1, 155, 1006, 0, 42, 3, 8, 1002, 8, -1, 10, 101, 1, 10, 10, 4, 10, 108, 0, 8, 10, 4, 10, 101, 0, 8, 180, 1, 106, 4, 10, 2, 1103, 0, 10, 1006, 0, 14, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 108, 0, 8, 10, 4, 10, 1001, 8, 0, 213, 1, 1009, 0, 10, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 0, 8, 10, 4, 10, 1002, 8, 1, 239, 1006, 0, 5, 2, 108, 5, 10, 2, 1104, 7, 10, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 108, 0, 8, 10, 4, 10, 102, 1, 8, 272, 2, 1104, 12, 10, 1, 1109, 10, 10, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4, 10, 102, 1, 8, 302, 1006, 0, 35, 101, 1, 9, 9, 1007, 9, 1095, 10, 1005, 10, 15, 99, 109, 648, 104, 0, 104, 1, 21102, 937268449940, 1, 1, 21102, 1, 343, 0, 1105, 1, 447, 21101, 387365315480, 0, 1, 21102, 1, 354, 0, 1105, 1, 447, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 21101, 0, 29220891795, 1, 21102, 1, 401, 0, 1106, 0, 447, 21101, 0, 248075283623, 1, 21102, 412, 1, 0, 1105, 1, 447, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 0, 21101, 0, 984353760012, 1, 21102, 1, 435, 0, 1105, 1, 447, 21102, 1, 718078227200, 1, 21102, 1, 446, 0, 1105, 1, 447, 99, 109, 2, 21202, -1, 1, 1, 21102, 40, 1, 2, 21101, 0, 478, 3, 21101, 468, 0, 0, 1106, 0, 511, 109, -2, 2106, 0, 0, 0, 1, 0, 0, 1, 109, 2, 3, 10, 204, -1, 1001, 473, 474, 489, 4, 0, 1001, 473, 1, 473, 108, 4, 473, 10, 1006, 10, 505, 1102, 1, 0, 473, 109, -2, 2105, 1, 0, 0, 109, 4, 1202, -1, 1, 510, 1207, -3, 0, 10, 1006, 10, 528, 21102, 1, 0, -3, 22102, 1, -3, 1, 22101, 0, -2, 2, 21101, 0, 1, 3, 21102, 1, 547, 0, 1105, 1, 552, 109, -4, 2105, 1, 0, 109, 5, 1207, -3, 1, 10, 1006, 10, 575, 2207, -4, -2, 10, 1006, 10, 575, 21202, -4, 1, -4, 1105, 1, 643, 21202, -4, 1, 1, 21201, -3, -1, 2, 21202, -2, 2, 3, 21102, 1, 594, 0, 1106, 0, 552, 22102, 1, 1, -4, 21101, 1, 0, -1, 2207, -4, -2, 10, 1006, 10, 613, 21101, 0, 0, -1, 22202, -2, -1, -2, 2107, 0, -3, 10, 1006, 10, 635, 22101, 0, -1, 1, 21101, 0, 635, 0, 106, 0, 510, 21202, -2, -1, -2, 22201, -4, -2, -4, 109, -5, 2105, 1, 0 }, false);
            IntCodeCompilerUtilities.DayElevenB(icc);
        }

        static void Q11a()
        {

            var icc = new IntCodeCompiler("Q11", new List<long> { 3, 8, 1005, 8, 326, 1106, 0, 11, 0, 0, 0, 104, 1, 104, 0, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 1001, 8, 0, 29, 2, 1003, 17, 10, 1006, 0, 22, 2, 106, 5, 10, 1006, 0, 87, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 1001, 8, 0, 65, 2, 7, 20, 10, 2, 9, 17, 10, 2, 6, 16, 10, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 0, 10, 4, 10, 101, 0, 8, 99, 1006, 0, 69, 1006, 0, 40, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 1008, 8, 1, 10, 4, 10, 101, 0, 8, 127, 1006, 0, 51, 2, 102, 17, 10, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4, 10, 1002, 8, 1, 155, 1006, 0, 42, 3, 8, 1002, 8, -1, 10, 101, 1, 10, 10, 4, 10, 108, 0, 8, 10, 4, 10, 101, 0, 8, 180, 1, 106, 4, 10, 2, 1103, 0, 10, 1006, 0, 14, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 108, 0, 8, 10, 4, 10, 1001, 8, 0, 213, 1, 1009, 0, 10, 3, 8, 1002, 8, -1, 10, 1001, 10, 1, 10, 4, 10, 108, 0, 8, 10, 4, 10, 1002, 8, 1, 239, 1006, 0, 5, 2, 108, 5, 10, 2, 1104, 7, 10, 3, 8, 102, -1, 8, 10, 101, 1, 10, 10, 4, 10, 108, 0, 8, 10, 4, 10, 102, 1, 8, 272, 2, 1104, 12, 10, 1, 1109, 10, 10, 3, 8, 102, -1, 8, 10, 1001, 10, 1, 10, 4, 10, 108, 1, 8, 10, 4, 10, 102, 1, 8, 302, 1006, 0, 35, 101, 1, 9, 9, 1007, 9, 1095, 10, 1005, 10, 15, 99, 109, 648, 104, 0, 104, 1, 21102, 937268449940, 1, 1, 21102, 1, 343, 0, 1105, 1, 447, 21101, 387365315480, 0, 1, 21102, 1, 354, 0, 1105, 1, 447, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 1, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 1, 21101, 0, 29220891795, 1, 21102, 1, 401, 0, 1106, 0, 447, 21101, 0, 248075283623, 1, 21102, 412, 1, 0, 1105, 1, 447, 3, 10, 104, 0, 104, 0, 3, 10, 104, 0, 104, 0, 21101, 0, 984353760012, 1, 21102, 1, 435, 0, 1105, 1, 447, 21102, 1, 718078227200, 1, 21102, 1, 446, 0, 1105, 1, 447, 99, 109, 2, 21202, -1, 1, 1, 21102, 40, 1, 2, 21101, 0, 478, 3, 21101, 468, 0, 0, 1106, 0, 511, 109, -2, 2106, 0, 0, 0, 1, 0, 0, 1, 109, 2, 3, 10, 204, -1, 1001, 473, 474, 489, 4, 0, 1001, 473, 1, 473, 108, 4, 473, 10, 1006, 10, 505, 1102, 1, 0, 473, 109, -2, 2105, 1, 0, 0, 109, 4, 1202, -1, 1, 510, 1207, -3, 0, 10, 1006, 10, 528, 21102, 1, 0, -3, 22102, 1, -3, 1, 22101, 0, -2, 2, 21101, 0, 1, 3, 21102, 1, 547, 0, 1105, 1, 552, 109, -4, 2105, 1, 0, 109, 5, 1207, -3, 1, 10, 1006, 10, 575, 2207, -4, -2, 10, 1006, 10, 575, 21202, -4, 1, -4, 1105, 1, 643, 21202, -4, 1, 1, 21201, -3, -1, 2, 21202, -2, 2, 3, 21102, 1, 594, 0, 1106, 0, 552, 22102, 1, 1, -4, 21101, 1, 0, -1, 2207, -4, -2, 10, 1006, 10, 613, 21101, 0, 0, -1, 22202, -2, -1, -2, 2107, 0, -3, 10, 1006, 10, 635, 22101, 0, -1, 1, 21101, 0, 635, 0, 106, 0, 510, 21202, -2, -1, -2, 22201, -4, -2, -4, 109, -5, 2105, 1, 0 }, false);
            Console.WriteLine(IntCodeCompilerUtilities.DayElevenA(icc));
        }
        static void Q9b()
        {
            var inputs = new Queue<long>();
            inputs.Enqueue(2);
            var icc = new IntCodeCompiler("Q9b", new List<long> { 1102, 34463338, 34463338, 63, 1007, 63, 34463338, 63, 1005, 63, 53, 1101, 0, 3, 1000, 109, 988, 209, 12, 9, 1000, 209, 6, 209, 3, 203, 0, 1008, 1000, 1, 63, 1005, 63, 65, 1008, 1000, 2, 63, 1005, 63, 904, 1008, 1000, 0, 63, 1005, 63, 58, 4, 25, 104, 0, 99, 4, 0, 104, 0, 99, 4, 17, 104, 0, 99, 0, 0, 1101, 29, 0, 1010, 1102, 1, 1, 1021, 1101, 0, 36, 1002, 1101, 573, 0, 1026, 1101, 0, 33, 1012, 1102, 1, 25, 1004, 1102, 1, 38, 1000, 1102, 31, 1, 1003, 1102, 23, 1, 1006, 1102, 777, 1, 1028, 1102, 20, 1, 1011, 1101, 0, 566, 1027, 1101, 0, 27, 1009, 1101, 26, 0, 1005, 1101, 0, 0, 1020, 1102, 1, 37, 1014, 1101, 32, 0, 1001, 1101, 0, 24, 1007, 1101, 0, 35, 1018, 1101, 30, 0, 1017, 1101, 0, 22, 1008, 1102, 460, 1, 1023, 1101, 0, 768, 1029, 1102, 1, 487, 1024, 1102, 1, 34, 1013, 1102, 1, 28, 1015, 1101, 0, 39, 1019, 1101, 478, 0, 1025, 1101, 0, 463, 1022, 1101, 21, 0, 1016, 109, 9, 1208, 0, 30, 63, 1005, 63, 201, 1001, 64, 1, 64, 1105, 1, 203, 4, 187, 1002, 64, 2, 64, 109, 3, 1201, -8, 0, 63, 1008, 63, 24, 63, 1005, 63, 227, 1001, 64, 1, 64, 1106, 0, 229, 4, 209, 1002, 64, 2, 64, 109, -1, 2108, 32, -8, 63, 1005, 63, 245, 1106, 0, 251, 4, 235, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -11, 2101, 0, 2, 63, 1008, 63, 35, 63, 1005, 63, 275, 1001, 64, 1, 64, 1105, 1, 277, 4, 257, 1002, 64, 2, 64, 109, 3, 2101, 0, -1, 63, 1008, 63, 36, 63, 1005, 63, 303, 4, 283, 1001, 64, 1, 64, 1106, 0, 303, 1002, 64, 2, 64, 109, 16, 21108, 40, 40, -6, 1005, 1013, 325, 4, 309, 1001, 64, 1, 64, 1106, 0, 325, 1002, 64, 2, 64, 109, -4, 21102, 41, 1, -4, 1008, 1011, 41, 63, 1005, 63, 351, 4, 331, 1001, 64, 1, 64, 1105, 1, 351, 1002, 64, 2, 64, 109, -15, 2102, 1, 4, 63, 1008, 63, 24, 63, 1005, 63, 375, 1001, 64, 1, 64, 1106, 0, 377, 4, 357, 1002, 64, 2, 64, 109, 6, 1201, -2, 0, 63, 1008, 63, 25, 63, 1005, 63, 403, 4, 383, 1001, 64, 1, 64, 1106, 0, 403, 1002, 64, 2, 64, 109, 8, 2102, 1, -6, 63, 1008, 63, 22, 63, 1005, 63, 425, 4, 409, 1106, 0, 429, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -1, 2108, 27, -4, 63, 1005, 63, 447, 4, 435, 1106, 0, 451, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 8, 2105, 1, 2, 1105, 1, 469, 4, 457, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 2105, 1, -2, 4, 475, 1001, 64, 1, 64, 1106, 0, 487, 1002, 64, 2, 64, 109, -33, 1202, 7, 1, 63, 1008, 63, 37, 63, 1005, 63, 507, 1105, 1, 513, 4, 493, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2107, 25, 10, 63, 1005, 63, 535, 4, 519, 1001, 64, 1, 64, 1106, 0, 535, 1002, 64, 2, 64, 109, 30, 21107, 42, 41, -9, 1005, 1016, 551, 1106, 0, 557, 4, 541, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2106, 0, 0, 1001, 64, 1, 64, 1105, 1, 575, 4, 563, 1002, 64, 2, 64, 109, -19, 1202, -7, 1, 63, 1008, 63, 32, 63, 1005, 63, 601, 4, 581, 1001, 64, 1, 64, 1105, 1, 601, 1002, 64, 2, 64, 109, -2, 1207, -1, 27, 63, 1005, 63, 619, 4, 607, 1106, 0, 623, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 21101, 43, 0, 6, 1008, 1014, 45, 63, 1005, 63, 647, 1001, 64, 1, 64, 1106, 0, 649, 4, 629, 1002, 64, 2, 64, 109, 17, 1205, -4, 663, 4, 655, 1106, 0, 667, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 4, 1205, -9, 683, 1001, 64, 1, 64, 1106, 0, 685, 4, 673, 1002, 64, 2, 64, 109, -17, 21101, 44, 0, -2, 1008, 1010, 44, 63, 1005, 63, 711, 4, 691, 1001, 64, 1, 64, 1105, 1, 711, 1002, 64, 2, 64, 109, 1, 21102, 45, 1, 3, 1008, 1016, 42, 63, 1005, 63, 735, 1001, 64, 1, 64, 1105, 1, 737, 4, 717, 1002, 64, 2, 64, 109, -9, 1207, 1, 25, 63, 1005, 63, 753, 1105, 1, 759, 4, 743, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 23, 2106, 0, 1, 4, 765, 1001, 64, 1, 64, 1106, 0, 777, 1002, 64, 2, 64, 109, -3, 1206, -3, 789, 1105, 1, 795, 4, 783, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -13, 2107, 25, -4, 63, 1005, 63, 815, 1001, 64, 1, 64, 1105, 1, 817, 4, 801, 1002, 64, 2, 64, 109, -9, 21108, 46, 44, 10, 1005, 1012, 833, 1105, 1, 839, 4, 823, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -4, 1208, 10, 22, 63, 1005, 63, 857, 4, 845, 1105, 1, 861, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 28, 1206, -6, 879, 4, 867, 1001, 64, 1, 64, 1105, 1, 879, 1002, 64, 2, 64, 109, -4, 21107, 47, 48, -3, 1005, 1019, 897, 4, 885, 1105, 1, 901, 1001, 64, 1, 64, 4, 64, 99, 21102, 27, 1, 1, 21101, 915, 0, 0, 1106, 0, 922, 21201, 1, 14615, 1, 204, 1, 99, 109, 3, 1207, -2, 3, 63, 1005, 63, 964, 21201, -2, -1, 1, 21102, 1, 942, 0, 1106, 0, 922, 22101, 0, 1, -1, 21201, -2, -3, 1, 21101, 957, 0, 0, 1105, 1, 922, 22201, 1, -1, -2, 1106, 0, 968, 22101, 0, -2, -2, 109, -3, 2105, 1, 0 }, inputs);
            icc.Calculate();
            Console.WriteLine(icc);
        }

        static void Q9a()
        {
            var inputs = new Queue<long>();
            inputs.Enqueue(1);
            var icc = new IntCodeCompiler("Q9a", new List<long> { 1102, 34463338, 34463338, 63, 1007, 63, 34463338, 63, 1005, 63, 53, 1101, 0, 3, 1000, 109, 988, 209, 12, 9, 1000, 209, 6, 209, 3, 203, 0, 1008, 1000, 1, 63, 1005, 63, 65, 1008, 1000, 2, 63, 1005, 63, 904, 1008, 1000, 0, 63, 1005, 63, 58, 4, 25, 104, 0, 99, 4, 0, 104, 0, 99, 4, 17, 104, 0, 99, 0, 0, 1101, 29, 0, 1010, 1102, 1, 1, 1021, 1101, 0, 36, 1002, 1101, 573, 0, 1026, 1101, 0, 33, 1012, 1102, 1, 25, 1004, 1102, 1, 38, 1000, 1102, 31, 1, 1003, 1102, 23, 1, 1006, 1102, 777, 1, 1028, 1102, 20, 1, 1011, 1101, 0, 566, 1027, 1101, 0, 27, 1009, 1101, 26, 0, 1005, 1101, 0, 0, 1020, 1102, 1, 37, 1014, 1101, 32, 0, 1001, 1101, 0, 24, 1007, 1101, 0, 35, 1018, 1101, 30, 0, 1017, 1101, 0, 22, 1008, 1102, 460, 1, 1023, 1101, 0, 768, 1029, 1102, 1, 487, 1024, 1102, 1, 34, 1013, 1102, 1, 28, 1015, 1101, 0, 39, 1019, 1101, 478, 0, 1025, 1101, 0, 463, 1022, 1101, 21, 0, 1016, 109, 9, 1208, 0, 30, 63, 1005, 63, 201, 1001, 64, 1, 64, 1105, 1, 203, 4, 187, 1002, 64, 2, 64, 109, 3, 1201, -8, 0, 63, 1008, 63, 24, 63, 1005, 63, 227, 1001, 64, 1, 64, 1106, 0, 229, 4, 209, 1002, 64, 2, 64, 109, -1, 2108, 32, -8, 63, 1005, 63, 245, 1106, 0, 251, 4, 235, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -11, 2101, 0, 2, 63, 1008, 63, 35, 63, 1005, 63, 275, 1001, 64, 1, 64, 1105, 1, 277, 4, 257, 1002, 64, 2, 64, 109, 3, 2101, 0, -1, 63, 1008, 63, 36, 63, 1005, 63, 303, 4, 283, 1001, 64, 1, 64, 1106, 0, 303, 1002, 64, 2, 64, 109, 16, 21108, 40, 40, -6, 1005, 1013, 325, 4, 309, 1001, 64, 1, 64, 1106, 0, 325, 1002, 64, 2, 64, 109, -4, 21102, 41, 1, -4, 1008, 1011, 41, 63, 1005, 63, 351, 4, 331, 1001, 64, 1, 64, 1105, 1, 351, 1002, 64, 2, 64, 109, -15, 2102, 1, 4, 63, 1008, 63, 24, 63, 1005, 63, 375, 1001, 64, 1, 64, 1106, 0, 377, 4, 357, 1002, 64, 2, 64, 109, 6, 1201, -2, 0, 63, 1008, 63, 25, 63, 1005, 63, 403, 4, 383, 1001, 64, 1, 64, 1106, 0, 403, 1002, 64, 2, 64, 109, 8, 2102, 1, -6, 63, 1008, 63, 22, 63, 1005, 63, 425, 4, 409, 1106, 0, 429, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -1, 2108, 27, -4, 63, 1005, 63, 447, 4, 435, 1106, 0, 451, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 8, 2105, 1, 2, 1105, 1, 469, 4, 457, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 5, 2105, 1, -2, 4, 475, 1001, 64, 1, 64, 1106, 0, 487, 1002, 64, 2, 64, 109, -33, 1202, 7, 1, 63, 1008, 63, 37, 63, 1005, 63, 507, 1105, 1, 513, 4, 493, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2107, 25, 10, 63, 1005, 63, 535, 4, 519, 1001, 64, 1, 64, 1106, 0, 535, 1002, 64, 2, 64, 109, 30, 21107, 42, 41, -9, 1005, 1016, 551, 1106, 0, 557, 4, 541, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2106, 0, 0, 1001, 64, 1, 64, 1105, 1, 575, 4, 563, 1002, 64, 2, 64, 109, -19, 1202, -7, 1, 63, 1008, 63, 32, 63, 1005, 63, 601, 4, 581, 1001, 64, 1, 64, 1105, 1, 601, 1002, 64, 2, 64, 109, -2, 1207, -1, 27, 63, 1005, 63, 619, 4, 607, 1106, 0, 623, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 21101, 43, 0, 6, 1008, 1014, 45, 63, 1005, 63, 647, 1001, 64, 1, 64, 1106, 0, 649, 4, 629, 1002, 64, 2, 64, 109, 17, 1205, -4, 663, 4, 655, 1106, 0, 667, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 4, 1205, -9, 683, 1001, 64, 1, 64, 1106, 0, 685, 4, 673, 1002, 64, 2, 64, 109, -17, 21101, 44, 0, -2, 1008, 1010, 44, 63, 1005, 63, 711, 4, 691, 1001, 64, 1, 64, 1105, 1, 711, 1002, 64, 2, 64, 109, 1, 21102, 45, 1, 3, 1008, 1016, 42, 63, 1005, 63, 735, 1001, 64, 1, 64, 1105, 1, 737, 4, 717, 1002, 64, 2, 64, 109, -9, 1207, 1, 25, 63, 1005, 63, 753, 1105, 1, 759, 4, 743, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 23, 2106, 0, 1, 4, 765, 1001, 64, 1, 64, 1106, 0, 777, 1002, 64, 2, 64, 109, -3, 1206, -3, 789, 1105, 1, 795, 4, 783, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -13, 2107, 25, -4, 63, 1005, 63, 815, 1001, 64, 1, 64, 1105, 1, 817, 4, 801, 1002, 64, 2, 64, 109, -9, 21108, 46, 44, 10, 1005, 1012, 833, 1105, 1, 839, 4, 823, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -4, 1208, 10, 22, 63, 1005, 63, 857, 4, 845, 1105, 1, 861, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 28, 1206, -6, 879, 4, 867, 1001, 64, 1, 64, 1105, 1, 879, 1002, 64, 2, 64, 109, -4, 21107, 47, 48, -3, 1005, 1019, 897, 4, 885, 1105, 1, 901, 1001, 64, 1, 64, 4, 64, 99, 21102, 27, 1, 1, 21101, 915, 0, 0, 1106, 0, 922, 21201, 1, 14615, 1, 204, 1, 99, 109, 3, 1207, -2, 3, 63, 1005, 63, 964, 21201, -2, -1, 1, 21102, 1, 942, 0, 1106, 0, 922, 22101, 0, 1, -1, 21201, -2, -3, 1, 21101, 957, 0, 0, 1105, 1, 922, 22201, 1, -1, -2, 1106, 0, 968, 22101, 0, -2, -2, 109, -3, 2105, 1, 0 }, inputs);
            icc.Calculate();
            Console.WriteLine(icc);
        }

        static void Q7()
        {
            Console.WriteLine(IntCodeCompilerUtilities.DaySeven(new List<long> { 3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 46, 67, 76, 101, 118, 199, 280, 361, 442, 99999, 3, 9, 1002, 9, 4, 9, 1001, 9, 2, 9, 102, 3, 9, 9, 101, 3, 9, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 3, 9, 102, 2, 9, 9, 1001, 9, 2, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 101, 3, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 1002, 9, 5, 9, 101, 5, 9, 9, 1002, 9, 4, 9, 101, 5, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 1001, 9, 5, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99 }));
        }

        static void Q7b()
        {
            Console.WriteLine(IntCodeCompilerUtilities.DaySevenB(new List<long> { 3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 46, 67, 76, 101, 118, 199, 280, 361, 442, 99999, 3, 9, 1002, 9, 4, 9, 1001, 9, 2, 9, 102, 3, 9, 9, 101, 3, 9, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 3, 9, 102, 2, 9, 9, 1001, 9, 2, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 101, 3, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 1002, 9, 5, 9, 101, 5, 9, 9, 1002, 9, 4, 9, 101, 5, 9, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 1001, 9, 5, 9, 102, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99 }));
        }

        static void Q5()
        {
            var q = new Queue<long>();
            q.Enqueue(1);
            RunWithInput(q);

            q.Clear();
            q.Enqueue(5);
            RunWithInput(q);
        }

        static void RunWithInput(Queue<long> inputs)
        {
            Console.WriteLine("with {0} (of {1})", inputs.Peek(), inputs.Count);
            IList<long> input = new List<long> { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 9, 90, 224, 1001, 224, -99, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 223, 224, 223, 1102, 26, 62, 225, 1101, 11, 75, 225, 1101, 90, 43, 225, 2, 70, 35, 224, 101, -1716, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 94, 66, 225, 1102, 65, 89, 225, 101, 53, 144, 224, 101, -134, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 224, 223, 223, 1102, 16, 32, 224, 101, -512, 224, 224, 4, 224, 102, 8, 223, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1001, 43, 57, 224, 101, -147, 224, 224, 4, 224, 102, 8, 223, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 36, 81, 225, 1002, 39, 9, 224, 1001, 224, -99, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 223, 224, 223, 1, 213, 218, 224, 1001, 224, -98, 224, 4, 224, 102, 8, 223, 223, 101, 2, 224, 224, 1, 224, 223, 223, 102, 21, 74, 224, 101, -1869, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 7, 224, 1, 224, 223, 223, 1101, 25, 15, 225, 1101, 64, 73, 225, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1008, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 329, 1001, 223, 1, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 344, 101, 1, 223, 223, 108, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 359, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 7, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 8, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 1008, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 434, 101, 1, 223, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 464, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 479, 1001, 223, 1, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 494, 1001, 223, 1, 223, 1108, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 509, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 524, 101, 1, 223, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 539, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 554, 101, 1, 223, 223, 1107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 569, 1001, 223, 1, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 101, 1, 223, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 599, 101, 1, 223, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 614, 101, 1, 223, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 629, 1001, 223, 1, 223, 7, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 644, 101, 1, 223, 223, 1007, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 659, 1001, 223, 1, 223, 1108, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 674, 101, 1, 223, 223, 4, 223, 99, 226 };
            var icc = new IntCodeCompiler(input, inputs);
            icc.Calculate();
        }
    }
}
