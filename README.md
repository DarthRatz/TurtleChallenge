# Turtle Challenge

[![Build Status](https://dev.azure.com/EamonnReilly/TurtleChallenge/_apis/build/status/DarthRatz.TurtleChallenge?branchName=master)](https://dev.azure.com/EamonnReilly/TurtleChallenge/_build/latest?definitionId=2&branchName=master)
![Azure DevOps tests](https://img.shields.io/azure-devops/tests/EamonnReilly/TurtleChallenge/2.svg)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/4195bfe624074cb680e31e9ef66fb56f)](https://www.codacy.com/app/eamonnreilly87/TurtleChallenge?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=DarthRatz/TurtleChallenge&amp;utm_campaign=Badge_Grade)

![GitHub last commit](https://img.shields.io/github/last-commit/DarthRatz/TurtleChallenge.svg)
![GitHub top language](https://img.shields.io/github/languages/top/DarthRatz/TurtleChallenge.svg)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/DarthRatz/TurtleChallenge.svg)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/DarthRatz/TurtleChallenge.svg)

## What we expect

In the solution to this challenge, we are looking for the following:

* Simplicity
  * Functions should be small
* Readability
  * Functions and variable names should strike a balance between being short and clear
* Testability
  * Try to include at least a few tests for your core logic code

## What we do not expect

These are things we do not care about in this solution, where possible, avoid spending time on
these elements.

* Extensive use of 3rd party libraries
  * Some use of libraries is fine, but we don’t need to see lots of dependency injection or fancy log libraries
* Enterprise directory structure
  * This is a small application, it is not necessary to demonstrate the layout needed for much larger applications

___

## Problem Definition

A turtle must walk through a minefield. Write a program that will read the initial game settings from one file and a sequence of moves from a different file.

Then the program will output if the sequence leads to the success or failure of the little turtle.

The program should also handle the scenario where the turtle doesn’t reach the exit point or doesn’t hit a mine.

## Inputs

The board is a grid of n by m number of tiles:

* 5x4 Board
* The starting position is a tile (x,y) and the initial direction the turtle is facing (that is: north, east, south, west):
* Starting position: x = 0, y = 1, dir = North
* The exit point is a tile (x,y)
* Exit point: x = 4, y = 2
* The mines are defined as a list of tiles (x,y).
* Turtle actions can be either a move (m) one tile forward or rotate (r) 90 degrees to the right.

### Expected Input

A game settings file including board size, start position, exit position and a list of mine positions.
A moves file containing a list of moves (either ‘m’ or ‘r’)

### Expected Output

A message on the console describing the result, one of Success, Mine hit, still in danger or Out of bounds.

___