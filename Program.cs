// See https://aka.ms/new-console-template for more information
using PlayerBase;
using EntityBase;
using SpikeBase;
using WallBase;
using PacMan;
Board board = new Board(new IEntity[] { new Player(),new Wall(10,10),new Spike(5,5)});
