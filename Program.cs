// See https://aka.ms/new-console-template for more information
using PacMan;

Board board = new Board(new IEntity[] { new Player(),new Wall(10,10) });
board.Start();
