using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private char[,] Board = new char[3, 3];

        private bool FirstPlayerMove;

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    Board[i, j] = ' ';
                }
            }
            foreach (var item in MainGrid.Children) { ((Button)item).Content = " "; }
            FirstPlayerMove = true;
        }

        private void buttonClick(object sender, RoutedEventArgs e)
        {
            // check if any move exists
            if (!NextMoveExists())
            {
                StartNewGame();
                return;
            }

            var button = (Button)sender;
            var row = Grid.GetRow(button);
            var col = Grid.GetColumn(button);

            // if cell already contains value of a move
            if (Board[row, col] != ' ')
            {
                return;
            }

            // set value of a move
            Board[row, col] = FirstPlayerMove ? 'X' : 'O';
            button.Content = Board[row, col];

            // check for a winner
            if (CheckForAWinner())
            {
                MessageBox.Show((FirstPlayerMove ? "Хрестики" : "Нолики") + " виграли!");
                StartNewGame();
            }
            FirstPlayerMove = !FirstPlayerMove;
        }

        private bool NextMoveExists()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[i, j] == ' ')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckForAWinner()
        {
            return CheckForAWinnerInARow(0)
                || CheckForAWinnerInARow(1)
                || CheckForAWinnerInARow(2)
                || CheckForAWinnerInAColumn(0)
                || CheckForAWinnerInAColumn(1)
                || CheckForAWinnerInAColumn(2)
                || CheckForAWinnerInMainDiagonal()
                || CheckForAWinnerInReverseDiagonal();
        }

        private bool CheckForAWinnerInARow(int row)
        {
            for (int col = 1; col < Board.GetLength(0); col++)
            {
                if (Board[row, col] == ' ') { return false; }
                if (Board[row, 0] != Board[row, col])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckForAWinnerInAColumn(int col)
        {
            for (int row = 1; row < Board.GetLength(0); row++)
            {
                if (Board[row, col] == ' ') { return false; }
                if (Board[0, col] != Board[row, col])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckForAWinnerInMainDiagonal()
        {
            for (int row = 0; row < Board.GetLength(0); row++)
            {
                if (Board[row, row] == ' ') { return false; }
                if (Board[0, 0] != Board[row, row])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckForAWinnerInReverseDiagonal()
        {
            for (int row = 0, col = Board.GetLength(0) - 1; row < Board.GetLength(0); row++, col--)
            {
                if (Board[row, col] == ' ') { return false; }
                if (Board[0, Board.GetLength(0) - 1] != Board[row, col])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
