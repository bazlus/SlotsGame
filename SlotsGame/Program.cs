using SlotsGame;
using SlotsGame.Factories;
using SlotsGame.Services;

var symbolFactory = new SymbolFactory();
var calculator = new Calculator();
var board = new Board(4, 3, symbolFactory);

var game = new GameEngine(board, calculator);  
game.Start();