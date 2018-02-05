# AI-Inteligente-Agent-Maze Goal

A practical way to show the general concepts and definitions of an intelligent agent. Project simulates an agent should react in decision-making situations.


# Project Description

There is a maze from where an IA (Intelligent Agent) will go until you find the exit. 

For this the IA will:
* Have a steering sensor for decision making when necessary.

The problem is to develop an agent program capable of "learning" the path out of the labyrinth, given the conditions of navigability and dangerous situations (monsters) of it.

# Methodology

The goal is to map the automaton of the labyrinth, taking into account the following criteria:

1. Each state of the machine will depict the crossover point of the maze. It is at this point that the IA should make a decision based on in the direction sensor it has.

2. In decision-making, in order to choose one of the paths to be taken, the IA should start with N (North) and keep the choice clockwise, if the initial choice fails. The IA should repeat the process until find a valid direction.

# Sensor
The IA features a steering sensor:
* N (north)
* E (East)
* S (South)
* W (West)

First the IA will always start with north. If he fails, he passes the choice to the East, South or West (clockwise), in that sequence, until a valid choice is done.

*Death sensor:

Detects if the IA has died and should return to the previous state with a valid output, that is, with at least one alternative to choose another path not yet performed.

# Environment

There is an 8x8 labyrinth with an exit and an entrance. 
When the IA is placed in the entrance of this environment, it should try to leave without the number of lives reaches 0.
The IA has in the beginning 2 lives that must be decremented every time it find a monster.
After leaving the maze once, the IA should be again and try to leave once more. However, in the second attempt, the number of lives
should not be decremented (learning with history).

The following figure determines the layout of the labyrinth:

<p align="center">
  <img alt="VS Code in action" src="https://github.com/Caio-Sousa/AI-Inteligente-Agent-Maze/blob/master/Labyrithn-8x8.png?raw=true">
</p>

# Learning 

Create an extra sensor and set its functionality for your "learning". If the agent learns the right path he should not "die" at the same point as before the learnig occured.

# Solution

Implemented in C# windows forms using visual studio and microsoft Access for storing the learning experience.

Solution Screenshots: 

<p align="center">
  <img alt="VS Code in action" src="https://github.com/Caio-Sousa/AI-Inteligente-Agent-Maze/blob/master/Program-Img1.png?raw=true">
</p>


<p align="center">
  <img alt="VS Code in action" src="https://github.com/Caio-Sousa/AI-Inteligente-Agent-Maze/blob/master/Program-Img2.png?raw=true">
</p>
