using System;
using System.Windows;
using System.Windows.Controls;

namespace Sudoku.Views
{
    public partial class SudokuWindow : Window
    {

        SudokuGame.Sudoku sudoku;

        public SudokuWindow(SudokuGame.Sudoku.Dificulty dificulty)
        {
            InitializeComponent();
            initWindows(dificulty);
            sudoku = new SudokuGame.Sudoku(dificulty);
            createButtons();
        }

        private void initWindows(SudokuGame.Sudoku.Dificulty dificulty)
        {
            if (dificulty == SudokuGame.Sudoku.Dificulty.EASY)
            {
                Height = 326.663;
                Width = 251.445;
                win.Margin = new Thickness(0, 0, 0, 0);
                solve.Margin = new Thickness(68, 198, 70,200);
            }
            else if(dificulty == SudokuGame.Sudoku.Dificulty.HARD)
            {
                Height = 481.063;
                Width = 437.845;
                solve.Margin = new Thickness(159, 375, 164, 34.2);
            }
        }

        private void createButtons()
        {

            int size = 30;
            int y = 0;
            int x = 0;
            for (int row=0; row < sudoku.getSize(); row++)
            {
                x += 35;
                if (row % Convert.ToInt32(Math.Log(sudoku.getSize(), 2)) == 0)
                    x += 5;


                for (int col=0; col<sudoku.getSize(); col++)
                {
                    y += 35;
                    if (col % Convert.ToInt32(Math.Log(sudoku.getSize(), 2)) == 0)
                        y += 5;

                    Button button = new Button();
                    button.Name = "b"+Convert.ToString(row)+Convert.ToString(col);
                    button.Width = size;
                    button.Height = size;
                    button.HorizontalAlignment = HorizontalAlignment.Left;
                    button.VerticalAlignment = VerticalAlignment.Top;
                    button.Click += new RoutedEventHandler(Increment_Button_Click);
                    button.Margin = new Thickness(y,x,0,0);
                    button.Content = sudoku.table[row, col];
                    win.Children.Add(button);
                }
                y = 0;
            }
        }

        private void Solve_Button_Click(object sender, RoutedEventArgs e)
        {
            bool solved = sudoku.startSolving();
            if (solved)
                MessageBox.Show("The puzzle was solved", "Solved");
            else
                MessageBox.Show("The puzzle could'n be solved", "Not solved");
            int row = 0;
            int col = 0;
            foreach(Button button in win.Children)
            {
                if (button != solve)
                {
                    button.Content = sudoku.table[row, col];
                    col++;
                    if (col == sudoku.getSize())
                    {
                        row++;
                        col = 0;
                    }
                }
            }

        }

        private void Increment_Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            int row = 0;
            int col = 0;
            int number;

            row = Convert.ToInt32(button.Name.Substring(1, 1));
            col = Convert.ToInt32(button.Name.Substring(2, 1));

            //Determine the next number
            if (button.Content == null)
                number = 1;
            else
            {
                number = (int)button.Content;
                if (number == sudoku.getSize())
                    number = 1;
                else
                    number++;
            }

            sudoku.table[row, col] = number;
            button.Content = number;
            button.FontWeight = FontWeights.Bold;
        }
    }
}
