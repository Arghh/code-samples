
#include <stdio.h>
#include <stdlib.h>
//simple tic tac toe user vs computer based on http://www.java2s.com/Code/C/Data-Type/AsimpleTicTacToegame.htm

char board[3][3];

void createBoard()
{
  int x, y;
  for (x = 0; x < 3; x++)
  for (y = 0; y < 3; y++)
    board[x][y] = ' ';
}

void displayBoard()
{
  int d;
  printf("  | 0 | 1 | 2 | \n");
  for (d = 0; d < 3; d++)
  {
     printf("%d | %c | %c | %c | ", d, board[d][0], board[d][1], board[d][2]);
     printf("\n");
  }
}

void userMove()
{
  int x, y;
  printf("Your move\n");
  while (scanf("%d, %d", &x, &y) != 2)
  {
   while (getchar() != '\n');
    displayBoard();
    printf ("Enter a row: 0-2 and then a column 0-2: \nlike so 0,0\n");
  }
    if(board[x][y] != ' ')
    {
      printf("Oops! Try again\n");
    }
    else 
    {
      board[x][y] = 'X';
    }
  
}
void computerMove()
{
  int x;
  int y;
  int boolean;
  boolean = 0;

  for (y= 0; y < 3; y++)
  {
   if (boolean)
       break;
   if (board[1][1] == ' ')
     {
       board[1][1] = 'O';
       break;
     }
  
   for (x= 3; x > 0; x--)
   {    
     if (board[x][y] == ' ')
     {
      board[x][y] = 'O';
       boolean=1;
       break;
     }
   }
  }
}
char checkWinner()
{
  //rows 3x, col 3x, diagonals
  int i;

  for(i=0; i<3; i++)//check rows
    {
      if(board[i][0]==board[i][1] && board[i][0]==board[i][2]) 
        {
          return board[i][0];
        }
    }

  for(i=0; i<3; i++)//check column
  {
    if(board[0][i]==board[1][i] && board[0][i]==board[2][i]) 
       {
         return board[0][i];
       }
  }

  //test diagonals
  if(board[0][0]==board[1][1] && board[1][1]==board[2][2])
  {
       return board[0][0];
  }

  if(board[0][2]==board[1][1] && board[1][1]==board[2][0])
  {
       return board[0][2];
  }
  return ' ';
}
void play()
{
  int count = 1;
  createBoard();
  do
  {
    displayBoard();
    userMove();
    checkWinner();
    if(checkWinner() != ' ')
      break;

    computerMove();
    checkWinner();
    if(checkWinner() != ' ')
      break;
    count++;
  } while(checkWinner() == ' ');
  displayBoard();
  if(checkWinner() == 'X')
  { 
    printf("You won in %d moves\n", count);
  }
  else
  {
    printf("You lost in %d moves\n", count);
  }
}

void main()
{
  int check = 1;
  do
  {
  play();
  printf("\n");
  printf("\n");
  printf("Press any key and ENTER to play again.\n");
  scanf("%d", &check);
  }while(check);
  system("pause");
}
