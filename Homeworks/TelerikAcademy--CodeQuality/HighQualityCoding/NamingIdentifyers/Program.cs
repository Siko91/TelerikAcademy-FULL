using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class MinesweeperGame
	{
		public class PlayerScore
		{
			string name;
			int score;

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Score
			{
				get { return score; }
				set { score = value; }
			}

			public PlayerScore() { }

			public PlayerScore(string name, int points)
			{
				this.name = name;
				this.score = points;
			}
		}

		static void Main(string[] args)
        {
            const int MARKS = 35;

			string command = string.Empty;
			char[,] gameBoard = GenerateGameField();
			char[,] bombs = GenerateBombs();
			int currentScore = 0;
			bool aMineHasExploded = false;
			List<PlayerScore> bestScores = new List<PlayerScore>(6);
			int selectedRow = 0;
			int selectedCol = 0;
			bool goingToStartANewGame = true;
			bool GameCompleated = false;

			do
			{
				if (goingToStartANewGame)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					DrawGameField(gameBoard);
					goingToStartANewGame = false;
				}
				Console.Write("Daj red i kolona : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out selectedRow) &&
					    int.TryParse(command[2].ToString(), out selectedCol) &&
						selectedRow <= gameBoard.GetLength(0) && 
                        selectedCol <= gameBoard.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						DisplayBestScores(bestScores);
						break;
					case "restart":
						gameBoard = GenerateGameField();
						bombs = GenerateBombs();
						DrawGameField(gameBoard);
						aMineHasExploded = false;
						goingToStartANewGame = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bombs[selectedRow, selectedCol] != '*')
						{
							if (bombs[selectedRow, selectedCol] == '-')
							{
								UpdateGameBoard(gameBoard, bombs, selectedRow, selectedCol);
								currentScore++;
							}
							if (MARKS == currentScore)
							{
								GameCompleated = true;
							}
							else
							{
								DrawGameField(gameBoard);
							}
						}
						else
						{
							aMineHasExploded = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (aMineHasExploded)
				{
					DrawGameField(bombs);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", currentScore);
					string nickname = Console.ReadLine();
					PlayerScore score = new PlayerScore(nickname, currentScore);
					if (bestScores.Count < 5)
					{
						bestScores.Add(score);
					}
					else
					{
						for (int i = 0; i < bestScores.Count; i++)
						{
							if (bestScores[i].Score < score.Score)
							{
								bestScores.Insert(i, score);
								bestScores.RemoveAt(bestScores.Count - 1);
								break;
							}
						}
					}
					bestScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Name.CompareTo(r1.Name));
					bestScores.Sort((PlayerScore r1, PlayerScore r2) => r2.Score.CompareTo(r1.Score));
					DisplayBestScores(bestScores);

					gameBoard = GenerateGameField();
					bombs = GenerateBombs();
					currentScore = 0;
					aMineHasExploded = false;
					goingToStartANewGame = true;
				}
				if (GameCompleated)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					DrawGameField(bombs);
					Console.WriteLine("Daj si imeto, batka: ");
					string nickname = Console.ReadLine();
					PlayerScore newHighScore = new PlayerScore(nickname, currentScore);
					bestScores.Add(newHighScore);
					DisplayBestScores(bestScores);
					gameBoard = GenerateGameField();
					bombs = GenerateBombs();
					currentScore = 0;
					GameCompleated = false;
					goingToStartANewGame = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void DisplayBestScores(List<PlayerScore> score)
		{
			Console.WriteLine("\nTo4KI:");
			if (score.Count > 0)
			{
				for (int i = 0; i < score.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, score[i].Name, score[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}
        
		private static void UpdateGameBoard(
            char[,] gameBoard, 
            char[,] bombs, 
            int selectedRow, 
            int selectedCol)
		{
			char numberOfNearbyBombs = CountNearbyBombs(bombs, selectedRow, selectedCol);
			bombs[selectedRow, selectedCol] = numberOfNearbyBombs;
			gameBoard[selectedRow, selectedCol] = numberOfNearbyBombs;
		}

		private static void DrawGameField(char[,] board)
		{
			int rows = board.GetLength(0);
			int cols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] GenerateGameField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] GenerateBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] gameBoard = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					gameBoard[i, j] = '-';
				}
			}

			List<int> generatedBombNumbers = new List<int>();
			while (generatedBombNumbers.Count < 15)
			{
				Random random = new Random();
				int generatedBombNum = random.Next(50);
				if (!generatedBombNumbers.Contains(generatedBombNum))
				{
					generatedBombNumbers.Add(generatedBombNum);
				}
			}

			foreach (int bombNum in generatedBombNumbers)
			{
				int bombPositionColumn = (bombNum / cols);
				int bombPositionRow = (bombNum % cols);
				if (bombPositionRow == 0 && bombNum != 0)
				{
					bombPositionColumn--;
					bombPositionRow = cols;
				}
				else
				{
					bombPositionRow++;
				}
				gameBoard[bombPositionColumn, bombPositionRow - 1] = '*';
			}

			return gameBoard;
		}

        /// <summary>
        /// Not used.
        /// </summary>
		private static void UpdateGameBoard2(char[,] gameBoard)
		{
			int cols = gameBoard.GetLength(0);
			int rows = gameBoard.GetLength(1);

			for (int i = 0; i < cols; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					if (gameBoard[i, j] != '*')
					{
						char nearbyBombs = CountNearbyBombs(gameBoard, i, j);
						gameBoard[i, j] = nearbyBombs;
					}
				}
			}
		}

		private static char CountNearbyBombs(char[,] gameBoard, int col, int row)
		{
			int countOfNearbyMines = 0;
			int rows = gameBoard.GetLength(0);
			int cols = gameBoard.GetLength(1);

			if (col - 1 >= 0)
			{
				if (gameBoard[col - 1, row] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			if (col + 1 < rows)
			{
				if (gameBoard[col + 1, row] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			if (row - 1 >= 0)
			{
				if (gameBoard[col, row - 1] == '*')
				{ 
					countOfNearbyMines++;
				}
			}
			if (row + 1 < cols)
			{
				if (gameBoard[col, row + 1] == '*')
				{ 
					countOfNearbyMines++;
				}
			}
			if ((col - 1 >= 0) && (row - 1 >= 0))
			{
				if (gameBoard[col - 1, row - 1] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			if ((col - 1 >= 0) && (row + 1 < cols))
			{
				if (gameBoard[col - 1, row + 1] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			if ((col + 1 < rows) && (row - 1 >= 0))
			{
				if (gameBoard[col + 1, row - 1] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			if ((col + 1 < rows) && (row + 1 < cols))
			{
				if (gameBoard[col + 1, row + 1] == '*')
				{ 
					countOfNearbyMines++; 
				}
			}
			return char.Parse(countOfNearbyMines.ToString());
		}
	}
}
